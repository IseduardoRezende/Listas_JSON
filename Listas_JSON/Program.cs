using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace Listas_JSON
{
    class Program
    {
        enum Menu{Listar = 1, Pesquisar , Sair}
        static void Main(string[] args)
        {
            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de Tarefas e converção JSON para C#\n");
                Console.WriteLine("1-Listar todas Tarefas\n2-Pesquisar Tarefa\n3-Sair\n");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 4)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            ReqLista();
                            break;
                        case Menu.Pesquisar:
                            Requnica();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Erro, tente novamente !");
                    Console.ReadLine();
                    escolheuSair = true;
                }

                Console.Clear();
            }
        }
        static void Requnica()
        {
                Console.WriteLine("Selecione o N° do ID que deseja pesquisar:\n ");
                string id = Console.ReadLine();

                var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/"+id);
                requisicao.Method = "GET";
                
                var resposta = requisicao.GetResponse();
                using (resposta)
                {
                    var stream = resposta.GetResponseStream();
                    StreamReader leitor = new StreamReader(stream);
                    object dados = leitor.ReadToEnd();

                    Tarefa tarefas = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());
                    tarefas.Exibir();

                    stream.Close();
                    resposta.Close();

                    Console.ReadLine();
                }
            }
        static void ReqLista()
        {
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";

            var resposta = requisicao.GetResponse();
            using (resposta)
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach (Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir();
                }

                Console.WriteLine(tarefas);

                stream.Close();
                resposta.Close();

                Console.ReadLine();
            }
        }
    }
}
