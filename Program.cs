using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "SAIR")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "L":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("==========================");
			Console.WriteLine("OBRIGRADO, VOLTE SEMPRE!");
			Console.WriteLine("==========================");
			Console.ReadLine();
        }
		private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Vamos lá. Escolha um gênero: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Escreva o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe o ano de lançamento da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Dê uma nota de 0 a 5 para esta série: ");
			float entradaNota = float.Parse(Console.ReadLine());

			Console.Write("Descreva um pouco sobre a série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										nota: entradaNota,
										descricao: entradaDescricao);
			
			repositorio.Insere(novaSerie);
		}
		private static void AtualizarSerie()
		{
			Console.Write("DIGITE O 'ID' DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("ESCOLHA A OPÇÃO DO GÊNERO CONFORME LISTA ACIMA: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("ESCREVA O TÍTULO DA SÉRIE: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("INFORME O ANO DE LANÇAMENTO DA SÉRIE: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("DÊ UMA NOTA DE 0 A 10 PARA A SÉRIE: ");
			float entradaNota = float.Parse(Console.ReadLine());

			Console.Write("DESCREVA BREVEMENTE A SÉRIE: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										nota: entradaNota,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ExcluirSerie()
		{
			Console.Write("DIGITE O 'ID' DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("DIGITE O 'ID' DA SÉRIE: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
       
        
        

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("==========================");
			Console.WriteLine("OLÁ, BEM VINDO A DIO SÉRIES!");
			Console.WriteLine("ESCOLHA UMA OPÇÃO");

			Console.WriteLine("1 - MOSTRAR TODAS AS SÉRIES:");
			Console.WriteLine("2 - CADASTRAR UMA SÉRIE");
			Console.WriteLine("3 - BUSCAR E ATUALIZAR UMA SÉRIE");
			Console.WriteLine("4 - EXCLUIR UMA SÉRIE");
			Console.WriteLine("5 - BUSCAR UMA SÉRIE");
			Console.WriteLine("L - LIMPAR A TELA");
			Console.WriteLine("SAIR - FINALIZAR SESSÃO");
			Console.WriteLine("==========================");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
