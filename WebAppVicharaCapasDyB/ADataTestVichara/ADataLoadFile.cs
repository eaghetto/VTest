using System;
using System.Linq;

namespace ADataTestVichara
{
    public class ADataLoadFile
    {
        public ADataLoadFile() { }

        public string LoadFile(string texto)
        {
            string lbreturn = string.Empty;
            try
            {
                string[] registro = texto.Split(';');
                string[] campos;
                string itemsRegistro = string.Empty;
                string evalsCampo = string.Empty;
                string evalsCampo2 = string.Empty;

                foreach (var item in registro)
                {
                    string[] tabla = item.Split(' ');

                    if (lbreturn == string.Empty)
                    {
                        switch (tabla[0].ToString())
                        {
                            case "ContactType":
                                itemsRegistro = item.Substring(12, item.Length - 12);
                                campos = itemsRegistro.Split(',');
                                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                                {
                                    evalsCampo = campos[1].Replace(@"""", "").Replace("]", "").Trim();

                                    //Comprobamos que el ContactType no exista.
                                    var contacty = (from ct in db.ContactType
                                                    where ct.Type == evalsCampo
                                                    select ct).FirstOrDefault();

                                    if (contacty == null)
                                    {
                                        DBase.ContactType contp = new DBase.ContactType() { Type = evalsCampo };
                                        db.ContactType.Add(contp);
                                        db.SaveChanges();
                                    }
                                }
                                break;
                            case "Contact":
                                itemsRegistro = item.Substring(8, item.Length - 8);
                                campos = itemsRegistro.Split(',');
                                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                                {
                                    evalsCampo = campos[1].Replace(@"""", "").Trim();

                                    //Comprobamos que el Contact no exista.
                                    var contact = (from c in db.Contact
                                                   where c.Name == evalsCampo
                                                   select c).FirstOrDefault();

                                    if (contact == null)
                                    {
                                        int tipoContactoId = int.Parse(campos[0].Replace(@"""", "").Replace("[", "").Trim());

                                        //Comprobamos que el ContactType si exista, dado que es una llave foranea.
                                        var typeC = (from tc in db.ContactType
                                                     where tc.ContactTypeID == tipoContactoId
                                                     select tc).FirstOrDefault();

                                        if (typeC != null)
                                        {
                                            DBase.Contact con = new DBase.Contact()
                                            {
                                                TypeID = tipoContactoId,
                                                Name = campos[1].Replace(@"""", "").Trim(),
                                                Address = campos[2].Replace(@"""", "").Replace("]", "").Trim()
                                            };

                                            db.Contact.Add(con);
                                            db.SaveChanges();
                                        }
                                        else
                                            lbreturn = "The contact type to be inserted does not exist in: " + itemsRegistro;
                                    }
                                }
                                break;
                            case "Product":
                                itemsRegistro = item.Substring(8, item.Length - 8);
                                campos = itemsRegistro.Split(',');
                                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                                {
                                    evalsCampo = campos[0].Replace(@"""", "").Replace("[", "").Trim();
                                    evalsCampo2 = campos[1].Replace(@"""", "").Replace("]", "").Trim();

                                    //Comprobamos que el Product no exista(tanto por Name como por Description).
                                    var product = (from p in db.Product
                                                   where p.Name == evalsCampo && p.Description == evalsCampo2
                                                   select p).FirstOrDefault();

                                    if (product == null)
                                    {
                                        DBase.Product prod = new DBase.Product()
                                        {
                                            Name = evalsCampo,
                                            Description = evalsCampo2
                                        };

                                        db.Product.Add(prod);
                                        db.SaveChanges();
                                    }
                                }
                                break;
                            case "Order":
                                itemsRegistro = item.Substring(6, item.Length - 6);
                                campos = itemsRegistro.Split(',');
                                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                                {
                                    int custContactID = int.Parse(campos[1].Replace(@"""", "").Trim());
                                    int vendorContactID = int.Parse(campos[2].Replace(@"""", "").Trim());
                                    int productID = int.Parse(campos[3].Replace(@"""", "").Trim());

                                    //Comprobamos que el Contact del Customer si exista, dado que es una llave foranea.
                                    var custCont = (from cc in db.Contact
                                                    where cc.ContactID == custContactID
                                                    select cc).FirstOrDefault();

                                    //Comprobamos que el Contact del Vendor si exista, dado que es una llave foranea.
                                    var vendorCont = (from vc in db.Contact
                                                      where vc.ContactID == vendorContactID
                                                      select vc).FirstOrDefault();

                                    if (custCont != null && vendorCont != null)
                                    {
                                        //Comprobamos que el Product si exista, dado que es una llave foranea.
                                        var productId = (from tc in db.Product
                                                         where tc.ProductID == productID
                                                         select tc).FirstOrDefault();

                                        if (productId != null)
                                        {
                                            DBase.Order ord = new DBase.Order()
                                            {
                                                OrderDate = DateTime.Parse(campos[0].Replace(@"""", "").Replace("[", "").Trim().Substring(0, 4) + "-" + campos[0].Replace(@"""", "").Replace("[", "").Trim().Substring(4, 2) + "-" + campos[0].Replace(@"""", "").Replace("[", "").Trim().Substring(6, 2)),
                                                CustContactID = custContactID,
                                                VendorContactID = vendorContactID,
                                                ProductID = productID,
                                                Quantity = int.Parse(campos[4].Replace(@"""", "").Replace("]", "").Trim())
                                            };

                                            db.Order.Add(ord);
                                            db.SaveChanges();
                                        }
                                        else
                                            lbreturn = "The product to be inserted does not exist in: " + itemsRegistro;
                                    }
                                    else
                                        lbreturn = "The contact to be inserted does not exist in: " + itemsRegistro;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                lbreturn = ex.Message + " / " + ex.StackTrace;
            }

            return lbreturn;
        }
    }
}
