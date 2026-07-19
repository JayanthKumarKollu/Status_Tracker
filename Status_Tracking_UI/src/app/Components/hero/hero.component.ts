import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css',
})
export class HeroComponent {
  constructor(private route: Router) {}
  ngOnInit() {}
  goToAddCustomer() {
    this.route.navigate(['/addCustomer']);
  }
  gotToViewCustomers() {
    this.route.navigate(['/viewCustomers']);
  }
}
