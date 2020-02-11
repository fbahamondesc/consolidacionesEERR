using System;

namespace NewConsolidado.Controladores.Clases
{
    public class Base64
    {
        public static string Base64Encode(string cadena)
        {
            byte[] cadenaByte = new byte[cadena.Length];
            cadenaByte = System.Text.Encoding.UTF8.GetBytes(cadena);
            string encodedCadena = Convert.ToBase64String(cadenaByte);
            return encodedCadena;
        }

        public static string Base64Decode(string cadena)
        {
            var encoder = new System.Text.UTF8Encoding();
            var utf8Decode = encoder.GetDecoder();

            byte[] cadenaByte = Convert.FromBase64String(cadena);
            int charCount = utf8Decode.GetCharCount(cadenaByte, 0, cadenaByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(cadenaByte, 0, cadenaByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return result;
        }
    }
}