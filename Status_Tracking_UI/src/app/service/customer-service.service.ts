import { HttpClient } from '@angular/common/http';
import {
  EnvironmentProviders,
  inject,
  Inject,
  Injectable,
} from '@angular/core';
import { environment } from '../../environments/environment.development';
import { PageResponse } from '../Models/PageResponse';
import { Customer } from '../Models/Customer';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomerServiceService {
  private http = inject(HttpClient);
  getCustomerDetailsURL = `${environment.baseUrl}/api/Customer/page`;
  addCustomerDetailsURL = `${environment.baseUrl}/api/Customer/addCustomer`;
  exportExcelURL = `${environment.baseUrl}/api/Customer/export`;
  updateCustomerURL = `${environment.baseUrl}/api/Customer/update`;
  delteCustomerURL = `${environment.baseUrl}/api/Customer`;

  constructor() {}

  getCustomerDetails(pageNumber: Number, pageSize: Number, search: String) {
    return this.http.get<PageResponse<Customer>>(
      `${this.getCustomerDetailsURL}/?pageNumber=${pageNumber}&pageSize=${pageSize}&search=${search}`,
    );
  }

  addCustomer(customerData: any) {
    return this.http.post(this.addCustomerDetailsURL, customerData);
  }

  exportExcel() {
    return this.http.get(this.exportExcelURL, { responseType: 'blob' });
  }
  updateCustomer(data: any) {
    return this.http.post(this.updateCustomerURL, data);
  }
  deleteCustomer(data: string) {
    return this.http.delete(`${this.delteCustomerURL}/${data}`);
  }
}
