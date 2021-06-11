import { TestBed } from '@angular/core/testing';

import { PokeService } from './poke.service';

describe('PokeService', () => { 
  let service: PokeService;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
      providers: [PokeService]
    });
    service = TestBed.inject(PokeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
