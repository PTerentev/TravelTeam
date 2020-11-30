import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessRegisterComponent } from './success-register.component';

describe('SuccessRegisterComponent', () => {
  let component: SuccessRegisterComponent;
  let fixture: ComponentFixture<SuccessRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuccessRegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuccessRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
