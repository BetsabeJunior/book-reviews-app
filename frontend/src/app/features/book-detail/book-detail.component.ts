import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../../core/services/book.service';
import { ReviewService } from '../../core/services/review.service';
import { BookDetail, Review } from '../../core/models/book.model';
import { CommonModule, Location } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class BookDetailComponent implements OnInit {
  book: BookDetail | null = null;
  reviews: Review[] = [];
  newReview = {
    rating: 5,
    comment: '',
  };
  currentUserId: number = 0;
  editingReviewId: number | null = null;
  editingReview = {
    rating: 0,
    comment: '',
  };

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService,
    private reviewService: ReviewService,
     private location: Location
  ) { }

  ngOnInit(): void {
    const user = localStorage.getItem('user');
    if (user) {
      this.currentUserId = Number(JSON.parse(user).id);
    }

    const bookId = Number(this.route.snapshot.paramMap.get('id'));
    if (!isNaN(bookId)) {
      this.bookService.getBookById(bookId).subscribe(
        (data: any) => {
          this.book = data as BookDetail;
          this.reviews = (data.reviews || []).sort(
            (a: Review, b: Review) =>
              new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
          );
        },
        () => (this.book = null)
      );
    }
  }

  isTokenValid(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const now = Math.floor(Date.now() / 1000);
      return payload.exp && payload.exp > now;
    } catch {
      return false;
    }
  }

  goBack(): void {
  this.location.back();
}

  submitReview(): void {
    if (!this.book) return;

    const token = localStorage.getItem('token');
    const users = localStorage.getItem('user');

    if (!token || !users || !this.isTokenValid(token)) return;

    const user = JSON.parse(users);
    const userId = user.id;
    const username = user.name;

    const review = {
      rating: this.newReview.rating,
      comment: this.newReview.comment,
      bookId: this.book.id,
      userId: userId
    };

    this.reviewService.createReview(review).subscribe(() => {
      const addedReview: Review = {
        id: Date.now(),
        bookId: this.book!.id,
        userId: userId,
        username: username,
        userAvatar: '',
        rating: this.newReview.rating,
        comment: this.newReview.comment,
        createdAt: new Date().toISOString(),
      };

      this.reviews = [addedReview, ...this.reviews];
      this.newReview = { rating: 5, comment: '' };
    });
  }

  editReview(review: Review): void {
    this.editingReviewId = review.id;
    this.editingReview = {
      rating: review.rating,
      comment: review.comment,
    };
  }

saveEditedReview(): void {
  if (!this.editingReviewId) return;
  this.reviewService.updateReview(this.editingReviewId.toString(), this.editingReview).subscribe(() => {
    const index = this.reviews.findIndex(r => r.id === this.editingReviewId);
    if (index !== -1) {
      this.reviews[index].rating = Number(this.editingReview.rating);
      this.reviews[index].comment = this.editingReview.comment;
    }
    this.editingReviewId = null;
  });
}


  cancelEdit(): void {
    this.editingReviewId = null;
  }


  deleteReview(id: number): void {
    this.reviewService.deleteReview(id.toString()).subscribe(() => {
      this.reviews = this.reviews.filter(r => r.id !== id);
    });
  }

  onImageError(event: Event): void {
    (event.target as HTMLImageElement).src = 'SinImagen.jpg';
  }

getStarArray(cantidad: number): number[] {
  return Array(Number(cantidad)).fill(0);
}

}
