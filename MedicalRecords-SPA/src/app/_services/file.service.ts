import { Injectable } from '@angular/core';
import { File } from '../_models/file';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../_models/client';

@Injectable({
  providedIn: 'root'
})

export class FileService {

  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  getFiles(): Observable<File[]> {
    return this.http.get<File[]>(this.baseUrl + 'files');
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
