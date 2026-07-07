using System.Collections.Generic;
using System.Linq;
using DIEFER.BLL;
using DIEFER.DAL;
using DIEFER.DAL.Interfaces;
using DIEFER.Servicios;
using DIEFER.Servicios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIEFER.Tests
{
    [TestClass]
    public class RolBLLTests_593CM
    {
        [TestMethod]
        public void CrearRolConPermisos_RechazaNombreVacio_593CM()
        {
            var bll = new RolBLL_593CM(new RolDALFake_593CM(), new RolPermisoDALFake_593CM(),
                                       new DVBLLFake_593CM());

            var resultado = bll.CrearRolConPermisos_593CM("   ", new[] { 1 }, null, out _);

            Assert.AreEqual(RolBLL_593CM.ResultadoCrearRol_593CM.NombreRequerido, resultado);
        }

        [TestMethod]
        public void CrearRolConPermisos_RechazaSinPermisos_593CM()
        {
            var bll = new RolBLL_593CM(new RolDALFake_593CM(), new RolPermisoDALFake_593CM(),
                                       new DVBLLFake_593CM());

            var resultado = bll.CrearRolConPermisos_593CM("Rol", null, null, out _);

            Assert.AreEqual(RolBLL_593CM.ResultadoCrearRol_593CM.PermisoRequerido, resultado);
        }

        [TestMethod]
        public void CrearRolConPermisos_CreaConPatentes_593CM()
        {
            var rolDAL = new RolDALFake_593CM();
            var rolPermisoDAL = new RolPermisoDALFake_593CM();
            var bll = new RolBLL_593CM(rolDAL, rolPermisoDAL, new DVBLLFake_593CM());

            var resultado = bll.CrearRolConPermisos_593CM("Rol", new[] { 1, 2 }, null, out int id);

            Assert.AreEqual(RolBLL_593CM.ResultadoCrearRol_593CM.Exitoso, resultado);
            Assert.AreEqual(1, id);
            Assert.AreEqual(2, rolPermisoDAL.Patentes[id].Count);
        }

        [TestMethod]
        public void EliminarRol_BloqueaSiTieneUsuarios_593CM()
        {
            var rolDAL = new RolDALFake_593CM();
            rolDAL.UsuariosPorRol[1] = 2;

            var bll = new RolBLL_593CM(rolDAL, new RolPermisoDALFake_593CM(), new DVBLLFake_593CM());

            var resultado = bll.EliminarRol_593CM(1);

            Assert.AreEqual(RolBLL_593CM.ResultadoEliminarRol_593CM.Referenciado, resultado);
        }

        [TestMethod]
        public void EliminarRol_EliminaSiNoTieneUsuarios_593CM()
        {
            var rolDAL = new RolDALFake_593CM();
            rolDAL.Roles.Add(new Rol_593CM { ID_593CM = 1, Nombre_593CM = "R1" });

            var bll = new RolBLL_593CM(rolDAL, new RolPermisoDALFake_593CM(), new DVBLLFake_593CM());

            var resultado = bll.EliminarRol_593CM(1);

            Assert.AreEqual(RolBLL_593CM.ResultadoEliminarRol_593CM.Exitoso, resultado);
            Assert.IsFalse(rolDAL.Roles.Any(r => r.ID_593CM == 1));
        }

        private class RolDALFake_593CM : IRolDAL_593CM
        {
            public List<Rol_593CM> Roles { get; } = new List<Rol_593CM>();
            public Dictionary<int, int> UsuariosPorRol { get; } = new Dictionary<int, int>();
            private int _nextId = 1;

            public List<Rol_593CM> ListarTodos_593CM() => Roles;

            public int ObtenerIDPorNombre_593CM(string nombre)
                => Roles.FirstOrDefault(r => r.Nombre_593CM == nombre)?.ID_593CM ?? 0;

            public int Crear_593CM(string nombre)
            {
                int id = _nextId++;
                Roles.Add(new Rol_593CM { ID_593CM = id, Nombre_593CM = nombre });
                return id;
            }

            public bool Renombrar_593CM(int idRol, string nombre)
            {
                var r = Roles.FirstOrDefault(x => x.ID_593CM == idRol);
                if (r != null) r.Nombre_593CM = nombre;
                return r != null;
            }

            public bool Eliminar_593CM(int idRol)
            {
                var r = Roles.FirstOrDefault(x => x.ID_593CM == idRol);
                if (r != null) Roles.Remove(r);
                return r != null;
            }

            public int ContarUsuarios_593CM(int idRol)
                => UsuariosPorRol.TryGetValue(idRol, out var c) ? c : 0;
        }

        private class RolPermisoDALFake_593CM : IRolPermisoDAL_593CM
        {
            public Dictionary<int, List<int>> Patentes { get; } = new Dictionary<int, List<int>>();
            public Dictionary<int, List<int>> Familias { get; } = new Dictionary<int, List<int>>();

            public List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol) => new List<Patente_593CM>();
            public List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol) => new List<Familia_593CM>();

            public bool AgregarPatente_593CM(int idRol, int idPatente)
            {
                if (!Patentes.TryGetValue(idRol, out var lista))
                    Patentes[idRol] = lista = new List<int>();
                lista.Add(idPatente);
                return true;
            }

            public bool AgregarFamilia_593CM(int idRol, int idFamilia)
            {
                if (!Familias.TryGetValue(idRol, out var lista))
                    Familias[idRol] = lista = new List<int>();
                lista.Add(idFamilia);
                return true;
            }

            public bool QuitarPatente_593CM(int idRol, int idPatente) => true;
            public bool QuitarFamilia_593CM(int idRol, int idFamilia) => true;
            public bool QuitarTodasLasPatentes_593CM(int idRol) { Patentes.Remove(idRol); return true; }
            public bool QuitarTodasLasFamilias_593CM(int idRol) { Familias.Remove(idRol); return true; }
        }

        private class DVBLLFake_593CM : IDVBLL_593CM
        {
            public List<string> VerificarIntegridad_593CM() => new List<string>();
            public void RecalcularTabla_593CM(string nombreTabla) { }
            public void RecalcularTablaConBitacora_593CM(string nombreTabla, string login,
                string modulo, string evento, int criticidad) { }
            public List<string> RecalcularTodo_593CM(string login) => new List<string>();
        }
    }
}
