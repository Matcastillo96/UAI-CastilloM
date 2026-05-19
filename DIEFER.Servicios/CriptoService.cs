using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DIEFER.Servicios
{
    // Servicio de criptografía: hashing SHA-256 y cifrado AES-256.
    // SHA-256 sin salt es requerimiento académico (cátedra). Producción real requeriría PBKDF2/bcrypt.
    public static class CriptoService_593CM
    {
        // Hashing irreversible — almacenamiento de contraseñas.
        public static string HashSHA256_593CM(string textoPlano)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
                var sb = new StringBuilder(64);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // AES-256: reversible — campos sensibles. IV aleatorio por operación, prefijado al resultado.
        public static string EncriptarAES_593CM(string textoPlano, string claveBase64)
        {
            byte[] key = Convert.FromBase64String(claveBase64);
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] input     = Encoding.UTF8.GetBytes(textoPlano);
                    byte[] encrypted = encryptor.TransformFinalBlock(input, 0, input.Length);
                    byte[] resultado = aes.IV.Concat(encrypted).ToArray();
                    return Convert.ToBase64String(resultado);
                }
            }
        }

        public static string DesencriptarAES_593CM(string textoCifradoBase64, string claveBase64)
        {
            byte[] datos  = Convert.FromBase64String(textoCifradoBase64);
            byte[] key    = Convert.FromBase64String(claveBase64);
            byte[] iv      = datos.Take(16).ToArray();
            byte[] cifrado = datos.Skip(16).ToArray();
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV  = iv;
                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] decrypted = decryptor.TransformFinalBlock(cifrado, 0, cifrado.Length);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
        }
    }
}
