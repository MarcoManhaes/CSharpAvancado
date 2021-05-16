using Dominio;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;


namespace ConsoleApp
{
    public static class AuxiliarSerializacao
    {

        #region [+] Serializer / Desserializer XML
        public static void SerializaXML()
        {
            string caminho = "C:\\Temp\\Treinamentos\\";
            string nomeArquivo = "Serializado.xml";
            Usuario usuario = new Usuario() { Nome = "Marco Manhães Júnior", Idade = 39, Cpf = "123.345.678-90" };
            string xmlSerializado = Biblioteca.Serializacao.ExecutaSerializacaoXml(usuario, typeof(Usuario), caminho, nomeArquivo);

            Console.WriteLine("*************************************\n");
            Console.WriteLine($" ==> Arquivo serializado salvo em: {xmlSerializado}\n");
            Console.WriteLine("*************************************\n");

            LeArquivoSerializado(xmlSerializado);
        }

        public static void DesserializaXML()
        {
            string caminho = "C:\\Temp\\Treinamentos\\";
            string nomeArquivo = "Serializado.xml";
            Usuario xmlDesserializado = (Usuario)Biblioteca.Serializacao.ExecutaDesserializacaoXml(typeof(Usuario), caminho, nomeArquivo);
            EscreveArquivoDesserializado(xmlDesserializado);
        }
        #endregion

        #region [+] Serializer / Desserializer Json
        public static void SerializaJsonConvert()
        {
            Usuario usuario = new Usuario() { Nome = "Marco Manhães Júnior", Idade = 39, Cpf = "123.345.678-90" };
            string jsonSerializado =  Biblioteca.Serializacao.ExecutaSerializacaoJsonConvert(usuario);
            EscreveOjbetoSerializado(jsonSerializado);
        }

        public static void SerializaJsonSerializer()
        {
            string caminho = "C:\\Temp\\Treinamentos\\";
            string nomeArquivo = "Serializado.json";
            Usuario usuario = new Usuario() { Nome = "Marco Manhães Júnior", Idade = 39, Cpf = "123.345.678-90" };
            string xmlSerializado = Biblioteca.Serializacao.ExecutaSerializacaoJsonSerializer(usuario, caminho, nomeArquivo);

            Console.WriteLine("*************************************\n");
            Console.WriteLine($" ==> Arquivo serializado salvo em: {xmlSerializado}\n");
            Console.WriteLine("*************************************\n");

            LeArquivoSerializado(xmlSerializado);
        }

        public static void DesserializaJson()
        {
            string caminho = "C:\\Temp\\Treinamentos\\";
            string nomeArquivo = "Serializado.json";
            Usuario xmlDesserializado = (Usuario)Biblioteca.Serializacao.ExecutaDesserializacaoJson(typeof(Usuario), caminho, nomeArquivo);
            EscreveArquivoDesserializado(xmlDesserializado);
        }
        #endregion

        #region [+] Le/Escreve Serializer e Desserializer
        private static void EscreveOjbetoSerializado(string serializado)
        {
            Console.WriteLine($" ==> Json gerado:\n");
            Console.Write($"{serializado}");
            Console.WriteLine("\n");
            Console.WriteLine("*************************************\n");
        }

        private static void EscreveArquivoDesserializado(Usuario xmlDesserializado)
        {
            Console.WriteLine($" ==> Objeto desserializado: {xmlDesserializado.GetType().Name}\n");
            foreach (PropertyInfo propertyInfo in xmlDesserializado.GetType().GetProperties())
            {
                Console.WriteLine($"    *** {propertyInfo.Name}: {propertyInfo.GetValue(xmlDesserializado, null)}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("*************************************\n");
        }

        public static void LeArquivoSerializado(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    Console.WriteLine($" ==> Arquivo serializado:\n");

                    String linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"    {linha}");
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("*************************************\n");
            }
        }
        #endregion
    }
}
