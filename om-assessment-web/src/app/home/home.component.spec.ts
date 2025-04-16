import { TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';

import { HttpClientModule} from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { DxPaginationModule } from 'devextreme-angular';
describe('HomeComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        RouterModule,
        DxPaginationModule
      ],
      declarations: [
        HomeComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(HomeComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'SimpleApp'`, () => {
    const fixture = TestBed.createComponent(HomeComponent);
    const homeComponent = fixture.componentInstance;
    expect(homeComponent.pageSize).toEqual(10);
    expect(homeComponent.total).toEqual(0);
    expect(homeComponent.pageIndex).toEqual(1);
  });

  // it('should render title', () => {
  //   const fixture = TestBed.createComponent(HomeComponent);
  //   fixture.detectChanges();
  //   const compiled = fixture.nativeElement as HTMLElement;
  //   expect(compiled.querySelector('.content span')?.textContent).toContain('SimpleApp app is running!');
  // });
});
