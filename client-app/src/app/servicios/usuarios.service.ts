import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {IUsuarioLoginDTO} from "../modelos/Usuario/UsuarioLoginDTO";
import {catchError, Observable, throwError} from "rxjs";
import Respuesta from "../modelos/Respuesta";
import UsuarioDTO from "../modelos/Usuario/UsuarioDTO";
import UsuarioForCreateorUpdateDTO from '../modelos/Usuario/UsuarioForCreateorUpdateDTO';
import UsuarioDataDTO from '../modelos/Usuario/UsuarioDataDTO';
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  url = "https://localhost:7259/api/usuarios/";
  urlSecurty = "https://localhost:7259/api/security";
  urlAuditories = "https://localhost:7259/api/auditorias/get"

  constructor(
    private http: HttpClient,
    private route:Router
  ) {  }

  //Moethods to cunsume  USUARIO endpoints
  getAll(): Observable<Respuesta<Array<UsuarioDTO>>>{
    return this.http.get<Respuesta<UsuarioDTO[]>>(`${this.url}get`);
  }

  getUser(id: number): Observable<Respuesta<UsuarioDTO>>{
    return this.http.get<Respuesta<UsuarioDTO>>(`${this.url}get/${id}`);
  }

  addUser(usuario: UsuarioForCreateorUpdateDTO){
    return this.http.post<Respuesta<UsuarioDTO>>(`${this.url}add`, usuario);
  }

  updateUser(id:number, usuario:UsuarioForCreateorUpdateDTO){
    return this.http.put<Respuesta<UsuarioDTO>>(`${this.url}update/${id}/`, usuario);
  }

  deleteUser(id: number){
    return this.http.delete<Respuesta<number>>(`${this.url}delete/${id}`);
  }

  getAudit(){
    return this.http.get(`${this.urlAuditories}/`)
  }
  // Method to consume Security endpoints
  getToken(usuario: IUsuarioLoginDTO): Observable<Respuesta<UsuarioDataDTO>>{
    return this.http.post(`${this.urlSecurty}/login`,usuario);
  }

  public verifiedLogged(): boolean{
    const token = localStorage.getItem("token");
    return !!token
    // return token ? true : false
  }
  public logout():void{
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
    this.route.navigate(['']);
  }


}
