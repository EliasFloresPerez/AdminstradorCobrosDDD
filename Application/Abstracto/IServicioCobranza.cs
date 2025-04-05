using Application.Base;
using Application.Dtos;



namespace Application.Abstracto
{
    public interface IServicioCobranza : IService
    {
        
        //Funcionalidades para agregar y elminar Links de Pagos
        Task<CResponse> AgregarInformacionCobroAsync(LinkDePago infoCobroDto);

        Task<CResponse> EliminarInformacionCobroAsync(Guid idInformacionCobro);

        //Funcionalidades para obtener Links de Pagos por nombre 
        Task<List<LinksTotal>> ObtenerInformacionCobroPorNombreAsync(string nombre);
    }
}