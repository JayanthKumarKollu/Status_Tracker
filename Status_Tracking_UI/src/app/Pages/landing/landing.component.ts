import { Component } from '@angular/core';
import { NavbarComponent } from '../../Components/navbar/navbar.component';
import { HeroComponent } from '../../Components/hero/hero.component';
@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [NavbarComponent, HeroComponent],
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.css',
})
export class LandingComponent {}
