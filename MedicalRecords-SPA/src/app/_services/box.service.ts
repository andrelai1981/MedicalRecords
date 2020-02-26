import { Injectable } from '@angular/core';
import { Box } from '../_models/Box';
import { County } from '../_models/County';
import { Department } from '../_models/department';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BoxService {

  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  getBoxes(page?, itemsPerPage?, boxParams?): Observable<PaginatedResult<Box[]>> {
    const paginatedResult: PaginatedResult<Box[]> = new PaginatedResult<Box[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (boxParams != null) {
      if (boxParams.barcodeNum == null) {
        params = params.append('barcodeNum', '0');
      } else {
        params = params.append('barcodeNum', boxParams.barcodeNum);
      }
      if (boxParams.departmentId == null) {
        params = params.append('departmentId', '0');
      } else {
        params = params.append('departmentId', boxParams.departmentId);
      }
      if (boxParams.countyId == null) {
        params = params.append('countyId', '0');
      } else {
        params = params.append('countyId', boxParams.countyId);
      }
      if (boxParams.showDestroyed == null) {
        params = params.append('showDestroyed', '0');
      } else {
        params = params.append('showDestroyed', boxParams.showDestroyed);
      }
      params = params.append('orderBy', boxParams.orderBy);
    }

    return this.http.get<Box[]>(this.baseUrl + 'boxes', {observe: 'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  getBox(id): Observable<Box> {
    return this.http.get<Box>(this.baseUrl + 'boxes/' + id);
  }

  getCounties(): Observable<County[]> {
    return this.http.get<County[]>(this.baseUrl + 'counties');
  }

  getCounty(id): Observable<County> {
    return this.http.get<County>(this.baseUrl + 'counties/' + id );
  }

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl + 'departments');
  }

  getDepartment(id): Observable<Department> {
    return this.http.get<Department>(this.baseUrl + 'departments/' + id );
  }

  addBox(box: Box) {
    return this.http.post(this.baseUrl + 'boxes/create', box);
  }

  updateBox(id: number, box: Box) {
    return this.http.put(this.baseUrl + 'boxes/' + id, box);
  }
}
