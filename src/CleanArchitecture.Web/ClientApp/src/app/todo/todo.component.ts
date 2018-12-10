import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  public todoItems: TodoItem[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TodoItem[]>(baseUrl + 'api/TodoItems').subscribe(result => {
      this.todoItems = result;
    }, error => console.error(error));
  }
  ngOnInit() {
  }

}

interface TodoItem {
  title: string;
  description: string;
  isDone: boolean;
}
