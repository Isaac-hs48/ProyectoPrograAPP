using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHVentaSegurosAPP.Services
{
    public class UserService
    {
        public static WSHHVentaSeguros.ClsUsuario[] GetUsers()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.GetUsers();
        }

        public static string CreateUser(string nombre, string usuario, string contrasena, int? idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.InsertUser(nombre, usuario, contrasena, idCreadoPor.ToString());

            return vMessage;
        }

        public static string UpdateUser(int idUsuario, string nombre, string usuario, string contrasena, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.UpdateUser(idUsuario, nombre, usuario, contrasena, idModificadoPor);

            return vMessage;
        }
        public static string DeleteUser(int userId)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            string vMessage = service.DeleteUser(userId);
            
            return vMessage;
        }
    }
}