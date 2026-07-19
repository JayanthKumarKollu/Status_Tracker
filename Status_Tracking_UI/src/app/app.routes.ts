import { Routes } from '@angular/router';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { LandingComponent } from './Pages/landing/landing.component';
import { HeroComponent } from './Components/hero/hero.component';
import { AddCustomerComponent } from './Pages/add-customer/add-customer.component';
import { ViewcustomerComponent } from './Pages/viewcustomer/viewcustomer.component';

export const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'addCustomer', component: AddCustomerComponent },
  { path: 'landingPage', component: LandingComponent },
  { path: 'viewCustomers', component: ViewcustomerComponent },
];
