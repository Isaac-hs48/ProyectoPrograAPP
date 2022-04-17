using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHVentaSegurosAPP.Services
{
    public class ServicesService
    {
        public static WSHHVentaSeguros.clsServicio[] GetServices()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.clsServicio[] services = service.GetServices();

            return services;
        }
        public static string InsertService(string tipoServicio, double precioColones, int idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.InsertService(tipoServicio, precioColones, idCreadoPor);
        }

        public static string UpdateService(int idServicio, string tipoServicio, float precioColones, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.UpdateService(idServicio, tipoServicio, precioColones, idModificadoPor);
        }
        public static string DeleteService(int pIdService)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.DeleteService(pIdService);
        }
    }
}