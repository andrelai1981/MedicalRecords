import { Injectable } from '@angular/core';
import { BoxService } from '../_services/box.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { County } from '../_models/County';

@Injectable()
export class CountyListResolver implements Resolve<County[]> {

  box: any = {};
  constructor(private boxService: BoxService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<County[]> {
      return this.boxService.getCounties().pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/boxes']);
          return of(null);
        })
      );
  }
}
