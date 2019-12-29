import { BoxService } from '../_services/box.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { Box } from '../_models/Box';
import { AuthService } from '../_services/auth.service';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';

@Injectable()
export class BoxEditResolver implements Resolve<Box> {
  constructor(private boxService: BoxService,
    private router: Router, private alertify: AlertifyService, private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Box> {
      return this.boxService.getBox(route.params['id']).pipe(
        catchError(error => {
          this.alertify.error('Problem retrieving your data');
          this.router.navigate(['/boxes']);
          return of(null);
        })
      );
    }
}
