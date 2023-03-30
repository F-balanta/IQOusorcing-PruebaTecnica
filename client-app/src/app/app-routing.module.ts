import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./componentes/login/login.component";
import {HomeComponent} from "./componentes/home/home.component";
import {AgregarUsuarioComponent} from "./componentes/agregar-usuario/agregar-usuario.component";
import {UsuariosComponent} from "./componentes/usuarios/usuarios.component";
import {ActualizarUsuarioComponent} from "./componentes/actualizar-usuario/actualizar-usuario.component";

const routes: Routes = [
  { path: "", component:UsuariosComponent  },
  { path: "login", component:LoginComponent  },
  { path:"usuarios/obtener", component:UsuariosComponent},
  { path:"usuarios/actualizar/:id", component: ActualizarUsuarioComponent },
  { path:"usuarios/agregar", component:AgregarUsuarioComponent},
  { path:"auditoria/obtener", component:HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
