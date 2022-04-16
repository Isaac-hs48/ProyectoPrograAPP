using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHVentaSegurosAPP.Services
{
    public class SaleService
    {
        public static WSHHVentaSeguros.clsVenta[] GetSales()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.clsVenta[] sales = service.GetSales();

            return sales;
        }
        public static string InsertSale(int idServicio, int idCliente, string identificacion, float totalColones, int idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.InsertSale(idServicio, idCliente, identificacion, totalColones, idCreadoPor);
        }

        public static string UpdateSale(int idVenta, int idServicio, int idCliente, string identificacion, float totalColones, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.UpdateSale(idVenta, idServicio, idCliente, identificacion, totalColones, idModificadoPor);
        }
        public static string DeleteSale(int pIdSale)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.DeleteSale(pIdSale);
        }
    }
}