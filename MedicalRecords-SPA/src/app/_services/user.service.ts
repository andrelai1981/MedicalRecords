import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  // updateUser(id: number, user: User) {
  //   return this.http.put(this.baseUrl + 'users/' + id, user);
  // }

  // setMainPhoto(userId: number, id: number) {
  //   return this.http.post(this.baseUrl + 'users/' + userId + '/photos/' + id + '/setMain', {});
  // }

  // deletePhoto(userId: number, id: number) {
  //   return this.http.delete(this.baseUrl + 'users/' + userId + '/photos/' + id);
  // }

}