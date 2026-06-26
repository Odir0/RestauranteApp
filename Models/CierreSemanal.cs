using System;

namespace RestauranteApp.Models
{
    public class CierreSemanal
    {
        public int Id { get; set; }
        public DateTime SemanaInicio { get; set; }
        public DateTime SemanaFin { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
