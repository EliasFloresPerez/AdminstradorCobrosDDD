namespace Application.Dtos
{
    public class LinksTotal
    {
        public string Nombre { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public decimal Monto { get; set; } = 0.0m;

        //Id de la informacion de Cobro
        public Guid Id { get; set; } = Guid.Empty;
    }
}