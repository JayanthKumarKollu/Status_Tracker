import { HttpClient } from '@angular/common/http';
import {
  EnvironmentProviders,
  inject,
  Inject,
  Injectable,
} from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CustomerServiceService {
  private http = inject(HttpClient);
  getCustomerDetailsURL = `${environment.baseUrl}/api/Customer`;
  addCustomerDetailsURL = `${environment.baseUrl}/api/Customer/addCustomer`;
  exportExcelURL = `${environment.baseUrl}/api/Customer/export`;
  constructor() {}

  getCustomerDetails() {
    return this.http.get(this.getCustomerDetailsURL);
  }

  addCustomer(customerData: any) {
    return this.http.post(this.addCustomerDetailsURL, customerData);
  }

  exportExcel() {
    return this.http.get(this.exportExcelURL, { responseType: 'blob' });
  }
}
