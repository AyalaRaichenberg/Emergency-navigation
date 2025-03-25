import { Component } from '@angular/core';
import { UserService } from '../service/user.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  buildings: any[] = [];
  constructor(private _userService: UserService, private router: Router) { };
  loginModel: any = { "email": "oritsh@gmail.com", "password": "1234" }
  errorMessage = '';

  onSubmit(event: Event) {
    event.preventDefault();
    if (!this.loginModel.email || !this.loginModel.password) {
      this.errorMessage = 'נא למלא את כל השדות'
      return;
    }
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(this.loginModel.email)) {
      this.errorMessage = 'כתובת אימייל אינה תקינה';
      return;
    }
    if (this.loginModel.password.length < 4) {
      this.errorMessage = 'הסיסמה חייבת להיות לפחות 4 תווים';
      return;
    }
    this._userService.loginServer(this.loginModel).subscribe({
      next: (data) => {
        localStorage.setItem('appSession', JSON.stringify({ user: data.user, token: data.token }));
        this.router.navigate(['/']);
      },
      error: () => { this.errorMessage = 'האימייל או הסיסמה שגויים'; }
    }
    )

  }
}