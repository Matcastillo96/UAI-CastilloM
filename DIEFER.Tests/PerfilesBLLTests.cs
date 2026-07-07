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
    public class PerfilesBLLTests_593CM
    {
        [TestMethod]
        public void CrearFamiliaConPatentes_RechazaNombreVacio_593CM()
        {
            var bll = new PerfilesBLL_593CM(
                new FamiliaDALFake_593CM(),
                new PatenteDALFake_593CM(),
                new RolPermisoDALFake_593CM(),
                new DVBLLFake_593CM());

            var resultado = bll.CrearFamiliaConPatentes_593CM("   ", new[] { 1 }, out _);

            Assert.AreEqual(PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.NombreRequerido, resultado);
        }

        [TestMethod]
        public void CrearFamiliaConPatentes_RechazaSinPatentes_593CM()
        {
            var bll = new PerfilesBLL_593CM(
                new FamiliaDALFake_593CM(),
                new PatenteDALFake_593CM(),
                new RolPermisoDALFake_593CM(),
                new DVBLLFake_593CM());

            var resultado = bll.CrearFamiliaConPatentes_593CM("Familia", Enumerable.Empty<int>(), out _);

            Assert.AreEqual(PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.PatenteRequerida, resultado);
        }

        [TestMethod]
        public void CrearFamiliaConPatentes_CreaYAsignaPatentes_593CM()
        {
            var familiaDAL = new FamiliaDALFake_593CM();
            var bll = new PerfilesBLL_593CM(
                familiaDAL,
                new PatenteDALFake_593CM(),
                new RolPermisoDALFake_593CM(),
                new DVBLLFake_593CM());

            var resultado = bll.CrearFamiliaConPatentes_593CM("Familia", new[] { 1, 2 }, out int id);

            Assert.AreEqual(PerfilesBLL_593CM.ResultadoCrearFamilia_593CM.Exitoso, resultado);
            Assert.AreEqual(1, id);
            Assert.AreEqual(2, familiaDAL.PatentesAgregadas[id].Count);
        }

        [TestMethod]
        public void EliminarFamilia_BloqueaSiReferenciada_593CM()
        {
            var familiaDAL = new FamiliaDALFake_593CM();
            familiaDAL.Referencias[1] = 1; // familia 1 referenciada

            var bll = new PerfilesBLL_593CM(
                familiaDAL,
                new PatenteDALFake_593CM(),
                new RolPermisoDALFake_593CM(),
                new DVBLLFake_593CM());

            var resultado = bll.EliminarFamilia_593CM(1);

            Assert.AreEqual(PerfilesBLL_593CM.ResultadoEliminarFamilia_593CM.Referenciada, resultado);
        }

        [TestMethod]
        public void EliminarFamilia_EliminaSiNoReferenciada_593CM()
        {
            var familiaDAL = new FamiliaDALFake_593CM();
            familiaDAL.Familias.Add(new Familia_593CM { ID_familia_593CM = 1, Nombre_593CM = "F1" });

            var bll = new PerfilesBLL_593CM(
                familiaDAL,
                new PatenteDALFake_593CM(),
                new RolPermisoDALFake_593CM(),
                new DVBLLFake_593CM());

            var resultado = bll.EliminarFamilia_593CM(1);

            Assert.AreEqual(PerfilesBLL_593CM.ResultadoEliminarFamilia_593CM.Exitoso, resultado);
            Assert.IsFalse(familiaDAL.Familias.Any(f => f.ID_familia_593CM == 1));
        }

        // ── Fakes mínimas ─────────────────────────────────────────────────────────

        private class FamiliaDALFake_593CM : IFamiliaDAL_593CM
        {
            public List<Familia_593CM> Familias { get; } = new List<Familia_593CM>();
            public Dictionary<int, List<int>> PatentesAgregadas { get; } = new Dictionary<int, List<int>>();
            public Dictionary<int, int> Referencias { get; } = new Dictionary<int, int>();
            private int _nextId = 1;

            public List<Familia_593CM> ListarTodas_593CM() => Familias;
            public Familia_593CM CargarConComponentes_593CM(int idFamilia)
                => Familias.FirstOrDefault(f => f.ID_familia_593CM == idFamilia);
            public List<int> ObtenerIdsFamiliasHijas_593CM(int idFamilia) => new List<int>();
            public GrafoFamilias_593CM CargarGrafo_593CM() => new GrafoFamilias_593CM();

            public int Crear_593CM(string nombre)
            {
                int id = _nextId++;
                Familias.Add(new Familia_593CM { ID_familia_593CM = id, Nombre_593CM = nombre });
                PatentesAgregadas[id] = new List<int>();
                return id;
            }

            public bool Renombrar_593CM(int idFamilia, string nombre)
            {
                var f = Familias.FirstOrDefault(x => x.ID_familia_593CM == idFamilia);
                if (f != null) f.Nombre_593CM = nombre;
                return f != null;
            }

            public bool Eliminar_593CM(int idFamilia)
            {
                var f = Familias.FirstOrDefault(x => x.ID_familia_593CM == idFamilia);
                if (f != null) Familias.Remove(f);
                return f != null;
            }

            public int ContarReferencias_593CM(int idFamilia)
                => Referencias.TryGetValue(idFamilia, out var c) ? c : 0;

            public bool AgregarPatente_593CM(int idFamilia, int idPatente)
            {
                if (!PatentesAgregadas.TryGetValue(idFamilia, out var lista))
                    PatentesAgregadas[idFamilia] = lista = new List<int>();
                lista.Add(idPatente);
                return true;
            }

            public bool AgregarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija) => true;
            public bool QuitarPatente_593CM(int idFamilia, int idPatente) => true;
            public bool QuitarSubFamilia_593CM(int idFamiliaPadre, int idFamiliaHija) => true;
        }

        private class PatenteDALFake_593CM : IPatenteDAL_593CM
        {
            public List<Patente_593CM> ListarTodas_593CM()
                => new List<Patente_593CM>
                {
                    new Patente_593CM { ID_patente_593CM = 1, Nombre_593CM = "P1", Permiso_593CM = "P1" },
                    new Patente_593CM { ID_patente_593CM = 2, Nombre_593CM = "P2", Permiso_593CM = "P2" }
                };
        }

        private class RolPermisoDALFake_593CM : IRolPermisoDAL_593CM
        {
            public List<Patente_593CM> ObtenerPatentesDirectas_593CM(int idRol) => new List<Patente_593CM>();
            public List<Familia_593CM> ObtenerFamiliasDirectas_593CM(int idRol) => new List<Familia_593CM>();
            public bool AgregarPatente_593CM(int idRol, int idPatente) => true;
            public bool AgregarFamilia_593CM(int idRol, int idFamilia) => true;
            public bool QuitarPatente_593CM(int idRol, int idPatente) => true;
            public bool QuitarFamilia_593CM(int idRol, int idFamilia) => true;
            public bool QuitarTodasLasPatentes_593CM(int idRol) => true;
            public bool QuitarTodasLasFamilias_593CM(int idRol) => true;
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
