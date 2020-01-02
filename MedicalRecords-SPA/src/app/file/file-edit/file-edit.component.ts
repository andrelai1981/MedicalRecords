import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';
import { File } from 'src/app/_models/file';
import { FileService } from 'src/app/_services/file.service';
import { Box } from 'src/app/_models/Box';
import { BoxService } from 'src/app/_services/box.service';
import { Client } from 'src/app/_models/client';

@Component({
  selector: 'app-file-edit',
  templateUrl: './file-edit.component.html',
  styleUrls: ['./file-edit.component.css']
})
export class FileEditComponent implements OnInit {
  @ViewChild('editForm', {static: true }) editForm: NgForm;
  file: File;
  fileId: number;
  clientId: number;
  clients: Client[];
  box: Box;
  boxId: number;
  barcodeNumber: number;
  boxes: Box[];

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private fileService: FileService, private alertify: AlertifyService, private router: Router,
    private route: ActivatedRoute, private boxService: BoxService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.file = data['file'];
    });
    this.getClients();
    this.getBarcodeNumbers();
  }

  updateFile() {
    console.log(this.file);
    this.fileService.updateFile(this.file.fileId, this.file).subscribe(next => {
      this.alertify.success('File update sucessfully');
      this.editForm.reset(this.file);
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.router.navigate(['/files/']);
  }

  getClients() {
    this.fileService.getClients().subscribe(response => {
      this.clients = response;
    }, error => {
      this.alertify.error(error);
    });
  }

  getBarcodeNumbers() {
    this.boxService.getBoxes().subscribe((boxes: Box[]) => {
      this.boxes = boxes;
      console.log(this.boxes);
    }, error => {
      this.alertify.error(error);
    });
  }
}
