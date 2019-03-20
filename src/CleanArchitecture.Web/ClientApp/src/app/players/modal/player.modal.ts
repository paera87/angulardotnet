import { PlayersComponentStore } from './../players.component.store';
import { Component } from '@angular/core';
import { action } from 'mobx-angular';
import { PlayersApiService } from './../players.api';
import { Player } from '../player';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'player-modal',
  templateUrl: './player.modal.html',
  styleUrls: ['./player.modal.scss']
})

export class PlayerModal{
  player: Player;
  constructor(
    public activeModal: NgbActiveModal,
    private api: PlayersApiService,
    private playerStore: PlayersComponentStore
    ) {
      this.player = new Player();
     }
  onSubmit()
  {
    this.addPlayer()
  }

  @action
  addPlayer()
  {
    this.api.addPlayer(this.player).subscribe(player => {
        this.playerStore.addPlayer(player);
        this.activeModal.close();
    }, error => console.log(error));
  }
}
