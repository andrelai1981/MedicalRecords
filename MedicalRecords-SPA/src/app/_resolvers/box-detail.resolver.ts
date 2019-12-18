import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { Box } from '../_models/Box';
import { BoxService } from '../_services/box.service';

@Injectable()
export class BoxDetailResolver implements Resolve<Box> {
  constructor(private boxService: BoxService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Box> {
    return this.boxService.getBox(route.params['id']).pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/boxes']);
        return of(null);
      })
    );
  }
}
