using System.Collections.Generic;
using System.Data.SqlClient;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    public class RolDAL_593CM : IRolDAL_593CM
    {
        public List<Rol_593CM> ListarTodos_593CM()
        {
            const string sql = "SELECT ID_rol, Nombre FROM ROLES ORDER BY Nombre";
            var lista = new List<Rol_593CM>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Rol_593CM
                    {
                        ID_593CM = reader.GetInt32(0),
                        Nombre_593CM = reader.GetString(1)
                    });
                }
            }

            return lista;
        }

        public int ObtenerIDPorNombre_593CM(string nombre)
        {
            const string sql = "SELECT ID_rol FROM ROLES WHERE Nombre = @Nombre";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
        }

        public int Crear_593CM(string nombre)
        {
            const string sql = "INSERT INTO ROLES (Nombre) OUTPUT INSERTED.ID_rol VALUES (@Nombre)";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : -1;
            }
        }
    }
}
