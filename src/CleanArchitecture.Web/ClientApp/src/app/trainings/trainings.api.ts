import { Injectable, Inject } from '@angular/core';
import { Training } from './training';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TrainingsComponentStore } from './trainings.component.store';

@Injectable({
  providedIn: 'root'
})
export class TrainingsApi {
  constructor(
    private http: HttpClient
    ,@Inject('BASE_URL') private baseUrl: string
    ,private trainingStore: TrainingsComponentStore
  ){
  }

  getTrainings(): Observable<Training[]>{
    return this.http.get<Training[]>(this.baseUrl + 'api/training')
    .pipe(
     catchError(val =>
       throwError(`${val.status}: ${val.message}`)
      )
   );
  }

  addTraining(training: Training): Observable<Training> {
    return this.http.post<Training>(this.baseUrl + 'api/training', training)
    .pipe(
      catchError(val =>
        throwError(`${val.status}: ${val.message}`)
       )
    );
  }

}
