import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RenewalListComponent } from './renewal-list/renewal-list.component';
import { RenewalDetailComponent } from './renewal-detail/renewal-detail.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'renewals', component: RenewalListComponent },
  { path: 'renewals/:id', component: RenewalDetailComponent },
];

@NgModule({
  declarations: [RenewalListComponent, RenewalDetailComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class RenewalsModule { }
