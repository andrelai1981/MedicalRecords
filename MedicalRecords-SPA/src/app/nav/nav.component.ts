import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  jwtHelper = new JwtHelperService();
  isAdmin: boolean;
  user: User;

  constructor(public authService: AuthService, private userService: UserService,
    private alertify: AlertifyService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.authService.isAdminUser.subscribe(isAdminUser => {
      this.isAdmin = isAdminUser;
    });
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
    localStorage.removeItem('user');
    // this.authService.decodedToken = null;
    // this.authService.currentUser = null;
    this.alertify.success('Logged out');
    this.router.navigate(['/home']);
  }

  // isAdminUser() {
  //   const user = localStorage.getItem('user');
  //   console.log(user);
  //   // this.route.data.subscribe(data => {
  //   //   this.user = data['user'].result;
  //   // });
  //   // // console.log(this.userService.getUser(userId));
  //   // debugger;
  //   // return false;
  // }
}
