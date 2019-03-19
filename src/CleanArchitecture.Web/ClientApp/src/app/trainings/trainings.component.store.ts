import { observable, action, computed } from 'mobx-angular';
import {createViewModel} from 'mobx-utils'
import { Injectable } from '@angular/core';
import { Training } from './training';

@Injectable({
  providedIn: 'root'
})
export class TrainingsComponentStore {

  @observable private trainingList: Training[];
  @observable public sortOrderAsc: boolean = true;
  @observable public sortProperty: string = '';
  @computed public get trainings(): Training[] { return this.trainingList; }

  @action
  setTrainingList(trainingList: Training[]): void {
    this.trainingList = trainingList;
    this.trainingList = this.trainingList.map(x => createViewModel(x))
    this.sortTrainings();
  }

  @action
  addTraining(training: Training): void {
    training = observable(training);
    this.trainingList.push(createViewModel(training));
    this.sortTrainings();
  }

  @action
  public setSortOrder(sortProperty: string) {
    if (sortProperty === this.sortProperty) {
      this.sortOrderAsc = !this.sortOrderAsc;
    } else {
      this.sortProperty = sortProperty;
      this.sortOrderAsc = true;
    }
    this.sortTrainings();
  }


  private sortTrainings() {
    this.trainingList = this.trainingList.slice().sort((a,b) => {
      //return b.date.before(a.date);
      return new Date(b.date).getTime() - new Date(a.date).getTime();
    });
  }
}
