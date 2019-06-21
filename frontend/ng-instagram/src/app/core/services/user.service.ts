import { User } from '../models/user.model';
import { Observable, BehaviorSubject, ReplaySubject } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { JwtService } from './jwt.service';
import { HttpClient, HttpParams } from '@angular/common/http';
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
  ) {
    var tokenExists = this.jwtService.getToken() != null;
    this.isAuthenticatedSubject.next(tokenExists);
  }

  populate() {
    var token = this.jwtService.getToken();
    if (token) {
      this.apiService.get('/user')
        .subscribe(
          data => {
            data.token = token;
            this.setAuth(data);
          },
          err => this.purgeAuth()
        );
    } else {
      this.purgeAuth();
    }
  }

  setAuth(data: any) {
    // Save JWT sent from server in localstorage
    this.jwtService.saveToken(data.token);
    // Set current user data into observable
    this.currentUserSubject.next(data.user as User);
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

  attemptAuth(credentials): any {
    return this.apiService.post('/Login', credentials)
      .pipe(map(
        data => {
          this.setAuth(data);
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

  getUser(id): any {
    return this.apiService
      .get('/user', new HttpParams().set('id', id))
      .pipe(map(data => {
        return data.user as User;
      }));
  }

  getUserByUsername(username): Observable<User> {
    return this.apiService
      .get('/user/getByUsername', new HttpParams().set('username', username))
      .pipe(map(
        data => {
          return data.user as User;
        }
      ));
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
