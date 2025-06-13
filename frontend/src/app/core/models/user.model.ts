// src/app/core/models/user.model.ts
export interface User {
  id: number;
  name: string;
  email: string;
  profilePicture?: string;
}

export interface AuthResponse {
  token: string;
  user: {
    id: number;
    name: string;
    email: string;
    profilePicture: string;
  };
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  name: string;
  email: string;
  password: string;
}
