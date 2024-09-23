import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerPortalRoutingModule } from './customer-portal-routing.module';
import { CustomerPortalComponent } from './customer-portal/customer-portal.component';


@NgModule({
  declarations: [
    CustomerPortalComponent
  ],
  imports: [
    CommonModule,
    CustomerPortalRoutingModule
  ]
})
export class CustomerPortalModule { }
