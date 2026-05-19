using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DIEFER.BE;
using DIEFER.BLL;
using DIEFER.DAL;
using DIEFER.Servicios;

namespace DIEFER.Tests
{
    [TestClass]
    public class UsuarioControllerTests_593CM
    {
        private Mock<IUsuarioDB_593CM>  _mockDB_593CM;
        private Mock<IEventoDAL_593CM>  _mockEventoDB_593CM;
        private UsuarioController_593CM _ctrl_593CM;
        private EventoBLL_593CM         _eventoBLL_593CM;

        // Hash SHA-256 de "12345678Rodriguez" (password inicial del usuario de prueba)
        private static readonly string HashCorrecto_593CM = CriptoService_593CM.HashSHA256_593CM("12345678Rodriguez");

        private Usuario_593CM UsuarioPrueba_593CM() => new Usuario_593CM
        {
            DNI_593CM       = "12345678",
            Apellidos_593CM = "Rodriguez",
            Nombre_593CM    = "Ana",
            Login_593CM     = "Ana.Rodriguez",
            Password_593CM  = HashCorrecto_593CM,
            Rol_593CM       = "Vendedor",
            Email_593CM     = "ana@test.com",
            Bloqueado_593CM = false,
            Activo_593CM    = true,
        };

        [TestInitialize]
        public void Setup_593CM()
        {
            SessionManager_593CM.GetInstancia_593CM().Cerrar_593CM();
            DVService_593CM.ResetearReferencia_593CM();
            _mockDB_593CM       = new Mock<IUsuarioDB_593CM>();
            _mockEventoDB_593CM = new Mock<IEventoDAL_593CM>();
            _mockDB_593CM.Setup(d => d.GetLoginsParaDV_593CM()).Returns(new List<string> { "Ana.Rodriguez" });
            _eventoBLL_593CM    = new EventoBLL_593CM(_mockEventoDB_593CM.Object, _mockDB_593CM.Object);
            _ctrl_593CM         = new UsuarioController_593CM(_mockDB_593CM.Object, _eventoBLL_593CM);
        }

        // ── Autenticación ───────────────────────────────────────────────────────────────

        [TestMethod]
        public void Autenticar_CredencialesCorrectas_RetornaExitoso_593CM()
        {
            _mockDB_593CM.Setup(d => d.BuscarPorLogin_593CM("Ana.Rodriguez")).Returns(UsuarioPrueba_593CM());

            var resultado = _ctrl_593CM.Autenticar_593CM("Ana.Rodriguez", "12345678Rodriguez", out var u);

            Assert.AreEqual(UsuarioController_593CM.ResultadoLogin_593CM.Exitoso, resultado);
            Assert.IsNotNull(u);
        }

        [TestMethod]
        public void Autenticar_PasswordIncorrecto_RetornaCredencialesInvalidas_593CM()
        {
            _mockDB_593CM.Setup(d => d.BuscarPorLogin_593CM("Ana.Rodriguez")).Returns(UsuarioPrueba_593CM());

            var resultado = _ctrl_593CM.Autenticar_593CM("Ana.Rodriguez", "wrongpassword", out _);

            Assert.AreEqual(UsuarioController_593CM.ResultadoLogin_593CM.CredencialesInvalidas, resultado);
        }

        [TestMethod]
        public void Autenticar_LoginInexistente_RetornaCuentaInactivaBloqueada_593CM()
        {
            _mockDB_593CM.Setup(d => d.BuscarPorLogin_593CM("nobody")).Returns((Usuario_593CM)null);

            var resultado = _ctrl_593CM.Autenticar_593CM("nobody", "pass", out _);

            Assert.AreEqual(UsuarioController_593CM.ResultadoLogin_593CM.CuentaInactivaBloqueada, resultado);
        }

        [TestMethod]
        public void Autenticar_UsuarioBloqueado_RetornaCuentaInactivaBloqueada_593CM()
        {
            var u = UsuarioPrueba_593CM();
            u.Bloqueado_593CM = true;
            _mockDB_593CM.Setup(d => d.BuscarPorLogin_593CM("Ana.Rodriguez")).Returns(u);

            var resultado = _ctrl_593CM.Autenticar_593CM("Ana.Rodriguez", "12345678Rodriguez", out _);

            Assert.AreEqual(UsuarioController_593CM.ResultadoLogin_593CM.CuentaInactivaBloqueada, resultado);
        }

