import { TestBed, inject } from '@angular/core/testing';

import { UserService } from './user.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from 'src/environments/environment';

describe('UserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        UserService,
      ],
      imports: [
        HttpClientTestingModule,
      ]
    });
  });

  let service: UserService;
  let httpMock: HttpTestingController;

  beforeEach(inject([UserService], s => {
    service = s;
  }));

  beforeEach(inject([HttpTestingController], http => {
    httpMock = http;
  }));

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch data from the correct URL', () => {

    service.getAllUsers().subscribe(response => {
      expect(response).toBeTruthy();
      expect(response.length).toBe(2);
    });
    const request = httpMock.expectOne(environment.usersUrl);
    expect(request.request.method).toEqual('GET');

    request.flush([
      { id: 1, nickname: 'James' },
      { id: 2, nickname: 'Menji' }
    ]);
  });

  it('should fetch a single user correctly', () => {

      const id = 1;
      service.getUserById(id).subscribe(response => {
        expect(response).toBeTruthy();
        expect(response.id).toBe(id);
        expect(response.nickname).toBe('James');
      });

      const request = httpMock.expectOne(`${environment.usersUrl}/${id}`);
      expect(request.request.method).toEqual('GET');

      request.flush(
        { id: 1, nickname: 'James' }
      );
    });

});
