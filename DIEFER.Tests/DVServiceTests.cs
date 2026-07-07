using System;
using System.Collections.Generic;
using System.Linq;
using DIEFER.Servicios;
using DIEFER.Servicios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DIEFER.Tests
{
    [TestClass]
    public class DVServiceTests_593CM
    {
        private class TablaFake_593CM : ITablaControlada_593CM
        {
            public string NombreTabla_593CM { get; }
            public List<(string clave, string cadena)> Registros_593CM { get; }

            public TablaFake_593CM(string nombre, List<(string, string)> registros)
            {
                NombreTabla_593CM = nombre;
                Registros_593CM = registros;
            }

            public IEnumerable<(string clave, string cadena)> ObtenerRegistros_593CM()
                => Registros_593CM;
        }

        private class RepositorioFake_593CM : IDVRepositorio_593CM
        {
            public Dictionary<string, string> DVVs { get; } = new Dictionary<string, string>();
            public Dictionary<string, Dictionary<string, string>> DVHs { get; }
                = new Dictionary<string, Dictionary<string, string>>();

            public List<string> ListarTablasControladas_593CM()
                => DVVs.Keys.ToList();

            public string ObtenerDVV_593CM(string nombreTabla)
                => DVVs.TryGetValue(nombreTabla, out var v) ? v : null;

            public void GuardarDVV_593CM(string nombreTabla, string dvv)
                => DVVs[nombreTabla] = dvv;

            public string ObtenerDVH_593CM(string nombreTabla, string claveRegistro)
            {
                if (DVHs.TryGetValue(nombreTabla, out var tabla) &&
                    tabla.TryGetValue(claveRegistro, out var dvh))
                    return dvh;
                return null;
            }

            public void GuardarDVH_593CM(string nombreTabla, string claveRegistro, string dvh)
            {
                if (!DVHs.TryGetValue(nombreTabla, out var tabla))
                {
                    tabla = new Dictionary<string, string>();
                    DVHs[nombreTabla] = tabla;
                }
                tabla[claveRegistro] = dvh;
            }

            public void EliminarDVHsDeTabla_593CM(string nombreTabla)
            {
                if (DVHs.ContainsKey(nombreTabla))
                    DVHs[nombreTabla].Clear();
            }

            public List<(string clave, string dvh)> ObtenerDVHsDeTabla_593CM(string nombreTabla)
            {
                if (!DVHs.TryGetValue(nombreTabla, out var tabla))
                    return new List<(string, string)>();
                return tabla.OrderBy(x => x.Key).Select(x => (x.Key, x.Value)).ToList();
            }
        }

        [TestMethod]
        public void CalcularDVH_EmiteHex64_593CM()
        {
            string hash = DVService_593CM.CalcularDVH_593CM("prueba");
            Assert.AreEqual(64, hash.Length);
            Assert.IsTrue(hash.All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f')));
        }

        [TestMethod]
        public void RecalcularTabla_GuardaDVHyDVV_593CM()
        {
            var repo = new RepositorioFake_593CM();
            repo.DVVs["T"] = "PENDIENTE";

            var tabla = new TablaFake_593CM("T", new List<(string, string)>
            {
                ("1", "A|B"),
                ("2", "C|D")
            });

            var proveedores = new Dictionary<string, ITablaControlada_593CM>
            {
                { "T", tabla }
            };

            var svc = new DVService_593CM(repo, proveedores);
            svc.RecalcularTabla_593CM("T");

            Assert.IsNotNull(repo.ObtenerDVV_593CM("T"));
            Assert.AreNotEqual("PENDIENTE", repo.ObtenerDVV_593CM("T"));
            Assert.IsNotNull(repo.ObtenerDVH_593CM("T", "1"));
            Assert.IsNotNull(repo.ObtenerDVH_593CM("T", "2"));
        }

        [TestMethod]
        public void VerificarTabla_DetectaTampering_593CM()
        {
            var repo = new RepositorioFake_593CM();
            repo.DVVs["T"] = "PENDIENTE";

            var tabla = new TablaFake_593CM("T", new List<(string, string)>
            {
                ("1", "A|B"),
                ("2", "C|D")
            });

            var proveedores = new Dictionary<string, ITablaControlada_593CM>
            {
                { "T", tabla }
            };

            var svc = new DVService_593CM(repo, proveedores);
            svc.RecalcularTabla_593CM("T");

            Assert.IsTrue(svc.VerificarTabla_593CM("T"));

            tabla.Registros_593CM[0] = ("1", "A|X"); // alterar
            Assert.IsFalse(svc.VerificarTabla_593CM("T"));
        }

        [TestMethod]
        public void VerificarTabla_DetectaRegistroEliminado_593CM()
        {
            var repo = new RepositorioFake_593CM();
            repo.DVVs["T"] = "PENDIENTE";

            var tabla = new TablaFake_593CM("T", new List<(string, string)>
            {
                ("1", "A|B"),
                ("2", "C|D")
            });

            var proveedores = new Dictionary<string, ITablaControlada_593CM>
            {
                { "T", tabla }
            };

            var svc = new DVService_593CM(repo, proveedores);
            svc.RecalcularTabla_593CM("T");

            tabla.Registros_593CM.RemoveAt(1);
            Assert.IsFalse(svc.VerificarTabla_593CM("T"));
        }

        [TestMethod]
        public void RecalcularTablaVacia_GeneraDVV_593CM()
        {
            var repo = new RepositorioFake_593CM();
            repo.DVVs["T"] = "PENDIENTE";

            var tabla = new TablaFake_593CM("T", new List<(string, string)>());
            var proveedores = new Dictionary<string, ITablaControlada_593CM>
            {
                { "T", tabla }
            };

            var svc = new DVService_593CM(repo, proveedores);
            svc.RecalcularTabla_593CM("T");

            Assert.IsNotNull(repo.ObtenerDVV_593CM("T"));
            Assert.AreEqual(64, repo.ObtenerDVV_593CM("T").Length);
        }

        [TestMethod]
        public void DVV_EsEstableAnteOrdenDeLectura_593CM()
        {
            var repo = new RepositorioFake_593CM();
            repo.DVVs["T"] = "PENDIENTE";

            var tabla = new TablaFake_593CM("T", new List<(string, string)>
            {
                ("2", "C|D"),
                ("1", "A|B")
            });

            var proveedores = new Dictionary<string, ITablaControlada_593CM>
            {
                { "T", tabla }
            };

            var svc = new DVService_593CM(repo, proveedores);
            svc.RecalcularTabla_593CM("T");

            string dvv = repo.ObtenerDVV_593CM("T");
            Assert.IsTrue(svc.VerificarTabla_593CM("T"));
        }
    }
}
