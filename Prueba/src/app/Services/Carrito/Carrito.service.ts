import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {
  itemsCarrito: any[] = [];

  constructor() { }

  agregarAlCarrito(producto:any):void{
    this.itemsCarrito.push(producto);
  }

  obtenerItemsCarrito(): any[] {
    return this.itemsCarrito;
  }

  vaciarCarrito():void{
    this.itemsCarrito = [];
  }

}
