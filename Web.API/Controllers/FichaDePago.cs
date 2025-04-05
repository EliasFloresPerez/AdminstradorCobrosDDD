using Microsoft.AspNetCore.Mvc;
using Application.Abstracto;
using Application.Dtos;


namespace Web.API.Controladores;


[Route("api/[controller]")]
[ApiController]

public class FichaDePagoController : ControllerBase
{
   
    private readonly IServicioCobranza _servicioCobranza;

    public FichaDePagoController(IServicioCobranza servicioCobranza)
    {
        _servicioCobranza = servicioCobranza;
    }

    [HttpPost("AgregarInformacionCobro")]

    public async Task<CResponse> AgregarInformacionCobro([FromBody] LinkDePago infoCobroDto)
    {
        var response = await _servicioCobranza.AgregarInformacionCobroAsync(infoCobroDto);

        return response;
    }

    [HttpDelete("EliminarInformacionCobro/{idInformacionCobro}")]
    public async Task<CResponse> EliminarInformacionCobro(Guid idInformacionCobro)
    {
        var response = await _servicioCobranza.EliminarInformacionCobroAsync(idInformacionCobro);
        
        return response;

    }
    [HttpGet("ObtenerInformacionCobroPorNombre/{nombre}")]
    public async Task<IActionResult> ObtenerInformacionCobroPorNombre(string nombre)
    {
        var response = await _servicioCobranza.ObtenerInformacionCobroPorNombreAsync(nombre);
        return Ok(response);
    }
}


