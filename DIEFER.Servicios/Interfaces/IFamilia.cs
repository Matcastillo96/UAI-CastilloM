using System.Collections.Generic;

namespace DIEFER.Servicios
{
    public interface IFamilia_593CM
    {
        List<Familia_593CM>  ListarTodas_593CM();
        Familia_593CM        CargarConComponentes_593CM(int idFamilia);  // 1 nivel de profundidad
        List<int>            ObtenerIdsFamiliasHijas_593CM(int idFamilia);
        bool Crear_593CM(string nombre);
        bool AgregarPatente_593CM(int idFamilia, int idPatente);
        bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);
        bool QuitarPatente_593CM(int idFamilia, int idPatente);
        bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);
    }
}
