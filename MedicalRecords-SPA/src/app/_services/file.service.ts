import { Injectable } from '@angular/core';
import { File } from '../_models/file';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../_models/client';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class FileService {

  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  getFiles(page?, itemsPerPage?, fileParams?): Observable<PaginatedResult<File[]>> {
    const paginatedResult: PaginatedResult<File[]> = new PaginatedResult<File[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (fileParams != null) {
      params = params.append('barcodeNum', fileParams.barcodeNum);
      params = params.append('clientId', fileParams.clientId);
      params = params.append('showDestroyed', fileParams.showDestroyed);
    }

    return this.http.get<File[]>(this.baseUrl + 'files', {observe: 'response', params})
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

  getFile(id): Observable<File> {
    return this.http.get<File>(this.baseUrl + 'files/' + id);
  }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseUrl + 'clients');
  }

  getClient(id): Observable<Client> {
    return this.http.get<Client>(this.baseUrl + 'clients/' + id );
  }

  addFile(file: File, boxId: number) {
    return this.http.post(this.baseUrl + 'boxes/' + boxId + '/files/create', file);
  }

  updateFile(id: number, file: File) {
    return this.http.put(this.baseUrl + 'files/' + id, file);
  }
}
