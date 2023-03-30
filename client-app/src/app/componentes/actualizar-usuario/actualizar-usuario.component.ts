import {Component, OnInit} from '@angular/core';
import {UsuariosService} from "../../servicios/usuarios.service";
import UsuarioForCreateorUpdateDTO from "../../modelos/Usuario/UsuarioForCreateorUpdateDTO";
import {Router, ActivatedRoute} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {catchError, throwError} from "rxjs";

@Component({
  selector: 'app-actualizar-usuario',
  templateUrl: './actualizar-usuario.component.html',
  styleUrls: ['./actualizar-usuario.component.scss']
})
export class ActualizarUsuarioComponent implements OnInit {

  errorStatus: boolean = false;
  datos: any
  usuario: UsuarioForCreateorUpdateDTO = new UsuarioForCreateorUpdateDTO();

  constructor(
    private apiService: UsuariosService,
    private route: Router,
    private router: ActivatedRoute,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    let id = this.router.snapshot.params['id'];
    if (!id) return;
    //console.log(id);
    this.getDataById(id);
    if (this.apiService.verifiedLogged()) {
      this.route.navigate(['usuarios/actualizar/']);
    } else {
      this.route.navigate(['']);
    }
  }

  validateform(): boolean {
    let canEdit: boolean = true;
    if (this.usuario != null) {
      if (this.usuario.nombre == null || this.usuario.nombre == '') {
        this.toastr.error("Por favorn ingrese un nombre");
        canEdit = false;
      }

      if (this.usuario.userName == null || this.usuario.userName == '') {
        this.toastr.error("Por favorn ingrese un nombre de usuario");
        canEdit = false;
      }
      if (this.usuario.correo == null || this.usuario.correo == '') {
        this.toastr.error("Por favorn ingrese un correo")
        canEdit = false;
      }
    }
    return canEdit;
  }

  getDataById(id: any) {
    this.apiService.getUser(id).subscribe(response => {
      this.datos = response.data;
      this.usuario = this.datos;
      console.log(this.usuario);

    })
  }

  updateDataUser(id: number, usuario: UsuarioForCreateorUpdateDTO) {
    if (this.validateform()) {
      this.apiService.updateUser(id, usuario).pipe(
        catchError(ex => {
          this.errorStatus = true;
          const statusCode = ex.status;
          if (statusCode == 0) {
            this.toastr.error("Error: Fue imposible comunicarse con el servidor");
          } else {
            this.toastr.error("Error: " + ex.error.message);
          }
          return throwError(ex);
        })
      ).subscribe(response => {
        console.log(response);
        this.toastr.success(`${response.message}`);
        this.route.navigate([''])

      })
    }
  }
}
