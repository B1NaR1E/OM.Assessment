import { Component } from '@angular/core';
import {CountryDetails, CountryService} from '../services/country.service'

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrl: './country-details.component.scss'
})
export class CountryDetailsComponent {
  countryName : string = "";
  countryDetails : CountryDetails = { name: "", capital:"", population:0, flag:"" };
  constructor(private countryService: CountryService) {
  }

  ngOnInit(): void {
    this.countryName = localStorage.getItem("country") as string;

    console.log(localStorage.getItem("country"));
    this.getCountryDetails(this.countryName)
  }

  getCountryDetails(countryName: string): void {
    this.countryService.getCountry(countryName).subscribe({
      next: data => {
        let response = data as Response
        this.countryDetails = response.data as CountryDetails;
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
}

