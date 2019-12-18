import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { BoxNewComponent } from './box/box-new/box-new.component';
import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BoxListComponent } from './box/box-list/box-list.component';
import { appRoutes } from './routes';
import { UserListComponent } from './user/user-list/user-list.component';
import { AlertifyService } from './_services/alertify.service';
import { AuthGuard } from './_guards/auth.guard';
import { FileListComponent } from './file/file-list/file-list.component';
import { BoxDetailComponent } from './box/box-detail/box-detail.component';
import { FileNewComponent } from './file/file-new/file-new.component';
import { BoxDetailResolver } from './_resolvers/box-detail.resolver';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      BoxListComponent,
      BoxDetailComponent,
      BoxNewComponent,
      FileListComponent,
      FileNewComponent,
      UserListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes, {onSameUrlNavigation: 'reload'}),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      UserService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      BoxDetailResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
