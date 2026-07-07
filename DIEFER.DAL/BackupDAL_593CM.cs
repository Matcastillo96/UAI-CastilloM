using System;
using System.Data.SqlClient;
using System.IO;
using DIEFER.DAL.Interfaces;

namespace DIEFER.DAL
{
    /// <summary>
    /// Implementación de BACKUP/RESTORE de SQL Server contra la base de datos master.
    /// </summary>
    public class BackupDAL_593CM : IBackupDAL_593CM
    {
        private const string NombreBaseDeDatos_593CM = "DIEFER";

        public void Backup_593CM(string rutaDestino)
        {
            ValidarRuta_593CM(rutaDestino, debeExistirDirectorio: true);

            string sql = $"BACKUP DATABASE [{NombreBaseDeDatos_593CM}] TO DISK = @Ruta";

            using (var conn = ConexionDB_593CM.AbrirConexionMaster_593CM())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Ruta", rutaDestino);
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        public void Restaurar_593CM(string rutaOrigen)
        {
            ValidarRuta_593CM(rutaOrigen, debeExistirArchivo: true);

            using (var conn = ConexionDB_593CM.AbrirConexionMaster_593CM())
            {
                string setSingleUser = $"ALTER DATABASE [{NombreBaseDeDatos_593CM}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                string restore = $"RESTORE DATABASE [{NombreBaseDeDatos_593CM}] FROM DISK = @Ruta WITH REPLACE";
                string setMultiUser = $"ALTER DATABASE [{NombreBaseDeDatos_593CM}] SET MULTI_USER";

                using (var cmd = new SqlCommand(setSingleUser, conn) { CommandTimeout = 300 })
                    cmd.ExecuteNonQuery();

                try
                {
                    using (var cmd = new SqlCommand(restore, conn) { CommandTimeout = 600 })
                    {
                        cmd.Parameters.AddWithValue("@Ruta", rutaOrigen);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    try
                    {
                        using (var cmd = new SqlCommand(setMultiUser, conn) { CommandTimeout = 300 })
                            cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        // No relanzar: el restore ya sucedió (o falló) y queremos dejar
                        // la BD en estado usable lo antes posible.
                    }
                }
            }
        }

        private static void ValidarRuta_593CM(string ruta, bool debeExistirDirectorio = false,
                                              bool debeExistirArchivo = false)
        {
            if (string.IsNullOrWhiteSpace(ruta))
                throw new ArgumentException("La ruta no puede estar vacía.", nameof(ruta));

            if (debeExistirArchivo && !File.Exists(ruta))
                throw new FileNotFoundException("No se encontró el archivo de backup.", ruta);

            if (debeExistirDirectorio)
            {
                string directorio = Path.GetDirectoryName(Path.GetFullPath(ruta));
                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);
            }
        }
    }
}
