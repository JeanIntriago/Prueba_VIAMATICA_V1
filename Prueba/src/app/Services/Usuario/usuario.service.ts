import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Enviroments/environment.service';
import { IUsuario } from 'src/app/Interfaces/IUsuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url = environment.endpoint;

constructor(private http:HttpClient) { }

  public Registrar(usuario:IUsuario):Observable<any>{
    const url = `${this.url}/Usuario/registrar`
    return this.http.post(url,usuario);
  }

}
