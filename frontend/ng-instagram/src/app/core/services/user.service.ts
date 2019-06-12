import { User } from '../models/user.model';
import { Observable, BehaviorSubject, ReplaySubject } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { JwtService } from './jwt.service';
import { HttpClient } from '@angular/common/http';
import { IdentityResult } from '../models/identity-result.model';

@Injectable()
export class UserService {
  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable().pipe(distinctUntilChanged());

  constructor(
    private apiService: ApiService,
    private http: HttpClient,
    private jwtService: JwtService
  ) { }

  populate() {
    if (this.jwtService.getToken()) {
      /* this.apiService.get('/user')
        .subscribe(
          data => this.setAuth(data.user),
          err => this.purgeAuth()
        ); */

      this.setAuth(this.jwtService.getToken());
    } else {
      this.purgeAuth();
    }
  }

  setAuth(token: string) {
    // Save JWT sent from server in localstorage
    this.jwtService.saveToken(token);
    // Set current user data into observable
    this.currentUserSubject.next({ token: token } as User);
    // Set isAuthenticated to true
    this.isAuthenticatedSubject.next(true);
  }

  purgeAuth() {
    // Remove JWT from localstorage
    this.jwtService.destroyToken();
    // Set current user to an empty object
    this.currentUserSubject.next({} as User);
    // Set auth status to false
    this.isAuthenticatedSubject.next(false);
  }

  attemptAuth(credentials): Observable<User> {
    return this.apiService.post('/Login', credentials)
      .pipe(map(
        data => {
          this.setAuth(data.token);
          return data;
        }
      ));
  }

  attemptRegister(credentials): Observable<IdentityResult> {
    return this.apiService.post('/Register', credentials)
      .pipe(map(
        data => {
          return data;
        }
      ));
  }

  getCurrentUser(): User {
    return this.currentUserSubject.value;
  }

  update(user): Observable<User> {
    return this.apiService
      .put('/user', { user })
      .pipe(map(data => {
        this.currentUserSubject.next(data.user);
        return data.user;
      }));
  }

}