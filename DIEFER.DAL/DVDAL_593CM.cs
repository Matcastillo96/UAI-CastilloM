using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.DAL
{
    /// <summary>
    /// Persistencia del Dígito Verificador y proveedores de tablas controladas.
    /// </summary>
    public class DVDAL_593CM : IDVDAL_593CM
    {
        private readonly Dictionary<string, ITablaControlada_593CM> _proveedores;

        public DVDAL_593CM()
        {
            _proveedores = new Dictionary<string, ITablaControlada_593CM>(StringComparer.OrdinalIgnoreCase)
            {
                { "USUARIO",         new UsuarioControlado_593CM() },
                { "ROLES",           new RolesControlado_593CM() },
                { "Patente",         new PatenteControlado_593CM() },
                { "Familia",         new FamiliaControlado_593CM() },
                { "Familia_Patente", new FamiliaPatenteControlado_593CM() },
                { "Familia_Familia", new FamiliaFamiliaControlado_593CM() },
                { "Rol_Patente",     new RolPatenteControlado_593CM() },
                { "Rol_Familia",     new RolFamiliaControlado_593CM() },
                { "EVENTOS",         new EventosControlado_593CM() },
            };

            Proveedores_593CM = _proveedores;
        }

        public IReadOnlyDictionary<string, ITablaControlada_593CM> Proveedores_593CM { get; }

        // ── IDVRepositorio ─────────────────────────────────────────────────────────

        public List<string> ListarTablasControladas_593CM()
        {
            const string sql = "SELECT NombreTabla FROM DV ORDER BY NombreTabla";
            var lista = new List<string>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    lista.Add(r.GetString(0));
            }

            return lista;
        }

        public string ObtenerDVV_593CM(string nombreTabla)
        {
            const string sql = "SELECT DVV FROM DV WHERE NombreTabla = @Tabla";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                var result = cmd.ExecuteScalar();
                return result == null ? null : result.ToString();
            }
        }

        public void GuardarDVV_593CM(string nombreTabla, string dvv)
        {
            const string sql = @"
MERGE INTO DV AS destino
USING (VALUES (@Tabla)) AS fuente(NombreTabla)
   ON destino.NombreTabla = fuente.NombreTabla
WHEN MATCHED THEN
    UPDATE SET DVV = @DVV, FechaUltimaActualizacion = GETDATE()
WHEN NOT MATCHED THEN
    INSERT (NombreTabla, DVV, FechaUltimaActualizacion)
    VALUES (@Tabla, @DVV, GETDATE());";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                cmd.Parameters.AddWithValue("@DVV", dvv);
                cmd.ExecuteNonQuery();
            }
        }

        public string ObtenerDVH_593CM(string nombreTabla, string claveRegistro)
        {
            const string sql = "SELECT DVH FROM DV_Detalle WHERE NombreTabla = @Tabla AND ClaveRegistro = @Clave";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                cmd.Parameters.AddWithValue("@Clave", claveRegistro);
                var result = cmd.ExecuteScalar();
                return result == null ? null : result.ToString();
            }
        }

        public void GuardarDVH_593CM(string nombreTabla, string claveRegistro, string dvh)
        {
            const string sql = @"
MERGE INTO DV_Detalle AS destino
USING (VALUES (@Tabla, @Clave)) AS fuente(NombreTabla, ClaveRegistro)
   ON destino.NombreTabla = fuente.NombreTabla
  AND destino.ClaveRegistro = fuente.ClaveRegistro
WHEN MATCHED THEN
    UPDATE SET DVH = @DVH
WHEN NOT MATCHED THEN
    INSERT (NombreTabla, ClaveRegistro, DVH)
    VALUES (@Tabla, @Clave, @DVH);";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                cmd.Parameters.AddWithValue("@Clave", claveRegistro);
                cmd.Parameters.AddWithValue("@DVH", dvh);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarDVHsDeTabla_593CM(string nombreTabla)
        {
            const string sql = "DELETE FROM DV_Detalle WHERE NombreTabla = @Tabla";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                cmd.ExecuteNonQuery();
            }
        }

        public List<(string clave, string dvh)> ObtenerDVHsDeTabla_593CM(string nombreTabla)
        {
            const string sql = "SELECT ClaveRegistro, DVH FROM DV_Detalle WHERE NombreTabla = @Tabla ORDER BY ClaveRegistro";
            var lista = new List<(string, string)>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Tabla", nombreTabla);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        lista.Add((r.GetString(0), r.GetString(1)));
                }
            }

            return lista;
        }

        // ── Helpers de cadena DV ───────────────────────────────────────────────────

        private static string Campo_593CM(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return string.Empty;

            if (valor is bool b)
                return b ? "1" : "0";

            if (valor is DateTime dt)
                return dt.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            if (valor is TimeSpan ts)
                return ts.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            return valor.ToString();
        }

        private static string Concatenar_593CM(params object[] valores)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < valores.Length; i++)
            {
                sb.Append(Campo_593CM(valores[i]));
                if (i < valores.Length - 1)
                    sb.Append('|');
            }
            return sb.ToString();
        }

        // ── Proveedores de tablas controladas ──────────────────────────────────────

        private abstract class ProveedorBase_593CM : ITablaControlada_593CM
        {
            public abstract string NombreTabla_593CM { get; }

            protected IEnumerable<(string clave, string cadena)> Leer_593CM(string sql,
                Func<SqlDataReader, (string clave, string cadena)> mapear)
            {
                using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
                using (var cmd = new SqlCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        yield return mapear(r);
                }
            }

            public abstract IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM();
        }

        private class UsuarioControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "USUARIO";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = @"
