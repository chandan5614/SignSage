import { Routes } from '@angular/router';
import { SystemSettingsComponent } from './features/admin-settings/system-settings/system-settings.component';
import { UserManagementComponent } from './features/admin-settings/user-management/user-management.component';
import { CustomerDashboardComponent } from './features/customer-onboarding/customer-dashboard/customer-dashboard.component';
import { CustomerPortalComponent } from './features/customer-onboarding/customer-portal/customer-portal.component';
import { DocumentDetailsComponent } from './features/document-creation/document-details/document-details.component';
import { DocumentGenerationComponent } from './features/document-creation/document-generation/document-generation.component';
import { DocumentPreviewComponent } from './features/document-creation/document-preview/document-preview.component';
import { SendForSignatureComponent } from './features/esignature/send-for-signature/send-for-signature.component';
import { SignatureStatusComponent } from './features/esignature/signature-status/signature-status.component';
import { RenewalCreationComponent } from './features/renewal-management/renewal-creation/renewal-creation.component';
import { RenewalDashboardComponent } from './features/renewal-management/renewal-dashboard/renewal-dashboard.component';
import { TemplateDetailsComponent } from './features/templates/template-details/template-details.component';
import { TemplateEditorComponent } from './features/templates/template-editor/template-editor.component';
import { TemplatePreviewComponent } from './features/templates/template-preview/template-preview.component';
import { TemplatesListComponent } from './features/templates/templates-list/templates-list.component';
import { AuthGuard } from './core/services/AuthGuard';
import { LoginComponent } from './features/auth/login/login.component';

export const routes: Routes = [
  { path: 'templates', component: TemplatesListComponent, canActivate: [AuthGuard] },
  { path: 'templates/editor', component: TemplateEditorComponent, canActivate: [AuthGuard] },
  { path: 'templates/details/:id', component: TemplateDetailsComponent, canActivate: [AuthGuard] },
  { path: 'templates/preview/:id', component: TemplatePreviewComponent, canActivate: [AuthGuard] },

  { path: 'documents/generate', component: DocumentGenerationComponent, canActivate: [AuthGuard] },
  { path: 'documents/preview/:id', component: DocumentPreviewComponent, canActivate: [AuthGuard] },
  { path: 'documents/details/:id', component: DocumentDetailsComponent, canActivate: [AuthGuard] },

  { path: 'esignature/send', component: SendForSignatureComponent, canActivate: [AuthGuard] },
  { path: 'esignature/status', component: SignatureStatusComponent, canActivate: [AuthGuard] },

  { path: 'customer/dashboard', component: CustomerDashboardComponent, canActivate: [AuthGuard] },
  { path: 'customer/portal', component: CustomerPortalComponent, canActivate: [AuthGuard] },

  { path: 'renewals/dashboard', component: RenewalDashboardComponent, canActivate: [AuthGuard] },
  { path: 'renewals/create', component: RenewalCreationComponent, canActivate: [AuthGuard] },

  { path: 'admin/users', component: UserManagementComponent, canActivate: [AuthGuard] },
  { path: 'admin/settings', component: SystemSettingsComponent, canActivate: [AuthGuard] },

  { path: 'login', component: LoginComponent },

  { path: '', redirectTo: '/templates', pathMatch: 'full' },
  { path: '**', redirectTo: '/templates' }
];
