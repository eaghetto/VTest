using ADataTestVichara;
using BRulesTestVichara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReporteCompradores : System.Web.UI.Page
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
        ordObjeto = reports.reportCustomers();

        if (ordObjeto != null)
        {
            gvReporte.DataSource = ordObjeto;
            gvReporte.DataBind();
        }
    }
}