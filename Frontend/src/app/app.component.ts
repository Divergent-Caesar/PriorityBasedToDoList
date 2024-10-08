import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TaskService } from './Services/task.service';
import { HttpClient, provideHttpClient, withFetch } from '@angular/common/http';
import { ButtonComponent } from './Components/Atoms/button/button.component';
import { InputFieldComponent } from './Components/Molecules/input-field/input-field.component';
import { SearchBarComponent } from './Components/Organisms/search-bar/search-bar.component';
import { MainLayoutComponent } from './Components/Templates/main-layout/main-layout.component';
import { HomeComponent } from './Pages/home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
    ButtonComponent, 
    InputFieldComponent, 
    SearchBarComponent, 
    MainLayoutComponent,
    HomeComponent,
  ],
  providers: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  message: string = 'Hello, World!';
  content: string = '';
  constructor(private taskService: TaskService) {}
  changeMessage(): void {
    this.message = 'Button Clicked!';
  }

  // Method to get tasks from the database
  getDBContent(): void {
    var result = this.taskService.getTasks().subscribe({
      next: (tasks : string) => {
        console.log(tasks);
        this.message = 'Tasks retrieved successfully!';
      },
      error: (error) => {
        console.error('Error retrieving tasks:', error);
        this.message = 'Failed to retrieve tasks.';
      },
    });
  }

  // Method to create a new task
  createTask(): void {
    this.taskService.createTask('New Task', 5, 'Math').subscribe({
      next: (task) => {
        console.log('Task created successfully:', task);
        this.message = 'Task created successfully!';
      },
      error: (error) => {
        console.error('Error creating task:', error);
        this.message = 'Failed to create task.';
      },
    });
  }
  /*
  getDBContent(): void {
    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        console.log(tasks);
        this.message = "Tasks retrieved successfully!"
      },
      error: (error) => {
        console.error('Error retrieving tasks:', error);
        this.message = 'Failed to retrieve tasks.';
      }
    })
  }
    */
}
