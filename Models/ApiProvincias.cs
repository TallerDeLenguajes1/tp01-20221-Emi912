using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAppPrueba.Models
{
    public class ApiProvincias
    {
        public List<Provincia> provincias;

        public ApiProvincias()
        {
            provincias = GetProvincias();
        }

        private List<Provincia> GetProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            Provincias ProvinciasArgentinas = null;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                ProvinciasArgentinas = JsonSerializer.Deserialize<Provincias>(responseBody);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Hubo un error con el servicio web");
            }

            return ProvinciasArgentinas.provincias;
        }
    }
}
