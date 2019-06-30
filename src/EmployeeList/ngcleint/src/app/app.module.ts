import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { NotfoundComponent } from './error-pages/notfound/notfound.component';
import { HttpClientModule } from '@angular/common/http';

import { EnvironmentUrlService } from './shared/services/environment-url.service';
import { InternalErrorComponent } from './error-pages/internal-error/internal-error.component';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import * as $ from 'jquery';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    NotfoundComponent,
    InternalErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [EnvironmentUrlService, ErrorHandlerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
