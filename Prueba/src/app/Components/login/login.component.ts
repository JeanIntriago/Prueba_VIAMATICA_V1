import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/Services/LoginService/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loading = false;
  hide = true;
  form:FormGroup;
  errorMessage: string = '';

  constructor(
    private _formBuilder : FormBuilder, 
    private api:LoginServiceService,
    private router: Router) {
    this.form = this._formBuilder.group({
      correo : ['', Validators.required],
      clave : ['',Validators.required]
    })

  }

  ngOnInit() {
  }

  validarLogin(){
    const correoForm = this.form.get('correo')?.value;
    var claveForm = this.form.get('clave')?.value;

    this.loading = true;
    this.api.Login(correoForm,claveForm).subscribe(
      response => {
          this.api.setToken(response.token);
          this.loading = false;
          this.router.navigate(["/home"]);
      },
      error => {
        this.loading = false;
        alert(error);
      }
    );
  }

  crearCuenta():void{
    this.router.navigate(['/registro']);
  }
}
