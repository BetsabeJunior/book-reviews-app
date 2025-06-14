import { Component, Input } from '@angular/core';
import { Book } from '../../../core/models/book.model';
import { StarRatingComponent } from "../star-rating/star-rating.component";
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-book-card',
  imports: [StarRatingComponent, RouterModule],
  templateUrl: './book-card.component.html',
  styleUrl: './book-card.component.css'
})
export class BookCardComponent {
  @Input() book!: Book;

  onImageError(event: Event): void {
    const element = event.target as HTMLImageElement;
    element.src = 'assets/images/SinImagen.jpg';
  }

}
