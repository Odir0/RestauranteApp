using System;

namespace RestauranteApp.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime CreadoEn { get; set; }
    }
}
