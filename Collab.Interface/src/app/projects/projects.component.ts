import { Component, OnInit } from '@angular/core';
import { ProjectService } from './project.service';
import { Project } from '../models/Project';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
  providers: [ProjectService]
})
export class ProjectsComponent implements OnInit {

  private projects: Project[];

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.getAllProjects();
  }

  getAllProjects() {
    return this.projectService.getAllProjects().subscribe(
      data => {
        this.projects = data;
      }
    );
  }

}
