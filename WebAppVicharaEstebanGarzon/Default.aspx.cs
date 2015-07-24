using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lkbuttonDB_Click(object sender, EventArgs e)
    {
        Response.Redirect("LecturaArchivo.aspx");
    }

    protected void lkbuttonRep_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteOrdenes.aspx");
    }

    protected void lkbuttonRep2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteCompradores.aspx");
    }
}