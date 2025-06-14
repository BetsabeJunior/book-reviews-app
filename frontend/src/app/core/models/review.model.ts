export interface Review {
  id: number;
  bookId: number;
  userId: number;
  username: string;
  userAvatar: string;
  rating: number;
  comment: string;
  createdAt: string;
}

export interface CreateReviewRequest {
  rating: number;
  comment: string;
  bookId: number;
  userId: number;
}
