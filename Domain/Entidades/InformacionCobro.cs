using Domain.Abstracto;

namespace Domain.Entidades
{
    public class InformacionCobro : IEntity
    {
        public Guid Id { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        // Total a cobrar por este concepto
        public decimal Total { get; set; } = 0.0m;

        // Relación con Cliente
        public Guid ClienteId { get; set; }  // Clave foránea
        public virtual Cliente? Cliente { get; set; }  // Navegación inversa

        //Fecha de estado y creación
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool Estado { get; set; } = true;
        
    }
}
