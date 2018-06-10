import { TestBed, async, fakeAsync, tick } from '@angular/core/testing';
import { MatToolbarModule } from '@angular/material';
import { AppComponent } from 'src/app/app.component';
import { UsersComponent } from 'src/app/users/users.component';
import { ProjectsComponent } from 'src/app/projects/projects.component';
import { HomeComponent } from 'src/app/home/home.component';
import { TopNavbarComponent } from 'src/app/top-navbar/top-navbar.component';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { RouterTestingModule } from '@angular/router/testing';
import { appRoutes } from 'src/app/app.module';

describe('AppComponent', () => {

  let router: Router;
  let location: Location;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        HomeComponent,
        UsersComponent,
        ProjectsComponent,
        TopNavbarComponent
      ],
      imports: [
        MatToolbarModule,
        RouterTestingModule.withRoutes(appRoutes),
      ]
    }).compileComponents();

    router = TestBed.get(Router);
    location = TestBed.get(Location);

    router.initialNavigation();
  }));

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));

  it(`should have as title 'Youtaite Collab'`, async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toBe('Youtaite Collab');
  }));

  it('should navigate to users on "/users"', fakeAsync(() => {
    router.navigate(['users']);
    tick();
    expect(location.path()).toBe('/users');
  }));
});
