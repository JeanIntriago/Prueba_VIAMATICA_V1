import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

/*COMPONENTES*/
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { HeaderComponent } from './Components/header/header.component';

/*MATERIAL*/
import {MatFormFieldModule} from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import { HttpClientModule } from '@angular/common/http';
import { AddUsersComponent } from './Modules/Dashboard/usuarios-module/added-users/add-users.component';
import { MatDialogModule } from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
import {MatToolbarModule} from '@angular/material/toolbar';
import { CarritoComponent } from './Components/carrito/carrito.component';
import { ToastrModule } from 'ngx-toastr';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
//import { JwtInterceptor } from './Services/Authentication/JwtInterceptor';
import { JwtInterceptor, JwtModule } from '@auth0/angular-jwt';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [	
    AppComponent,
    LoginComponent,
    HomeComponent,
    AddUsersComponent,
    HeaderComponent,
    CarritoComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatIconModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    MatTableModule,
    MatSelectModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true,
      toastClass: 'ngx-toastr custom-toast'
    }),
    JwtModule.forRoot(
      {
        config:{
          tokenGetter: tokenGetter,
          allowedDomains: ['https://localhost:7101/api'],
          disallowedRoutes: [
            'https://localhost:7101/api/Login/validar_login' 
          ]
        }
      }
    )
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})



export class AppModule { }
