import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementComponent } from './user-management/user-management.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'admin/user-management', component: UserManagementComponent },
];

@NgModule({
  declarations: [UserManagementComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class AdminModule { }
