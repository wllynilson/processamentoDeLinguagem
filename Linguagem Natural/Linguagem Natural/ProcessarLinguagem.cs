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
<<<<<<< HEAD

            ProcessaEstatisticas("conversas.json","acoes.json");
=======
            ProcessaEstatisticas("conversas.json");
>>>>>>> 28dc1c94f76f7e5362d653108c88fb96c2056069
        }
        static void Cabecalho()
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""Disciplina"" : ""Linguagens Formais"", ""Professor"" : ""Jackson Gomes"", ""Alunos"": ""[Ewerton Santiago, Marcos Mourão, Maria do Carmo, Wllynilson Carneiro]"" }";
<<<<<<< HEAD
            
=======

>>>>>>> 28dc1c94f76f7e5362d653108c88fb96c2056069

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

<<<<<<< HEAD
        static void ProcessaEstatisticas(string dialogo, string acoes)
        {
            //string expressao = "";
            //nova instancia de Regex
            var rgx = new Regex(@"([Oo]i, eu sou [?oa] [A-Za-z]*)|([Oo]i, sou o [A-Za-z]*)|([Ee]u sou o [A-Za-z]*)|(sou [o|a] [A-Za-z]*)+(. Gostaria de )|(e queria)|(\w+)");
            var actions = new Regex(@"(comprar)|(saber)|(vender)|(gostaria)|(desejo)|(valor)|(pagamento)");

            //adiciona o arquivo 'acoes' para começar a processa-lo
            var arquivo = rgx.Matches(acoes);

            //novo dicionário com 'chave valor'
            Dictionary<int, string> dic = new Dictionary<int, string>();

            //iteração sobre o arquivo percorrendo palavra por palavra
            foreach(Match item in arquivo)
            {
                dic.Add(int.Parse(item.Groups[0].Value), item.Groups[1].Value);
                Console.WriteLine(dic);                
            }


            Match m = rgx.Match(dialogo);
            Console.WriteLine(m);
            Console.ReadKey();
            //Console.WriteLine(rgx);
=======
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
>>>>>>> 28dc1c94f76f7e5362d653108c88fb96c2056069
            Console.ReadKey();
        }
    }
}
