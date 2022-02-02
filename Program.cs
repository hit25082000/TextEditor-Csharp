using System;
//2, texto, C:\Dev\arrquivo.txt

namespace TextEditor
{
    class Program 
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que voçe deseja fazer ?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho a salvar desejado ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Aquivo {path} Salvo");
            Console.ReadLine();
            Menu();
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo ?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite (Esc para sair)");
            Console.WriteLine("==============================");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);
            Save(text);
        }
    }
}


