import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {UsuariosService} from "../../servicios/usuarios.service";
import UsuarioForCreateorUpdateDTO from "../../modelos/Usuario/UsuarioForCreateorUpdateDTO";
import {catchError, throwError} from "rxjs";
import {ToastrService} from "ngx-toastr";


@Component({
  selector: 'app-agregar-usuario',
  templateUrl: './agregar-usuario.component.html',
  styleUrls: ['./agregar-usuario.component.scss']
})
export class AgregarUsuarioComponent implements OnInit {

  usuario: UsuarioForCreateorUpdateDTO = new UsuarioForCreateorUpdateDTO();

  errorMsj = ""

  constructor(
    private apiService: UsuariosService,
    private router: Router,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.asignarTitulo()
  }

  titulo: string = "";

  validateform(): boolean {
    let canCreate: boolean = true
    if (this.usuario != null) {
      if (this.usuario.correo == null || this.usuario.correo == '') {
        this.toastr.error("Por favor, ingrese un correo")
        canCreate = false;
      }
      if (this.usuario.userName == null || this.usuario.userName == '') {
        this.toastr.error("Por favor, ingrese un nombre e ususario")
        canCreate = false;
      }
      if (this.usuario.password == null || this.usuario.password == '') {
        this.toastr.error("Por favor, ingrese una contraseña")
        canCreate = false;
      }
      if (this.usuario.nombre == null || this.usuario.nombre == '') {
        this.toastr.error("Por favor, ingrese un nombre")
        canCreate = false;
      }
    }
    return canCreate
  }

  asignarTitulo(): void {
    if (localStorage.getItem("token")) {
      this.titulo = "Crear usuario"
    } else {
      this.titulo = "Regístrate"
    }
  }

  addUser(usuario: UsuarioForCreateorUpdateDTO) {
    if (this.validateform()) {
      this.apiService.addUser(usuario).pipe(
        catchError(ex => {
          this.errorMsj = ex.error.message;
          const statusCode = ex.status;
          if (statusCode == 0) {
            this.toastr.error("Error: Fue imposible comunicarse con el servidor");
          } else {
            this.toastr.error("Error: " + ex.error.message);
          }
          return throwError(ex);
        })
      ).subscribe(response => {
        if (response != null) {
          console.log(response);
          this.toastr.success(`${response.message}`)
        }
        this.router.navigate(['/usuarios/obtener'])
      })
    }

  }
}
