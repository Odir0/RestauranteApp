using System;

namespace RestauranteApp.Models
{
    public class CierreDiario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
