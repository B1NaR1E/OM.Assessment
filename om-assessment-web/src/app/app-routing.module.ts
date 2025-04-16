import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CountryDetailsComponent } from "./country-details/country-details.component";

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./home/home.module')
        .then(m => m.HomeModule)
  },
  {
    path: 'countryDetails',
    component: CountryDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}

