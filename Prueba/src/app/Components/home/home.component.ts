import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { CategoriaService } from 'src/app/Services/Categoria/categoria.service';
import { CarritoComponent } from '../carrito/carrito.component';
import { ToastrService } from 'ngx-toastr';
import { CarritoService } from 'src/app/Services/Carrito/Carrito.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loading = false;
  dataSource : any = [];
  titleColumns : string[] = ['IdProducto','NombreProducto','Precio','Cantidad','Acciones'];
  categoriaElegida : string | undefined;
  form!:FormGroup;
  itemsCarrito : any[] = [];

  constructor(
    private fb: FormBuilder, 
    private apiCategoria:CategoriaService,
    public dialog: MatDialog,
    private toast: ToastrService,
    private carritoService:CarritoService
  ) { 
    this.form = this.fb.group({
      categoriaElegida : ['']
    })
  }
    
  ngOnInit() {
  }

  obtenerProductosPorCategoria():void{
    this.loading=true;
    if(this.categoriaElegida){
      this.apiCategoria.ObtenerTodosProductosPorCategoria(this.categoriaElegida).subscribe((data:any)=>{
        this.dataSource = data;
        this.loading = false;
        console.log(data);
      })
    }
  }

  verCarrito(){
    console.log(this.itemsCarrito);
    this.dialog.open(CarritoComponent,{
      data:this.itemsCarrito
    });
  }

  AgregarAlCarrito(productoElegido:any):void{
    this.carritoService.agregarAlCarrito(productoElegido);
    this.toast.success('Producto agregado al carrito!', 'Éxito',{
    toastClass: 'ngx-toastr custom-toast custom-toast-success'
  });
  }

}
