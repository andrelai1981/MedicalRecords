import { FileService } from '../_services/file.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { File } from '../_models/file';
import { AuthService } from '../_services/auth.service';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';

@Injectable()
export class FileEditResolver implements Resolve<File> {
  constructor(private fileService: FileService,
    private router: Router, private alertify: AlertifyService, private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<File> {
      return this.fileService.getFile(route.params['id']).pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving your data');
          this.router.navigate(['/files']);
          return of(null);
        })
      );
    }
}
