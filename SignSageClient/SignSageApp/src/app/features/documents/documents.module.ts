import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentListComponent } from './document-list/document-list.component';
import { DocumentDetailComponent } from './document-detail/document-detail.component';
import { DocumentSignComponent } from './document-sign/document-sign.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'documents', component: DocumentListComponent },
  { path: 'documents/:id', component: DocumentDetailComponent },
  { path: 'documents/sign/:id', component: DocumentSignComponent },
];

@NgModule({
  declarations: [DocumentListComponent, DocumentDetailComponent, DocumentSignComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class DocumentsModule { }
