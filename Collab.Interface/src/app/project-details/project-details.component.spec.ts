import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectDetailsComponent } from './project-details.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ProjectService } from 'src/app/shared/project.service';
import { ActivatedRoute } from '@angular/router';
import { appRoutes } from 'src/app/app.module';
import { RouterTestingModule } from '@angular/router/testing';

describe('ProjectDetailsComponent', () => {
  let component: ProjectDetailsComponent;
  let fixture: ComponentFixture<ProjectDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectDetailsComponent ],
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        ProjectService,
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              params: []
            }
          }
        }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
