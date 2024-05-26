import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/Enviroments/environment.service';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  url = environment.endpoint;

  constructor(
    private http: HttpClient,
    private jwtHelper: JwtHelperService
  ) { }
  

  Login(correo:string, clave:string):Observable<any>{
    const urlApi = `${this.url}/Login/validar_login`
    return this.http.post(urlApi, { correo, clave }).pipe(
      catchError(error => {
        if (error.status === 401) {
          console.log('Correo o contraseña incorrecto');
          return throwError('Correo o contraseña incorrecto');
        } else {
          console.log('Error al iniciar sesión');
          return throwError('Error al iniciar sesión');
        }
      })
    );
  }

  setToken(token:string):void{
    localStorage.setItem('token',token);
  }

  getToken():string|null{
    return localStorage.getItem('token');
  }

  isLogged():boolean{
    const token = this.getToken();
    return token? !this.jwtHelper.isTokenExpired(token):false;
  }

  logout():void{
    localStorage.removeItem('token');
  }
}
