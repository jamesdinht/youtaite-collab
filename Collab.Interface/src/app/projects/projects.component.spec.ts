import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectsComponent } from './projects.component';
import { ProjectService } from '../shared/project.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MatCardModule, MatButtonModule } from '@angular/material';
import { ProjectDetailsComponent } from '../project-details/project-details.component';
import { RouterTestingModule } from '@angular/router/testing';
import { appRoutes } from 'src/app/app.module';
import { HomeComponent } from 'src/app/home/home.component';
import { UsersComponent } from 'src/app/users/users.component';

describe('ProjectsComponent', () => {
  let component: ProjectsComponent;
  let fixture: ComponentFixture<ProjectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        ProjectsComponent,
        ProjectDetailsComponent
      ],
      imports: [
        HttpClientTestingModule,
        MatCardModule,
        MatButtonModule,
        RouterTestingModule.withRoutes([]),
      ],
      providers: [
        ProjectService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
