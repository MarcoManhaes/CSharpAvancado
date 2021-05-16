
using Biblioteca;
using System;
using System.Threading;

namespace ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Prática Curso - C# Avnçado
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Aguardar("Aguarde testes Serializer... ");

            ExecutaSecaoSerializacao();
            //Aguardar("Aguarde testes Generics... ");
            //Console.WriteLine("Teste teste");
            //ExecutaSecaoSerializacao();
        }

        public static void Aguardar(string texto)
        {
            var spinner = new Spinner(5, 5, texto);
            spinner.Start();
            Thread.Sleep(5000);
            spinner.Stop();
        }

        /// <summary>
        /// Serializar formato XML
        /// Deserializar formato XML
        /// Serializar formato JSON
        /// Deserializar formato JSON
        /// </summary>
        public static void ExecutaSecaoSerializacao()
        {
            #region [+] Seção Serialização
            AuxiliarSerializacao.SerializaXML();
            AuxiliarSerializacao.DesserializaXML();
            AuxiliarSerializacao.SerializaJsonConvert();
            AuxiliarSerializacao.SerializaJsonSerializer();
            AuxiliarSerializacao.DesserializaJson();
            #endregion
        }
    }
}
