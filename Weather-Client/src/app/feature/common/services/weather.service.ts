import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Coordinates } from '../models/coordinates.model';
import { Observable } from 'rxjs';
import { WeatherStatistics } from '../models/weatherStatistics.model';
import { Csv } from '../models/csv.model';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient, private datePipe: DatePipe) {}

  public getWeatherForCoordinates(
    coordinates: Coordinates
  ): Observable<WeatherStatistics> {
    return this.http.post<WeatherStatistics>(
      `${environment.apiUrl}Weather`,
      coordinates
    );
  }

  public generateCsv(weatherStatistics: WeatherStatistics): Csv {
    const csv = new Csv();
    weatherStatistics.dailyAvgTemperature.forEach((x) => {
      const date = this.datePipe.transform(x.day, 'yyy-MM-dd');
      csv.addRow(`${date},${x.avgTemperature}`);
    });
    return csv;
  }
}
