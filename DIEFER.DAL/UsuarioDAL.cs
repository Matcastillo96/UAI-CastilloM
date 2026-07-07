using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DIEFER.DAL
{
    public class UsuarioDAL_593CM : IUsuarioDAL_593CM
    {
        private const string SelectConJoin_593CM = @"
SELECT U.DNI, U.Apellidos, U.Nombre, U.Login, U.Password,
       U.ID_rol, R.Nombre AS RolNombre, U.Email, U.Bloqueado, U.Activo, U.Idioma
FROM USUARIO U INNER JOIN ROLES R ON U.ID_rol = R.ID_rol";

        public bool ExisteDNI_593CM(string dni)
        {
            const string sql = "SELECT COUNT(1) FROM USUARIO WHERE DNI = @DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DNI", dni);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool ExisteLogin_593CM(string login, string dniExcluir = null)
        {
            string sql = dniExcluir == null
                ? "SELECT COUNT(1) FROM USUARIO WHERE Login = @Login"
                : "SELECT COUNT(1) FROM USUARIO WHERE Login = @Login AND DNI <> @DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);

                if (dniExcluir != null)
                    cmd.Parameters.AddWithValue("@DNI", dniExcluir);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool Insertar_593CM(Usuario_593CM u)
        {
            const string sql = @"
INSERT INTO USUARIO (DNI, Apellidos, Nombre, Login, Password, ID_rol, Email, Bloqueado, Activo)
VALUES (@DNI, @Ape, @Nom, @Login, @Pass, @IDRol, @Email, @Bloqueado, @Activo)";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                AgregarParametros_593CM(cmd, u);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Usuario_593CM BuscarPorLogin_593CM(string login)
        {
            string sql = SelectConJoin_593CM + " WHERE U.Login = @Login";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Read() ? MapearUsuario_593CM(reader) : null;
                }
            }
        }

        public Usuario_593CM BuscarPorDNI_593CM(string dni)
        {
            string sql = SelectConJoin_593CM + " WHERE U.DNI = @DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DNI", dni);

                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Read() ? MapearUsuario_593CM(reader) : null;
                }
            }
        }

        public bool Actualizar_593CM(Usuario_593CM u)
        {
            const string sql = @"
UPDATE USUARIO
SET Apellidos=@Ape, Nombre=@Nom, Login=@Login, ID_rol=@IDRol, Email=@Email
WHERE DNI=@DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DNI", u.DNI_593CM);
                cmd.Parameters.AddWithValue("@Ape", u.Apellidos_593CM);
                cmd.Parameters.AddWithValue("@Nom", u.Nombre_593CM);
                cmd.Parameters.AddWithValue("@Login", u.Login_593CM);
                cmd.Parameters.AddWithValue("@IDRol", u.ID_rol_593CM);
                cmd.Parameters.AddWithValue("@Email", u.Email_593CM);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarBloqueo_593CM(string dni, bool bloqueado)
        {
            const string sql = "UPDATE USUARIO SET Bloqueado=@B WHERE DNI=@DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@B", bloqueado);
                cmd.Parameters.AddWithValue("@DNI", dni);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarActivo_593CM(string dni, bool activo)
        {
            const string sql = "UPDATE USUARIO SET Activo=@A WHERE DNI=@DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@A", activo);
                cmd.Parameters.AddWithValue("@DNI", dni);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarPassword_593CM(string dni, string nuevoHash)
        {
            const string sql = "UPDATE USUARIO SET Password=@P WHERE DNI=@DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@P", nuevoHash);
                cmd.Parameters.AddWithValue("@DNI", dni);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Usuario_593CM> GetBloqueados_593CM()
        {
            string sql = SelectConJoin_593CM + " WHERE U.Bloqueado=1 AND U.Activo=1 ORDER BY U.Apellidos";
            var lista = new List<Usuario_593CM>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    lista.Add(MapearUsuario_593CM(reader));
            }

            return lista;
        }

        public List<Usuario_593CM> Listar_593CM(
            bool soloActivos,
            string filtroDNI = null,
            string filtroApellidos = null,
            string filtroNombre = null,
            string filtroEmail = null,
            string filtroRol = null,
            string filtroLogin = null)
        {
            var where = new StringBuilder("WHERE 1=1");

            if (soloActivos) where.Append(" AND U.Activo=1");
            if (!string.IsNullOrEmpty(filtroDNI)) where.Append(" AND U.DNI LIKE @FDNI");
            if (!string.IsNullOrEmpty(filtroApellidos)) where.Append(" AND U.Apellidos LIKE @FApe");
            if (!string.IsNullOrEmpty(filtroNombre)) where.Append(" AND U.Nombre LIKE @FNom");
            if (!string.IsNullOrEmpty(filtroEmail)) where.Append(" AND U.Email LIKE @FEmail");
            if (!string.IsNullOrEmpty(filtroRol)) where.Append(" AND R.Nombre LIKE @FRol");
            if (!string.IsNullOrEmpty(filtroLogin)) where.Append(" AND U.Login LIKE @FLogin");

            string sql = $"{SelectConJoin_593CM} {where} ORDER BY U.Apellidos, U.Nombre";
            var lista = new List<Usuario_593CM>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrEmpty(filtroDNI)) cmd.Parameters.AddWithValue("@FDNI", $"%{filtroDNI}%");
                if (!string.IsNullOrEmpty(filtroApellidos)) cmd.Parameters.AddWithValue("@FApe", $"%{filtroApellidos}%");
                if (!string.IsNullOrEmpty(filtroNombre)) cmd.Parameters.AddWithValue("@FNom", $"%{filtroNombre}%");
                if (!string.IsNullOrEmpty(filtroEmail)) cmd.Parameters.AddWithValue("@FEmail", $"%{filtroEmail}%");
                if (!string.IsNullOrEmpty(filtroRol)) cmd.Parameters.AddWithValue("@FRol", $"%{filtroRol}%");
                if (!string.IsNullOrEmpty(filtroLogin)) cmd.Parameters.AddWithValue("@FLogin", $"%{filtroLogin}%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(MapearUsuario_593CM(reader));
                }
            }

            return lista;
        }

        public List<string> GetLoginsParaDV_593CM()
        {
            const string sql = "SELECT Login FROM USUARIO WHERE Activo=1 ORDER BY Login";
            var lista = new List<string>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    lista.Add(reader.GetString(0));
            }

            return lista;
        }

        public bool ActualizarIdioma_593CM(string dni, string codigo)
        {
            const string sql = "UPDATE USUARIO SET Idioma=@I WHERE DNI=@DNI";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@I", codigo);
                cmd.Parameters.AddWithValue("@DNI", dni);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public (string Nombre, string Apellido) BuscarNombreApellidoPorLogin_593CM(string login)
        {
            const string sql = "SELECT Nombre, Apellidos FROM USUARIO WHERE Login = @Login";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Login", login);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return (reader.GetString(0), reader.GetString(1));

                    return (string.Empty, string.Empty);
                }
            }
        }

        private static void AgregarParametros_593CM(SqlCommand cmd, Usuario_593CM u)
        {
            cmd.Parameters.AddWithValue("@DNI", u.DNI_593CM);
            cmd.Parameters.AddWithValue("@Ape", u.Apellidos_593CM);
            cmd.Parameters.AddWithValue("@Nom", u.Nombre_593CM);
            cmd.Parameters.AddWithValue("@Login", u.Login_593CM);
            cmd.Parameters.AddWithValue("@Pass", u.Password_593CM);
            cmd.Parameters.AddWithValue("@IDRol", u.ID_rol_593CM);
            cmd.Parameters.AddWithValue("@Email", u.Email_593CM);
            cmd.Parameters.AddWithValue("@Bloqueado", u.Bloqueado_593CM);
            cmd.Parameters.AddWithValue("@Activo", u.Activo_593CM);
        }

        private static Usuario_593CM MapearUsuario_593CM(SqlDataReader r)
        {
            return new Usuario_593CM
            {
                DNI_593CM = r["DNI"].ToString(),
                Apellidos_593CM = r["Apellidos"].ToString(),
                Nombre_593CM = r["Nombre"].ToString(),
                Login_593CM = r["Login"].ToString(),
                Password_593CM = r["Password"].ToString(),
                ID_rol_593CM = Convert.ToInt32(r["ID_rol"]),
                Rol_593CM = r["RolNombre"].ToString(),
                Email_593CM = r["Email"].ToString(),
                Bloqueado_593CM = Convert.ToBoolean(r["Bloqueado"]),
                Activo_593CM = Convert.ToBoolean(r["Activo"]),
                Idioma_593CM = r["Idioma"] == DBNull.Value ? "es" : r["Idioma"].ToString(),
            };
        }
    }
}