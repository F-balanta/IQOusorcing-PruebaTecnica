import { Component, OnInit } from '@angular/core';
import {UsuariosService} from "../../servicios/usuarios.service";
import AuditoriaDTO from "../../modelos/AuditoriaDTO";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  auditoria: AuditoriaDTO[] =[]
  datos:any;

  constructor(
    private apiService:UsuariosService,
    private router:Router,
    private toastr:ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllAuditories();
    if(this.apiService.verifiedLogged()){
      this.router.navigate(['auditoria/obtener']);
    }else{
      this.router.navigate(['login']);
    }
  }

  getAllAuditories(){
  this.apiService.getAudit().subscribe(response=>{
    this.datos = response;
    this.auditoria = this.datos.data;
    console.log(this.auditoria)
  })
  }

}
