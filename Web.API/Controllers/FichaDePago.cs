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

    public async Task<IActionResult> AgregarInformacionCobro([FromBody] LinkDePago infoCobroDto)
    {
        var response = await _servicioCobranza.AgregarInformacionCobroAsync(infoCobroDto);
        return Ok( response.message);

    }

    [HttpDelete("EliminarInformacionCobro/{idInformacionCobro}")]
    public async Task<IActionResult> EliminarInformacionCobro(Guid idInformacionCobro)
    {
        var response = await _servicioCobranza.EliminarInformacionCobroAsync(idInformacionCobro);
        
        return Ok(response.message);

    }
    [HttpGet("ObtenerInformacionCobroPorNombre/{nombre}")]
    public async Task<IActionResult> ObtenerInformacionCobroPorNombre(string nombre)
    {
        var response = await _servicioCobranza.ObtenerInformacionCobroPorNombreAsync(nombre);
        return Ok(response);
    }

}


