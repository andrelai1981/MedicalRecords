import { Component, OnInit, Output, EventEmitter, HostListener } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/Box';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { isNumber } from 'util';

@Component({
  selector: 'app-box-list',
  templateUrl: './box-list.component.html',
  styleUrls: ['./box-list.component.css']
})
export class BoxListComponent implements OnInit {
  boxes: any = {};
  boxParams: any = {};
  pagination: Pagination;
  addBoxMode = false;
  mySubscription: any;
  destroyedList = [{value: 0, display: 'Show Not Destroyed'}, {value: 1, display: 'Show Destroyed'}, {value: 2, display: 'Show All'}];
  counties: any;
  departments: any;

  constructor(private boxService: BoxService, private alertify: AlertifyService, private router: Router,
    private route: ActivatedRoute) {
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

  onKeyDown(event) {
    if (!isFinite(event.key) && event.key !== 'Backspace' && event.key !== 'Delete' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
      event.preventDefault();
    }
  }

  ngOnInit() {
    this.boxParams.showDestroyed = 0;
    this.boxParams.barcodeNum = null;
    this.boxParams.departmentId = 0;
    this.boxParams.countyId = 0;
    this.boxParams.orderBy = 'barcodeNum';

    this.route.data.subscribe(data => {
      this.boxes = data['boxes'].result;
      this.pagination = data['boxes'].pagination;
    });

    this.getDepartments();
    this.getCounties();
    // document.querySelector('#barcodeNum').addEventListener('keydown', KeyboardEvent => {
    //   if ((KeyboardEvent.keyCode < 48 || KeyboardEvent.keyCode > 57)
    //       && (KeyboardEvent.keyCode < 96 || KeyboardEvent.keyCode > 105)
    //       && KeyboardEvent.keyCode != 8) {
    //       KeyboardEvent.preventDefault();
    //   }
    // });
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

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadBoxes();
  }

  resetFilters() {
    this.boxParams.showDestroyed = 0;
    this.boxParams.barcodeNum = null;
    this.boxParams.countyId = 0;
    this.boxParams.departmentId = 0;
    this.loadBoxes();
  }
  addBoxToggle() {
    this.addBoxMode = true;
  }

  cancelAddBoxMode(addBoxMode: boolean) {
    this.addBoxMode = addBoxMode;
  }

  loadBoxes() {
    this.boxService
      .getBoxes(this.pagination.currentPage, this.pagination.itemsPerPage, this.boxParams)
      .subscribe((res: PaginatedResult<Box[]>) => {
      this.boxes = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

  destroyBox(boxId: number) {
    this.alertify.confirm('Are you sure you want to destroy this box?', () => {
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
    });
  }
}
