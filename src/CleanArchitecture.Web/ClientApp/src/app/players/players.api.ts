import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Player } from './player';

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
}
