import { Component, OnInit } from '@angular/core';
import { FileService } from 'src/app/_services/file.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { File } from 'src/app/_models/File';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css']
})
export class FileListComponent implements OnInit {
  files: File[];

  constructor(private fileService: FileService, private alertify: AlertifyService) { }

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

}
