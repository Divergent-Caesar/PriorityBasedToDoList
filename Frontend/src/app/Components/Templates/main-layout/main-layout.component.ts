import { Component } from '@angular/core';
import { SearchBarComponent } from '../../Organisms/search-bar/search-bar.component';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [SearchBarComponent],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.css'
})
export class MainLayoutComponent {

}
