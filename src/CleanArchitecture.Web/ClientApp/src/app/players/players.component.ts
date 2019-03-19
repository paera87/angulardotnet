import { Component, OnInit, ChangeDetectionStrategy, Inject  } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
import { PlayersComponentStore } from './players.component.store';
import { action, computed } from 'mobx-angular';
import { Player } from './player';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
    , private playerStore:  PlayersComponentStore) {
  }

  @action
  getPlayerList() {
    this.http.get<Player[]>(this.baseUrl + 'api/player').subscribe(result => {
      this.playerStore.setPlayerList(result);

    }, error => console.error(error));
  }

  @computed
  public get playerList(): Player[]{
    return this.playerStore.players;
  }

  @action
  sort(columnName){
    this.playerStore.setSortOrder(columnName);
  }
  ngOnInit() {
    this.getPlayerList();
  }

}


