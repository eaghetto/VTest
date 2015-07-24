using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADataTestVichara;

namespace BRulesTestVichara
{
    public class BRulesReports
    {
        ADataSReports adReport = new ADataSReports();

        public BRulesReports() { }

        public List<Ordenes> reportOrders()
        {
            try
            {
                List<Ordenes> lbreturn = new List<Ordenes>();

                lbreturn = adReport.reportOrders();

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

                lbreturn = adReport.reportCustomers();

                return lbreturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
