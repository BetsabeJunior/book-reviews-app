import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-star-rating',
  imports: [],
  templateUrl: './star-rating.component.html',
  styleUrl: './star-rating.component.css'
})
export class StarRatingComponent {
  @Input() rating = 0;
  @Input() readonly = false;
  @Input() size: 'sm' | 'md' | 'lg' = 'md';
  @Output() ratingChange = new EventEmitter<number>();

  stars = Array(5).fill(0);
  hoverRating = 0;

  setRating(rating: number): void {
    this.rating = rating;
    this.ratingChange.emit(rating);
  }

  setHoverRating(rating: number): void {
    this.hoverRating = rating;
  }

  getStarClass(starNumber: number): string {
    const isActive = starNumber <= (this.hoverRating || this.rating);
    const baseClass = this.readonly ? '' : 'hover:scale-110 cursor-pointer';
    
    return `${baseClass} ${isActive ? 'text-yellow-400' : 'text-gray-300'}`;
  }

  getSvgSize(): string {
    switch (this.size) {
      case 'sm': return 'w-4 h-4';
      case 'lg': return 'w-8 h-8';
      default: return 'w-5 h-5';
    }
  }
}