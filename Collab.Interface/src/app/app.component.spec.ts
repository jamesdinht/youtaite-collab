import { TestBed, async, tick, fakeAsync } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material';
import { RouterTestingModule } from '@angular/router/testing';
import { Router } from '@angular/router';
import { appRoutes } from 'src/app/app.module';
import { Location } from '@angular/common';
import { ProjectsComponent } from 'src/app/projects/projects.component';
import { HomeComponent } from 'src/app/home/home.component';

describe('AppComponent', () => {

  let location: Location;
  let router: Router;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        HomeComponent,
        UsersComponent,
        ProjectsComponent
      ],
      imports: [
        HttpClientModule,
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
    expect(app.title).toEqual('Youtaite Collab');
  }));

  it('should render material toolbar', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('mat-toolbar'));
  }));

  it('should navigate to users on "/users"', fakeAsync(() => {
    router.navigate(['users']);
    tick();
    expect(location.path()).toBe('/users');
  }));
});
