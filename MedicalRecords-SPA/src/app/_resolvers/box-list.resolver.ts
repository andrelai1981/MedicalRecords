import { BoxService } from '../_services/box.service';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { Box } from '../_models/Box';
import { catchError } from 'rxjs/operators';

@Injectable()
export class BoxListResolver implements Resolve<Box[]> {
  pageNumber = 1;
  pageSize = 10;
  box: any = {};
  constructor(private boxService: BoxService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Box[]> {
      return this.boxService.getBoxes(this.pageNumber, this.pageSize).pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/boxes']);
          return of(null);
        })
      );
  }
}

