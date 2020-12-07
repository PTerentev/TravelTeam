import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleTourComponent } from './single-tour.component';

describe('SingleTourComponent', () => {
  let component: SingleTourComponent;
  let fixture: ComponentFixture<SingleTourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleTourComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleTourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
