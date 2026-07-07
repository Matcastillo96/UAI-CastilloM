using System.Collections.Generic;
using DIEFER.Servicios;

namespace DIEFER.DAL.Interfaces
{
    /// <summary>
    /// Contrato de acceso a datos para la asignación de permisos
    /// (familias y patentes) a roles.
    /// </summary>
    public interface IRolPermisoDAL_593CM
    {
        /// <summary>Patentes asignadas directamente al rol (no incluye las heredadas vía familias).</summary>
        List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol);

        /// <summary>Familias asignadas directamente al rol.</summary>
        List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol);

        bool AgregarPatente_593CM(int idRol, int idPatente);
        bool AgregarFamilia_593CM(int idRol, int idFamilia);
        bool QuitarPatente_593CM(int idRol, int idPatente);
        bool QuitarFamilia_593CM(int idRol, int idFamilia);

        /// <summary>
        /// Agrega una familia a un rol y, en la misma transacción nativa, quita
        /// las patentes/familias directas que quedaron redundantes. Evita abrir
        /// varias conexiones dentro de una transacción ambiente (lo que forzaría
        /// una promoción a transacción distribuida/MSDTC).
        /// </summary>
        bool AgregarFamiliaConLimpieza_593CM(
            int idRol,
            int idFamilia,
            IEnumerable<int> idsPatentesAQuitar,
            IEnumerable<int> idsFamiliasAQuitar);
    }
}
