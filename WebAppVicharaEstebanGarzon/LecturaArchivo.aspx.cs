using BRulesTestVichara;
using System;
using System.IO;

public partial class LecturaArchivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCargar_Click(object sender, EventArgs e)
    {
        BRulesLoadFile loadArchivo = new BRulesLoadFile();
        string mensajeCargaDB = string.Empty;

        if (FileUpload1.HasFile)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), FileUpload1.FileName);
            FileUpload1.SaveAs(fullPath);

            using (StreamReader archivo = new StreamReader(fullPath))
            {
                mensajeCargaDB = loadArchivo.LoadFile(archivo);
            }

            if (mensajeCargaDB == string.Empty)
                lblMensaje.Text = "The file is successfully loaded into the database.";
            else
                lblMensaje.Text = "Error: " + mensajeCargaDB;
        }
        else
        {
            lblMensaje.Text = "Select a file.";
        }
    }
}