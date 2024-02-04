import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactCreationComponent } from './contact-creation.component';

describe('ContactCreationComponent', () => {
  let component: ContactCreationComponent;
  let fixture: ComponentFixture<ContactCreationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContactCreationComponent]
    });
    fixture = TestBed.createComponent(ContactCreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
