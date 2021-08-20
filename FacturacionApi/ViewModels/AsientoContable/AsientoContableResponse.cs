using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionApi.ViewModels.AsientoContable
{
    public class AsientoContableResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("catalogoAuxiliarId")]
        public int CatalogoAuxiliarId { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("monedasId")]
        public int MonedasId { get; set; }

        [JsonProperty("tasaCambio")]
        public int TasaCambio { get; set; }

        [JsonProperty("catalogoAuxiliar")]
        public object CatalogoAuxiliar { get; set; }

        [JsonProperty("monedas")]
        public object Monedas { get; set; }

        [JsonProperty("transacciones")]
        public List<Transaccione> Transacciones { get; set; }


    }

    public class Transaccione
    {
        [JsonProperty("id_transaccion")]
        public int IdTransaccion { get; set; }

        [JsonProperty("cuentasContablesId")]
        public int CuentasContablesId { get; set; }

        [JsonProperty("tipoMovimientoId")]
        public int TipoMovimientoId { get; set; }

        [JsonProperty("monto")]
        public int Monto { get; set; }

        [JsonProperty("asientoId")]
        public int AsientoId { get; set; }
    }
}
