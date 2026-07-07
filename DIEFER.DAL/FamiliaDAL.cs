using System.Collections.Generic;
using System.Data.SqlClient;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    public class FamiliaDAL_593CM : IFamiliaDAL_593CM
    {
        public List<Familia_593CM> ListarTodas_593CM()
        {
            const string sql = "SELECT ID_familia, Nombre FROM Familia ORDER BY Nombre";
            var lista = new List<Familia_593CM>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new Familia_593CM
                    {
                        ID_familia_593CM = r.GetInt32(0),
                        Nombre_593CM = r.GetString(1)
                    });
                }
            }

            return lista;
        }

        public Familia_593CM CargarConComponentes_593CM(int idFamilia)
        {
            Familia_593CM familia = null;

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            {
                using (var cmd = new SqlCommand("SELECT ID_familia, Nombre FROM Familia WHERE ID_familia=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            familia = new Familia_593CM
                            {
                                ID_familia_593CM = r.GetInt32(0),
                                Nombre_593CM = r.GetString(1)
                            };
                        }
                    }
                }

                if (familia == null)
                    return null;

                const string sqlPat = @"
SELECT P.ID_patente, P.Nombre, P.Permiso
FROM Familia_Patente FP INNER JOIN Patente P ON FP.ID_patente = P.ID_patente
WHERE FP.ID_familia = @ID ORDER BY P.Nombre";

                using (var cmd = new SqlCommand(sqlPat, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            familia.Agregar_593CM(new Patente_593CM
                            {
                                ID_patente_593CM = r.GetInt32(0),
                                Nombre_593CM = r.GetString(1),
                                Permiso_593CM = r.GetString(2)
                            });
                        }
                    }
                }

                const string sqlFam = @"
SELECT F.ID_familia, F.Nombre
FROM Familia_Familia FF INNER JOIN Familia F ON FF.ID_familiaHija = F.ID_familia
WHERE FF.ID_familiaPadre = @ID ORDER BY F.Nombre";

                using (var cmd = new SqlCommand(sqlFam, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idFamilia);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            familia.Agregar_593CM(new Familia_593CM
                            {
                                ID_familia_593CM = r.GetInt32(0),
                                Nombre_593CM = r.GetString(1)
                            });
                        }
                    }
                }
            }

            return familia;
        }

        public List<int> ObtenerIdsFamiliasHijas_593CM(int idFamilia)
        {
            const string sql = "SELECT ID_familiaHija FROM Familia_Familia WHERE ID_familiaPadre=@ID";
            var ids = new List<int>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", idFamilia);

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        ids.Add(r.GetInt32(0));
                }
            }

            return ids;
        }

        public GrafoFamilias_593CM CargarGrafo_593CM()
        {
            var grafo = new GrafoFamilias_593CM();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            {
                const string sqlFF = "SELECT ID_familiaPadre, ID_familiaHija FROM Familia_Familia";

                using (var cmd = new SqlCommand(sqlFF, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        grafo.AgregarHija_593CM(r.GetInt32(0), r.GetInt32(1));
                }

                const string sqlFP = "SELECT ID_familia, ID_patente FROM Familia_Patente";

                using (var cmd = new SqlCommand(sqlFP, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        grafo.AgregarPatente_593CM(r.GetInt32(0), r.GetInt32(1));
                }
            }

            return grafo;
        }

        public int Crear_593CM(string nombre)
        {
            const string sql = "INSERT INTO Familia (Nombre) OUTPUT INSERTED.ID_familia VALUES (@Nombre)";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : -1;
            }
        }

        public bool AgregarPatente_593CM(int idFamilia, int idPatente)
        {
            const string sql = "INSERT INTO Familia_Patente (ID_familia, ID_patente) VALUES (@ID1, @ID2)";
            return Ejecutar_593CM(sql, idFamilia, idPatente);
        }

        public bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            const string sql = "INSERT INTO Familia_Familia (ID_familiaPadre, ID_familiaHija) VALUES (@ID1, @ID2)";
            return Ejecutar_593CM(sql, idFamiliaPadre, idFamiliaHija);
        }

        public bool QuitarPatente_593CM(int idFamilia, int idPatente)
        {
            const string sql = "DELETE FROM Familia_Patente WHERE ID_familia=@ID1 AND ID_patente=@ID2";
            return Ejecutar_593CM(sql, idFamilia, idPatente);
        }

        public bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija)
        {
            const string sql = "DELETE FROM Familia_Familia WHERE ID_familiaPadre=@ID1 AND ID_familiaHija=@ID2";
            return Ejecutar_593CM(sql, idFamiliaPadre, idFamiliaHija);
        }

        public bool AgregarSubFamiliaConLimpieza_593CM(
            int idFamiliaPadre,
            int idFamiliaHija,
            IEnumerable<int> idsPatentesAQuitar,
            IEnumerable<int> idsFamiliasAQuitar)
        {
            const string sqlInsertar = "INSERT INTO Familia_Familia (ID_familiaPadre, ID_familiaHija) VALUES (@ID1, @ID2)";
            const string sqlQuitarPatente = "DELETE FROM Familia_Patente WHERE ID_familia=@ID1 AND ID_patente=@ID2";
            const string sqlQuitarSubFamilia = "DELETE FROM Familia_Familia WHERE ID_familiaPadre=@ID1 AND ID_familiaHija=@ID2";

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    if (!EjecutarEnTransaccion_593CM(conn, tx, sqlInsertar, idFamiliaPadre, idFamiliaHija))
                    {
                        tx.Rollback();
                        return false;
                    }

                    foreach (var idPatente in idsPatentesAQuitar)
                        EjecutarEnTransaccion_593CM(conn, tx, sqlQuitarPatente, idFamiliaPadre, idPatente);

                    foreach (var idFamiliaHijaAQuitar in idsFamiliasAQuitar)
                        EjecutarEnTransaccion_593CM(conn, tx, sqlQuitarSubFamilia, idFamiliaPadre, idFamiliaHijaAQuitar);

                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        private static bool Ejecutar_593CM(string sql, int param1, int param2)
        {
            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID1", param1);
                cmd.Parameters.AddWithValue("@ID2", param2);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private static bool EjecutarEnTransaccion_593CM(SqlConnection conn, SqlTransaction tx, string sql, int param1, int param2)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ID1", param1);
                cmd.Parameters.AddWithValue("@ID2", param2);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}