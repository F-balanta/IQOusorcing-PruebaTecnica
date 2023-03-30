import { Component, OnInit } from '@angular/core';
import {UsuariosService} from "../../servicios/usuarios.service";
import UsuarioDTO from "../../modelos/Usuario/UsuarioDTO";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {catchError, throwError} from "rxjs";


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss']
})
export class UsuariosComponent implements OnInit {
  listaUsuarios: UsuarioDTO[] = [];
  datos: any;
  usuario: UsuarioDTO = new UsuarioDTO();
  constructor(
    private usuarioService: UsuariosService,
    private toastr:ToastrService,
    private route:Router
  ) { }

  ngOnInit(): void {
    this.getAllData();
    if(this.usuarioService.verifiedLogged()){
      this.route.navigate(['usuarios/obtener']);
    }else{
      this.route.navigate(['login']);
    }
  }

  getAllData(){
    this.usuarioService.getAll().subscribe(response=>{
      console.log(response);
      this.datos = response;
      this.listaUsuarios = this.datos.data;
    })
  }

  seleccionar(item:any){
    this.route.navigate(['/usuarios/actualizar',item.id]);
  }

  deleteUser(id:number){
    this.usuarioService.deleteUser(id).pipe(
      catchError(e => {
        this.toastr.error(`Error: ${e.error.message}`)
        return throwError(e);
      })).subscribe(response=>{
        console.log(response);
        this.toastr.success(`${response.message}`)
        this.getAllData();
    })
  }
}
