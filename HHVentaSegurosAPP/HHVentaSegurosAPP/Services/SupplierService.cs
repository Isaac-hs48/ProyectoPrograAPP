using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHVentaSegurosAPP.Services
{
    public class SupplierService
    {
        public static WSHHVentaSeguros.ClsProveedor[] GetSuppliers()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.ClsProveedor[] suppliers = service.GetSuppliers();

            return suppliers;
        }
        public static string InsertSupplier(string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, string descripcion, int idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.InsertSupplier(nombre, tipoCedula, numeroCedula, numeroTelefono, correoElectronico, descripcion, idCreadoPor);
        }

        public static string UpdateSupplier(int idCliente, string nombre, string tipoCedula, string numeroCedula, string numeroTelefono, string correoElectronico, string descripcion, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.UpdateSupplier(idCliente, nombre, tipoCedula, numeroCedula, numeroTelefono, correoElectronico, descripcion, idModificadoPor);
        }
        public static string DeleteSupplier(int pIdSupplier)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.DeleteSupplier(pIdSupplier);
        }
    }
}