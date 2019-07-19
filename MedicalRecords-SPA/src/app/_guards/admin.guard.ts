import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  jwtHelper = new JwtHelperService();
  decodedToken: any;
  isAdminUser: boolean;

  constructor(private userService: UserService, private authService: AuthService,
    private router: Router, private alertify: AlertifyService) {}

  canActivate(): boolean {
    // const token = localStorage.getItem('token');
    // const userId = this.jwtHelper.decodeToken(token).nameid;
    // this.userService.isAdmin(userId).subscribe(r => this.isAdminUser);
    this.isAdminUser = true;
    if (this.isAdminUser) {
      return true;
    }

    this.alertify.error('You shall not pass!!!!');
    this.router.navigate(['/home']);
    return false;
  }
}
