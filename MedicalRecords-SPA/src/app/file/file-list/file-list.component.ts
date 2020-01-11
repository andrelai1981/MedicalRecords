import { Component, OnInit } from '@angular/core';
import { FileService } from 'src/app/_services/file.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { File } from 'src/app/_models/File';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css']
})
export class FileListComponent implements OnInit {
  files: File[];
  mySubscription: any;
  fileParams: any = {};
  pagination: Pagination;
  destroyedList = [{value: 0, display: 'Show Not Destroyed'}, {value: 1, display: 'Show Destroyed'}, {value: 2, display: 'Show All'}];

  constructor(private fileService: FileService, private alertify: AlertifyService, private router: Router, private route: ActivatedRoute) {

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
    this.fileParams.showDestroyed = 0;
    this.fileParams.barcodeNum = 0;
    this.fileParams.clientId = 0;

    this.route.data.subscribe(data => {
      this.files = data['files'].result;
      this.pagination = data['files'].pagination;
    });
  }

  loadFiles() {
    if (this.fileParams.clientId === undefined) {
      delete this.fileParams.clientId;
    }
    this.fileService
      .getFiles(this.pagination.currentPage, this.pagination.itemsPerPage, this.fileParams)
      .subscribe((res: PaginatedResult<File[]>) => {
    this.files = res.result;
    this.pagination = res.pagination;
  }, error => {
    this.alertify.error(error);
  });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadFiles();
  }

  resetFilters() {
    this.fileParams.showDestroyed = undefined;
    this.fileParams.barcodeNum = 0;
    this.fileParams.clientId = 0;
    this.loadFiles();
  }

  destroyFile(fileId: number) {

    this.alertify.confirm('Are you sure you want to destroy this file?', () => {
      this.fileService.getFile(fileId).subscribe((file: File) => {
        file.destroyed = true;
        this.fileService.updateFile(fileId, file).subscribe(next => {
          this.alertify.success('File destroyed');
          this.router.navigateByUrl('/files', { skipLocationChange: true }).then(() => {
            this.router.navigate(['/files']);
          });
        }, error => {
          this.alertify.error(error);
        });
      }, error => {
        this.alertify.error(error);
      });
    });

      // if (confirm('Are you sure to destroy this file')) {
      //   this.fileService.getFile(fileId).subscribe((file: File) => {
      //     file.destroyed = true;
      //     this.fileService.updateFile(fileId, file).subscribe(next => {
      //       this.alertify.success('File destroyed');
      //       this.router.navigateByUrl('/files', { skipLocationChange: true }).then(() => {
      //         this.router.navigate(['/files']);
      //       });
      //     }, error => {
      //       this.alertify.error(error);
      //     });
      //   }, error => {
      //     this.alertify.error(error);
      //   });
      // }
  }
}
