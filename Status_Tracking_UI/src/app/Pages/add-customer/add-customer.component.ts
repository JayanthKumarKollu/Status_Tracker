import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { CustomerServiceService } from '../../service/customer-service.service';

@Component({
  selector: 'app-add-customer',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule, ButtonModule, CardModule],
  templateUrl: './add-customer.component.html',
  styleUrl: './add-customer.component.css',
})
export class AddCustomerComponent {
  userInput: string = '';
  customer: any = {};
  keys = [
    'Date',
    'Month',
    'Customer_Name',
    'Mobile_Number',
    'RM_Name',
    'TM_Name',
    'Status',
    'Value',
    'Remarks',
    'Remarks1',
    'Remarks2',
  ];
  constructor(private service: CustomerServiceService) {}

  ngOnInit() {}

  onSubmit() {
    if (this.userInput.trim()) {
      let val = this.userInput.split(',');
      for (let i = 0; i < this.keys.length; i++) {
        this.customer[this.keys[i]] = val[i].trim();
      }
      console.log(this.customer);
      this.service.addCustomer(this.customer).subscribe((res) => {
        console.log('data', res);
        this.userInput = '';
      });
      // Add your API submission logic here
    } else {
      alert('Please enter some text before submitting.');
    }
  }

  onClear() {
    this.userInput = '';
    console.log('Input cleared.');
  }

  onExport() {
    this.service.exportExcel().subscribe((res: Blob) => {
      const blob = new Blob([res], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });

      const url = window.URL.createObjectURL(blob);

      const a = document.createElement('a');
      a.href = url;
      a.download = 'CustomerDetails.xlsx';
      a.click();

      window.URL.revokeObjectURL(url);
      console.log('exported sucessfully', res);
    });
  }
}
