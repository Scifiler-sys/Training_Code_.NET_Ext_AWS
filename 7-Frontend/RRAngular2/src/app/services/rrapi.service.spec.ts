import { TestBed } from '@angular/core/testing';

import { RrapiService } from './rrapi.service';

describe('RrapiService', () => {
  let service: RrapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RrapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
