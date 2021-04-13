namespace WebApiCv
{
    using Dtos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        #region Properties
        private readonly IUserConfigurationService userConfiguration;
        #endregion
        #region Constructores
        public UserController(IUserConfigurationService userConfiguration)
        {
            this.userConfiguration = userConfiguration;
        }
        #endregion
        #region Methods
        [HttpGet("prueba")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var a = await userConfiguration.prueba();
            return Ok(new
            {
                response = a
            });
        }

        [HttpPost("account/createusercredentials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public IActionResult CrearUsuarioPorCredenciales(CreateUserDto createUserDto)
        {
            try
            {
                userConfiguration.CreateUser(createUserDto);
                return Ok(new
                {
                    message = "Usuario creado con exito, confirma tu email para iniciar sesion"
                });
            }
            catch (BussinessException e)
            {
                return Json(new
                {
                    message = e.ReasonPhrase ?? e.Message,
                    statusCode = e.StatusCode
                });
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Retorna el token del usuario si se logeo correctamente
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost("account/login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Login(UserDto userDto)
        {
            try
            {
                string token = userConfiguration.LogIn(userDto);
                return Ok(new
                {
                    response = token,
                });
            }
            catch (BussinessException e)
            {
                return Json(new
                {
                    message = e.ReasonPhrase ?? e.Message,
                    statusCode = e.StatusCode
                });
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Confirma el email del usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("account/confirmemail/{username}/{token}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConfirmEmail(string username, string token)
        {
            try
            {
                userConfiguration.ConfirmEmail(username, token);
                return Ok(new
                {
                    response = "Confirmacion exitosa, puede logearse"
                });
            }
            catch (BussinessException e)
            {
                return Json(new
                {
                    message = e.ReasonPhrase ?? e.Message,
                    statusCode = e.StatusCode
                });
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Reenvia un correo de confirmacion para habilitar un usuario
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost("account/ressendemail")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ResendConfirmEmail(UserDto userDto)
        {
            try
            {
                userConfiguration.ResendConfirmEmail(userDto);
                return Ok(new
                {
                    message = "Email enviado con éxito, confirma tu email para iniciar sesion"
                });
            }
            catch (BussinessException e)
            {
                return Json(new
                {
                    message = e.ReasonPhrase ?? e.Message,
                    statusCode = e.StatusCode
                });
            }
            catch (Exception) { throw; }
        }

        public IActionResult RecoverPassword()
        {

        }
        #endregion
    }
}
