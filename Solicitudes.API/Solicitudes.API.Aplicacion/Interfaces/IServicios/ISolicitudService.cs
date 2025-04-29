using Solicitudes.API.Entidades.DTOs;
using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Interfaces.IServicios
{
    public interface ISolicitudService
    {
        Task<string> CrearSolicitudAsync(SolicitudDTO solicitudDTO);
        public Task<SolicitudDTO> consultaSolicitudPorID(int id);
        Task<string> ActualizarEstadoSolicitudAsync(int id, string nuevoEstado);

        
    }
}
