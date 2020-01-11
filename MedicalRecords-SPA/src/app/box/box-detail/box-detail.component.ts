import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { File } from 'src/app/_models/file';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { FileService } from 'src/app/_services/file.service';

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
  mySubscription: any;

  constructor(private boxService: BoxService, private alertify: AlertifyService,
    private route: ActivatedRoute, private fileService: FileService, private router: Router) {
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
    this.route.data.subscribe(data => {
      this.box = data['box'];
    });
    this.getBoxId.emit(this.route.snapshot.params['id']);
  }

  destroyFile(fileId: number) {
    this.alertify.confirm('Are you sure you want to destroy this file?', () => {
      this.fileService.getFile(fileId).subscribe((file: File) => {
        const boxId: string = this.route.snapshot.params['id'];
        console.log('/boxes/' + boxId);
        file.destroyed = true;
        this.fileService.updateFile(fileId, file).subscribe(next => {
          this.alertify.success('File destroyed');
          this.router.navigateByUrl('/boxes/', { skipLocationChange: true }).then(() => {
            this.router.navigate(['/boxes/' + boxId]);
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
