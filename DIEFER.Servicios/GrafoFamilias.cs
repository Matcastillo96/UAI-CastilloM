using System.Collections.Generic;

namespace DIEFER.Servicios
{
<<<<<<< HEAD
    /// <summary>
    /// Representación en memoria del grafo de composición de permisos:
    /// relaciones Familia→sub-Familias y Familia→Patentes.
    /// Se carga una única vez por operación para evitar consultas N+1
    /// durante los recorridos BFS de la capa de negocio.
    /// </summary>
=======
>>>>>>> origin/dev
    public class GrafoFamilias_593CM
    {
        private static readonly List<int> _empty = new List<int>();

<<<<<<< HEAD
        private readonly Dictionary<int, List<int>> _hijasDe    = new Dictionary<int, List<int>>();
        private readonly Dictionary<int, List<int>> _patentesDe = new Dictionary<int, List<int>>();

        /// <summary>Registra una relación padre→hija entre dos familias.</summary>
        public void AgregarHija_593CM(int idPadre, int idHija)
        {
            if (!_hijasDe.TryGetValue(idPadre, out var lista))
                _hijasDe[idPadre] = lista = new List<int>();
            lista.Add(idHija);
        }

        /// <summary>Registra una patente como componente directo de una familia.</summary>
        public void AgregarPatente_593CM(int idFamilia, int idPatente)
        {
            if (!_patentesDe.TryGetValue(idFamilia, out var lista))
                _patentesDe[idFamilia] = lista = new List<int>();
            lista.Add(idPatente);
        }

        /// <summary>IDs de las sub-familias directas de la familia indicada.</summary>
        public IReadOnlyList<int> GetHijas_593CM(int idFamilia) =>
            _hijasDe.TryGetValue(idFamilia, out var v) ? v : _empty;

        /// <summary>IDs de las patentes directas de la familia indicada.</summary>
        public IReadOnlyList<int> GetPatentes_593CM(int idFamilia) =>
            _patentesDe.TryGetValue(idFamilia, out var v) ? v : _empty;
=======
        public Dictionary<int, List<int>> HijasDe    { get; } = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> PatentesDe { get; } = new Dictionary<int, List<int>>();

        public List<int> GetHijas(int idFamilia) =>
            HijasDe.TryGetValue(idFamilia, out var v) ? v : _empty;

        public List<int> GetPatentes(int idFamilia) =>
            PatentesDe.TryGetValue(idFamilia, out var v) ? v : _empty;
>>>>>>> origin/dev
    }
}
