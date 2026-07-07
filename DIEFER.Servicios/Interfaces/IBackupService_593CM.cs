namespace DIEFER.Servicios.Interfaces
{
    /// <summary>
    /// Contrato de dominio para operaciones de backup y restore de la base de datos.
    /// </summary>
    public interface IBackupService_593CM
    {
        /// <summary>Crea una copia de seguridad de la BD en la ruta indicada.</summary>
        void Backup_593CM(string rutaDestino);

        /// <summary>Restaura la BD desde la ruta indicada.</summary>
        void Restaurar_593CM(string rutaOrigen);
    }
}
