using System;
using System.Collections.Generic;
using DIEFER.BE;

namespace DIEFER.DAL
{
    // Contrato de acceso a datos para la entidad Eventos_593CM (bitácora).
    public interface IEventoDAL_593CM
    {
        void Insertar_593CM(Eventos_593CM e);
        List<Eventos_593CM> GetByFiltro_593CM(DateTime? fechaIni, DateTime? fechaFin,
                                               string login, string modulo,
                                               string evento, int? criticidad);
    }
}
