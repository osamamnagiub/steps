import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {StepComponent} from './step/step.component';
import {StepsComponent} from './steps/steps.component';
import {AddEditComponent} from './add-edit/add-edit.component';
import {StepsService} from "./steps.service";
import {LoginComponent} from './login/login.component';
import {AuthGuard} from "./auth.guard";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StepComponent,
    StepsComponent,
    AddEditComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '', pathMatch: 'full', redirectTo: 'steps'
      },
      {
        path: 'steps', component: StepsComponent, canActivate: [AuthGuard],
        children: [{path: ':id', component: StepComponent}]
      },
      {path: 'login', component: LoginComponent}
    ])
  ],
  providers: [StepsService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
