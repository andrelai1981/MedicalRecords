import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BoxListComponent } from './box/box-list/box-list.component';
import { BoxDetailComponent } from './box/box-detail/box-detail.component';
import { FileListComponent } from './file/file-list/file-list.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { BoxNewComponent } from './box/box-new/box-new.component';
import { FileNewComponent } from './file/file-new/file-new.component';
import { BoxDetailResolver } from './_resolvers/box-detail.resolver';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'boxes', component: BoxListComponent},
      { path: 'boxes/new', component: BoxNewComponent},
      { path: 'boxes/:id', component: BoxDetailComponent, resolve: {box: BoxDetailResolver}},
      { path: 'files', component: FileListComponent},
      { path: 'boxes/:id/files/new', component: FileNewComponent},
      { path: 'users', component: UserListComponent},
    ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
