using System.Collections.Generic;
using DIEFER.Servicios;

namespace DIEFER.DAL.Interfaces
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

        bool AgregarPatente_593CM(int idFamilia, int idPatente);
        bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);
        bool QuitarPatente_593CM(int idFamilia, int idPatente);
        bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija);

        /// <summary>
        /// Agrega una sub-familia a una familia padre y, en la misma transacción
        /// nativa, quita las patentes/sub-familias directas que quedaron
        /// redundantes. Evita abrir varias conexiones dentro de una transacción
        /// ambiente (lo que forzaría una promoción a transacción distribuida/MSDTC).
        /// </summary>
        bool AgregarSubFamiliaConLimpieza_593CM(
            int idFamiliaPadre,
            int idFamiliaHija,
            IEnumerable<int> idsPatentesAQuitar,
            IEnumerable<int> idsFamiliasAQuitar);
    }
}
