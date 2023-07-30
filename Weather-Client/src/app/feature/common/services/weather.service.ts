import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Coordinates } from '../models/coordinates.model';
import { Observable } from 'rxjs';
import { WeatherStatistics } from '../models/weatherStatistics.model';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient) {}

  public getWeatherForCoordinates(
    coordinates: Coordinates
  ): Observable<WeatherStatistics> {
    return this.http.post<WeatherStatistics>(
      `${environment.apiUrl}Weather`,
      coordinates
    );
  }
}
