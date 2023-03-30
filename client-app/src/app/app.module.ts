import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import { NgModule } from '@angular/core';

import { ActualizarUsuarioComponent } from './componentes/actualizar-usuario/actualizar-usuario.component';
import { AgregarUsuarioComponent } from './componentes/agregar-usuario/agregar-usuario.component';
import { UsuariosComponent } from './componentes/usuarios/usuarios.component';
import {TokenInterceptorService} from "./servicios/token-interceptor.service";
import { NavbarComponent } from './componentes/navbar/navbar.component';
import {LoginComponent} from "./componentes/login/login.component";
import { HomeComponent } from './componentes/home/home.component';
import { AppComponent } from './app.component';
import {ToastrModule} from "ngx-toastr";
import { FooterComponent } from './componentes/footer/footer.component';


@NgModule({
  declarations: [
    AgregarUsuarioComponent,
    ActualizarUsuarioComponent,
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavbarComponent,
    UsuariosComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass:"toast-top-right",
      preventDuplicates:true,
      timeOut:3000
    })
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass:TokenInterceptorService,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
