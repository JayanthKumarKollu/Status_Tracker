import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerServiceService } from './service/customer-service.service';
import { Customer } from './Models/Customer';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
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

  ngOnInit() {
    this.service.getCustomerDetails().subscribe((res) => console.log(res));
  }

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
