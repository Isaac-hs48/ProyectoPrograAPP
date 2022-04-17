using HHVentaSegurosAPP.Services;
using HHVentaSegurosAPP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HHVentaSegurosAPP
{
    public partial class SalePage : System.Web.UI.Page
    {
        public static List<string> CustomerList { get; set; }
        public static List<string> ServicesList { get; set; }
        private void FillDataGrid()
        {
            WSHHVentaSeguros.clsVenta[] sales = SaleService.GetSales();
            grdVenta.DataSource = null;
            grdVenta.DataBind();
            grdVenta.DataSource = sales;
            grdVenta.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CustomerList = new List<string>();
                ServicesList = new List<string>();
                InitVariables();
                FillDataGrid();
                ViewState["Mode"] = 'C';
                ViewState["ShowAlert"] = false;
                FillCustomerList();
                FillServicesList();
            }
        }
        private void InitVariables()
        {
            btnGuardarVenta.Enabled = false;
            txtIdVenta.Enabled = false;
            servicesList.Enabled = false;
            customerList.Enabled = false;
            txtIdentificacion.Enabled = false;
            txtTotalColones.Enabled = false;
        }

        private void EnableInputs(bool enabled)
        {
            btnGuardarVenta.Enabled = enabled;
            servicesList.Enabled = enabled;
            customerList.Enabled = enabled;
            txtIdentificacion.Enabled = enabled;
        }

        private void ClearInputs()
        {
            txtIdVenta.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
        }

        protected void dissmisAlert_Click(object sender, EventArgs e)
        {
            ViewState["ShowAlert"] = false;
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = 'C';
            ClearInputs();
            EnableInputs(true);
        }

        protected void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (ViewState["Mode"].ToString() == "C")
            {
                message = SaleService.InsertSale((Convert.ToInt32(servicesList.SelectedValue.Split(' ')[0])), Convert.ToInt32(customerList.SelectedValue.Split(' ')[0]), txtIdentificacion.Text, Convert.ToInt32(txtTotalColones.Text), Master.currUser.IdUsuario);
            }
            else
            {
                message = SaleService.UpdateSale(Convert.ToInt32(txtIdVenta.Text), (Convert.ToInt32(servicesList.SelectedValue.Split(' ')[0])), Convert.ToInt32(customerList.SelectedValue.Split(' ')[0]), txtIdentificacion.Text, Convert.ToInt32(txtTotalColones.Text), Master.currUser.IdUsuario);
            }

            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
            FillDataGrid();
            ClearInputs();
            EnableInputs(false);
        }

        protected void btnDepreciacion_Click(object sender, EventArgs e)
        {
            
        }

        protected void grdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = grdVenta.SelectedRow;

            txtIdVenta.Text = selectedRow.Cells[0].Text;
            servicesList.SelectedValue = SetListSelectedValue(Convert.ToInt32(selectedRow.Cells[1].Text), ServicesList);
            customerList.SelectedValue = SetListSelectedValue(Convert.ToInt32(selectedRow.Cells[2].Text), CustomerList);
            txtIdentificacion.Text = selectedRow.Cells[3].Text;
            txtTotalColones.Text = selectedRow.Cells[4].Text;

            ViewState["Mode"] = 'M';

            EnableInputs(true);
        }

        protected void grdVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idVenta = Convert.ToInt32(grdVenta.Rows[e.RowIndex].Cells[0].Text);

            string message = SaleService.DeleteSale(idVenta);

            FillDataGrid();
            clsShared.ShowAlert(alertMessage, message);
            ViewState["ShowAlert"] = true;
        }

        protected void FillCustomerList()
        {
            WSHHVentaSeguros.ClsCliente[] clientes = CustomerService.GetCustomers();

            foreach (WSHHVentaSeguros.ClsCliente customer in clientes)
            {
                CustomerList.Add(String.Format("{0} {1}", customer.IdCliente, customer.NombreCompleto));
            }

            customerList.DataSource = null;
            customerList.DataBind();
            customerList.DataSource = CustomerList;
            customerList.DataBind();
        }

        protected void FillServicesList()
        {
            WSHHVentaSeguros.clsServicio[] services = ServicesService.GetServices();

            foreach (WSHHVentaSeguros.clsServicio service in services)
            {
                ServicesList.Add(String.Format("{0} {1}", service.idServicio, service.tipoServicio));
            }

            servicesList.DataSource = null;
            servicesList.DataBind();
            servicesList.DataSource = ServicesList;
            servicesList.DataBind();
        }

        protected string SetListSelectedValue(int _objectID, List<string> _list)
        {
            return _list.Find(c => Convert.ToInt32(c.Split(' ')[0]) == _objectID);
        }

        protected void ServicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WSHHVentaSeguros.clsServicio[] servicios = ServicesService.GetServices();

            double precio = servicios.FirstOrDefault(s => s.idServicio == Convert.ToInt32(servicesList.SelectedValue.Split(' ')[0])).precioColones;

            txtTotalColones.Text = precio.ToString();
        }
    }
}