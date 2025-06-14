import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book, BookFilter } from '../models/book.model';
import { environment } from '../../environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private readonly API_URL = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getBooks(filter?: BookFilter): Observable<Book[]> {
    let params = new HttpParams();

    if (filter?.search) {
      params = params.set('search', filter.search);
    }

    if (filter?.category) {
      params = params.set('categoryId', filter.category);
    }

    return this.http.get<Book[]>(`${this.API_URL}/Book`, { params });
  }

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.API_URL}/Book/${id}`);
  }

  createBook(book: Partial<Book>): Observable<Book> {
    return this.http.post<Book>(`${this.API_URL}/Book`, book);
  }

  updateBook(id: number, book: Partial<Book>): Observable<void> {
    return this.http.put<void>(`${this.API_URL}/Book/${id}`, book);
  }

  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/Book/${id}`);
  }
}
