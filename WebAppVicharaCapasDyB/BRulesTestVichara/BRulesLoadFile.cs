using ADataTestVichara;
using System;
using System.IO;

namespace BRulesTestVichara
{
    public class BRulesLoadFile
    {
        public BRulesLoadFile() { }

        public string LoadFile(StreamReader sr)
        {
            ADataLoadFile ADLoad = new ADataLoadFile();
            string lbreturn = string.Empty;

            try
            {
                string texto = string.Empty;
                string linea = string.Empty;

                while ((linea = sr.ReadLine()) != null)
                {
                    texto += linea + ";"; 
                }

                lbreturn = ADLoad.LoadFile(texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lbreturn;
        }
    }
}
