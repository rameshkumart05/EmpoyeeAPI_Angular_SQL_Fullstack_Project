import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  http = inject(HttpClient);

  loginobj = {
    email: '',
    contactno: ''
  };

  errorMessage = '';
  validationErrors: string[] = [];

  onLogin() {
    this.errorMessage = '';
    this.validationErrors = [];

    this.http.post(
      'https://localhost:7233/api/EmployeeMaster/login',
      this.loginobj
    ).subscribe({
      next: (result: any) => {
        console.log('Login successful:', result);
      },

      error: (err: HttpErrorResponse) => {
        console.error('HTTP Error:', err);

        if (err.status === 400) {
          this.errorMessage =
            err.error?.title || 'Bad Request. Please check your input.';

          const errors = err.error?.errors;

          if (errors && typeof errors === 'object') {
            this.validationErrors = Object.entries(errors)
              .flatMap(([field, messages]) =>
                (Array.isArray(messages) ? messages : [messages])
                  .map(message => `${field}: ${message}`)
              );
          } else if (err.error?.message) {
            this.validationErrors = [err.error.message];
          }

          console.log('API message:', this.errorMessage);
          console.log('Validation errors:', this.validationErrors);

        } else if (err.status === 401) {
          this.errorMessage = 'Invalid email or contact number.';
        } else if (err.status === 0) {
          this.errorMessage =
            'Unable to connect to the API. Check the server and URL.';
        } else {
          this.errorMessage =
            `An error occurred. HTTP Status: ${err.status}`;
        }
      }
    });
  }
}