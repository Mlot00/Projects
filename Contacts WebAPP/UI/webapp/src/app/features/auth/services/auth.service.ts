import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginComponent } from '../login/login.component';
import { LoginRequest } from '../models/login-request.model';
import { LoginResposne } from '../models/login-response.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { User } from '../models/user.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  $user = new BehaviorSubject<User | undefined>(undefined);

  constructor(private http: HttpClient,
    private cookieService: CookieService) { }

  login(reguest: LoginRequest): Observable<LoginResposne>{
    return this.http.post<LoginResposne>(`${environment.apiBaseUrl}/api/auth/login`, {email: reguest.email, password: reguest.password});
  }


  setUser(user: User) :void {
    this.$user.next(user);
    localStorage.setItem('user-email', user.email);
    localStorage.setItem('user-roles', user.roles.join(','));
  }

  user() : Observable<User | undefined> {
    return this.$user.asObservable();
  }

  getUser(): User | undefined {
    const email = localStorage.getItem('user-email');
    const roles = localStorage.getItem('user-roles')

    if(email&&roles){
      const user: User = {
        email: email,
        roles: roles?.split(',')
      };
      return user;
    }
    return undefined;
  }

  logout():void {
    console.log("logout");
    localStorage.clear();
    this.cookieService.delete('Authorization', '/');
    this.$user.next(undefined);
  }
}
