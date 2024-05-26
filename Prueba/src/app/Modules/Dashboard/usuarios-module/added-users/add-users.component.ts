import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IUsuario } from 'src/app/Interfaces/IUsuario';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UsuarioService } from 'src/app/Services/Usuario/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-users',
  templateUrl: './add-users.component.html',
  styleUrls: ['./add-users.component.css']
})
export class AddUsersComponent implements OnInit {

  hide = true;
  form!:FormGroup;
  data : IUsuario | undefined;
  constructor(    
    private _formBuilder : FormBuilder, 
    private apiUsuario: UsuarioService,
    private route:Router
  ) 
  { 
    this.form = this._formBuilder.group({
      nombre : ['', Validators.required],
      apellido : ['', Validators.required],
      correo : ['', Validators.required],
      clave : ['',Validators.required]
    })
  }

  ngOnInit() {
  }
  registrar(){
    const usuario: IUsuario= {
      Nombre: this.form.value.nombre,
      Apellido : this.form.value.apellido,
      Correo : this.form.value.correo,
      Clave : this.form.value.clave
    }

    
    this.apiUsuario.Registrar(usuario).subscribe(
      response => {
        console.log("Usuario registrado correctamente")
      }
    )
  }

  iniciarSesion():void{
    this.route.navigate(['/login']);
  }

}
