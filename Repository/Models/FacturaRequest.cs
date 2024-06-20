﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class FacturaRequest
    {
        public string NroFactura { get; set; } = "";
        public DateTime FechaHora { get; set; }
        public double Total { get; set; }
        public double TotalIva5 { get; set; }
        public double TotalIva10 { get; set; }
        public double TotalIva { get; set; }
        public string TotalLetras { get; set; } = "";
        public string? Sucursal { get; set; }
        public int IdCliente { get; set; }
    }
}
