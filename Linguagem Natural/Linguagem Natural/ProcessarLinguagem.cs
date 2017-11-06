using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

namespace Linguagem_Natural
{
    class ProcessarLinguagem
    {
        static void Main(string[] args)
        {
            //   Cabecalho();
            LerArquivoJson("conversas.json");
            LerArquivoJson("produtos.json");
            LerArquivoJson("acoes.json");
        }
        static void Cabecalho()
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""nome"" : ""Wllynilson"", ""sobrenome"" : ""Carneiro"", ""email"": ""wllynilson@gmail.com"" }";
            //string json2 =@"{ ""nome"" : ""Teste"", ""sobrenome"" : ""Outro Teste"", ""email"": ""teste @gmail.com""}";

            dynamic resultado = serializer.DeserializeObject(json);
            Console.WriteLine("-> -> Resultado da leitura do arquivo JSON <- <-");
            Console.WriteLine("");
            foreach (KeyValuePair<string, object> entry in resultado)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                Console.WriteLine(String.Format("{0} : {1}", key, value));
            }

            Console.WriteLine("");
            Console.WriteLine(serializer.Serialize(resultado));
            Console.WriteLine("");
            Console.ReadKey();

        }

        static void LerArquivoJson(string arquivo)
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            using (StreamReader r = new StreamReader(arquivo))
            {
                string json = r.ReadToEnd();
                dynamic array = serializer.DeserializeObject(json);
                Console.WriteLine("");
                Console.WriteLine(serializer.Serialize(array));
                Console.WriteLine("");
                Console.ReadKey();
            }
        }

        static void ProcessaEstatisticas(string dialogo, string expressao)
        {
            //string expressao = "";
            //nova instancia de Regex
            var rgx = new Regex("");


            Match m = rgx.Match(dialogo);

        }
    }
}
