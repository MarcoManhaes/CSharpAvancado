using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Biblioteca
{
    public static class Serializacao
    {
        public static string ExecutaSerializacaoXml(object valor, Type tipo, string caminho, string nome)
        {
            XmlSerializer serializador = new XmlSerializer(tipo);

            using (StreamWriter sw = new StreamWriter($"{caminho}{nome}"))
            {
                serializador.Serialize(sw, valor);
            }

            var arquivosXml = Directory.GetFiles($"{caminho}", "*.xml");
            var xmlSerializado = arquivosXml.FirstOrDefault(x => Path.GetFileName(x) == nome);
            return xmlSerializado;
        }

        public static object ExecutaDesserializacaoXml(Type tipo, string caminho, string nome)
        {
            XmlSerializer serializador = new XmlSerializer(tipo);
            using (StreamReader sr = new StreamReader($"{caminho}{nome}"))
            {
                var objeto = serializador.Deserialize(sr);
                return objeto;
            }
        }

        public static object ExecutaDesserializacaoJson(Type tipo, string caminho, string nome)
        {
            JsonSerializer serializador = new JsonSerializer();
            using (StreamReader sr = new StreamReader($"{caminho}{nome}"))
            {
                var objeto = serializador.Deserialize(sr, tipo);
                return objeto;
            }
        }

        public static string ExecutaSerializacaoJsonConvert(object valor)
        {
            string arquivoSerializado = JsonConvert.SerializeObject(valor, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return arquivoSerializado;
        }

        public static string ExecutaSerializacaoJsonSerializer(object valor, string caminho, string nome)
        {
            using (StreamWriter sw = new StreamWriter($"{caminho}{nome}"))
            {
                JsonSerializer serializador = new JsonSerializer();
                serializador.Formatting = Formatting.Indented;
                serializador.Serialize(sw, valor);

                var arquivosJson = Directory.GetFiles($"{caminho}", "*.json");
                var jsonSerializado = arquivosJson.FirstOrDefault(x => Path.GetFileName(x) == nome);
                return jsonSerializado;
            }
        }
    }
}
