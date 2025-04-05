using Microsoft.AspNetCore.Mvc;
using Application.Abstracto;
using Application.Dtos;


namespace Web.API.Controladores;


[Route("api/[controller]")]
[ApiController]

public class FichaDePagoController : ControllerBase
{
   
    private readonly IServicioCobranza _repositorioInfCobro;

    public FichaDePagoController(IServicioCobranza repositorioInfCobro)
    {
        _repositorioInfCobro = repositorioInfCobro;
    }

    [HttpPost("AgregarInformacionCobro")]

    public async Task<IActionResult> AgregarInformacionCobro([FromBody] LinkDePago infoCobroDto)
    {
        var response = await _repositorioInfCobro.AgregarInformacionCobroAsync(infoCobroDto);
        return Ok(response);
    }

    [HttpDelete("EliminarInformacionCobro/{idInformacionCobro}")]
    public async Task<IActionResult> EliminarInformacionCobro(Guid idInformacionCobro)
    {
        var response = await _repositorioInfCobro.EliminarInformacionCobroAsync(idInformacionCobro);
        return Ok(response);
    }
    [HttpGet("ObtenerInformacionCobroPorNombre/{nombre}")]
    public async Task<IActionResult> ObtenerInformacionCobroPorNombre(string nombre)
    {
        var response = await _repositorioInfCobro.ObtenerInformacionCobroPorNombreAsync(nombre);
        return Ok(response);
    }
}


