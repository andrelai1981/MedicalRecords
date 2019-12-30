import { Component, OnInit } from '@angular/core';
import { FileService } from 'src/app/_services/file.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { File } from 'src/app/_models/File';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css']
})
export class FileListComponent implements OnInit {
  files: File[];
  mySubscription: any;

  constructor(private fileService: FileService, private alertify: AlertifyService, private router: Router) {

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
    this.loadFiles();
  }

  loadFiles() {
    this.fileService.getFiles().subscribe((files: File[]) => {
      this.files = files;
    }, error => {
      this.alertify.error(error);
    });
  }

  destroyFile(fileId: number) {
      if (confirm('Are you sure to destroy this file')) {
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
      }
  }
}
