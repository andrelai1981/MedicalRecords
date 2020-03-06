import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/_models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  @ViewChild('editForm', {static: true }) editForm: NgForm;
  user: User;
  constructor(private route: ActivatedRoute, private router: Router, private userService: UserService
    , private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });
  }

  updateUser() {
    this.userService.updateUser(this.user.userId, this.user).subscribe(next => {
      this.alertify.success('User update successful');
      this.router.navigate(['/users']);
      this.editForm.reset(this.user);
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.router.navigate(['/users']);
  }

}
