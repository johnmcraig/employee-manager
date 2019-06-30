import { TestBed } from '@angular/core/testing';

import { EnvironmentUrlService } from './environment-url.service';

describe('EnvironmentUrlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EnvironmentUrlService = TestBed.get(EnvironmentUrlService);
    expect(service).toBeTruthy();
  });
});