SELECT DNI, Apellidos, Nombre, Login, Password, ID_rol, Email, Bloqueado, Activo, Idioma
FROM USUARIO ORDER BY DNI";

                return Leer_593CM(sql, r =>
                (
                    r.GetString(0),
                    Concatenar_593CM(r.GetString(0), r.GetString(1), r.GetString(2),
                                     r.GetString(3), r.GetString(4), r.GetInt32(5),
                                     r.GetString(6), r.GetBoolean(7), r.GetBoolean(8),
                                     r.GetString(9))
                ));
            }
        }

        private class RolesControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "ROLES";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_rol, Nombre FROM ROLES ORDER BY ID_rol";

                return Leer_593CM(sql, r =>
                (
                    r.GetInt32(0).ToString(CultureInfo.InvariantCulture),
                    Concatenar_593CM(r.GetInt32(0), r.GetString(1))
                ));
            }
        }

        private class PatenteControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Patente";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_patente, Nombre, Permiso FROM Patente ORDER BY ID_patente";

                return Leer_593CM(sql, r =>
                (
                    r.GetInt32(0).ToString(CultureInfo.InvariantCulture),
                    Concatenar_593CM(r.GetInt32(0), r.GetString(1), r.GetString(2))
                ));
            }
        }

        private class FamiliaControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Familia";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_familia, Nombre FROM Familia ORDER BY ID_familia";

                return Leer_593CM(sql, r =>
                (
                    r.GetInt32(0).ToString(CultureInfo.InvariantCulture),
                    Concatenar_593CM(r.GetInt32(0), r.GetString(1))
                ));
            }
        }

        private class FamiliaPatenteControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Familia_Patente";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_familia, ID_patente FROM Familia_Patente ORDER BY ID_familia, ID_patente";

                return Leer_593CM(sql, r =>
                (
                    $"{r.GetInt32(0)}-{r.GetInt32(1)}",
                    Concatenar_593CM(r.GetInt32(0), r.GetInt32(1))
                ));
            }
        }

        private class FamiliaFamiliaControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Familia_Familia";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_familiaPadre, ID_familiaHija FROM Familia_Familia ORDER BY ID_familiaPadre, ID_familiaHija";

                return Leer_593CM(sql, r =>
                (
                    $"{r.GetInt32(0)}-{r.GetInt32(1)}",
                    Concatenar_593CM(r.GetInt32(0), r.GetInt32(1))
                ));
            }
        }

        private class RolPatenteControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Rol_Patente";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_rol, ID_patente FROM Rol_Patente ORDER BY ID_rol, ID_patente";

                return Leer_593CM(sql, r =>
                (
                    $"{r.GetInt32(0)}-{r.GetInt32(1)}",
                    Concatenar_593CM(r.GetInt32(0), r.GetInt32(1))
                ));
            }
        }

        private class RolFamiliaControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "Rol_Familia";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = "SELECT ID_rol, ID_familia FROM Rol_Familia ORDER BY ID_rol, ID_familia";

                return Leer_593CM(sql, r =>
                (
                    $"{r.GetInt32(0)}-{r.GetInt32(1)}",
                    Concatenar_593CM(r.GetInt32(0), r.GetInt32(1))
                ));
            }
        }

        private class EventosControlado_593CM : ProveedorBase_593CM
        {
            public override string NombreTabla_593CM => "EVENTOS";

            public override IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
            {
                const string sql = @"
SELECT Id_Evento, Login, Fecha, Hora, Modulo, Evento, Criticidad
FROM EVENTOS ORDER BY Id_Evento";

                return Leer_593CM(sql, r =>
                (
                    r.GetInt32(0).ToString(CultureInfo.InvariantCulture),
                    Concatenar_593CM(r.GetInt32(0), r.GetString(1), r.GetDateTime(2),
                                     r.GetTimeSpan(3), r.GetString(4), r.GetString(5),
                                     r.GetInt32(6))
                ));
            }
        }
    }
}
