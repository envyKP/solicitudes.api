using AutoMapper;
using Solicitudes.API.Aplicacion.Interfaces.IRepositorios;
using Solicitudes.API.Aplicacion.Interfaces.IServicios;
using Solicitudes.API.Entidades.DTOs;
using Solicitudes.API.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Aplicacion.Servicios
{
    public class SolicitudService : ISolicitudService
    {

        private readonly ISolicitudRepositorio _repositorio;
        private readonly IMapper _mapper;


        public SolicitudService(ISolicitudRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<string> CrearSolicitudAsync(SolicitudDTO solicitudDTO)
        {
            try
            {
                var solicitudEntity = _mapper.Map<TBL_SOLICITUD>(solicitudDTO);
                var resultado = await _repositorio.GuardarSolicitudAsync(solicitudEntity);
                return resultado.Length > 400
                    ? resultado.Substring(0, 400)
                    : resultado;
            }
            catch (Exception ex)
            {
                var mensajeError = $"Error al crear la solicitud: {ex.Message}";
                return mensajeError.Length > 400
                    ? mensajeError.Substring(0, 400)
                    : mensajeError;
            }
        }
    public async Task<SolicitudDTO> consultaSolicitudPorID(int id)
        {
            try
            {   // consulto la transaccion de la capa de repositorio
                var trxExistente = await _repositorio.consultaSolicitudPorID(id);
                // Si no se encuentra retornar null
                if (trxExistente == null)
                {
                    return null;
                }
                // Mapear la entidad a DTO
                var SolicitudDTO = _mapper.Map<SolicitudDTO>(trxExistente);

                return SolicitudDTO;
            }
            catch (Exception ex)
            {
                // Manejo de error y retornando null si ocurre un fallo
                return null;
            }
        }
        

    }
}
