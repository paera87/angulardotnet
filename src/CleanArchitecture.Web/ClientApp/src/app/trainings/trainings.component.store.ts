import { observable, action, computed } from 'mobx-angular';
import { Injectable } from '@angular/core';
import { Training } from './training';

@Injectable({
  providedIn: 'root'
})
export class TrainingsComponentStore {

  @observable trainingList: Training[];
  @observable public sortOrderAsc: boolean = true;
  @observable public sortProperty: string = '';
  @computed
  public get trainings(): Training[] {
    return this.trainingList;
  }

  @action
  setTrainingList(trainingList: Training[]): void {
    this.trainingList = trainingList;
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
      this.trainingList = this.trainingList.slice().sort((a: any, b: any) => {
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

      this.trainingList = this.trainingList.slice().sort((a: any, b: any) => {
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
