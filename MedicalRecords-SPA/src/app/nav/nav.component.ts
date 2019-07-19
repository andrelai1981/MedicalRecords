import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  jwtHelper = new JwtHelperService();
  admin: any;

  constructor(public authService: AuthService, private userService: UserService, 
    private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {

  }

  login() {
    this.authService.login(this.model).subscribe(next => {

      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/boxes']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.success('Logged out');
    this.router.navigate(['/home']);
  }

  isAdminUser() {
    const token = localStorage.getItem('token');
    const userId = this.jwtHelper.decodeToken(token).nameid;
    // this.userService.getUser(userId)
    console.log(this.userService.getUser(userId));
    debugger;
    return false;
  }
}
