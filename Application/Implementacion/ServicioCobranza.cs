using Domain.Entidades;

using Application.Abstracto;
using Application.Dtos;

using Domain.Abstracto;
using Domain.Repositorios;


namespace Application.Implementacion
{
    public class ServicioCobranza : IServicioCobranza
    {
        
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepositorioCliente _IRepositorioCliente;

        private readonly IRepositorioInfCobro _IRepositorioInfCobro;
        public ServicioCobranza(IRepositorioCliente IRepositorioCliente, IUnitOfWork unitOfWork, IRepositorioInfCobro IRepositorioInfCobro)
        {
            _IRepositorioCliente = IRepositorioCliente;
            _unitOfWork = unitOfWork;
            _IRepositorioCliente = IRepositorioCliente;
            _IRepositorioInfCobro = IRepositorioInfCobro;
        }


        public async Task<CResponse> AgregarInformacionCobroAsync(LinkDePago infoCobroDto)
        {

            //Validamos que el Monto no sea menor a 0
            if (infoCobroDto.Monto < 0)
            {
                throw new Exception("El monto no puede ser menor a 0.");
                
            }

            
            Cliente? cliente = new Cliente();
            bool existeCliente = true;
            //Verificamos que el nombre no exista en la base de datos
            cliente = await _IRepositorioCliente.ObtenerPorNombreAsync(infoCobroDto.Nombre);
            if (cliente == null)
            {
                existeCliente = false;
                //Creamos la entidad cliente
                cliente = new Cliente()
                {
                    Nombre = infoCobroDto.Nombre,
                    InformacionesCobro = new List<InformacionCobro>()
                };
            }

            // A Este cliente se le agrega la informacion de cobro
            
            InformacionCobro infocobro =  new InformacionCobro(){
                Descripcion = infoCobroDto.Motivo,
                Total = infoCobroDto.Monto,
            };

            cliente.InformacionesCobro.Add(infocobro);

            // Guardamos el cliente y la informacion de cobro en la base de datos
            
            if (existeCliente == false){
                _IRepositorioCliente.Agregar(cliente);
            }

            
            await _unitOfWork.CommitAsync();

            return new CResponse { statusCode = 200, message = "Informacion de cobro agregada correctamente." };
        }

        //Dado un Id de Informacion de cobro, eliminamos la informacion de cobro
        public async Task<CResponse> EliminarInformacionCobroAsync(Guid idInformacionCobro)
        {
            // Buscamos la informacion de cobro por su Id
            InformacionCobro? infoCobro = await _IRepositorioInfCobro.ObtenerPorIdAsync(idInformacionCobro);

            if (infoCobro != null)
            {
                // Cambiamos el estado a false
                infoCobro.Estado = false;
                //_IRepositorioInfCobro.Eliminar(infoCobro);
                await _unitOfWork.CommitAsync();

                return new CResponse { statusCode = 200, message = "Informacion de cobro eliminada correctamente." };
            }
            else
            {
                //return new CResponse { statusCode = 404, message = "Informacion de cobro no encontrada." };
                //Enviamos un throw de error
                throw new Exception("Informacion de cobro no encontrada.");
            }
        }

        //Dado un nombre de cliente, buscamos la informacion de cobro
        public async Task<List<LinksTotal>> ObtenerInformacionCobroPorNombreAsync(string nombre)
        {
            // Buscamos el cliente por su nombre
            Cliente? cliente = await _IRepositorioCliente.ObtenerPorNombreAsync(nombre);

            

            if (cliente != null)
            {
                // Obtenemos la información de cobro del cliente
                IEnumerable<InformacionCobro> infoCobroEnumerable = await _IRepositorioInfCobro.ObtenerPorClienteIdAsync(cliente.Id);

                // Convertimos el IEnumerable a una lista
                List<InformacionCobro> infoCobro = infoCobroEnumerable.ToList();

                // Verificamos si se obtuvo información de cobro
                if (infoCobro.Any()) // Puedes usar .Any() para verificar si hay elementos
                {
                    List<LinksTotal> linksTotal = new List<LinksTotal>();

                    foreach (var item in infoCobro)
                    {

                        linksTotal.Add(new LinksTotal()
                        {
                            Nombre = cliente.Nombre,
                            Motivo = item.Descripcion,
                            Monto = item.Total,
                            Id = item.Id
                        });
                    }

                    return linksTotal;
                }

            }
                        
            return new List<LinksTotal>();
        }
}
}
        