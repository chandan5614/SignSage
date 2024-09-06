import { Routes } from '@angular/router';

// Import feature components here
import { TemplatesListComponent } from './features/templates/templates-list/templates-list.component';
import { TemplateEditorComponent } from './features/templates/template-editor/template-editor.component';
import { TemplateDetailsComponent } from './features/templates/template-details/template-details.component';
import { TemplatePreviewComponent } from './features/templates/template-preview/template-preview.component';

import { DocumentGenerationComponent } from './features/document-creation/document-generation/document-generation.component';
import { DocumentPreviewComponent } from './features/document-creation/document-preview/document-preview.component';
import { DocumentDetailsComponent } from './features/document-creation/document-details/document-details.component';

import { SendForSignatureComponent } from './features/esignature/send-for-signature/send-for-signature.component';
import { SignatureStatusComponent } from './features/esignature/signature-status/signature-status.component';

import { CustomerDashboardComponent } from './features/customer-onboarding/customer-dashboard/customer-dashboard.component';
import { CustomerPortalComponent } from './features/customer-onboarding/customer-portal/customer-portal.component';

import { RenewalDashboardComponent } from './features/renewal-management/renewal-dashboard/renewal-dashboard.component';
import { RenewalCreationComponent } from './features/renewal-management/renewal-creation/renewal-creation.component';

import { UserManagementComponent } from './features/admin-settings/user-management/user-management.component';
import { SystemSettingsComponent } from './features/admin-settings/system-settings/system-settings.component';

export const routes: Routes = [
  { path: 'templates', component: TemplatesListComponent },
  { path: 'templates/editor', component: TemplateEditorComponent },
  { path: 'templates/details/:id', component: TemplateDetailsComponent },
  { path: 'templates/preview/:id', component: TemplatePreviewComponent },

  { path: 'documents/generate', component: DocumentGenerationComponent },
  { path: 'documents/preview/:id', component: DocumentPreviewComponent },
  { path: 'documents/details/:id', component: DocumentDetailsComponent },

  { path: 'esignature/send', component: SendForSignatureComponent },
  { path: 'esignature/status', component: SignatureStatusComponent },

  { path: 'customer/dashboard', component: CustomerDashboardComponent },
  { path: 'customer/portal', component: CustomerPortalComponent },

  { path: 'renewals/dashboard', component: RenewalDashboardComponent },
  { path: 'renewals/create', component: RenewalCreationComponent },

  { path: 'admin/users', component: UserManagementComponent },
  { path: 'admin/settings', component: SystemSettingsComponent },

  { path: '', redirectTo: '/templates', pathMatch: 'full' },
  { path: '**', redirectTo: '/templates' }
];
