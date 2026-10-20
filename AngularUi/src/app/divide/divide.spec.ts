import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Divide } from './divide';

describe('Divide', () => {
  let component: Divide;
  let fixture: ComponentFixture<Divide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Divide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Divide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
