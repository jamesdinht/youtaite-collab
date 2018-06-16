import { async, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';

import { TopNavbarComponent } from './top-navbar.component';
import { MatToolbarModule, MatCardModule } from '@angular/material';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { appRoutes } from 'src/app/app.module';
import { Router } from '@angular/router';
import { HomeComponent } from 'src/app/home/home.component';
import { UsersComponent } from 'src/app/users/users.component';
import { ProjectsComponent } from 'src/app/projects/projects.component';
import { ProjectDetailsComponent } from '../project-details/project-details.component';
import { AuthService } from 'src/app/shared/auth.service';

describe('TopNavbarComponent', () => {
  let component: TopNavbarComponent;
  let fixture: ComponentFixture<TopNavbarComponent>;
  let router: Router;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        HomeComponent,
        UsersComponent,
        ProjectsComponent,
        ProjectDetailsComponent,
        TopNavbarComponent
      ],
      imports: [
        HttpClientTestingModule,
        MatToolbarModule,
        MatCardModule,
        RouterTestingModule.withRoutes(appRoutes),
      ],
      providers: [
        AuthService
      ]
    })
    .compileComponents();

    router = TestBed.get(Router);

    router.initialNavigation();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render material toolbar', async(() => {
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('mat-toolbar'));
  }));
});
