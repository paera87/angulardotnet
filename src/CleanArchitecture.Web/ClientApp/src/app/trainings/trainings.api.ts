import { Injectable, Inject } from '@angular/core';
import { Training } from './training';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrainingsApi {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
  }

  getTrainings(): Observable<Training[]> {
    return this.http.get<Training[]>(this.baseUrl + 'api/training');
  }

  addTraining(training: Training): Observable<Training> {
    return this.http.post<Training>(this.baseUrl + 'api/training', training);
  }

}
