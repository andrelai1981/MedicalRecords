import { FileService } from '../_services/file.service';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { File } from '../_models/file';
import { catchError } from 'rxjs/operators';

@Injectable()
export class FileListResolver implements Resolve<File[]> {
  pageNumber = 1;
  pageSize = 10;
  file: any = {};
  constructor(private fileService: FileService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<File[]> {
      return this.fileService.getFiles(this.pageNumber, this.pageSize).pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/files']);
          return of(null);
        })
      );
  }
}

