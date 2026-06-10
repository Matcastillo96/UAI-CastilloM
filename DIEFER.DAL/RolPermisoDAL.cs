using System.Collections.Generic;
using System.Data.SqlClient;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    public class RolPermisoDAL_593CM : IRolPermiso_593CM
    {
        public List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol)
        {
            const string sql = @"
SELECT P.ID_patente, P.Nombre, P.Permiso
FROM Rol_Patente RP INNER JOIN Patente P ON RP.ID_patente = P.ID_patente
WHERE RP.ID_rol = @ID ORDER BY P.Nombre";
            var lista = new List<Patente_593CM>();
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idRol);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            lista.Add(new Patente_593CM {
                                ID_patente_593CM = r.GetInt32(0),
                                Nombre_593CM     = r.GetString(1),
                                Permiso_593CM    = r.GetString(2)
                            });
                }
            }
            return lista;
        }

        public List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol)
        {
            const string sql = @"
SELECT F.ID_familia, F.Nombre
FROM Rol_Familia RF INNER JOIN Familia F ON RF.ID_familia = F.ID_familia
WHERE RF.ID_rol = @ID ORDER BY F.Nombre";
            var lista = new List<Familia_593CM>();
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idRol);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            lista.Add(new Familia_593CM {
                                ID_familia_593CM = r.GetInt32(0),
                                Nombre_593CM     = r.GetString(1)
                            });
                }
            }
            return lista;
        }

        public bool AgregarPatente_593CM(int idRol, int idPatente)
        {
            const string sql = "INSERT INTO Rol_Patente (ID_rol, ID_patente) VALUES (@R, @P)";
            return Ejecutar_593CM(sql, idRol, idPatente);
        }

        public bool AgregarFamilia_593CM(int idRol, int idFamilia)
        {
            const string sql = "INSERT INTO Rol_Familia (ID_rol, ID_familia) VALUES (@R, @P)";
            return Ejecutar_593CM(sql, idRol, idFamilia);
        }

        public bool QuitarPatente_593CM(int idRol, int idPatente)
        {
            const string sql = "DELETE FROM Rol_Patente WHERE ID_rol=@R AND ID_patente=@P";
            return Ejecutar_593CM(sql, idRol, idPatente);
        }

        public bool QuitarFamilia_593CM(int idRol, int idFamilia)
        {
            const string sql = "DELETE FROM Rol_Familia WHERE ID_rol=@R AND ID_familia=@P";
            return Ejecutar_593CM(sql, idRol, idFamilia);
        }

        private static bool Ejecutar_593CM(string sql, int param1, int param2)
        {
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@R", param1);
                    cmd.Parameters.AddWithValue("@P", param2);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
