using FacturacionApi.Models.Entities;
using FacturacionApi.ViewModels.AsientoContable;
using FacturacionApi.ViewModels.Facturacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FacturacionApi.Services
{
    public class ContabilidadService : IDisposable
    {
        HttpClient _client;

        public ContabilidadService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://contabilidad2021.azurewebsites.net/api/")
            };
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            //Hope it works
        }

        public void GetAsientoContable(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"Asientos/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var asiento326 = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public FacturacionViewModel PostAsientoContable(FacturacionViewModel factura)
        {
            AsientoContableRequest request = new();


            request.Fecha = factura.Fecha.ToString("yyyy-MM-dd");
            request.Descripcion = factura.Cliente;
            foreach (var item in factura.Detalle)
            {
                request.Transacciones.Add(new()
                {
                    CuentasContablesId = item.Id,
                    Monto = item.Cantidad,
                    TipoMovimientoId = 1

                });
            }

            var response = _client.PostAsJsonAsync("Asientos", request).Result;

            if (response.IsSuccessStatusCode)
            {
                var asientoContableResponse = JsonConvert.DeserializeObject<AsientoContableResponse>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in factura.Detalle)
                {
                    item.IdAsiento = asientoContableResponse.Transacciones.Where(x => x.CuentasContablesId == item.Id).Select(x => x.AsientoId).FirstOrDefault();
                }
                
            }
            else
                Console.Write("Error");

            return factura;

        }
    }
}
