import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { untilDestroyed } from 'ngx-take-until-destroy';
import { TrainingsComponentStore } from './trainings.component.store';
import { action, computed } from 'mobx-angular';
import { Training } from './training';
import { TrainingModal } from './modal/training.modal';
import { TrainingsApi } from './trainings.api';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.scss']
})
export class TrainingsComponent implements OnInit, OnDestroy {
  constructor(
    private trainingStore: TrainingsComponentStore,
    private modalService: NgbModal,
    private api: TrainingsApi
  ) {}

  @computed
  public get trainings(): Training[] {
    return this.trainingStore.trainings;
  }

  @action
  getTrainingsList() {
    this.api.getTrainings()
      .pipe(untilDestroyed(this))
      .subscribe(
        result => {
          this.trainingStore.setTrainingList(result);
        },
        error => console.error(error)
      );
  }

  ngOnInit() {
    this.getTrainingsList();
  }

  ngOnDestroy(): void {
    //Called once, before the instance is destroyed.
    //Add 'implements OnDestroy' to the class.
  }
  open() {
    const modalRef = this.modalService.open(TrainingModal);
  }
}
