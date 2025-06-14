import { Component, OnInit, signal, computed, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subject, debounceTime, distinctUntilChanged, takeUntil } from 'rxjs';
import { BookService } from '../../core/services/book.service';
import { CategoryService } from '../../core/services/category.service';
import { Book, BookFilter } from '../../core/models/book.model';
import { Category } from '../../core/models/category.model';
import { BookCardComponent } from '../../shared/components/book-card/book-card.component';
import { LoadingSpinnerComponent } from '../../shared/components/loading-spinner/loading-spinner.component';
import { AuthService } from '../../core/services/auth.service';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, BookCardComponent, LoadingSpinnerComponent, RouterModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject<void>();
  private searchSubject = new Subject<string>();

  books = signal<Book[]>([]);
  categories = signal<Category[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);
  searchTerm = signal('');
  selectedCategory = signal<number | 'all'>('all');
  searchInput = '';

  filteredBooks = computed(() => {
    const allBooks = this.books();
    const search = this.searchTerm().toLowerCase();
    const selectedCat = this.selectedCategory();

    return allBooks.filter(book => {
      const matchesSearch = !search ||
        book.title.toLowerCase().includes(search) ||
        book.author.toLowerCase().includes(search) ||
        book.description.toLowerCase().includes(search);

      const matchesCategory =
        selectedCat === 'all' || book.category === this.getCategoryNameById(selectedCat);

      return matchesSearch && matchesCategory;
    });
  });

  totalBooks = computed(() => this.filteredBooks().length);
  featuredBooks = computed(() =>
    this.filteredBooks()
      .filter(book => (book.averageRating ?? 0) >= 4.5)
      .slice(0, 6)
  );

  constructor(
    private bookService: BookService,
    private categoryService: CategoryService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadBooks();
    this.loadCategories();
    this.setupSearch();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private setupSearch(): void {
    this.searchSubject
      .pipe(debounceTime(300), distinctUntilChanged(), takeUntil(this.destroy$))
      .subscribe(searchTerm => {
        this.searchTerm.set(searchTerm);
      });
  }

  private loadBooks(): void {
    this.loading.set(true);
    this.error.set(null);

    const filter: BookFilter = {};
    if (this.searchTerm()) {
      filter.search = this.searchTerm();
    }
    if (this.selectedCategory() !== 'all') {
      filter.category = String(this.selectedCategory());
    }

    this.bookService.getBooks(filter).subscribe({
      next: (books) => {
        this.books.set(books);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('Error al cargar los libros. Intenta nuevamente.');
        this.loading.set(false);
      }
    });
  }

  private loadCategories(): void {
    this.categoryService.getAllCategories().subscribe({
      next: (categories) => {
        this.categories.set(categories);
      },
      error: () => {
        this.error.set('Error al cargar las categorías.');
      }
    });
  }

  onSearchInput(): void {
    this.searchSubject.next(this.searchInput);
  }

  onSearch(): void {
    this.searchTerm.set(this.searchInput);
    this.loadBooks();
  }

    logout(): void {
    this.authService.logout(); 
    this.router.navigate(['/']); 
  }

  setCategory(categoryId: number | 'all'): void {
    this.selectedCategory.set(categoryId);
    this.loadBooks();
  }

  setCategoryFromEvent(event: Event): void {
  const target = event.target as HTMLSelectElement;
  const value = target.value;

  if (value === 'all') {
    this.setCategory('all');
  } else {
    this.setCategory(+value);
  }
}


  clearFilters(): void {
    this.searchInput = '';
    this.searchTerm.set('');
    this.selectedCategory.set('all');
    this.loadBooks();
  }

  retryLoadBooks(): void {
    this.loadBooks();
  }

  getStatusMessage(): string {
    const total = this.totalBooks();
    const search = this.searchTerm();
    const categoryId = this.selectedCategory();
    const categoryName = this.getCategoryNameById(categoryId);

    if (search && categoryId !== 'all') {
      return `${total} libro${total !== 1 ? 's' : ''} encontrado${total !== 1 ? 's' : ''} para "${search}" en ${categoryName}`;
    } else if (search) {
      return `${total} libro${total !== 1 ? 's' : ''} encontrado${total !== 1 ? 's' : ''} para "${search}"`;
    } else if (categoryId !== 'all') {
      return `${total} libro${total !== 1 ? 's' : ''} en ${categoryName}`;
    } else {
      return `${total} libro${total !== 1 ? 's' : ''} disponible${total !== 1 ? 's' : ''}`;
    }
  }

  getCategoryNameById(id: number | 'all'): string {
    if (id === 'all') return 'Todas las categorías';
    const category = this.categories().find(c => c.id === id);
    return category?.name ?? 'Desconocida';
  }

  trackByBookId(index: number, book: Book): number {
    return book.id;
  }
  
}
