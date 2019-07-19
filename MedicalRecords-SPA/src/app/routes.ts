import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BoxListComponent } from './box/box-list/box-list.component';
import { FilesListComponent } from './files/files-list/files-list.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminGuard } from './_guards/admin.guard';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'boxes', component: BoxListComponent},
      { path: 'files', component: FilesListComponent},
      { path: 'users', component: UserListComponent, canActivate: [AdminGuard]},
    ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
