import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Player } from './player';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayersApiService{
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {

  }

  public getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.baseUrl + 'api/player')
  }

  public addPlayer(player: Player): Observable<Player>{
    return this.http.post<Player>(this.baseUrl + 'api/player', player)
    .pipe(
      catchError(val =>
        throwError(`${val.status}: ${val.message}`)
       )
    );
  }
}
