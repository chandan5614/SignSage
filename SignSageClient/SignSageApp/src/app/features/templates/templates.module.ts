import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemplatesRoutingModule } from './templates-routing.module';
import { TemplateListComponent } from './template-list/template-list.component';
import { TemplateDetailComponent } from './template-detail/template-detail.component';
import { TemplateFormComponent } from './template-form/template-form.component';


@NgModule({
  declarations: [
    TemplateListComponent,
    TemplateDetailComponent,
    TemplateFormComponent
  ],
  imports: [
    CommonModule,
    TemplatesRoutingModule
  ]
})
export class TemplatesModule { }
