using System.Collections.Generic;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    /// <summary>
    /// Contrato de acceso a datos para la entidad Familia (composite del
    /// patrón Composite) y sus relaciones de composición.
    /// </summary>
    public interface IFamiliaDAL_593CM
    {
        /// <summary>Lista todas las familias, sin componentes.</summary>
        List<Familia_593CM> ListarTodas_593CM();

        /// <summary>Carga una familia con sus componentes directos (un nivel de profundidad).</summary>
        Familia_593CM CargarConComponentes_593CM(int idFamilia);

        /// <summary>IDs de las sub-familias directas de una familia.</summary>
        List<int> ObtenerIdsFamiliasHijas_593CM(int idFamilia);

        /// <summary>Carga el grafo completo de composición en memoria (2 consultas).</summary>
        GrafoFamilias_593CM CargarGrafo_593CM();

        /// <summary>Crea una familia. Retorna el ID generado, o -1 si falla.</summary>
        int Crear_593CM(string nombre);

        /// <summary>Renombra una familia. Retorna true si fue exitoso.</summary>
        bool Renombrar_593CM(int idFamilia, string nombre);

        /// <summary>
        /// Elimina una familia. Previamente se deben haber eliminado sus vínculos.
        /// Retorna true si fue exitoso.
        /// </summary>
        bool Eliminar_593CM(int idFamilia);

        /// <summary>
        /// Cuenta las referencias a la familia como hija en Familia_Familia o en Rol_Familia.
        /// </summary>
        int ContarReferencias_593CM(int idFamilia);

        bool AgregarPatente_593CM(int idFamilia, int idPatente);
        bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);
        bool QuitarPatente_593CM(int idFamilia, int idPatente);
        bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);
    }
}
