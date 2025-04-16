import {Component} from '@angular/core';
import {CountryService, Country} from '../services/country.service'
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  countries: Country[] = [];
  total = 0;
  pageIndex = 1;
  pageSize = 10;
  readonly allowedPageSizes = [10, 20, 30];

  constructor(private countriesService: CountryService, private router: Router) {
  }

  ngOnInit(): void {
    this.fetchCountries();
  }

  onPageIndexChange(val: number): void {
    this.pageIndex = val;
    void this.fetchCountries();
  }

  onPageSizeChange(val: number): void {
    this.pageSize = val;
    void this.fetchCountries();
  }

  onFlagClick(countryName: string): void {
    localStorage.setItem('country', countryName);
    this.router.navigate(['/countryDetails']);
  }

  fetchCountries(): void {
    this.countriesService.getCountries(this.pageIndex, this.pageSize).subscribe({
      next: data => {
        let response = data as Response
        this.total = response.totalItems;
        this.countries = response.data as Country[];
        console.log(response.data);
      },
      error: err => {
        alert("An error occurred while getting countries.");
        console.log(err);
      }
    });
  }
}

interface Response {
  message: string;
  data: object;
  successful: boolean;
  totalItems: number;
}
