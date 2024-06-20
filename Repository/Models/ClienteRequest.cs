namespace Repository.Models
{
    public class ClienteRequest
    {
        public int? IdBanco { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Documento { get; set; } = "";
        public string? Direccion { get; set; }
        public string? Mail { get; set; }
        public string? Celular { get; set; }
        public string? Estado { get; set; } = "ACTIVO";
    }
}
