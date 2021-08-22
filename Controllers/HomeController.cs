using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppPrueba.Models;

namespace WebAppPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public string Practica(string a, string b)
        {
            int A;
            int B;
            try
            {
                A = int.Parse(a);
                B = int.Parse(b);
               return Convert.ToString(A + B);
            } catch (FormatException E)
            {
                return "Error en el formato escrito " + E.Message; 

            }catch(OverflowException E)
            {
                return "Escribiste un numero muy grande " + E.Message;
            }catch(Exception E)
            {
                return "Hubo un error intenta nuevamente " + E.Message;
            }
           
        }

        public string Problema1(string a)
        {
            try
            {
                int B = int.Parse(a);
                B = B * B;
                return Convert.ToString(B);
            }catch(FormatException E)
            {
                return "Error en el formato escrito " + E.Message;

            }catch (OverflowException E)
            {
                return "Escribiste un numero muy grande, intenta nuevamente " + E.Message;
            }
            catch (Exception E)
            {
                return "Hubo un error intenta nuevamente " + E.Message;
            }
        }

        public string Problema2(string a, string b)
        {
            int A;
            int B;
            try
            {
                A = int.Parse(a);
                B = int.Parse(b);
                return Convert.ToString(A / B);
            }
            catch (FormatException E)
            {
                return "Error en el formato escrito " + E.Message;

            }
            catch (OverflowException E)
            {
                return "Escribiste un numero muy grande " + E.Message;
            }
            catch (Exception E)
            {
                return "Hubo un error intenta nuevamente " + E.Message;
            }

        }

        public string Problema3()
        {
            ApiProvincias apiProvincias = new ApiProvincias();
            string ListadoProvincias = "";
            foreach (var item in apiProvincias.provincias)
            {
                ListadoProvincias += $"{item.nombre} Id = {item.id} \n";
            }

            return ListadoProvincias;


        }

        public string Problema4(string a, string b)
        {
            int C;
            int A;
            int B;
            try
            {
                A = int.Parse(a);
                B = int.Parse(b);
                C = A / B;
                return $"Kilometros por litro: {Convert.ToString(C)} K/L";
            }
            catch (FormatException E)
            {
                return "Error en el formato escrito " + E.Message;

            }
            catch (OverflowException E)
            {
                return "Escribiste un numero muy grande, intenta nuevamente " + E.Message;
            }
            catch (Exception E)
            {
                return "Hubo un error intenta nuevamente " + E.Message;
            }

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
