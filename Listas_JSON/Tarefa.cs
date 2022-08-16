using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_JSON
{
    class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("");
            Console.WriteLine("Tarefas:");
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Título: {title}");
            Console.WriteLine($"Finalizou ? {completed}");
            Console.WriteLine("");
            Console.WriteLine("==============================");
        }
    }
}
