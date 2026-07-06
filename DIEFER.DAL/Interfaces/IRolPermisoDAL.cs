using System.Collections.Generic;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    /// <summary>
    /// Contrato de acceso a datos para la asignación de permisos
    /// (familias y patentes) a roles.
    /// </summary>
    public interface IRolPermisoDAL_593CM
    {
        /// <summary>Patentes asignadas directamente al rol (no incluye las heredadas via familias).</summary>
        List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol);

        /// <summary>Familias asignadas directamente al rol.</summary>
        List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol);

        bool AgregarPatente_593CM(int idRol, int idPatente);
        bool AgregarFamilia_593CM(int idRol, int idFamilia);
        bool QuitarPatente_593CM(int idRol, int idPatente);
        bool QuitarFamilia_593CM(int idRol, int idFamilia);
    }
}
