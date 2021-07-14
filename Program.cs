using System;

namespace DIO.Receitas
{
    class Program
    {
        static ReceitaRepositorio repositorio = new ReceitaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarReceitas();
						break;
					case "2":
						InserirReceita();
						break;
					case "3":
						AtualizarReceita();
						break;
					case "4":
						ExcluirReceita();
						break;
					case "5":
						VisualizarReceita();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						Console.WriteLine("Coloque um número correspondente:");
						break;
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Bom Apetite!");
			Console.ReadLine();
        }

        private static void ExcluirReceita()
		{
			Console.Write("Digite o id da Receita: ");
			int indiceReceita = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceReceita);
		}

        private static void VisualizarReceita()
		{
			Console.Write("Digite o id da Receita: ");
			int indiceReceita = int.Parse(Console.ReadLine());

			var Receita = repositorio.RetornaPorId(indiceReceita);

			Console.WriteLine(Receita);
		}

        private static void AtualizarReceita()
		{
			Console.Write("Digite o id da Receita: ");
			int indiceReceita = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Prato)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Prato), i));
			}
			Console.Write("Digite o tipo de prato entre as opções acima: ");
			int idPrato = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Receita: ");
			string nome = Console.ReadLine();

			Console.Write("Digite os Ingredientes: ");
			string ingredientes = Console.ReadLine();

			Console.Write("Digite o Modo de Preparo: ");
			string modo_de_preparo = Console.ReadLine();

			Console.Write("Digite a Nota da Receita: ");
			int entradaNota = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Chef: ");
			string chef = Console.ReadLine();

			Receita atualizaReceita = new Receita(id: indiceReceita,
										prato: (Prato)idPrato,
										nome: nome,
										modo_de_preparo: modo_de_preparo,
										ingredientes: ingredientes,
										nota: entradaNota,
										chef: chef);

			repositorio.Atualiza(indiceReceita, atualizaReceita);
		}
        private static void ListarReceitas()
		{
			Console.WriteLine("Listar Receitas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Receita cadastrada.");
				return;
			}

			foreach (var Receita in lista)
			{
                var excluido = Receita.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Receita.retornaId(), Receita.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirReceita()
		{
			Console.WriteLine("Inserir nova Receita");

			foreach (int i in Enum.GetValues(typeof(Prato)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Prato), i));
			}

			Console.Write("Digite o tipo de prato entre as opções acima: ");
			int idPrato = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Receita: ");
			string nome = Console.ReadLine();

			Console.Write("Digite os Ingredientes: ");
			string ingredientes = Console.ReadLine();

			Console.Write("Digite o Modo de Preparo: ");
			string modo_de_preparo = Console.ReadLine();

			Console.Write("Digite a Nota da Receita: ");
			int entradaNota = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Chef: ");
			string chef = Console.ReadLine();
			

			Receita novaReceita = new Receita(id: repositorio.ProximoId(),
										prato: (Prato)idPrato,
										nome: nome,
										modo_de_preparo: modo_de_preparo,
										ingredientes: ingredientes,										
										nota: entradaNota, 
										chef: chef);

			repositorio.Insere(novaReceita);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Receitas para te ajudar!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Mostrar Receitas");
			Console.WriteLine("2- Adicionar nova Receita");
			Console.WriteLine("3- Atualizar Receita");
			Console.WriteLine("4- Excluir Receita");
			Console.WriteLine("5- Visualizar Receita");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
