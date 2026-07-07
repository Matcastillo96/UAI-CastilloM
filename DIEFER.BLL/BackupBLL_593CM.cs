using DIEFER.DAL;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using DIEFER.Servicios.Interfaces;

namespace DIEFER.BLL
{
    /// <summary>
    /// Orquesta operaciones de backup/restore y su registro en bitácora.
    /// </summary>
    public class BackupBLL_593CM : IBackupService_593CM
    {
        private readonly IBackupDAL_593CM _backupDAL_593CM;
        private readonly EventoBLL_593CM  _eventoBLL_593CM;

        public BackupBLL_593CM() : this(new BackupDAL_593CM(), new EventoBLL_593CM()) { }

        public BackupBLL_593CM(IBackupDAL_593CM backupDAL, EventoBLL_593CM eventoBLL)
        {
            _backupDAL_593CM = backupDAL;
            _eventoBLL_593CM = eventoBLL;
        }

        /// <summary>Crea una copia de seguridad y registra el evento.</summary>
        public void Backup_593CM(string rutaDestino)
        {
            _backupDAL_593CM.Backup_593CM(rutaDestino);

            string login = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM
                           ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(login, "Servicio", "Backup ejecutado", 2);
        }

        /// <summary>Restaura la BD desde un backup y registra el evento.</summary>
        public void Restaurar_593CM(string rutaOrigen)
        {
            _backupDAL_593CM.Restaurar_593CM(rutaOrigen);

            string login = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM
                           ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(login, "Servicio", "Restore ejecutado", 1);
        }
    }
}
