import { Component } from '@angular/core';
import { ContactsI, ContactsService } from '../contacts-service.service';
import { NotifierNotificationComponent, NotifierService } from 'angular-notifier';
import { NotifierNotificationOptions } from 'angular-notifier/lib/models/notifier-notification.model';

@Component({
  selector: 'app-contact-creation',
  templateUrl: './contact-creation.component.html',
  styleUrls: ['./contact-creation.component.scss']
})
export class ContactCreationComponent {
  name: string = "";
  telephoneNumber: number | undefined;
  email: string = "";
  emailRegex = new RegExp('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$');
  
  constructor(private contactsService: ContactsService, private notifier: NotifierService){ }
  
  createContact(){
    if(this.name.length <= 50){
      if(this.emailRegex.test(this.email)){
        let contact: ContactsI = {
          name: this.name,
          telephoneNumber: this.telephoneNumber,
          email: this.email
        }
        
        this.contactsService.createContact(contact);
    
        this.name = '';
        this.telephoneNumber = undefined;
        this.email = '';
  
        this.notifier.show({
          type: 'success',
          message: 'Contact created!'
        });
      }
      else{
        this.notifier.notify('warning', 'Invalid email!');
      }
    }
    else{
      this.notifier.notify('warning', 'Name can not have more than 50 characters!');
    }
  }
}
