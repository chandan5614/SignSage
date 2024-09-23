import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' }, // Redirect to dashboard by default
  { path: 'auth', loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule) },
  { path: 'dashboard', loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule) },
  { path: 'admin', loadChildren: () => import('./features/admin/admin.module').then(m => m.AdminModule) },
  { path: 'customer-portal', loadChildren: () => import('./features/customer-portal/customer-portal.module').then(m => m.CustomerPortalModule) },
  { path: 'documents', loadChildren: () => import('./features/documents/documents.module').then(m => m.DocumentsModule) },
  { path: 'templates', loadChildren: () => import('./features/templates/templates.module').then(m => m.TemplatesModule) },
  { path: 'renewals', loadChildren: () => import('./features/renewals/renewals.module').then(m => m.RenewalsModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
