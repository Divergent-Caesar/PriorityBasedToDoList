import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'http://localhost:5000/';

  constructor(private http: HttpClient) { }

  getTasks() : Observable<string> {
    return this.http.get<string>(this.apiUrl +"task/getAll", {});
  }
  createTask(taskDescription: string, estimateInHours: number, subject: string): Observable<void> {
    // Construct the query parameters
    const params = new HttpParams()
      .set('taskDescription', taskDescription)
      .set('estimateInHours', estimateInHours.toString())
      .set('subject', subject);

    // Make the GET request (or use POST if your API accepts it)
    return this.http.post<void>(this.apiUrl + "api/tasks/create", { params });
  }
}
