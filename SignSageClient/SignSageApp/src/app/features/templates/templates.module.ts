import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TemplateListComponent } from './template-list/template-list.component';
import { TemplateDetailComponent } from './template-detail/template-detail.component';
import { TemplateFormComponent } from './template-form/template-form.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'templates', component: TemplateListComponent },
  { path: 'templates/:id', component: TemplateDetailComponent },
  { path: 'templates/create', component: TemplateFormComponent },
];

@NgModule({
  declarations: [TemplateListComponent, TemplateDetailComponent, TemplateFormComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class TemplatesModule { }
