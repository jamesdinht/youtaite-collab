import { async, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';

import { TopNavbarComponent } from './top-navbar.component';
import { MatToolbarModule, MatCardModule, MatProgressSpinnerModule } from '@angular/material';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { appRoutes } from '../app.module';
import { Router } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { UsersComponent } from '../users/users.component';
import { ProjectsComponent } from '../projects/projects.component';
import { ProjectDetailsComponent } from '../project-details/project-details.component';
import { AuthService } from '../auth/auth/auth.service';
import { CallbackComponent } from '../auth/callback/callback.component';
import { ProfileComponent } from '../profile/profile.component';

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
        TopNavbarComponent,
        CallbackComponent,
        ProfileComponent
      ],
      imports: [
        HttpClientTestingModule,
        MatToolbarModule,
        MatCardModule,
        MatProgressSpinnerModule,
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
