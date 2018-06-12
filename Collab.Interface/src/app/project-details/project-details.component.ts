import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../shared/project.service';
import { ActivatedRoute } from '@angular/router';
import { Project } from 'src/app/models/Project';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
  providers: [ProjectService]
})
export class ProjectDetailsComponent implements OnInit {

  project: Project;

  constructor(private projectService: ProjectService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.project = new Project(null, null);
    const id = +this.route.snapshot.params['id'];

    this.projectService.getProjectById(id)
      .subscribe(
        data => { this.project = data; }
      );
  }

}
