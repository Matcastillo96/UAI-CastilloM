using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.Servicios
{
    /// <summary>
    /// Motor de Dígito Verificador (DVH por registro + DVV por tabla).
    /// No mantiene estado en memoria: lee y escribe a través de <see cref="IDVRepositorio_593CM"/>.
    /// </summary>
    public class DVService_593CM
    {
        private readonly IDVRepositorio_593CM _repositorio_593CM;
        private readonly IReadOnlyDictionary<string, ITablaControlada_593CM> _proveedores_593CM;

        public DVService_593CM(IDVRepositorio_593CM repositorio,
                               IReadOnlyDictionary<string, ITablaControlada_593CM> proveedores)
        {
            _repositorio_593CM = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _proveedores_593CM = proveedores ?? throw new ArgumentNullException(nameof(proveedores));
        }

        /// <summary>Calcula el DVH de una cadena base mediante SHA-256 (hex 64).</summary>
        public static string CalcularDVH_593CM(string cadena)
        {
            if (cadena == null) cadena = string.Empty;

            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(cadena));
                var sb = new StringBuilder(64);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>Recalcula DVH de cada registro y el DVV de una tabla, persistiéndolos.</summary>
        public void RecalcularTabla_593CM(string nombreTabla)
        {
            if (!_proveedores_593CM.TryGetValue(nombreTabla, out var proveedor))
                throw new InvalidOperationException($"No hay proveedor DV para la tabla '{nombreTabla}'.");

            var registros = proveedor.ObtenerRegistros_593CM().ToList();

            _repositorio_593CM.EliminarDVHsDeTabla_593CM(nombreTabla);

            var dvhList = new List<string>(registros.Count);

            foreach (var (clave, cadena) in registros.OrderBy(r => r.clave, StringComparer.Ordinal))
            {
                string dvh = CalcularDVH_593CM(cadena);
                _repositorio_593CM.GuardarDVH_593CM(nombreTabla, clave, dvh);
                dvhList.Add(dvh);
            }

            string dvv = CalcularDVH_593CM(string.Join("|", dvhList));
            _repositorio_593CM.GuardarDVV_593CM(nombreTabla, dvv);
        }

        /// <summary>Recalcula el DV de todas las tablas controladas.</summary>
        public void RecalcularTodo_593CM()
        {
            foreach (string tabla in _repositorio_593CM.ListarTablasControladas_593CM())
                RecalcularTabla_593CM(tabla);
        }

        /// <summary>
        /// Verifica una tabla sin modificar DV. Retorna true si es consistente.
        /// </summary>
        public bool VerificarTabla_593CM(string nombreTabla)
        {
            if (!_proveedores_593CM.TryGetValue(nombreTabla, out var proveedor))
                return false;

            string dvvAlmacenado = _repositorio_593CM.ObtenerDVV_593CM(nombreTabla);
            if (dvvAlmacenado == null)
                return false;

            var dvhAlmacenados = _repositorio_593CM.ObtenerDVHsDeTabla_593CM(nombreTabla)
                .ToDictionary(x => x.clave, x => x.dvh, StringComparer.Ordinal);

            var registros = proveedor.ObtenerRegistros_593CM().ToList();

            var dvhCalculados = new List<string>(registros.Count);

            foreach (var (clave, cadena) in registros.OrderBy(r => r.clave, StringComparer.Ordinal))
            {
                string dvhCalculado = CalcularDVH_593CM(cadena);
                dvhCalculados.Add(dvhCalculado);

                if (!dvhAlmacenados.TryGetValue(clave, out string dvhAlmacenado) ||
                    !string.Equals(dvhAlmacenado, dvhCalculado, StringComparison.Ordinal))
                {
                    return false;
                }
            }

            // También detecta registros borrados: sobran DVH almacenados.
            if (dvhAlmacenados.Count != registros.Count)
                return false;

            string dvvCalculado = CalcularDVH_593CM(string.Join("|", dvhCalculados));
            return string.Equals(dvvAlmacenado, dvvCalculado, StringComparison.Ordinal);
        }

        /// <summary>
        /// Verifica la integridad de todas las tablas controladas sin modificar DV.
        /// Retorna la lista de nombres de tablas afectadas.
        /// </summary>
        public List<string> VerificarIntegridad_593CM()
        {
            var afectadas = new List<string>();

            foreach (string tabla in _repositorio_593CM.ListarTablasControladas_593CM())
            {
                if (!VerificarTabla_593CM(tabla))
                    afectadas.Add(tabla);
            }

            return afectadas;
        }
    }
}
