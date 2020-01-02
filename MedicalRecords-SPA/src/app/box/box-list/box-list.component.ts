import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/Box';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-box-list',
  templateUrl: './box-list.component.html',
  styleUrls: ['./box-list.component.css']
})
export class BoxListComponent implements OnInit {
  boxes: any = {};
  addBoxMode = false;
  mySubscription: any;

  constructor(private boxService: BoxService, private alertify: AlertifyService, private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
    this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Trick the Router into believing it's last link wasn't previously loaded
        this.router.navigated = false;
      }
    });
  }

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
  destroyBox(boxId: number) {
    if (confirm('Are you sure to destroy this box')) {
      this.boxService.getBox(boxId).subscribe((box: Box) => {
        box.destroyed = true;
        this.boxService.updateBox(boxId, box).subscribe(next => {
          this.alertify.success('Box destroyed');
          this.router.navigateByUrl('/boxes', { skipLocationChange: true }).then(() => {
            this.router.navigate(['/boxes']);
          });
        }, error => {
          this.alertify.error(error);
        });
      }, error => {
        this.alertify.error(error);
      });
    }
}
}
