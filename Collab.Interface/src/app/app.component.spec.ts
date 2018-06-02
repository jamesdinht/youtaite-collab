import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material';
describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        UsersComponent
      ],
      imports: [
        HttpClientModule,
        MatToolbarModule
      ]
    }).compileComponents();
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
});
