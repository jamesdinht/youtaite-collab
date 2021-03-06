import { TestBed, inject } from '@angular/core/testing';

import { ProjectService } from './project.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Project } from '../models/Project';
import { environment } from '../../environments/environment';

describe('ProjectService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProjectService],
      imports: [
        HttpClientTestingModule
      ]
    });
  });

  let service: ProjectService;
  let httpMock: HttpTestingController;

  beforeEach((inject([ProjectService], s => {
    service = s;
  })));

  beforeEach((inject([HttpTestingController], http => {
    httpMock = http;
  })));

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch all projects', () => {

    const fakeProject = new Project(1, 'Test');
    const fakeProject2 = new Project(2, 'Fake');

    service.getAllProjects().subscribe(response => {
      expect(response).toBeTruthy();
      expect(response.length).toBe(2);
    });

    const request = httpMock.expectOne(environment.projectsUrl);
    expect(request.request.method).toBe('GET');

    request.flush(
      [fakeProject, fakeProject2],
    );
  });

  it('should fetch a single Project correctly', () => {

    const fakeProject = new Project(1, 'Test');

    service.getProjectById(fakeProject.id).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toEqual(fakeProject);
    });

    const request = httpMock.expectOne(`${environment.projectsUrl}/${fakeProject.id}`);
    expect(request.request.method).toBe('GET');

    request.flush(
      fakeProject
    );
  });

  it('should return an error message on 404', () => {
    // TODO: Need to implement some kind of error message
    const fakeProject = new Project(1, 'Test');

    service.getProjectById(fakeProject.id).subscribe(response => {
      expect(response).toBeFalsy();
    });

    const request = httpMock.expectOne(`${environment.projectsUrl}/${fakeProject.id}`);
    expect(request.request.method).toBe('GET');
  });

  it('should create a new Project correctly', () => {
    const fakeProject = new Project(1, 'Test');

    service.createProject(fakeProject).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toEqual(fakeProject);
    });

    const request = httpMock.expectOne(`${environment.projectsUrl}`);
    expect(request.request.method).toBe('POST');
  });

  it('should update a Project correctly', () => {
    // TODO: Look into testing PUT requests correctly
    const fakeProject = new Project(1, 'Test');
    const updatedProject = new Project(1, 'Update');

    service.updateProject(updatedProject).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toEqual(updatedProject);
    });

    const request = httpMock.expectOne(`${environment.projectsUrl}/${fakeProject.id}`);
    expect(request.request.method).toBe('PUT');

    request.flush(
      updatedProject
    );
  });

  it('should delete a Project correctly', () => {
    const fakeProject = new Project(1, 'Test');

    service.deleteProject(fakeProject).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toEqual(fakeProject);
    });

    const request = httpMock.expectOne(`${environment.projectsUrl}/${fakeProject.id}`);
    expect(request.request.method).toBe('DELETE');

    request.flush(
      fakeProject
    );
  });
});
