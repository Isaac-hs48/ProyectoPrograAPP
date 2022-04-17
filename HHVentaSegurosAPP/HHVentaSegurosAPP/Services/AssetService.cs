﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHVentaSegurosAPP.Services
{
    public class AssetService
    {
        public static WSHHVentaSeguros.clsActivo[] GetAsset()
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            WSHHVentaSeguros.clsActivo[] assets = service.GetAssets();

            return assets;
        }
        public static string InsertAsset(string descripcion, float precioColones, int vidaUtilAnos, float valorDesechoColones, int idCreadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.InsertAsset(descripcion, precioColones, vidaUtilAnos, valorDesechoColones, idCreadoPor);
        }

        public static string UpdateAsset(int idActivo, string descripcion, float precioColones, int vidaUtilAnos, float valorDesechoColones, int idModificadoPor)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.UpdateAsset(idActivo, descripcion, precioColones, vidaUtilAnos, valorDesechoColones, idModificadoPor);
        }
        public static string DeleteAsset(int pIdAsset)
        {
            WSHHVentaSeguros.HHVentaSergurosWS service = new WSHHVentaSeguros.HHVentaSergurosWS();

            return service.DeleteAsset(pIdAsset);
        }
    }
}