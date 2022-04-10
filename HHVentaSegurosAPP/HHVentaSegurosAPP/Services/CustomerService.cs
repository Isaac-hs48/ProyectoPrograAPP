using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HHVentaSegurosAPP.Services
{
    public class CustomerService
    {
        public static WSHHVentaSeguros.ClsCliente[] GetCustomers()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.ClsCliente[] customers = service.GetCustomers();

            return customers;
        }
        public static string InsertCustomer(string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, int idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.InsertCustomer(nombre, tipoCedula, numeroCedula, numeroTelefono, correoElectronico, idCreadoPor);
        }
        
        public static string UpdateCustomer(int idCliente, string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.UpdateCustomer(idCliente, nombre, tipoCedula, numeroCedula, numeroTelefono, correoElectronico, idModificadoPor);
        }
        public static string DeleteCustomer(int pIdCustomer)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.DeleteCustomer(pIdCustomer);
        }
    }
}