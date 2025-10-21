import { Component } from '@angular/core';
import {SidebarComponent} from "./sidebar/sidebar.component";
import {TopbarComponent} from "./topbar/topbar.component";
import {RouterOutlet} from "@angular/router";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, TopbarComponent, SidebarComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
