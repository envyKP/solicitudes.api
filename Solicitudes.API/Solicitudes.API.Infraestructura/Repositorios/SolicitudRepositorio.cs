using Microsoft.EntityFrameworkCore;
using Solicitudes.API.Aplicacion.Interfaces.IRepositorios;
using Solicitudes.API.Entidades.Entities;
using Solicitudes.API.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicitudes.API.Infraestructura.Repositorios
{
    public class SolicitudRepositorio : ISolicitudRepositorio
    {


        private readonly SolicitudesContextBD _context;

        public SolicitudRepositorio(SolicitudesContextBD context)
        {
            _context = context;
        }

        public async Task<string> GuardarSolicitudAsync(TBL_SOLICITUD solicitud)
        {
            try
            {
                // Aquí no insertamos directamente, sino que ejecutamos el SP
                // Llamamos al SP y pasamos los parámetros desde el DTO
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_crear_solicitudes @descripcion, @monto, @fecha_esperada, @estado, @comentario",
                    new Microsoft.Data.SqlClient.SqlParameter("@descripcion", solicitud.DESCRIPCION),
                    new Microsoft.Data.SqlClient.SqlParameter("@monto", solicitud.MONTO),
                    new Microsoft.Data.SqlClient.SqlParameter("@fecha_esperada", solicitud.FECHA_ESPERADA),
                    new Microsoft.Data.SqlClient.SqlParameter("@estado", solicitud.ESTADO),
                    new Microsoft.Data.SqlClient.SqlParameter("@comentario", solicitud.COMENTARIO)
                );

                return "Solicitud creada exitosamente.";

            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException?.Message ?? ex.Message;
                return mensajeError.Length > 400 ? mensajeError.Substring(0, 400) : mensajeError;
            }
        }
         public async Task<TBL_SOLICITUD> consultaSolicitudPorID(int id)
        {
            // Buscamos la transaccion por su ID
            return await _context.TBL_SOLICITUD.FirstOrDefaultAsync(t => t.ID == id);
        }

    }
}
