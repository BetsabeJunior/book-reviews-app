import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { LoadingSpinnerComponent } from '../../../shared/components/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, LoadingSpinnerComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  
  loading = signal(false);
  error = signal<string | null>(null);
  showPassword = signal(false);

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initForm();

    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/home']);
    }
  }

  private initForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [
        Validators.required, 
        Validators.email,
        Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)
      ]],
      password: ['', [
        Validators.required, 
        Validators.minLength(6)
      ]],
      rememberMe: [false]
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.loading.set(true);
      this.error.set(null);

      const { email, password } = this.loginForm.value;

      this.authService.login({ email, password }).subscribe({
        next: (response) => {
          console.log('API response:', response);
          this.loading.set(false);
          this.router.navigate(['/home']);
        },
        error: (error) => {
          console.error('Login error:', error);
          this.loading.set(false);
          this.error.set(
            error.error?.message ||
            'Error al iniciar sesión. Verifica tus credenciales.'
          );
        }
      });
    } else {
      this.markFormGroupTouched();
    }
  }

  private markFormGroupTouched(): void {
    Object.keys(this.loginForm.controls).forEach(key => {
      this.loginForm.get(key)?.markAsTouched();
    });
  }

  togglePasswordVisibility(): void {
    this.showPassword.update(value => !value);
  }

  // Getters para validaciones
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }

  get isEmailInvalid(): boolean {
    return !!(this.email?.invalid && this.email?.touched);
  }

  get isPasswordInvalid(): boolean {
    return !!(this.password?.invalid && this.password?.touched);
  }

  get emailErrorMessage(): string {
    if (this.email?.errors?.['required']) {
      return 'El email es obligatorio';
    }
    if (this.email?.errors?.['email'] || this.email?.errors?.['pattern']) {
      return 'Ingresa un email válido';
    }
    return '';
  }

  get passwordErrorMessage(): string {
    if (this.password?.errors?.['required']) {
      return 'La contraseña es obligatoria';
    }
    if (this.password?.errors?.['minlength']) {
      return 'La contraseña debe tener al menos 6 caracteres';
    }
    return '';
  }
}