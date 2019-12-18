import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/Box';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-box-detail',
  templateUrl: './box-detail.component.html',
  styleUrls: ['./box-detail.component.css']
})
export class BoxDetailComponent implements OnInit {

  @Output() getBoxId = new EventEmitter<number>();
  box: Box;

  constructor(private boxService: BoxService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.box = data['box'];
    });
    this.getBoxId.emit(this.route.snapshot.params['id']);
  }
  // box/4
  // loadBox() {
  //   this.boxService.getBox(+this.route.snapshot.params['id']).subscribe((box: Box) => {
  //     this.box = box;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }
}
