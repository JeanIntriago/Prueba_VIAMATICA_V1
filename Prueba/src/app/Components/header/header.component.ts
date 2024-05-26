import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/Services/LoginService/login-service.service';
import { CarritoComponent } from '../carrito/carrito.component';
import { ToastrService } from 'ngx-toastr';
import { CarritoService } from 'src/app/Services/Carrito/Carrito.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  //itemsCarrito : any[] = []; FUNCIONA

  constructor(
    private route:Router, 
    private _loginService: LoginServiceService,
    public dialog: MatDialog,
    private toast: ToastrService,
    private carritoService: CarritoService
  ) { }

  ngOnInit() {
  }
  cerrarSesion(){
    this._loginService.logout();
    this.route.navigate(['/login']);
  }

  verCarrito(){
    /*FUNCIONA
    console.log(this.itemsCarrito);
    this.dialog.open(CarritoComponent,{
      data:this.itemsCarrito
    });
    */
    const itemsCarrito = this.carritoService.obtenerItemsCarrito();
    this.dialog.open(CarritoComponent, {
      data: itemsCarrito
    });
  }

  productosAlmacenados():any[]{
    return this.carritoService.itemsCarrito;
  }
}
