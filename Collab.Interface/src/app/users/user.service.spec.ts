import { TestBed, inject } from '@angular/core/testing';

import { UserService } from './user.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../../environments/environment';
import { User } from '../models/user';

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
    expect(request.request.method).toBe('GET');

    request.flush([
      { id: 1, nickname: 'James' },
      { id: 2, nickname: 'Menji' }
    ]);
  });

  it('should fetch a single user correctly', () => {

      const id = 1;
      const nickname = 'James';
      const email = 'james@test.com';
      const fakeUser = new User(nickname, email, id);

      service.getUserById(id).subscribe(response => {
        expect(response).toBeTruthy();
        expect(response).toEqual(fakeUser);
      });

      const request = httpMock.expectOne(`${environment.usersUrl}/${id}`);
      expect(request.request.method).toBe('GET');

      request.flush(
        fakeUser
      );
    });

    it('should return an error message on 404', () => {
      // TODO: Elaborate more. Perhaps, add some kind of error response to service
      const id = 1;
      service.getUserById(id).subscribe(response => {
        expect(response).toBeFalsy();
      });

      const request = httpMock.expectOne(`${environment.usersUrl}/${id}`);
      expect(request.request.method).toBe('GET');
    });

    it('should add new user correctly', () => {

      const id = 1;
      const nickname = 'James';
      const email = 'james@test.com';
      const newUser = new User(nickname, email, id);

      service.createUser(newUser).subscribe(response => {
        expect(response).toBeTruthy();
        expect(response).toEqual(newUser);
      });

      const request = httpMock.expectOne(`${environment.usersUrl}`);
      expect(request.request.method).toBe('POST');
    });

    // TODO: Find out how to correctly implement this test case
    it('should update a user correctly', () => {

      const id = 1;
      const nickname = 'James';
      const newNickname = 'Menji';
      const email = 'james@test.com';
      const newEmail = 'Menji@test.com';
      const fakeUser = new User(nickname, email, id);
      const updatedUser = new User(newNickname, newEmail, id);

      service.updateUser(updatedUser).subscribe(response => {
        expect(response).toBeTruthy();
        expect(response).toEqual(updatedUser);
      });

      const request = httpMock.expectOne(`${environment.usersUrl}/${id}`);
      expect(request.request.method).toBe('PUT');

      request.flush(
        updatedUser
      );
    });

    // TODO: Find out whether this is correct, later
    it('should delete a user correctly', () => {

      const id = 1;
      const nickname = 'James';
      const email = 'james@test.com';
      const fakeUser = new User(nickname, email, id);

      service.deleteUser(fakeUser).subscribe(response => {
        expect(response).toBeTruthy();
        expect(response).toEqual(fakeUser);
      });

      const request = httpMock.expectOne(`${environment.usersUrl}/${id}`);
      expect(request.request.method).toBe('DELETE');

      request.flush(
        fakeUser
      );
    });
});
