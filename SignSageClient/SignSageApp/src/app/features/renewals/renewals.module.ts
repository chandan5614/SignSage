import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RenewalsRoutingModule } from './renewals-routing.module';
import { RenewalListComponent } from './renewal-list/renewal-list.component';
import { RenewalDetailComponent } from './renewal-detail/renewal-detail.component';


@NgModule({
  declarations: [
    RenewalListComponent,
    RenewalDetailComponent
  ],
  imports: [
    CommonModule,
    RenewalsRoutingModule
  ]
})
export class RenewalsModule { }
