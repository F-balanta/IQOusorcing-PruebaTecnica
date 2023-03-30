using IQOUTSOURCING.BusinessLogic.Services.Base;
using IQOUTSOURCING.Domain;
using IQOUTSOURCING.Domain.DTOs.Usuario;
using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces;
using IQOUTSOURCING.Domain.Interfaces.Services;
using IQOUTSOURCING.TransversalHelpers.ExceptionHelper;
using IQOUTSOURCING.TransversalHelpers.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace IQOUTSOURCING.BusinessLogic.Services
{
    public class UsuarioService : BaseService, IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO>
    {
        private readonly IPasswordHasher<Usuario> passwordHasher;
        private readonly JWT jwt;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<Usuario> PasswordHasher, IOptions<JWT> jwt) : base(unitOfWork, mapper)
        {
            passwordHasher = PasswordHasher;
            this.jwt = jwt.Value;
        }

        public async Task<Response<UsuarioDTO>> Add(UsuarioCommandDTO entityDTO)
        {
            Response<UsuarioDTO> respuesta = new();

            Usuario usuario = mapper.Map<Usuario>(entityDTO);
            usuario.Password = passwordHasher.HashPassword(usuario, entityDTO.Password);

            Usuario? usuarioExiste = await unitOfWork.UsuarioRepository!.Find(p => p.UserName == entityDTO.UserName);

            if (usuarioExiste == null)
            {
                Rol? rolPredeterminado = await unitOfWork.RolRepository!.Find(x => x.Nombre == "Usuario");

                usuario.Roles!.Add(rolPredeterminado!);
                await unitOfWork.UsuarioRepository.Add(usuario);

                await unitOfWork.SaveAsync();
                respuesta.Message = "Usuario registrado con éxito";
                respuesta.Data = mapper.Map<UsuarioDTO>(entityDTO);
                respuesta.Data.Id = usuario.Id;
            }
            else
                throw new RestException(HttpStatusCode.BadRequest, $"El usuario {entityDTO.UserName} ya existe.");


            return respuesta;
        }

        public async Task<Response<int>> Delete(Guid id)
        {
            Response<int> response = new();
            Usuario? usuario = await unitOfWork.UsuarioRepository!.GetById(id) ?? throw new RestException(HttpStatusCode.NotFound, $"No existe ningún usuario con el id {id}");

            unitOfWork.UsuarioRepository.Delete(usuario!);
            response.Data = await unitOfWork.SaveAsync();
            response.Message = "Usuario eliminado con éxito";

            return response;
        }

        public async Task<Response<ICollection<UsuarioDTO>>> GetAll()
        {
            Response<ICollection<UsuarioDTO>> response = new();

            response.Data = mapper.Map<List<UsuarioDTO>>(await unitOfWork.UsuarioRepository!.GetAll()!);
            response.Message = response.Data != null ? "Usuarios obtenidos con éxito" : "No existen usuarios registrados en el sistema";

            return response;
        }

        public async Task<Response<UsuarioDTO>> GetById(Guid id)
        {
            Response<UsuarioDTO> response = new();

            Usuario? usuario = await unitOfWork.UsuarioRepository!.GetById(id) ?? throw new RestException(HttpStatusCode.NotFound, $"No existe ningún usuario con el id {id}");
            response.Data = mapper.Map<UsuarioDTO>(usuario);
            response.Message = "Usuario obtenido con éxito";

            return response;
        }

        public async Task<Response<UsuarioDTO>> Update(Guid id, UsuarioCommandDTO entityDTO)
        {
            Response<UsuarioDTO> respuesta = new();

            Usuario? usuario = await unitOfWork.UsuarioRepository!.GetById(id) ?? throw new RestException(HttpStatusCode.NotFound, $"No existe ningún usuario con el id {id}");
            if(entityDTO.Password != null)
                usuario.Password = passwordHasher.HashPassword(usuario, entityDTO.Password) ?? usuario.Password;
            usuario.UserName = entityDTO.UserName ?? usuario.UserName;
            usuario.Nombre = entityDTO.Nombre ?? usuario.Nombre;
            usuario.Correo = entityDTO.Correo ?? usuario.Correo;

            unitOfWork.UsuarioRepository!.Update(usuario);
            await unitOfWork.SaveAsync();

            respuesta.Data = mapper.Map<UsuarioDTO>(usuario);
            respuesta.Message = "Usuario actualizado con éxito";

            return respuesta;
        }



        public async Task<Response<UsuarioDataDTO>> GetToken(UsuarioLoginDTO entityDTO)
        {
            Response<UsuarioDataDTO> response = new();

            using (TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled))
            {
                UsuarioDataDTO datosUsuarioDTO = new UsuarioDataDTO();

                Usuario? usuario = await unitOfWork.UsuarioRepository!.Find(x => x.UserName == entityDTO.UserName) ?? throw new RestException(HttpStatusCode.BadRequest, $"No existe el usuario {entityDTO.UserName}");
                PasswordVerificationResult resultadoAutenticacion = passwordHasher.VerifyHashedPassword(usuario, usuario.Password, entityDTO.Password);

                switch (resultadoAutenticacion)
                {
                    case PasswordVerificationResult.Success:
                        datosUsuarioDTO.Token = CreateToken(usuario);
                        datosUsuarioDTO.UserName = usuario.UserName;
                        datosUsuarioDTO.Id = usuario.Id;
                        break;
                    case PasswordVerificationResult.Failed:
                        throw new RestException(HttpStatusCode.Unauthorized, "Usuario o contraseña incorrectos");
                }

                Auditoria auditoria = new()
                {
                    UsuarioId = usuario.Id
                };

                await unitOfWork.AuditoriaRepository!.Add(auditoria);
                await unitOfWork.SaveAsync();

                response.Data = datosUsuarioDTO;
                transaction.Complete();
            }

            return response;
        }

        private string? CreateToken(Usuario usuario)
        {
            var roles = usuario.Roles;
            var roleClaims = new List<Claim>();

            foreach (var role in roles!)
            {
                roleClaims.Add(new Claim("roles", role.Nombre!));
            }
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Correo!),
                        new Claim("uid", usuario.Id.ToString()!)

            }.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}

