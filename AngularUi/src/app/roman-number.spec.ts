import { TestBed } from '@angular/core/testing';

import { RomanNumber } from './roman-number';

describe('RomanNumber', () => {
  let service: RomanNumber;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RomanNumber);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
