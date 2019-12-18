/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FileNewComponent } from './file-new.component';

describe('FileNewComponent', () => {
  let component: FileNewComponent;
  let fixture: ComponentFixture<FileNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
