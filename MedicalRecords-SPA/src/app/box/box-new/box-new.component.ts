import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BoxService } from 'src/app/_services/box.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Box } from 'src/app/_models/Box';
import { Router } from '@angular/router';

@Component({
  selector: 'app-box-new',
  templateUrl: './box-new.component.html',
  styleUrls: ['./box-new.component.css']
})
export class BoxNewComponent implements OnInit {
  @Output() cancelAddBox = new EventEmitter();
  box: any = {};
  counties: any;
  departments: any;

  constructor(private boxService: BoxService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.getCounties();
    this.getDepartments();
  }
  getCounties() {
    this.boxService.getCounties().subscribe(response => {
      this.counties = response;
    }, error => {
      this.alertify.error(error);
    });
  }

  getDepartments() {
    this.boxService.getDepartments().subscribe(response => {
      this.departments = response;
    }, error => {
      this.alertify.error(error);
    });
  }

  addBox() {
    this.boxService.addBox(this.box).subscribe(() => {
      this.alertify.success('Added box successfully');
      this.router.navigate(['/boxes']);
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/boxes']);
    });
  }

  cancel() {
    this.router.navigate(['/boxes']);
  }
}
