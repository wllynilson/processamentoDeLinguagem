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
            LerArquivo();
            processa();

        }
        static void Cabecalho()
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""Disciplina"" : ""Linguagens Formais"", ""Professor"" : ""Jackson Gomes"", ""Alunos"": ""[Ewerton Santiago, Marcos Mourão, Rodrigo Figueiredo, Wllynilson Carneiro]"" }";

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

        static void LerArquivo()
        {
            if (File.Exists("conversas.txt"))
            {
                Stream entrada = File.Open("conversas.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada);

                string linha = leitor.ReadLine();

                while (linha != null)
                {
                    Console.WriteLine(linha);
                    linha = leitor.ReadLine();
                    Console.ReadKey();
                }

                leitor.Close();
                entrada.Close();
            }
        }

        static void ProcessaEstatisticas(string dialogo)
        {
            
            //nova instancia de Regex
            var rgx = new Regex(@"([Oo]i, eu sou [?oa] [A-Za-z]*)|([Oo]i, sou o [A-Za-z]*)|([Ee]u sou o [A-Za-z]*)|(sou [o|a] [A-Za-z]*)+(. Gostaria de )|(e queria)|(\w+)");            

            //açoes direto na string
            string teste = @"(comprar) | (saber) | (vender) | (gostaria) | (desejo) | (valor) | (pagamento)";

            //açoes direto de arquivo
            string teste2 = @"acoes.txt";



            
        }

        static void processa()
        {

            string pattern = @"[Oo]i, eu sou [ao]|[Ee]u sou [oa]|[Ss]ou|(\w+)^|, [Gg]ostaria de|e|(\w+)^|uma|valor|um|do|o produto|(\w+)";            

            string input = @"Oi, eu sou o jackson, gostaria de comprar uma televisao Jackson, comprar televisao Zania saber valor geladeira Oi, eu sou a Karol, quero um freezer Comprar dvd Eu sou a Maria, gostaria de saber do sofa Sou Rafael e queria o produto notebook Goku comprar lampada Vegeta comprar racao Madimbu comprar pastel Picolo comprar arroz";
            

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' ", m.Groups[3].Value);
                Console.WriteLine();
            }
            Console.ReadKey();

            string[] t = input.Split(' ');

            Console.WriteLine("================= Imprimir Verbos ==================");
            foreach (string word in t)
            {
                if (word.Equals("comprar") || word.Equals("saber") || word.Equals("vender") || word.Equals("pagar") || word.Equals("desejar") || word.Equals("valor") )
                {
                    Console.WriteLine(word);
                }
                    
            }
            Console.ReadKey();

            Console.WriteLine("================= Imprimir Quantidade de Vendas ==================");
            foreach (string word in t)
            {
                if (word.Equals("comprar") || word.Equals("saber") || word.Equals("vender") || word.Equals("pagar") || word.Equals("desejar") || word.Equals("valor"))
                {
                    Console.WriteLine(word);
                }

            }
        }
    }
}