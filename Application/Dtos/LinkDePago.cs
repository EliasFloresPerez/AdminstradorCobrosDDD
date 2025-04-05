
/*

Clase para rescibir la informacion del Link de Pago

*Nombre
*Motivo
*Monto
*/

namespace Application.Dtos
{
    public class LinkDePago
    {
        public string Nombre { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public decimal Monto { get; set; } = 0.0m;
    }
}