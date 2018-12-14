import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TrainingsComponentStore } from './trainings.component.store';
import { action, computed } from 'mobx-angular';
import { Training } from './training';

@Component({
  selector: 'app-trainings',
  templateUrl: './trainings.component.html',
  styleUrls: ['./trainings.component.scss']
})
export class TrainingsComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string
  , private trainingStore:  TrainingsComponentStore) {
  }

  @computed
  public get trainings(): Training[]{
    return this.trainingStore.trainings;
  }

  @action
  getTrainingsList() {
    this.http.get<Training[]>(this.baseUrl + 'api/training').subscribe(result => {
      this.trainingStore.setTrainingList(result);
      console.log(this.trainingStore.trainings);
    }, error => console.error(error));
  }

  ngOnInit() {
    this.getTrainingsList();
  }

}
