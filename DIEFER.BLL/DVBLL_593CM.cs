using System.Collections.Generic;
using System.Linq;
using DIEFER.DAL;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.BLL
{
    /// <summary>
    /// Orquesta las operaciones de Dígito Verificador para la UI y otras BLL.
    /// </summary>
    public class DVBLL_593CM : IDVBLL_593CM
    {
        private readonly DVService_593CM _dvService_593CM;
        private readonly EventoBLL_593CM _eventoBLL_593CM;

        public DVBLL_593CM() : this(new DVDAL_593CM(), new EventoBLL_593CM()) { }

        public DVBLL_593CM(IDVDAL_593CM dvDAL, EventoBLL_593CM eventoBLL)
        {
            _dvService_593CM = new DVService_593CM(dvDAL, dvDAL.Proveedores_593CM);
            _eventoBLL_593CM = eventoBLL;
        }

        /// <summary>Verifica la integridad de todas las tablas controladas sin modificar DV.</summary>
        public List<string> VerificarIntegridad_593CM()
        {
            return _dvService_593CM.VerificarIntegridad_593CM();
        }

        /// <summary>Recalcula el DV de una sola tabla (sin registrar bitácora).</summary>
        public void RecalcularTabla_593CM(string nombreTabla)
        {
            _dvService_593CM.RecalcularTabla_593CM(nombreTabla);
        }

        /// <summary>
        /// Recalcula el DV de una tabla controlada y registra el evento de negocio.
        /// Si la tabla no es EVENTOS, también normaliza el DV de EVENTOS para
        /// reflejar el nuevo registro de bitácora.
        /// </summary>
        public void RecalcularTablaConBitacora_593CM(string nombreTabla, string login,
                                                     string modulo, string evento, int criticidad)
        {
            _eventoBLL_593CM.Registrar_593CM(login, modulo, evento, criticidad);
            _dvService_593CM.RecalcularTabla_593CM(nombreTabla);

            if (nombreTabla != "EVENTOS")
                _dvService_593CM.RecalcularTabla_593CM("EVENTOS");
        }

        /// <summary>
        /// Recalcula el DV de todas las tablas controladas (CU-103).
        /// Registra la acción en bitácora y normaliza EVENTOS al final.
        /// Retorna la lista de tablas que aún presentan inconsistencias (vacía si OK).
        /// </summary>
        public List<string> RecalcularTodo_593CM(string login)
        {
            var tablas = _dvService_593CM.VerificarIntegridad_593CM()
                .Union(new[] { "EVENTOS" })
                .Distinct()
                .ToList();

            foreach (string tabla in tablas)
            {
                if (tabla != "EVENTOS")
                    _dvService_593CM.RecalcularTabla_593CM(tabla);
            }

            _eventoBLL_593CM.Registrar_593CM(login, "Servicio", "Recalcular DV", 1);
            _dvService_593CM.RecalcularTabla_593CM("EVENTOS");

            return _dvService_593CM.VerificarIntegridad_593CM();
        }
    }
}
