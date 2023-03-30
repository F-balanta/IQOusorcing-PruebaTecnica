import { Component, OnInit } from '@angular/core';
import {IUsuarioLoginDTO} from "../../modelos/Usuario/UsuarioLoginDTO";
import {UsuariosService} from "../../servicios/usuarios.service";
import { Router } from '@angular/router';
import Respuesta from "../../modelos/Respuesta";
import UsuarioDataDTO from "../../modelos/Usuario/UsuarioDataDTO";
import {catchError, throwError} from "rxjs";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  dataUsuario : IUsuarioLoginDTO = {
    password: "", username:""
  };
  response: Respuesta<UsuarioDataDTO> = new Respuesta<UsuarioDataDTO>();
  errorStatus:boolean = false;
  errorMsj:string | undefined  ="";
  constructor(private apisecurity:UsuariosService, private route: Router, private toastr:ToastrService)
  {}

  ngOnInit(): void {
    if(this.apisecurity.verifiedLogged()){
      this.route.navigate(['']);
    }else{
      this.route.navigate(['login']);
    }
  }

  validarFomurlario():boolean{
    let sePuedeLoguear : boolean = true;
    if(this.dataUsuario != null){
      if(this.dataUsuario.username == null || this.dataUsuario.username == ''){
        sePuedeLoguear = false;
        this.toastr.error("Por favor, ingrese el usuario");

      }

      if(this.dataUsuario.password == null || this.dataUsuario.password == ''){
        sePuedeLoguear = false;
        this.toastr.error("Por favor, ingrese la contraseña");
      }
    }
    return sePuedeLoguear;
  }

  startLogin(usuario: IUsuarioLoginDTO){
    if(this.validarFomurlario()){
      this.apisecurity.getToken(usuario).pipe(
        catchError(ex => {
          const statusCode = ex.status;
          this.errorStatus = true;
          this.toastr.error("Error: " + ex.error.message);
          return throwError(ex);
        })
      ).subscribe(response=>{
        console.log(response);
        if(response != null){
          this.errorStatus = true;
          this.errorMsj = response.message
          this.toastr.success("Inicio exitoso");
          localStorage.setItem("token", response.data!.token);
          localStorage.setItem("userName", response.data!.userName);
          localStorage.setItem("userId", response.data!.id);
          this.route.navigate(['']);
        }
      })
    }
  }

}
