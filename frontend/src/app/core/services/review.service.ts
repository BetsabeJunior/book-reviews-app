import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review, CreateReviewRequest } from '../models/review.model';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
  private readonly API_URL = `${environment.apiUrl}/Review`;

  constructor(private http: HttpClient) {}

  createReview(review: CreateReviewRequest): Observable<Review> {
    return this.http.post<Review>(this.API_URL, review);
  }

updateReview(id: string, review: { comment: string; rating: number }): Observable<void> {
  const body = {
    id: Number(id),
    comment: review.comment,
    rating: review.rating
  };
  return this.http.put<void>(`${this.API_URL}/${id}`, body);
}

  deleteReview(id: string): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
}
