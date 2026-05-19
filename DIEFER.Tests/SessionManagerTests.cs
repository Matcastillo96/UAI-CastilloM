using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIEFER.BE;
using DIEFER.BLL;

namespace DIEFER.Tests
{
    [TestClass]
    public class SessionManagerTests_593CM
    {
        [TestInitialize]
        public void Setup_593CM()
        {
            SessionManager_593CM.GetInstancia_593CM().Cerrar_593CM();
        }

        [TestMethod]
        public void GetInstancia_RetornaMismaInstancia_593CM()
        {
            var sm1 = SessionManager_593CM.GetInstancia_593CM();
            var sm2 = SessionManager_593CM.GetInstancia_593CM();
            Assert.AreSame(sm1, sm2);
        }

        [TestMethod]
        public void Iniciar_EstableceUsuarioActual_593CM()
        {
            var u = new Usuario_593CM { DNI_593CM = "12345678", Login_593CM = "Juan.Perez", Rol_593CM = "Vendedor" };
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(u);
            Assert.AreEqual("Juan.Perez", SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM?.Login_593CM);
        }

        [TestMethod]
        public void Cerrar_LimpiaUsuarioActual_593CM()
        {
            var u = new Usuario_593CM { DNI_593CM = "12345678", Login_593CM = "Juan.Perez", Rol_593CM = "Vendedor" };
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(u);
            SessionManager_593CM.GetInstancia_593CM().Cerrar_593CM();
            Assert.IsNull(SessionManager_593CM.GetInstancia_593CM().UsuarioActual_593CM);
        }

        [TestMethod]
        public void HaySesionActiva_SinIniciar_EsFalso_593CM()
        {
            Assert.IsFalse(SessionManager_593CM.GetInstancia_593CM().HaySesionActiva_593CM);
        }

        [TestMethod]
        public void HaySesionActiva_ConUsuario_EsVerdadero_593CM()
        {
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(new Usuario_593CM { Login_593CM = "test" });
            Assert.IsTrue(SessionManager_593CM.GetInstancia_593CM().HaySesionActiva_593CM);
        }
    }
}
