import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user-new',
  templateUrl: './user-new.component.html',
  styleUrls: ['./user-new.component.css']
})
export class UserNewComponent implements OnInit {
  user: any = {};
  constructor(private router: Router, private userService: UserService
    , private alertify: AlertifyService) { }

  ngOnInit() {
  }

  addUser() {
    console.log(this.user);
    this.userService.create(this.user).subscribe(() => {
      this.alertify.success('Added user successfully');
      this.router.navigate(['/users']);
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/users']);
    });
  }

  cancel() {
    this.router.navigate(['/users']);
  }

}
