import { Component } from '@angular/core';
import { ButtonComponent } from '../../Components/Atoms/button/button.component';
import { InputFieldComponent } from '../../Components/Molecules/input-field/input-field.component';
import { SearchBarComponent } from '../../Components/Organisms/search-bar/search-bar.component';
import { MainLayoutComponent } from '../../Components/Templates/main-layout/main-layout.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MainLayoutComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