        // ── Crear ───────────────────────────────────────────────────────────────────────

        [TestMethod]
        public void Crear_CamposRequeridos_FaltaDNI_RetornaCamposRequeridos_593CM()
        {
            var res = _ctrl_593CM.Crear_593CM("", "Perez", "Luis", "l@x.com", "Vendedor");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCrear_593CM.CamposRequeridos, res);
        }

        [TestMethod]
        public void Crear_EmailInvalido_RetornaEmailInvalido_593CM()
        {
            _mockDB_593CM.Setup(d => d.ExisteDNI_593CM("99999999")).Returns(false);
            var res = _ctrl_593CM.Crear_593CM("99999999", "Perez", "Luis", "no-es-email", "Vendedor");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCrear_593CM.EmailInvalido, res);
        }

        [TestMethod]
        public void Crear_DNIExistente_RetornaDNIExistente_593CM()
        {
            _mockDB_593CM.Setup(d => d.ExisteDNI_593CM("12345678")).Returns(true);
            var res = _ctrl_593CM.Crear_593CM("12345678", "Rodriguez", "Ana", "ana@test.com", "Vendedor");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCrear_593CM.DNIExistente, res);
        }

        [TestMethod]
        public void Crear_DatosValidos_RetornaExitoso_593CM()
        {
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(
                new Usuario_593CM { Login_593CM = "Sistema.Admin", Rol_593CM = "Administrador" });
            _mockDB_593CM.Setup(d => d.ExisteDNI_593CM("88888888")).Returns(false);
            _mockDB_593CM.Setup(d => d.ExisteLogin_593CM("Maria.Lopez", null)).Returns(false);
            _mockDB_593CM.Setup(d => d.Insertar_593CM(It.IsAny<Usuario_593CM>())).Returns(true);
            _mockDB_593CM.Setup(d => d.GetLoginsParaDV_593CM()).Returns(new List<string>());

            var res = _ctrl_593CM.Crear_593CM("88888888", "Lopez", "Maria", "maria@test.com", "Cajero");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCrear_593CM.Exitoso, res);
            _mockDB_593CM.Verify(d => d.Insertar_593CM(It.Is<Usuario_593CM>(u =>
                u.DNI_593CM      == "88888888"   &&
                u.Login_593CM    == "Maria.Lopez" &&
                u.Activo_593CM   == true          &&
                u.Bloqueado_593CM == false         &&
                u.Password_593CM.Length == 64)), Times.Once);
        }

        // ── CambiarClave ────────────────────────────────────────────────────────────────

        [TestMethod]
        public void CambiarClave_ConfirmacionNoCoincide_RetornaError_593CM()
        {
            var res = _ctrl_593CM.CambiarClave_593CM("claveActual", "Clave123", "Clave456");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCambiarClave_593CM.ConfirmacionNoCoincide, res);
        }

        [TestMethod]
        public void CambiarClave_NuevaClaveDebil_RetornaInvalida_593CM()
        {
            var res = _ctrl_593CM.CambiarClave_593CM("claveActual", "corta", "corta");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCambiarClave_593CM.NuevaClaveInvalida, res);
        }

        [TestMethod]
        public void CambiarClave_ClaveActualIncorrecta_RetornaError_593CM()
        {
            var u = UsuarioPrueba_593CM();
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(u);

            var res = _ctrl_593CM.CambiarClave_593CM("ClaveWrong1", "Clave123Nuevo", "Clave123Nuevo");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCambiarClave_593CM.ClaveActualIncorrecta, res);
        }

        [TestMethod]
        public void CambiarClave_DatosCorrectos_RetornaExitoso_593CM()
        {
            var u = UsuarioPrueba_593CM();
            SessionManager_593CM.GetInstancia_593CM().Iniciar_593CM(u);
            _mockDB_593CM.Setup(d => d.ActualizarPassword_593CM(u.DNI_593CM, It.IsAny<string>())).Returns(true);

            var res = _ctrl_593CM.CambiarClave_593CM("12345678Rodriguez", "NuevaClave1A", "NuevaClave1A");
            Assert.AreEqual(UsuarioController_593CM.ResultadoCambiarClave_593CM.Exitoso, res);
            _mockDB_593CM.Verify(d => d.ActualizarPassword_593CM(u.DNI_593CM, It.IsAny<string>()), Times.Once);
        }
    }
}
