using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace Linguagem_Natural
{
    class ProcessarLinguagem
    {
        static void Main(string[] args)
        {
               Cabecalho();
            LerArquivoJson("conversas.json");
            LerArquivoJson("produtos.json");
            LerArquivoJson("acoes.json");
            ProcessaEstatisticas("conversas.json");
        }
        static void Cabecalho()
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""Disciplina"" : ""Linguagens Formais"", ""Professor"" : ""Jackson Gomes"", ""Alunos"": ""[Ewerton Santiago, Marcos Mourão, Maria do Carmo, Wllynilson Carneiro]"" }";


            dynamic resultado = serializer.DeserializeObject(json);
            Console.WriteLine("-> -> Processamento de linguagem natural <- <-");
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

        static void ProcessaEstatisticas(string dialogo)
        {
            //string expressao = "";
            //nova instancia de Regex
            var rgx = new Regex(@"([Oo]i, eu sou [?oa] [A-Za-z]*)");

            var primeiroEncontrado = rgx.Match(dialogo);
            var encontrados = rgx.Matches(dialogo);
            //Match m = rgx.Match(dialogo);

            Dictionary<int, string> dic = new Dictionary<int, string>();

            foreach (Match item in encontrados)
            {
                dic.Add(int.Parse(item.Groups[1].Value), item.Groups[2].Value);
                Console.WriteLine(dic);
            }
                
            Console.WriteLine(primeiroEncontrado);
            Console.WriteLine(encontrados);
            Console.ReadKey();
        }
    }
}
