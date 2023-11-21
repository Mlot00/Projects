import { Component, OnDestroy } from '@angular/core';
import { LoginRequest } from '../models/login-request.model';
import { AuthService } from '../services/auth.service';
import { Subscription } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnDestroy{
model: LoginRequest;
loginSubscription?: Subscription;

constructor(private authService: AuthService,
  private cookieservice: CookieService,
  private router: Router) {
  this.model = {
    email: '',
    password: ''
  };
}


onFormSubmit(): void {
  this.loginSubscription = this.authService.login(this.model).subscribe({
    next: (resposne) =>{
      //Set Auth Cookie
      this.cookieservice.set('Authorization', `Bearer ${resposne.token}`,
      undefined, '/', undefined, true, 'Strict');

      // Set User
      this.authService.setUser({
        email: resposne.email,
        roles: resposne.roles
      })

      //Redirect back to home
      this.router.navigateByUrl('/');
    }
  });
}

ngOnDestroy(): void {
  this.loginSubscription?.unsubscribe();
}

}
