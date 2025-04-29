using Microsoft.AspNetCore.Mvc;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;
using Solicitudes.API.Entidades.DTOs;

namespace Solicitudes.API.Controllers
{
    public class SolicitudController : Controller

    {
        private readonly ISolicitudService _solicitudService;

        // Constructor
        public SolicitudController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }


        // POST api/solicitud
        [HttpPost("crearSolicitud")]
        public async Task<IActionResult> CrearSolicitud([FromBody] SolicitudDTO solicitudDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos de solicitud inválidos.");
            var resultado = await _solicitudService.CrearSolicitudAsync(solicitudDTO);
            if (resultado.ToLower().Contains("error") || resultado.ToLower().Contains("excepción") || resultado.ToLower().Contains("problema"))
                return BadRequest(resultado);

            return Ok(resultado);
        }
        
        [HttpGet("solicitud/{id}")]
         public async Task<IActionResult> consultaSolicitudPorID(int id)
        {
            if (id == null)
            {
                return BadRequest("ID de transacción inválido.");
            }
            var transaccion = await _solicitudService.consultaSolicitudPorID(id);
            if (transaccion == null)
            {
                return NotFound("No se encontró la Solicitud con el ID proporcionado.");
            }
            return Ok(transaccion);
        }

/*
        [HttpPut("actualizarEstado/{id}")]
        public async Task<IActionResult> ActualizarEstadoSolicitud(int id, [FromBody] string nuevoEstado)
        {
            if (id == null)
            {
                return BadRequest("ID de solicitud inválido.");
            }
            if (string.IsNullOrEmpty(nuevoEstado))
            {
                return BadRequest("El nuevo estado no puede estar vacío.");
            }

            var resultado = await _solicitudService.ActualizarEstadoSolicitudAsync(id, nuevoEstado);
            if (resultado.ToLower().Contains("error") || resultado.ToLower().Contains("excepción") || resultado.ToLower().Contains("problema"))
                return BadRequest(resultado);

            return Ok(resultado);
        }*/
    }
}
