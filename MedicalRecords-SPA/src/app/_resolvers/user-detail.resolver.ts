import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { User } from '../_models/User';
import { UserService } from '../_services/user.service';

@Injectable()
export class UserDetailResolver implements Resolve<User> {
  constructor(private boxService: UserService, private router: Router, private alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.boxService.getUser(route.params['id']).pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/Users']);
        return of(null);
      })
    );
  }
}
