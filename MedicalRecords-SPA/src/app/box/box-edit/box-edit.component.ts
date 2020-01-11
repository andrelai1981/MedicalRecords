import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { NgForm } from '@angular/forms';
import { Box } from 'src/app/_models/Box';
import { County } from 'src/app/_models/county';
import { Department } from 'src/app/_models/department';

@Component({
  selector: 'app-box-edit',
  templateUrl: './box-edit.component.html',
  styleUrls: ['./box-edit.component.css']
})
export class BoxEditComponent implements OnInit {
  @ViewChild('editForm', {static: true }) editForm: NgForm;
  box: Box;
  counties: County[];
  departments: Department[];

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
    private boxService: BoxService, private router: Router) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.box = data['box'];
    });
    this.getCounties();
    this.getDepartments();
  }

  updateBox() {
    this.boxService.updateBox(this.box.boxId, this.box).subscribe(next => {
      this.alertify.success('Box update successfully');
      this.editForm.reset(this.box);
    }, error => {
      this.alertify.error(error);
    });
  }

  getCounties() {
    this.route.data.subscribe(data => {
      this.counties = data['counties'];
    }, error => {
      this.alertify.error(error);
    });
  }

  getDepartments() {
    this.route.data.subscribe(data => {
      this.departments = data['departments'];
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.router.navigate(['/boxes']);
  }
}
