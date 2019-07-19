/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BoxNewComponent } from './box-new.component';

describe('BoxNewComponent', () => {
  let component: BoxNewComponent;
  let fixture: ComponentFixture<BoxNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
