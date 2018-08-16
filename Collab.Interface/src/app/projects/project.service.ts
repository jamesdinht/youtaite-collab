import { Injectable } from '@angular/core';
import { HttpService } from '../shared/http.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Project } from '../models/Project';
import { catchError } from 'rxjs/operators';
import { LogService } from '../shared/log.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends HttpService {

  constructor(private http: HttpClient, private logService: LogService) {
    super(http, logService, environment.projectsUrl);
  }

  public getAllProjects(): Observable<Project[]> {
    return super.getAll<Project>()
      .pipe(
        catchError(super.handleError<Project[]>('getAllProjects', []))
      );
  }

  public getProjectById(id: number): Observable<Project> {
    return super.getById<Project>(id)
      .pipe(
        catchError(super.handleError<Project>(`getProjectById id=${id}`))
      );
  }

  public createProject(projectToCreate: Project): Observable<Project> {
    return super.create<Project>(projectToCreate)
      .pipe(
        catchError(super.handleError<Project>('createProject', projectToCreate))
      );
  }

  public updateProject(updatedProject: Project): Observable<Project> {
    return super.update<Project>(updatedProject)
      .pipe(
        catchError(super.handleError<Project>('updateProject', updatedProject))
      );
  }

  public deleteProject(projectToDelete: Project): Observable<Project> {
    return super.delete<Project>(projectToDelete)
      .pipe(
        catchError(super.handleError<Project>('deleteProject', projectToDelete))
      );
  }
}
