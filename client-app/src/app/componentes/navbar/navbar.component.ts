import {Component, OnInit} from '@angular/core';
import {UsuariosService} from "../../servicios/usuarios.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public textLink = "IQ OUTSOURCING"
  public iQLink = "https://www.iqoutsourcing.com/quienes-somos/";
  logueado: boolean = false;

  constructor(
    private apiService: UsuariosService,
    private toastr: ToastrService
  ) {
    if (this.apiService.verifiedLogged()) {
      this.logueado = true;
    } else {
      this.logueado = false;
    }
  }

  userName: string | null = localStorage.getItem('userName');

  ngOnInit(): void {

  }

  onLogout(): void {
    this.apiService.logout();
  }
}
