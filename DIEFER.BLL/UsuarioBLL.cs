using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.BLL
{
    public class UsuarioBLL_593CM
    {
        private readonly IUsuario_593CM  _usuarioDAL_593CM;
        private readonly EventoBLL_593CM _eventoBLL_593CM;
        private readonly RolBLL_593CM    _rolBLL_593CM;

        private static readonly Dictionary<string, int> _intentosFallidos_593CM =
            new Dictionary<string, int>();
        private static readonly object _loginLock = new object();

        public UsuarioBLL_593CM() : this(new UsuarioDAL_593CM(), new EventoBLL_593CM()) { }

        public UsuarioBLL_593CM(IUsuario_593CM usuarioDAL, EventoBLL_593CM eventoBLL)
        {
            _usuarioDAL_593CM = usuarioDAL;
            _eventoBLL_593CM  = eventoBLL;
            _rolBLL_593CM     = new RolBLL_593CM();
        }

        // ── Autenticación ───────────────────────────────────────────────────────────────

        public enum ResultadoLogin_593CM
        {
            Exitoso, CredencialesInvalidas, CuentaInactivaBloqueada,
            ErrorIntegridad, Bloqueado, CuentaNoExistente
        }

        public ResultadoLogin_593CM Autenticar_593CM(string login, string password,
                                                      out Usuario_593CM usuarioAutenticado)
        {
            usuarioAutenticado = null;
            var usuario = _usuarioDAL_593CM.BuscarPorLogin_593CM(login);

            if (usuario == null)
                return ResultadoLogin_593CM.CuentaNoExistente;

            if (!usuario.Activo_593CM || usuario.Bloqueado_593CM)
            {
                _eventoBLL_593CM.Registrar_593CM(login, "Usuario", "Login fallido", 1);
                return ResultadoLogin_593CM.CuentaInactivaBloqueada;
            }

            string hashIngresado = CriptoService_593CM.HashSHA256_593CM(password);
            if (!string.Equals(hashIngresado, usuario.Password_593CM, StringComparison.Ordinal))
            {
                _eventoBLL_593CM.Registrar_593CM(login, "Usuario", "Login fallido", 1);

                bool bloquear = false;
                lock (_loginLock)
                {
                    if (!_intentosFallidos_593CM.ContainsKey(login))
                        _intentosFallidos_593CM[login] = 0;
                    _intentosFallidos_593CM[login]++;
                    bloquear = _intentosFallidos_593CM[login] >= 3;
                }

                if (bloquear)
                {
                    _usuarioDAL_593CM.ActualizarBloqueo_593CM(usuario.DNI_593CM, true);
                    _eventoBLL_593CM.Registrar_593CM(login, "Usuario", "Bloquear Usuario", 1);
                    ActualizarDV_593CM();
                    return ResultadoLogin_593CM.Bloqueado;
                }
                return ResultadoLogin_593CM.CredencialesInvalidas;
            }

            var logins = _usuarioDAL_593CM.GetLoginsParaDV_593CM();
            if (!DVService_593CM.VerificarIntegridad_593CM(logins))
                return ResultadoLogin_593CM.ErrorIntegridad;

            lock (_loginLock)
                _intentosFallidos_593CM.Remove(login);
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(usuario);

            // Restaurar idioma preferido del usuario
            IdiomaService_593CM.GetInstancia_593CM().CambiarIdioma_593CM(
                usuario.Idioma_593CM ?? "es");

            _eventoBLL_593CM.Registrar_593CM(login, "Usuario", "Login", 1);
            usuarioAutenticado = usuario;
            return ResultadoLogin_593CM.Exitoso;
        }

        // ── Crear ───────────────────────────────────────────────────────────────────────

        public enum ResultadoCrear_593CM
        {
            Exitoso, DNIExistente, LoginExistente, CamposRequeridos, EmailInvalido
        }

        public ResultadoCrear_593CM Crear_593CM(string dni, string apellidos, string nombre,
                                                 string email, string rol)
        {
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(rol))
                return ResultadoCrear_593CM.CamposRequeridos;

            if (!EsEmailValido_593CM(email))
                return ResultadoCrear_593CM.EmailInvalido;

            if (_usuarioDAL_593CM.ExisteDNI_593CM(dni))
                return ResultadoCrear_593CM.DNIExistente;

            string login    = $"{nombre.Trim()}.{apellidos.Trim()}";
            string passHash = CriptoService_593CM.HashSHA256_593CM($"{dni}{apellidos.Trim()}");

            if (_usuarioDAL_593CM.ExisteLogin_593CM(login))
                return ResultadoCrear_593CM.LoginExistente;

            var u = new Usuario_593CM
            {
                DNI_593CM       = dni.Trim(),
                Apellidos_593CM = apellidos.Trim(),
                Nombre_593CM    = nombre.Trim(),
                Login_593CM     = login,
                Password_593CM  = passHash,
                ID_rol_593CM    = _rolBLL_593CM.ObtenerIDPorNombre_593CM(rol),
                Rol_593CM       = rol,
                Email_593CM     = email.Trim(),
                Bloqueado_593CM = false,
                Activo_593CM    = true,
            };

            _usuarioDAL_593CM.Insertar_593CM(u);
            ActualizarDV_593CM();

            string loginActual = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(loginActual, "Usuario", "Crear Usuario", 2);
            return ResultadoCrear_593CM.Exitoso;
        }

        // ── Modificar ───────────────────────────────────────────────────────────────────

        public enum ResultadoModificar_593CM
        {
            Exitoso, CamposRequeridos, EmailInvalido, LoginExistente
        }

        public ResultadoModificar_593CM Modificar_593CM(string dni, string apellidos, string nombre,
                                                         string email, string rol)
        {
            if (string.IsNullOrWhiteSpace(apellidos) || string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(rol))
                return ResultadoModificar_593CM.CamposRequeridos;

            if (!EsEmailValido_593CM(email))
                return ResultadoModificar_593CM.EmailInvalido;

            string nuevoLogin = $"{nombre.Trim()}.{apellidos.Trim()}";
            if (_usuarioDAL_593CM.ExisteLogin_593CM(nuevoLogin, dni))
                return ResultadoModificar_593CM.LoginExistente;

            var u = new Usuario_593CM
            {
                DNI_593CM       = dni,
                Apellidos_593CM = apellidos.Trim(),
                Nombre_593CM    = nombre.Trim(),
                Login_593CM     = nuevoLogin,
                ID_rol_593CM    = _rolBLL_593CM.ObtenerIDPorNombre_593CM(rol),
                Rol_593CM       = rol,
                Email_593CM     = email.Trim(),
            };

            _usuarioDAL_593CM.Actualizar_593CM(u);
            ActualizarDV_593CM();

            string loginActual = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(loginActual, "Usuario", "Modificar Usuario", 2);
            return ResultadoModificar_593CM.Exitoso;
        }

        // ── Desbloquear ─────────────────────────────────────────────────────────────────

        public enum ResultadoDesbloquear_593CM
        {
            Exitoso, ConfirmacionNoCoincide, NuevaClaveInvalida, ErrorDB
        }

        public ResultadoDesbloquear_593CM Desbloquear_593CM(string dni, string nuevaClave, string confirmacion)
        {
            if (!string.Equals(nuevaClave, confirmacion, StringComparison.Ordinal))
                return ResultadoDesbloquear_593CM.ConfirmacionNoCoincide;

            if (!CumpleReglasClave_593CM(nuevaClave))
                return ResultadoDesbloquear_593CM.NuevaClaveInvalida;

            string nuevoHash = CriptoService_593CM.HashSHA256_593CM(nuevaClave);
            _usuarioDAL_593CM.ActualizarPassword_593CM(dni, nuevoHash);

            bool ok = _usuarioDAL_593CM.ActualizarBloqueo_593CM(dni, false);
            if (!ok) return ResultadoDesbloquear_593CM.ErrorDB;

            ActualizarDV_593CM();
            string loginActual = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(loginActual, "Usuario", "Desbloquear Usuario", 1);
            return ResultadoDesbloquear_593CM.Exitoso;
        }

        // ── Activar / Desactivar ────────────────────────────────────────────────────────

        public enum ResultadoCambiarEstado_593CM { Exitoso, NoPermitido }

        public ResultadoCambiarEstado_593CM CambiarEstado_593CM(string dni, bool activar)
        {
            var actual = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (!activar && actual != null && actual.DNI_593CM == dni)
                return ResultadoCambiarEstado_593CM.NoPermitido;

            _usuarioDAL_593CM.ActualizarActivo_593CM(dni, activar);
            ActualizarDV_593CM();

            string loginActual = actual?.Login_593CM ?? "Sistema";
            _eventoBLL_593CM.Registrar_593CM(loginActual, "Usuario", "Activar / Desactivar Usuario", 2);
            return ResultadoCambiarEstado_593CM.Exitoso;
        }

        // ── Cambiar Clave ───────────────────────────────────────────────────────────────

        public enum ResultadoCambiarClave_593CM
        {
            Exitoso, ClaveActualIncorrecta, NuevaClaveInvalida, ConfirmacionNoCoincide
        }

        public ResultadoCambiarClave_593CM CambiarClave_593CM(string claveActual, string claveNueva,
                                                               string confirmacion)
        {
            if (!string.Equals(claveNueva, confirmacion, StringComparison.Ordinal))
                return ResultadoCambiarClave_593CM.ConfirmacionNoCoincide;

            if (!CumpleReglasClave_593CM(claveNueva))
                return ResultadoCambiarClave_593CM.NuevaClaveInvalida;

            var usuario = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            string hashActual = CriptoService_593CM.HashSHA256_593CM(claveActual);
            if (!string.Equals(hashActual, usuario.Password_593CM, StringComparison.Ordinal))
                return ResultadoCambiarClave_593CM.ClaveActualIncorrecta;

            string hashNuevo = CriptoService_593CM.HashSHA256_593CM(claveNueva);
            _usuarioDAL_593CM.ActualizarPassword_593CM(usuario.DNI_593CM, hashNuevo);

            usuario.Password_593CM = hashNuevo;

            _eventoBLL_593CM.Registrar_593CM(usuario.Login_593CM, "Usuario", "Cambiar Clave", 2);
            return ResultadoCambiarClave_593CM.Exitoso;
        }

        // ── Cambiar Idioma ──────────────────────────────────────────────────────────────

        public bool CambiarIdioma_593CM(string codigo)
        {
            var usuario = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (usuario == null) return false;

            bool ok = _usuarioDAL_593CM.ActualizarIdioma_593CM(usuario.DNI_593CM, codigo);
            if (ok)
            {
                usuario.Idioma_593CM = codigo;
                IdiomaService_593CM.GetInstancia_593CM().CambiarIdioma_593CM(codigo);
                _eventoBLL_593CM.Registrar_593CM(usuario.Login_593CM, "Usuario", "Cambiar Idioma", 1);
            }
            return ok;
        }

        // ── Logout ──────────────────────────────────────────────────────────────────────

        public void Logout_593CM()
        {
            var usuario = SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM;
            if (usuario != null)
                _eventoBLL_593CM.Registrar_593CM(usuario.Login_593CM, "Usuario", "Logout", 1);
            SessionManager_593CM.GetInstancia_593CM().Cerrar_593CM();
        }

        // ── Consultas ───────────────────────────────────────────────────────────────────

        public Usuario_593CM GetByDNI_593CM(string dni) => _usuarioDAL_593CM.BuscarPorDNI_593CM(dni);

        public List<Usuario_593CM> GetBloqueados_593CM() => _usuarioDAL_593CM.GetBloqueados_593CM();

        public List<Usuario_593CM> Listar_593CM(bool soloActivos, string fdni = null,
                                                 string fape = null, string fnom = null,
                                                 string femail = null, string frol = null,
                                                 string flogin = null)
            => _usuarioDAL_593CM.Listar_593CM(soloActivos, fdni, fape, fnom, femail, frol, flogin);

        // ── Helpers ─────────────────────────────────────────────────────────────────────

        private static bool EsEmailValido_593CM(string email)
        {
            try { var _ = new System.Net.Mail.MailAddress(email); return true; }
            catch { return false; }
        }

        private static bool CumpleReglasClave_593CM(string clave)
        {
            if (clave.Length < 8) return false;
            bool tieneNumero    = Regex.IsMatch(clave, @"\d");
            bool tieneMayuscula = Regex.IsMatch(clave, @"[A-Z]");
            return tieneNumero && tieneMayuscula;
        }

        private void ActualizarDV_593CM()
        {
            var logins = _usuarioDAL_593CM.GetLoginsParaDV_593CM();
            DVService_593CM.ActualizarReferencia_593CM(logins);
        }
    }
}
