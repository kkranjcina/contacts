import { Component, OnInit, Input} from '@angular/core';
import { ContactsI, ContactsService } from '../contacts-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss']
})
export class ContactDetailsComponent implements OnInit {
  //@Input() contactFromList?: ContactsI;
  id: number = 0;
  public contact!: ContactsI;
  emailRegex = new RegExp('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$');

  constructor(private contactsService: ContactsService, private route: ActivatedRoute, private router: Router,private notifier: NotifierService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
    });
    this.contactsService.getContact(this.id).subscribe(c => this.contact = c);
  }

  updateContact(){
    if(this.contact.name.length <= 50){
      if(this.emailRegex.test(this.contact.email)){
        this.contactsService.updateContact(this.contact);
  
        this.notifier.show({
          type: 'success',
          message: 'Contact updated!'
        });
        
        this.router.navigate(['/contactsList']);
      }
      else{
        this.notifier.notify('warning', 'Invalid email!');
      }
    }
    else{
      this.notifier.notify('warning', 'Name can not have more than 50 characters!');
    }
  }

  deleteContact(){
    this.contactsService.deleteContact(this.contact.id);
    this.notifier.notify('error', 'Contact deleted!');
    this.router.navigate(['/contactsList']);
  }
}
