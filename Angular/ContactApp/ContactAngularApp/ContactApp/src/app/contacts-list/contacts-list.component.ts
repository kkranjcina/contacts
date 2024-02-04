import { Component, OnInit, OnChanges } from '@angular/core';
import { ContactsI, ContactsService } from '../contacts-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.scss'],
  providers: [ContactsService]
})
export class ContactsListComponent implements OnInit, OnChanges  {
  contactsList = new Array<ContactsI>();
  contactToUpdate?: ContactsI;
  searchInput: string = "";
  contactsSearchList = new Array<ContactsI>();

  constructor(private contactsService: ContactsService, private router: Router) { }

  ngOnInit(): void {
    this.contactsService.getAllContacts().subscribe(c => this.contactsList = c);
  }

  ngOnChanges(){
    this.contactsService.getAllContacts().subscribe(c => this.contactsList = c);
  }

  showDetails(id: number | undefined){
    this.router.navigate(['/contactDetails'], {queryParams :{ id : id }});
  }

  searchContact(){
    this.contactsSearchList = this.contactsList.filter(contact =>
      contact.name.toLowerCase().includes(this.searchInput.toLowerCase())
    )
  }

  sortAscending(){
    if(this.contactsSearchList.length == 0){
      this.contactsList.sort((a, b) => a.name.localeCompare(b.name));
    }
    else{
      this.contactsSearchList.sort((a, b) => a.name.localeCompare(b.name));
    }
  }

  sortDescending(){
    if(this.contactsSearchList.length == 0){
      this.contactsList.sort((a, b) => a.name.localeCompare(b.name)).reverse();
    }
    else{
      this.contactsSearchList.sort((a, b) => a.name.localeCompare(b.name)).reverse();
    }
  }
}
