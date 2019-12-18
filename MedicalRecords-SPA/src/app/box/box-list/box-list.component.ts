import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/Box';

@Component({
  selector: 'app-box-list',
  templateUrl: './box-list.component.html',
  styleUrls: ['./box-list.component.css']
})
export class BoxListComponent implements OnInit {
  boxes: Box[];
  addBoxMode = false;

  constructor(private boxService: BoxService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadBoxes();
  }

  addBoxToggle() {
    this.addBoxMode = true;
  }

  cancelAddBoxMode(addBoxMode: boolean) {
    this.addBoxMode = addBoxMode;
  }

  loadBoxes() {
    this.boxService.getBoxes().subscribe((boxes: Box[]) => {
      this.boxes = boxes;
    }, error => {
      this.alertify.error(error);
    });
  }

}
