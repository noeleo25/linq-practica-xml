using System;
using System.Linq;
using System.Xml.Linq;

namespace LQPracticaXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LINQ de archivo XML
            var archivo = @"C:\Users\noemi\source\repos\LQPracticaXML\pagos.xml";
            //Ej 1
            var docXml = XDocument.Load(archivo);
            var pagosProcesados = docXml.Element("pagos").Elements("pago")
                .Where(p => p.Attribute("procesado").Value == "true")
                .Select(pg => pg.Element("descripcion").Value);
            
           foreach(var p in pagosProcesados)
           {
                Console.WriteLine(p);
           }
           //Ej 2
           var pagos = docXml.Descendants("pago")
                .Where(p => p.Attribute("procesado")?.Value == "true")
                .Select(pg => new Tuple<string, bool, string, float>
                                (pg.Attribute("idEmpleado").Value,
                                 bool.Parse(pg.Attribute("firmado").Value),
                                 pg.Element("descripcion").Value,
                                 float.Parse(pg.Element("montoBase").Value)
                                )
                       );

            #endregion
        }
    }
}
