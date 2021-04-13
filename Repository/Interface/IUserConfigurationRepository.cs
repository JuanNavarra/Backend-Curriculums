namespace Repository
{
    using Dtos;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserConfigurationRepository
    {
        Task<Users> prueba();
        /// <summary>
        /// Busca si existe el usuario con su contraseña
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Users FindUser(Users users);
        /// <summary>
        /// Guarda un usuario en la base de datos
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int CreateUser(Users user);
        /// <summary>
        /// Valida si el usuario existe
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool UserExist(string username);
        /// <summary>
        /// Actualiza la entidad de usuarios
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUser(Users user);
        /// <summary>
        /// Encuentra el usuario validado por el token y el nombre del usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Users FindUserByUserNameTokenConfirm(ConfirmEmailDto user);
    }
}
