using Domain.Abstracto;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Cliente : IEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        //Informacion de Estado y Fecha de Creacion
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool Estado { get; set; } = true;

        // Relación uno a muchos con InformacionCobro
        public virtual ICollection<InformacionCobro> InformacionesCobro { get;  set; } = new List<InformacionCobro>();

        public Cliente(string nombre, IEnumerable<InformacionCobro> informacionesCobro)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;

            InformacionesCobro = informacionesCobro.ToList();
        }

        public Cliente()
        {
            Id = Guid.NewGuid();
            Nombre = "";

            InformacionesCobro = new List<InformacionCobro>();
        }

        // Puedes agregar métodos para manejar la relación, por ejemplo:
        public void AgregarInformacionCobro(InformacionCobro infoCobro)
        {
            InformacionesCobro.Add(infoCobro);
        }
    }
}
