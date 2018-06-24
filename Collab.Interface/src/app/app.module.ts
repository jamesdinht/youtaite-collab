import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatButtonModule, MatListModule, MatCardModule, MatProgressSpinnerModule } from '@angular/material';

import { UsersComponent } from 'src/app/users/users.component';
import { ProjectsComponent } from 'src/app/projects/projects.component';
import { HomeComponent } from 'src/app/home/home.component';
import { TopNavbarComponent } from 'src/app/top-navbar/top-navbar.component';
import { ProjectDetailsComponent } from 'src/app/project-details/project-details.component';
import { CallbackComponent } from 'src/app/auth/callback/callback.component';

export const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'users',
    component: UsersComponent
  },
  {
    path: 'projects/:id',
    component: ProjectDetailsComponent
  },
  {
    path: 'projects',
    component: ProjectsComponent
  },
  {
    path: 'callback',
    component: CallbackComponent
  }
];

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    ProjectsComponent,
    HomeComponent,
    TopNavbarComponent,
    ProjectDetailsComponent,
    CallbackComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes,
    ),
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatListModule,
    MatCardModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
