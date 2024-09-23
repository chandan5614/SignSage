import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerPortalComponent } from './customer-portal/customer-portal.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: CustomerPortalComponent },
  { path: 'customer-portal', component: CustomerPortalComponent },
];

@NgModule({
  declarations: [CustomerPortalComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class CustomerPortalModule { }
