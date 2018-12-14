import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';

export class PlayersApiService{
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {

  }
}
