import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LeaveRequestComponent } from './leave-request/leave-request.component';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LeaveRequestService } from "./services/leave-request.service";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LeaveRequestComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'request-leave', component: LeaveRequestComponent}
      // { path: 'fetch-data', component: FetchDataComponent },
    ]),
    DateInputsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  providers: [LeaveRequestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
