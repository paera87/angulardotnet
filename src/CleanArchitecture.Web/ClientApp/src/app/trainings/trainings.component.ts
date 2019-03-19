import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TrainingsComponentStore } from './trainings.component.store';
import { action, computed } from 'mobx-angular';
import { Training } from './training';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TrainingModal } from './modal/training.modal';
import { TrainingsApi } from './trainings.api';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.scss']
})
export class TrainingsComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string
  , private trainingStore:  TrainingsComponentStore
  , private modalService: NgbModal
  , private api: TrainingsApi) {
  }

  @computed
  public get trainings(): Training[]{
    return this.trainingStore.trainings;
  }

  @action
  getTrainingsList() {
    this.api.getTrainings().subscribe(result => {
      this.trainingStore.setTrainingList(result);
    }, error => console.error(error));
  }

  ngOnInit() {
    this.getTrainingsList();
  }
  open() {
    const modalRef = this.modalService.open(TrainingModal)
  }

}
