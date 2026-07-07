namespace DIEFER.DAL.Interfaces
{
    /// <summary>Contrato DAL para operaciones BACKUP/RESTORE de SQL Server.</summary>
    public interface IBackupDAL_593CM
    {
        void Backup_593CM(string rutaDestino);
        void Restaurar_593CM(string rutaOrigen);
    }
}
