import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private httpClient : HttpClient) {
  }

  getCountries(pageNo : number, pageSize: number) {
    let url = "http://localhost:5225/api/countries?pageNo=" + pageNo + "&pageSize=" + pageSize;
    console.log(url);
    return this.httpClient.get(url);
  }

  getCountry(name: string){
    let url = "http://localhost:5225/api/countries/" + name;
    return this.httpClient.get(url);
  }
}

export interface Country {
  name: string;
  flag: string;
}
export interface CountryDetails {
  name: string;
  flag: string;
  capital: string;
  population: number;
}

