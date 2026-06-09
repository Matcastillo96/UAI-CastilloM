using System.Collections.Generic;
using DIEFER.BE;

namespace DIEFER.Servicios
{
    public interface IUsuario_593CM
    {
        bool ExisteDNI_593CM(string dni);
        bool ExisteLogin_593CM(string login, string dniExcluir = null);
        bool Insertar_593CM(Usuario_593CM u);
        Usuario_593CM BuscarPorLogin_593CM(string login);
        Usuario_593CM BuscarPorDNI_593CM(string dni);
        bool Actualizar_593CM(Usuario_593CM u);
        bool ActualizarBloqueo_593CM(string dni, bool bloqueado);
        bool ActualizarActivo_593CM(string dni, bool activo);
        bool ActualizarPassword_593CM(string dni, string nuevoHash);
        List<Usuario_593CM> GetBloqueados_593CM();
        List<Usuario_593CM> Listar_593CM(bool soloActivos, string filtroDNI = null,
                             string filtroApellidos = null, string filtroNombre = null,
                             string filtroEmail = null, string filtroRol = null,
                             string filtroLogin = null);
        List<string> GetLoginsParaDV_593CM();
        (string Nombre, string Apellido) BuscarNombreApellidoPorLogin_593CM(string login);
        bool ActualizarIdioma_593CM(string dni, string codigo);
    }
}
