import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  OnDestroy
} from '@angular/core';
import { PlayersComponentStore } from './players.component.store';
import { action, computed } from 'mobx-angular';
import { Player } from './player';
import { untilDestroyed } from 'ngx-take-until-destroy';
import { PlayersApiService } from './players.api';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit, OnDestroy {
  constructor(
    private api: PlayersApiService,
    private playerStore: PlayersComponentStore
  ) {}

  @action
  getPlayerList() {
    this.api.getPlayers()
      .pipe(untilDestroyed(this))
      .subscribe(
        result => {
          this.playerStore.setPlayerList(result);
        },
        error => console.error(error)
      );
  }

  @computed
  public get playerList(): Player[] {
    return this.playerStore.players;
  }

  @action
  sort(columnName: string) {
    this.playerStore.setSortOrder(columnName);
  }

  ngOnInit() {
    this.getPlayerList();
  }

  ngOnDestroy(): void {}
}
