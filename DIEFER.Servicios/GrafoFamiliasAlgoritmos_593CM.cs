using System.Collections.Generic;

namespace DIEFER.Servicios
{
    /// <summary>
    /// Algoritmos de recorrido sobre <see cref="GrafoFamilias_593CM"/>: alcanzabilidad
    /// de patentes y detección de ciclos. Separado de la capa de negocio para que el
    /// algoritmo se pueda testear de forma aislada, sin depender del DAL.
    /// </summary>
    public static class GrafoFamiliasAlgoritmos_593CM
    {
        /// <summary>
        /// BFS en memoria sobre el grafo precargado: retorna todos los IDs de
        /// patentes alcanzables desde la familia indicada.
        /// </summary>
        public static HashSet<int> BfsPatentes_593CM(int idFamilia, GrafoFamilias_593CM grafo)
        {
            var resultado = new HashSet<int>();
            var visitados = new HashSet<int>();
            var cola = new Queue<int>();

            cola.Enqueue(idFamilia);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (!visitados.Add(actual)) continue;

                foreach (var idP in grafo.GetPatentes_593CM(actual))
                    resultado.Add(idP);

                foreach (var idH in grafo.GetHijas_593CM(actual))
                {
                    if (!visitados.Contains(idH))
                        cola.Enqueue(idH);
                }
            }

            return resultado;
        }

        /// <summary>Verifica en ambas direcciones si vincular padre→hija generaría un ciclo.</summary>
        public static bool CreariaCirculo_593CM(int idPadre, int idHija, GrafoFamilias_593CM grafo)
        {
            return DesciendeDe_593CM(idPadre, idHija, grafo)
                || DesciendeDe_593CM(idHija, idPadre, grafo);
        }

        /// <summary>BFS: true si idFamilia desciende (directa o transitivamente) de idAncestro.</summary>
        private static bool DesciendeDe_593CM(int idFamilia, int idAncestro, GrafoFamilias_593CM grafo)
        {
            var visitados = new HashSet<int>();
            var cola = new Queue<int>();

            cola.Enqueue(idFamilia);

            while (cola.Count > 0)
            {
                int actual = cola.Dequeue();
                if (!visitados.Add(actual)) continue;
                if (actual == idAncestro) return true;

                foreach (var hijo in grafo.GetHijas_593CM(actual))
                {
                    if (!visitados.Contains(hijo))
                        cola.Enqueue(hijo);
                }
            }

            return false;
        }
    }
}
