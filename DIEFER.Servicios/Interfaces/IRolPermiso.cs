using System.Collections.Generic;

namespace DIEFER.Servicios
{
    public interface IRolPermiso_593CM
    {
        List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol);
        List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol);
        bool AgregarPatente_593CM(int idRol, int idPatente);
        bool AgregarFamilia_593CM(int idRol, int idFamilia);
        bool QuitarPatente_593CM(int idRol, int idPatente);
        bool QuitarFamilia_593CM(int idRol, int idFamilia);
    }
}
