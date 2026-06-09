using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DIEFER.Servicios;

namespace DIEFER.DAL
{
    // Implementación de IEventoDAL_593CM sobre SQL Server LocalDB.
    public class EventoDAL_593CM : IEventoDAL_593CM
    {
        public void Insertar_593CM(Eventos_593CM e)
        {
            const string sql = @"
INSERT INTO EVENTOS (Login, Fecha, Hora, Modulo, Evento, Criticidad)
VALUES (@Login, @Fecha, @Hora, @Modulo, @Evento, @Criticidad)";

            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Login",      e.Login_593CM);
                    cmd.Parameters.AddWithValue("@Fecha",      e.Fecha_593CM.Date);
                    cmd.Parameters.AddWithValue("@Hora",       e.Hora_593CM.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Modulo",     e.Modulo_593CM);
                    cmd.Parameters.AddWithValue("@Evento",     e.Evento_593CM);
                    cmd.Parameters.AddWithValue("@Criticidad", e.Criticidad_593CM);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Eventos_593CM> GetByFiltro_593CM(DateTime? fechaIni, DateTime? fechaFin,
                                                      string login, string modulo,
                                                      string evento, int? criticidad)
        {
            var where = new System.Text.StringBuilder("WHERE 1=1");
            if (fechaIni.HasValue)               where.Append(" AND Fecha >= @FIni");
            if (fechaFin.HasValue)               where.Append(" AND Fecha <= @FFin");
            if (!string.IsNullOrEmpty(login))    where.Append(" AND Login    = @Login");
            if (!string.IsNullOrEmpty(modulo))   where.Append(" AND Modulo   = @Modulo");
            if (!string.IsNullOrEmpty(evento))   where.Append(" AND Evento   = @Evento");
            if (criticidad.HasValue)             where.Append(" AND Criticidad = @Crit");

            string sql = $"SELECT * FROM EVENTOS {where} ORDER BY Fecha DESC, Hora DESC";
            var lista  = new List<Eventos_593CM>();

            using (var conn = ConexionDB_593CM.ObtenerConexion_593CM())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (fechaIni.HasValue)             cmd.Parameters.AddWithValue("@FIni",  fechaIni.Value.Date);
                    if (fechaFin.HasValue)             cmd.Parameters.AddWithValue("@FFin",  fechaFin.Value.Date);
                    if (!string.IsNullOrEmpty(login))  cmd.Parameters.AddWithValue("@Login", login);
                    if (!string.IsNullOrEmpty(modulo)) cmd.Parameters.AddWithValue("@Modulo",modulo);
                    if (!string.IsNullOrEmpty(evento)) cmd.Parameters.AddWithValue("@Evento",evento);
                    if (criticidad.HasValue)           cmd.Parameters.AddWithValue("@Crit", criticidad.Value);

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            lista.Add(MapearEvento_593CM(reader));
                }
            }
            return lista;
        }

        private static Eventos_593CM MapearEvento_593CM(SqlDataReader r)
        {
            var fecha = r.GetDateTime(r.GetOrdinal("Fecha"));
            var hora  = r.GetTimeSpan(r.GetOrdinal("Hora"));
            return new Eventos_593CM
            {
                Id_Evento_593CM  = r.GetInt32(r.GetOrdinal("Id_Evento")),
                Login_593CM      = r["Login"].ToString(),
                Fecha_593CM      = fecha,
                Hora_593CM       = fecha.Date.Add(hora),
                Modulo_593CM     = r["Modulo"].ToString(),
                Evento_593CM     = r["Evento"].ToString(),
                Criticidad_593CM = r.GetInt32(r.GetOrdinal("Criticidad")),
            };
        }
    }
}
