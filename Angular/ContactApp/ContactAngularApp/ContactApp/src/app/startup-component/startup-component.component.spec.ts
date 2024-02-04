import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StartupComponent } from './startup-component.component';

describe('StartupComponentComponent', () => {
  let component: StartupComponent;
  let fixture: ComponentFixture<StartupComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StartupComponent]
    });
    fixture = TestBed.createComponent(StartupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
