import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component'
import { CountryDetailsComponent } from './country-details/country-details.component'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { DxPaginationModule } from 'devextreme-angular';
describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterModule,
        HttpClientModule,
        AppRoutingModule,
        DxPaginationModule
      ],
      declarations: [
        AppComponent,
        HomeComponent,
        CountryDetailsComponent
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have the 'om-assessment-web' title`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('om-assessment-web');
  });
});
