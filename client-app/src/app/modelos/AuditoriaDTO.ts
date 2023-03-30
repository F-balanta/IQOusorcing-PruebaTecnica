import UsuarioDTO from "./Usuario/UsuarioDTO";
import UsuarioWithoutPasswordDTO from "./Usuario/UsuarioWithoutPasswordDTO";

export default class AuditoriaDTO{
  id:string = "";
  fechaInicioSesion: string = "";
  usuario: UsuarioWithoutPasswordDTO = {
    id: "",
    userName: "",
    correo: "",
    nombre: ""
  };
}
