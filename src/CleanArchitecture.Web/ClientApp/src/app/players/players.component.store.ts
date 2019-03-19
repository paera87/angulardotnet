import { observable, action, computed } from 'mobx-angular';
import { Injectable } from '@angular/core';
import { Player } from './player';
import { createViewModel } from 'mobx-utils';

@Injectable({
  providedIn: 'root'
})
export class PlayersComponentStore {

  @observable private playerList: Player[];
  @observable public sortOrderAsc: boolean = true;
  @observable public sortProperty: string = '';
  @computed  public get players(): Player[] { return this.playerList; }

  @action
  setPlayerList(playerList: Player[]): void {
    this.playerList = playerList;
    this.playerList = this.playerList.map(x => createViewModel(x))
  }

  @action
  public setSortOrder(sortProperty: string) {
    if (sortProperty === this.sortProperty) {
      this.sortOrderAsc = !this.sortOrderAsc;
    } else {
      this.sortProperty = sortProperty;
      this.sortOrderAsc = true;
    }
    this.sortPlayers();
  }

  private sortPlayers() {
    switch (this.sortProperty) {
      case 'firstName':
      case 'lastName':
        this.sortAlpha(this.sortProperty, this.sortOrderAsc);
        break;
      case 'totalPoints':
      case 'StatusCode':
      case 'WageFormId':
        this.sortNumeric(this.sortProperty, this.sortOrderAsc);
        break;
    }
  }

  @action
  private sortAlpha(sortProperty: string, sortOrderAsc: boolean) {
      this.playerList = this.playerList.slice().sort((a: any, b: any) => {
        const first = a[sortProperty];
        const second = b[sortProperty];
        if (sortOrderAsc) {
          if (first > second) {
            return 1;
          }
          if (first < second) {
            return -1;
          }
        } else {
          if (first < second) {
            return 1;
          }
          if (first > second) {
            return -1;
          }
        }
      });

      return 0;
    };
    @action

    private sortNumeric(sortProperty: string, sortOrderAsc: boolean) {

      this.playerList = this.playerList.slice().sort((a: any, b: any) => {
        const first = a[sortProperty];
        const second = b[sortProperty];
        let diff: number;

        if (first === null) {
          diff = 1;
        } else if (second === null) {
          diff = -1;
        } else {
          diff = first - second;
        }

        if (sortOrderAsc) {
          return diff;
        } else {
          return diff * -1;
        }
      });
    };
}
