import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/app/Enviroments/environment.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

url = environment.endpoint;

constructor(private http:HttpClient) { }

  public ObtenerTodosProductosPorCategoria(categoria:string):Observable<any>{
    const url = `${this.url}/Categoria/${categoria}/productos`
    return this.http.get(url).pipe(map((response:any)=>response.$values));
  }

}
