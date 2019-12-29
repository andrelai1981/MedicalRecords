import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/Box';
import { ActivatedRoute } from '@angular/router';
import { County } from 'src/app/_models/county';
import { Department } from 'src/app/_models/department';

@Component({
  selector: 'app-box-detail',
  templateUrl: './box-detail.component.html',
  styleUrls: ['./box-detail.component.css']
})
export class BoxDetailComponent implements OnInit {

  @Output() getBoxId = new EventEmitter<number>();
  box: any = {};
  county: any = {};
  department: any = {};

  constructor(private boxService: BoxService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.box = data['box'];
    });
    this.boxService.getCounty(this.box.county).subscribe(response => {
      this.county = response;
    });
    this.boxService.getDepartment(this.box.department).subscribe(response => {
      this.department = response;
    });
    this.getBoxId.emit(this.route.snapshot.params['id']);
  }
}
