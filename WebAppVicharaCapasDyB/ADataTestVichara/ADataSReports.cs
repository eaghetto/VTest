using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADataTestVichara
{
    public class ADataSReports
    {
        public ADataSReports() { }

        public List<Ordenes> reportOrders()
        {
            try
            {
                List<Ordenes> lbreturn = new List<Ordenes>();

                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                {
                    List<Ordenes> repOrdenes = (from ro in db.Order
                                                join c in db.Contact on ro.CustContactID equals c.ContactID
                                                join cv in db.Contact on ro.VendorContactID equals cv.ContactID
                                                join p in db.Product on ro.ProductID equals p.ProductID
                                                orderby ro.OrderDate
                                                select new Ordenes
                                                {
                                                    CustomerName = c.Name,
                                                    VendorName = cv.Name,
                                                    ProductName = p.Name,
                                                    ProductDesc = p.Description,
                                                    Quantities = ro.Quantity.Value,
                                                    DateOrder = ro.OrderDate.Value
                                                }).ToList<Ordenes>();
                    
                    lbreturn = repOrdenes;
                }

                return lbreturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenes> reportCustomers()
        {
            try
            {
                List<Ordenes> lbreturn = new List<Ordenes>();

                using (DBase.Esteban_Garzon_DBEntities db = new DBase.Esteban_Garzon_DBEntities())
                {
                    List<Ordenes> repCompradores = (from ro in db.Order
                                                    join c in db.Contact on ro.CustContactID equals c.ContactID
                                                    group c by c.Name into comp
                                                    select new Ordenes
                                                    {
                                                        CustomerName = comp.Key,
                                                        Quantities = comp.Count()
                                                    }).ToList<Ordenes>();

                    lbreturn = repCompradores;
                }

                return lbreturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
