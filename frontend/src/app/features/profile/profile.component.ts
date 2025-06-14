import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { User } from '../../core/models/user.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  imports: [CommonModule, FormsModule, RouterModule],
})
export class ProfileComponent implements OnInit {
  user!: User;
  editedUser!: User;
  isEditing: boolean = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.user = this.authService.getCurrentUser();
    this.editedUser = { ...this.user };
  }

  startEdit(): void {
    this.isEditing = true;
  }

  cancelEdit(): void {
    this.editedUser = { ...this.user };
    this.isEditing = false;
  }

  saveEdit(): void {
  this.authService.updateUser(this.editedUser).subscribe({
    next: (response) => {
      this.user = response.user;
      localStorage.setItem('user', JSON.stringify(response.user));
      localStorage.setItem('token', response.token);
      this.isEditing = false;
    },
    error: (err) => {
      console.error('Error updating user:', err);
      
    },
  });
}
  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
