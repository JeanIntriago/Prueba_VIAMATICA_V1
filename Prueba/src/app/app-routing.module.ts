import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { HomeComponent } from './Components/home/home.component';
import { AddUsersComponent } from './Modules/Dashboard/usuarios-module/added-users/add-users.component';
import { AuthenticationService } from './Services/Authentication/authentication.service';

const routes: Routes = [
  {path:'', redirectTo: 'login', pathMatch: 'full' },
  {path:'login',  component: LoginComponent},
  {path:'home',   component: HomeComponent, canActivate:[AuthenticationService]},
  {path:'registro', component:AddUsersComponent},

  { path: '**', redirectTo: 'login' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
