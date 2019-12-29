import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { File } from 'src/app/_models/file';
import { FileService } from 'src/app/_services/file.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BoxService } from 'src/app/_services/box.service';
import { Box } from 'src/app/_models/box';
import { Client } from 'src/app/_models/client';

@Component({
  selector: 'app-file-new',
  templateUrl: './file-new.component.html',
  styleUrls: ['./file-new.component.css']
})
export class FileNewComponent implements OnInit {
  file: any = {};
  box: Box;
  clients: Client[];
  boxId: number;
  barcodeNumber: number;

  constructor(private fileService: FileService, private alertify: AlertifyService, private router: Router,
    private route: ActivatedRoute, private boxService: BoxService) { }

  ngOnInit() {
    // gets id from path
    this.route.params.subscribe(params => {
      this.boxId = params.id;
    });

    this.loadBox();
    this.getClients();
  }

  addFile() {
    this.fileService.addFile(this.file, this.boxId).subscribe(() => {
      this.alertify.success('Added file successfully');
      this.router.navigate(['/boxes/' + this.boxId]);
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/boxes/' + this.boxId]);
    });
  }

  cancel() {
    this.router.navigate(['/boxes/' + this.boxId]);
  }

  loadBox() {
    this.boxService.getBox(+this.route.snapshot.params['id']).subscribe((box: Box) => {
      this.barcodeNumber = box.barcodeNum;
    }, error => {
      this.alertify.error(error);
    });
  }

  getClients() {
    this.fileService.getClients().subscribe(response => {
      this.clients = response;
    }, error => {
      this.alertify.error(error);
    });
  }
}
