import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsListComponent } from './contacts-list/contacts-list.component';
import { ContactCreationComponent } from './contact-creation/contact-creation.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { StartupComponent as StartupComponent } from './startup-component/startup-component.component';

const routes: Routes = [
  {path: '', redirectTo: '/index', pathMatch: 'full'},
  {path: 'index', component: StartupComponent},
  {path: 'contactCreation', component: ContactCreationComponent},
  {path: 'contactsList', component: ContactsListComponent},
  {path: 'contactDetails', component: ContactDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
