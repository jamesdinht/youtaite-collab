import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Project } from 'src/app/models/Project';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends HttpService {

  constructor(private http: HttpClient) {
    super(http, environment.projectsUrl);
  }

  getAllProjects(): Observable<Project[]> {
    return this.getAll<Project>()
      .pipe(
        catchError(this.handleError<Project[]>('getAllProjects', []))
      );
  }

  getProjectById(id: number): Observable<Project> {
    return this.getById<Project>(id)
      .pipe(
        catchError(this.handleError<Project>(`getProjectById id=${id}`))
      );
  }

  createProject(projectToCreate: Project): Observable<Project> {
    return this.create<Project>(projectToCreate)
      .pipe(
        catchError(this.handleError<Project>('createProject', projectToCreate))
      );
  }

  updateProject(updatedProject: Project): Observable<Project> {
    return this.update<Project>(updatedProject)
      .pipe(
        catchError(this.handleError<Project>('updateProject', updatedProject))
      );
  }

  deleteProject(projectToDelete: Project): Observable<Project> {
    return this.delete<Project>(projectToDelete)
      .pipe(
        catchError(this.handleError<Project>('deleteProject', projectToDelete))
      );
  }
}
