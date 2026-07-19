import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Toolbar } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { SplitButton } from 'primeng/splitbutton';
import { InputTextModule } from 'primeng/inputtext';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { AvatarModule } from 'primeng/avatar';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  standalone: true,

  imports: [
    Toolbar,
    SplitButton,
    ButtonModule,
    InputTextModule,
    IconField,
    InputIcon,
    AvatarModule,
    CommonModule,
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  menuOpen: boolean = false;
  constructor(private router: Router) {}
  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }
  goToHome() {
    this.router.navigate(['/landingPage']);
    if (this.menuOpen) {
      this.toggleMenu();
    }
  }

  goToViewCustomer() {
    if (this.menuOpen) {
      this.toggleMenu();
    }
    this.router.navigate(['/viewCustomers']);
  }
  goToAddCustomer() {
    if (this.menuOpen) {
      this.toggleMenu();
    }
    this.router.navigate(['/addCustomer']);
  }
}
