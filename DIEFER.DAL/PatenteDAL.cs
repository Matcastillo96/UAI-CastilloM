using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DIEFER.DAL
{
    public class PatenteDAL_593CM : IPatenteDAL_593CM
    {
        public List<Patente_593CM> ListarTodas_593CM()
        {
            const string sql = "SELECT ID_patente, Nombre, Permiso FROM Patente ORDER BY Nombre";
            var lista = new List<Patente_593CM>();

            using (var conn = ConexionDB_593CM.AbrirConexion_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new Patente_593CM
                    {
                        ID_patente_593CM = r.GetInt32(0),
                        Nombre_593CM = r.GetString(1),
                        Permiso_593CM = r.GetString(2)
                    });
                }
            }

            return lista;
        }
    }
}
