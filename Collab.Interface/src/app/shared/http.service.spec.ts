import { TestBed, inject } from '@angular/core/testing';

import { HttpService } from './http.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('HttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        HttpService,
        { provide: String, useValue: ''}
      ],
      imports: [
        HttpClientTestingModule
      ]
    });
  });

  let service: HttpService;

  beforeEach(inject([HttpService], s => {
    service = s;
  }));

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
