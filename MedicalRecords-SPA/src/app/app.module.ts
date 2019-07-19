import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { BoxNewComponent } from './box/box-new/box-new.component';
import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BoxListComponent } from './box/box-list/box-list.component';
import { appRoutes } from './routes';
import { FilesListComponent } from './files/files-list/files-list.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { AlertifyService } from './_services/alertify.service';
import { AuthGuard } from './_guards/auth.guard';
import { AdminGuard } from './_guards/admin.guard';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      BoxListComponent,
      BoxNewComponent,
      FilesListComponent,
      UserListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      UserService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      AdminGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
