namespace DIEFER.Servicios
{
    /// <summary>
    /// Patrón Singleton (thread-safe, double-checked locking): única instancia
    /// que mantiene el estado de la sesión activa durante toda la ejecución.
    /// Constructor privado; acceso exclusivo por <see cref="GetInstancia_593CM"/>.
    /// </summary>
    public sealed class SessionManager_593CM
    {
        private static volatile SessionManager_593CM _instancia_593CM;
        private static readonly object _lock_593CM = new object();

        private SessionManager_593CM() { }

        public static SessionManager_593CM GetInstancia_593CM()
        {
            if (_instancia_593CM == null)
                lock (_lock_593CM)
                    if (_instancia_593CM == null)
                        _instancia_593CM = new SessionManager_593CM();
            return _instancia_593CM;
        }

        public Usuario_593CM UsuarioActual_593CM { get; private set; }
        public bool HaySesionActiva_593CM => UsuarioActual_593CM != null;

        public void Iniciar_593CM(Usuario_593CM usuario)
        {
            UsuarioActual_593CM = usuario;
        }

        public void Cerrar_593CM()
        {
            UsuarioActual_593CM = null;
        }
    }
}
