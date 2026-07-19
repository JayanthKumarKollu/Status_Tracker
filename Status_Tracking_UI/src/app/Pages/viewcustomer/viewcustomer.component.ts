import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { CommonModule } from '@angular/common';
import { TagModule } from 'primeng/tag';
import { SelectModule } from 'primeng/select';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService, SelectItem } from 'primeng/api';
import { CustomerServiceService } from '../../service/customer-service.service';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import {
  debounce,
  debounceTime,
  distinctUntilChanged,
  Subject,
  switchMap,
} from 'rxjs';
@Component({
  selector: 'app-viewcustomer',
  standalone: true,
  imports: [
    TableModule,
    ToastModule,
    CommonModule,
    TagModule,
    SelectModule,
    ButtonModule,
    InputTextModule,
    FormsModule,
    DropdownModule,
    InputIconModule,
    IconFieldModule,
  ],
  templateUrl: './viewcustomer.component.html',
  styleUrl: './viewcustomer.component.css',
})
export class ViewcustomerComponent {
  columns = [
    { field: 'date', header: 'Date' },
    { field: 'month', header: 'Month' },
    { field: 'customer_Name', header: 'Customer Name' },
    { field: 'mobile_Number', header: 'Mobile Number' },
    { field: 'rM_Name', header: 'RM_Name' },
    { field: 'tM_Name', header: 'TM_Name' },
    { field: 'status', header: 'Status' },
    { field: 'value', header: 'Value' },
    { field: 'remarks', header: 'Remark' },
    { field: 'remarks1', header: 'Remark1' },
    { field: 'remarks2', header: 'Remark2' },
  ];

  customerDetails: any = [];
  pageNumber = 1;
  pageSize = 10;
  totalRecords = 0;
  searchText = '';
  searchSubject = new Subject<string>();
  constructor(private service: CustomerServiceService) {}
  ngOnInit() {
    // this.getCustomerDetails(this.pageNumber, this.pageSize);
    this.searchSubject
      .pipe(
        debounceTime(500),
        distinctUntilChanged(),
        switchMap((search) => {
          this.searchText = search;
          return this.service.getCustomerDetails(1, this.pageSize, search);
        }),
      )
      .subscribe((res) => this.settingData(res));
  }

  getCustomerDetails(
    pageNumber: Number,
    pageSize: Number,
    search: string = '',
  ) {
    this.service
      .getCustomerDetails(pageNumber, pageSize, search)
      .subscribe((res: any) => {
        this.settingData(res);
        console.log(res);
      });
  }

  settingData(resp: any) {
    this.customerDetails = resp.data;
    this.totalRecords = resp.totalRecords;
    this.pageNumber = resp.pageNumber;
    this.pageSize = resp.pageSize;
  }
  updateCustomer(customer: any) {
    console.log(customer);
    this.service.updateCustomer(customer).subscribe((res) => {
      console.log(res);
      // res.success --> use this in if condition for later to add snack box to show success or failure cases.
      this.getCustomerDetails(this.pageNumber, this.pageSize);
    });
  }
  cancleUpdate() {
    this.getCustomerDetails(this.pageNumber, this.pageSize);
  }
  deleteCustomer(customer: string) {
    console.log(customer);
    this.service.deleteCustomer(customer).subscribe((res) => {
      console.log(res);
      this.getCustomerDetails(this.pageNumber, this.pageSize);
    });
  }
  // the below function is responsible to call the table data at the time of page loading because we have used lazyload in table so no need to call again in ngOnInit
  loadCustomers(event: any) {
    this.pageNumber = event.first / event.rows + 1;
    this.pageSize = event.rows;
    this.getCustomerDetails(this.pageNumber, this.pageSize);
  }
  onSearch(value: string) {
    // this.service.setSearch(value);
    this.searchSubject.next(value);
  }
}
