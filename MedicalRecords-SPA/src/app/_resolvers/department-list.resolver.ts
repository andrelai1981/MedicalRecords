import { Injectable } from '@angular/core';
import { BoxService } from '../_services/box.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Department } from '../_models/department';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class DepartmentListResolver implements Resolve<Department[]> {

  box: any = {};
  constructor(private boxService: BoxService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Department[]> {
      return this.boxService.getDepartments().pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving data');
          this.router.navigate(['/boxes']);
          return of(null);
        })
      );
  }
}
