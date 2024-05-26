import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Enviroments/environment.service';
import { IOrdenVenta } from 'src/app/Interfaces/IOrdenVenta';

@Injectable({
  providedIn: 'root'
})
export class OrdenVentaService {

url = environment.endpoint;

constructor(private http:HttpClient) { }

  public GenerarOrdenVenta(ordenVenta:IOrdenVenta):Observable<any>{
    console.log(ordenVenta);
    return this.http.post(`${this.url}/OrdenCompra/guardar`,ordenVenta);
  }

}
