using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADataTestVichara;
using BRulesTestVichara;

public partial class ReporteOrdenes : System.Web.UI.Page
{
    BRulesReports reports = new BRulesReports();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargaControles();
        }
    }

    private void CargaControles()
    {
        List<Ordenes> ordObjeto = new List<Ordenes>();
        ordObjeto = reports.reportOrders();

        if (ordObjeto != null)
        {
            gvReporte.DataSource = ordObjeto;
            gvReporte.DataBind();
        }
    }
}