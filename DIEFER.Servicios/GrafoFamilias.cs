using System.Collections.Generic;

namespace DIEFER.Servicios
{
    public class GrafoFamilias_593CM
    {
        private static readonly List<int> _empty = new List<int>();

        public Dictionary<int, List<int>> HijasDe    { get; } = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> PatentesDe { get; } = new Dictionary<int, List<int>>();

        public List<int> GetHijas(int idFamilia) =>
            HijasDe.TryGetValue(idFamilia, out var v) ? v : _empty;

        public List<int> GetPatentes(int idFamilia) =>
            PatentesDe.TryGetValue(idFamilia, out var v) ? v : _empty;
    }
}
