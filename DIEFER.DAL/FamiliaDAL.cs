using System.Collections.Generic;
using System.Data.SqlClient;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    public class FamiliaDAL_593CM : IFamilia_593CM
    {
        public List<Familia_593CM> ListarTodas_593CM()
        {
            const string sql = "SELECT ID_familia, Nombre FROM Familia ORDER BY Nombre";
            var lista = new List<Familia_593CM>();
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Familia_593CM {
                            ID_familia_593CM = r.GetInt32(0),
                            Nombre_593CM     = r.GetString(1)
                        });
            }
            return lista;
        }

        // Carga la familia con sus hijos directos (1 nivel): sub-familias + patentes.
        public Familia_593CM CargarConComponentes_593CM(int idFamilia)
        {
            Familia_593CM familia = null;

            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();

                // Cargar cabecera
                using (var cmd = new SqlCommand("SELECT ID_familia, Nombre FROM Familia WHERE ID_familia=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);
                    using (var r = cmd.ExecuteReader())
                        if (r.Read())
                            familia = new Familia_593CM {
                                ID_familia_593CM = r.GetInt32(0),
                                Nombre_593CM     = r.GetString(1)
                            };
                }

                if (familia == null) return null;

                // Cargar patentes directas
                const string sqlPat = @"
SELECT P.ID_patente, P.Nombre, P.Permiso
FROM Familia_Patente FP INNER JOIN Patente P ON FP.ID_patente = P.ID_patente
WHERE FP.ID_familia = @ID ORDER BY P.Nombre";
                using (var cmd = new SqlCommand(sqlPat, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            familia.Agregar_593CM(new Patente_593CM {
                                ID_patente_593CM = r.GetInt32(0),
                                Nombre_593CM     = r.GetString(1),
                                Permiso_593CM    = r.GetString(2)
                            });
                }

                // Cargar sub-familias directas (shallow — sin sus propios hijos)
                const string sqlFam = @"
SELECT F.ID_familia, F.Nombre
FROM Familia_Familia FF INNER JOIN Familia F ON FF.ID_familiaHija = F.ID_familia
WHERE FF.ID_familiaPadre = @ID ORDER BY F.Nombre";
                using (var cmd = new SqlCommand(sqlFam, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            familia.Agregar_593CM(new Familia_593CM {
                                ID_familia_593CM = r.GetInt32(0),
                                Nombre_593CM     = r.GetString(1)
                            });
                }
            }

            return familia;
        }

        public List<int> ObtenerIdsFamiliasHijas_593CM(int idFamilia)
        {
            const string sql = "SELECT ID_familiaHija FROM Familia_Familia WHERE ID_familiaPadre=@ID";
            var ids = new List<int>();
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) ids.Add(r.GetInt32(0));
                }
            }
            return ids;
        }

        public bool Crear_593CM(string nombre)
        {
            const string sql = "INSERT INTO Familia (Nombre) VALUES (@Nombre)";
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AgregarPatente_593CM(int idFamilia, int idPatente)
        {
            const string sql = "INSERT INTO Familia_Patente (ID_familia, ID_patente) VALUES (@F, @P)";
            return Ejecutar_593CM(sql, idFamilia, idPatente);
        }

        public bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            const string sql = "INSERT INTO Familia_Familia (ID_familiaPadre, ID_familiaHija) VALUES (@F, @P)";
            return Ejecutar_593CM(sql, idFamiliaPadre, idFamiliaHija);
        }

        public bool QuitarPatente_593CM(int idFamilia, int idPatente)
        {
            const string sql = "DELETE FROM Familia_Patente WHERE ID_familia=@F AND ID_patente=@P";
            return Ejecutar_593CM(sql, idFamilia, idPatente);
        }

        public bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            const string sql = "DELETE FROM Familia_Familia WHERE ID_familiaPadre=@F AND ID_familiaHija=@P";
            return Ejecutar_593CM(sql, idFamiliaPadre, idFamiliaHija);
        }

        private static bool Ejecutar_593CM(string sql, int param1, int param2)
        {
            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@F", param1);
                    cmd.Parameters.AddWithValue("@P", param2);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
