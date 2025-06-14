export interface Review {
  id: number;
  bookId: number;
  userId: string;
  username: string;
  userAvatar: string;
  rating: number;
  comment: string;
  createdAt: string;
}

export interface Book {
  id: number;
  title: string;
  author: string;
  category: string;
  description: string;
  imageUrl: string | null;
  publishedDate?: Date;
  averageRating?: number;
  totalReviews?: number;
}

export interface BookFilter {
  search?: string;
  category?: string;
}

export interface BookDetail {
  id: number;
  title: string;
  author: string;
  category: string;
  description: string;
  imageUrl: string | null;
  reviews: Review[];
}
