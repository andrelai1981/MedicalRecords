import { Injectable } from '@angular/core';
import { Box } from '../_models/Box';
import { County } from '../_models/County';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { Department } from '../_models/department';

@Injectable({
  providedIn: 'root'
})
export class BoxService {

  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  getBoxes(): Observable<Box[]> {
    return this.http.get<Box[]>(this.baseUrl + 'boxes');
  }

  getBox(id): Observable<Box> {
    return this.http.get<Box>(this.baseUrl + 'boxes/' + id);
  }

  getCounties(): Observable<County[]>{
    return this.http.get<County[]>(this.baseUrl + 'counties');
  }

  getDepartments(): Observable<Department[]>{
    return this.http.get<Department[]>(this.baseUrl + 'departments');
  }

  addBox(box: Box) {
    return this.http.post(this.baseUrl + 'boxes/createbox', box);
  }
}
