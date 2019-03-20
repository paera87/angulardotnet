import { Component, Input } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { Training } from '../training';
import { TrainingsApi } from '../trainings.api';
import { TrainingsComponentStore } from '../trainings.component.store';
import { action } from 'mobx-angular';

@Component({
  selector: 'training-modal',
  templateUrl: './training.modal.html',
  styleUrls: ['./training.modal.scss']
})
export class TrainingModal {
  date: NgbDate
  training: Training
  constructor(public activeModal: NgbActiveModal
    , private trainingStore:  TrainingsComponentStore
    , private trainingsApi: TrainingsApi) {
    this.training = new Training;
    let today = new Date();
    this.date = new NgbDate(today.getFullYear(), today.getMonth()+1, today.getDate())
  }
  get diagnostic() { return JSON.stringify(this.training); }

  @action
  addTraining()
  {
    this.trainingsApi.addTraining(this.training).subscribe(training => {
        this.trainingStore.addTraining(training);
        this.activeModal.close();
    }, error => console.log(error));
  }

  onSubmit()
  {
    let x= this.date.year +'-'+ this.date.month + '-' + this.date.day;
    this.training.date = x;
    this.addTraining()
  }

}
