import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocumentsRoutingModule } from './documents-routing.module';
import { DocumentListComponent } from './document-list/document-list.component';
import { DocumentDetailComponent } from './document-detail/document-detail.component';
import { DocumentSignComponent } from './document-sign/document-sign.component';


@NgModule({
  declarations: [
    DocumentListComponent,
    DocumentDetailComponent,
    DocumentSignComponent
  ],
  imports: [
    CommonModule,
    DocumentsRoutingModule
  ]
})
export class DocumentsModule { }
