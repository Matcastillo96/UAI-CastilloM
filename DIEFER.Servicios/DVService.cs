using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DIEFER.Servicios
{
    // Dígito Verificador de integridad de tabla USUARIO.
    // Calcula un hash SHA-256 de los campos clave de todos los registros.
    // Si alguien modifica la DB directamente (sin pasar por la app), el hash difiere.
    public static class DVService_593CM
    {
        private static string _hashReferencia_593CM = null;

        public static bool VerificarIntegridad_593CM(IEnumerable<string> registrosClave)
        {
            string hashActual = ComputarHash_593CM(registrosClave);
            if (_hashReferencia_593CM == null)
            {
                // Primera ejecución: establece el baseline
                _hashReferencia_593CM = hashActual;
                return true;
            }
            return string.Equals(hashActual, _hashReferencia_593CM, StringComparison.Ordinal);
        }

        // Llamar después de cualquier modificación que pase por la app
        public static void ActualizarReferencia_593CM(IEnumerable<string> registrosClave)
        {
            _hashReferencia_593CM = ComputarHash_593CM(registrosClave);
        }

        // Forzar reseteo (p.ej. después de restaurar backup autorizado)
        public static void ResetearReferencia_593CM()
        {
            _hashReferencia_593CM = null;
        }

        private static string ComputarHash_593CM(IEnumerable<string> datos)
        {
            var sb = new StringBuilder();
            foreach (var item in datos)
                sb.Append(item ?? string.Empty).Append('|');

            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
