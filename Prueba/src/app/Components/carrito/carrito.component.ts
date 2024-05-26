import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IOrdenVenta } from 'src/app/Interfaces/IOrdenVenta';
import { CarritoService } from 'src/app/Services/Carrito/Carrito.service';
import { OrdenVentaService } from 'src/app/Services/OrdenCompra/orden-venta.service';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent implements OnInit {

  loading = false;
  total : number= 0;
  productoData: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data:any,
    private urlOrden : OrdenVentaService,
    private route: Router,
    private dialogRef: MatDialog,
    private carritoService:CarritoService
  ) { 
    this.productoData = this.data;
  }

  calcularTotal(){
    this.total = this.data.reduce((sum: any,item: { precio: any; })=>sum+item.precio,0)
  }

  ngOnInit() {
    this.calcularTotal();
  }

  productosAlmacenados():any[]{
    return this.carritoService.itemsCarrito;
  }

  registrarCompra(){

    const productos = this.productoData.map((producto: { idProducto: any; }) => ({
      IdProducto: producto.idProducto,
    }));

    const orden : IOrdenVenta = {
      Total : this.total,
      FechaRegistro: new Date(),
      Productos: productos
    }
    this.loading = true;
    this.urlOrden.GenerarOrdenVenta(orden).subscribe(
      response => {
        console.log("Orden de venta generada con exito");
        this.loading = false;
        this.dialogRef.closeAll();
        this.carritoService.vaciarCarrito();
        this.data = [];
        this.productoData = [];
        console.log(this.data);
        this.route.navigate(['/home']);
      }
    )
    console.error("Al parecer ocurrio un error");
  }

}
