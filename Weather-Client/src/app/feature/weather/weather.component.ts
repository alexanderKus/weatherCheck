import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import { WeatherService } from '../common/services/weather.service';
import { Coordinates } from '../common/models/coordinates.model';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { WeatherStatistics } from '../common/models/weatherStatistics.model';
import { Observable, catchError, finalize, of, take } from 'rxjs';
import { CommonModule } from '@angular/common';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { Csv } from '../common/models/csv.model';
import { DownloadService } from '../common/services/download.service';

@Component({
  standalone: true,
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss'],
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule,
    MatTableModule,
    CommonModule,
    NgxSpinnerModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class WeatherComponent {
  public coordinates: Coordinates = {
    latitude: 50.0647,
    longitude: 19.945,
  };
  public weatherStatistics: Observable<WeatherStatistics> | undefined;
  displayedColumns: string[] = ['day', 'avg_temp'];

  constructor(
    private weatherService: WeatherService,
    private downloadService: DownloadService,
    private spinner: NgxSpinnerService
  ) {}

  public getWeather() {
    this.spinner.show();
    this.weatherStatistics = this.weatherService
      .getWeatherForCoordinates(this.coordinates)
      .pipe(
        catchError((err) => {
          alert('Something went wrong');
          return of(err);
        }),
        finalize(() => this.spinner.hide())
      );
  }

  public download() {
    this.weatherStatistics?.pipe(take(1)).subscribe((weatherStatistics) => {
      const csv: Csv = this.weatherService.generateCsv(weatherStatistics);
      const data: Blob = new Blob(csv.getRows, {
        type: 'text/csv;encoding:uft-8',
      });
      this.downloadService.downloadFile(data, 'weather-statistics.csv');
    });
  }
}
