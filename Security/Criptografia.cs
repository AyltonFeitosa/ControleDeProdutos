using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ControleDeProdutos.Security
{
    public class Criptografia
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public Criptografia()
        {
            _key = Convert.FromBase64String("zb+W8GF3F0uPy7QZUXqOOg==");
            _iv = Convert.FromBase64String("/ECfy8JYc0GkcGXLYSnLMQ==");
        }

        public string Criptografar(string valorDescriptrografado)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform encriptador = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msCriptografar = new MemoryStream();
            using CryptoStream csCriptografar = new CryptoStream(msCriptografar, encriptador, CryptoStreamMode.Write);
            using (StreamWriter swCriptografar = new StreamWriter(csCriptografar))
            {
                swCriptografar.Write(valorDescriptrografado);
            }

            // Retorna os dados criptografados como uma string Base64
            return Convert.ToBase64String(msCriptografar.ToArray());
        }
    }
}
