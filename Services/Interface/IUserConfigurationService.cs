namespace Services
{
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserConfigurationService
    {
        Task<Users> prueba();
        /// <summary>
        /// Genera el token para logearse
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        string LogIn(UserDto userDto);
        /// <summary>
        /// Guarda un usuario
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        void CreateUser(CreateUserDto createUserDto);
        /// <summary>
        /// Confirma el email retornando un string de confirmacion
        /// </summary>
        /// <param name="username"></param>
        /// <param name="token"></param>
        void ConfirmEmail(string username, string token);
        /// <summary>
        /// Reenvia un correo de confirmacion para habilitar un usuario
        /// </summary>
        /// <param name="userDto"></param>
        void ResendConfirmEmail(UserDto userDto);
    }
}
