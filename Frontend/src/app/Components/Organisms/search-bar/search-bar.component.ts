import { Component } from '@angular/core';
import { InputFieldComponent } from '../../Molecules/input-field/input-field.component';
import { ButtonComponent } from '../../Atoms/button/button.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [FormsModule, InputFieldComponent, ButtonComponent],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {
  searchQuery: string = '';

  onSearch() {
    console.log('Searching for:', this.searchQuery);
  }
}
