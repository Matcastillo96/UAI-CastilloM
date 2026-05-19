using Microsoft.VisualStudio.TestTools.UnitTesting;
using DIEFER.Servicios;

namespace DIEFER.Tests
{
    [TestClass]
    public class CriptoServiceTests_593CM
    {
        [TestMethod]
        public void HashSHA256_MismoInput_ProduceMismoOutput_593CM()
        {
            string h1 = CriptoService_593CM.HashSHA256_593CM("MiPassword123");
            string h2 = CriptoService_593CM.HashSHA256_593CM("MiPassword123");
            Assert.AreEqual(h1, h2);
        }

        [TestMethod]
        public void HashSHA256_InputsDiferentes_ProducenOutputsDiferentes_593CM()
        {
            string h1 = CriptoService_593CM.HashSHA256_593CM("pass1");
            string h2 = CriptoService_593CM.HashSHA256_593CM("pass2");
            Assert.AreNotEqual(h1, h2);
        }

        [TestMethod]
        public void HashSHA256_Longitud_Es64Caracteres_593CM()
        {
            string hash = CriptoService_593CM.HashSHA256_593CM("cualquier texto");
            Assert.AreEqual(64, hash.Length);
        }

        [TestMethod]
        public void HashSHA256_SoloHexadecimal_593CM()
        {
            string hash = CriptoService_593CM.HashSHA256_593CM("test");
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(hash, "^[0-9a-f]{64}$"));
        }

        [TestMethod]
        public void AES_RoundTrip_RecuperaTextoOriginal_593CM()
        {
            string clave    = System.Convert.ToBase64String(new byte[32]); // 32 bytes de ceros (desarrollo)
            string original = "DNI123456";
            string cifrado  = CriptoService_593CM.EncriptarAES_593CM(original, clave);
            string resultado= CriptoService_593CM.DesencriptarAES_593CM(cifrado, clave);
            Assert.AreEqual(original, resultado);
        }

        [TestMethod]
        public void AES_MismoTexto_ProduceCifradosDiferentes_593CM()
        {
            // IV aleatorio garantiza que el mismo texto cifrado dos veces produce resultados distintos
            string clave = System.Convert.ToBase64String(new byte[32]);
            string c1    = CriptoService_593CM.EncriptarAES_593CM("DNI", clave);
            string c2    = CriptoService_593CM.EncriptarAES_593CM("DNI", clave);
            Assert.AreNotEqual(c1, c2);
        }

        [TestMethod]
        public void PasswordInicialAdministrador_HashConsistente_593CM()
        {
            string passInicial = CriptoService_593CM.HashSHA256_593CM("00000000Admin");
            Assert.AreEqual(64, passInicial.Length);
            Assert.AreEqual(passInicial, CriptoService_593CM.HashSHA256_593CM("00000000Admin"));
        }
    }
}
