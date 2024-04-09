import { Component, OnInit } from '@angular/core';
import { Contact } from './models/contact.model';
import { ContactService } from './services/contact.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'ContactManagerClient';
  contacts: Contact[] = [];

  sortOptions = [
    {name: 'Name', value: 'name'},
    {name: 'Phone', value: 'phone'},
    {name: 'Date of birth', value: 'dateOfBirth'},
    {name: 'Married', value: 'married'},
    {name: 'Salary', value: 'salary'},

  ]

  constructor(private contactService: ContactService) { }
  
  ngOnInit(): void {
    this.getContacts();
  }
  
  getContacts(): void {
    this.contactService.getContacts().subscribe({
      next: (data) => {
        this.contacts = data;
      }
    });
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    this.uploadFile(file);
    this.getContacts();
  }

  uploadFile(file: File): void {
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    this.contactService.uploadCsvFile(file).subscribe({
      next: () =>{
        this.getContacts();
      }
    })
  }
  
  onSortSelected(event: any) {

    let field = event.target.value;
    
    switch (field) {
      case 'name':
          this.contacts.sort((a, b) => a.name.localeCompare(b.name));
          break;
      case 'phone':
          this.contacts.sort((a, b) => a.phone.localeCompare(b.phone));
          break;
      case 'dateOfBirth':
          this.contacts.sort((a, b) => new Date(a.dateOfBirth).getTime() - new Date(b.dateOfBirth).getTime());
          break;
      case 'married':
          this.contacts.sort((a, b) => a.married === b.married ? 0 : a.married ? 1 : -1);
          break;
      case 'salary':
          this.contacts.sort((a, b) => a.salary - b.salary);
          break;
      default:
          break;
    }
  }
}
