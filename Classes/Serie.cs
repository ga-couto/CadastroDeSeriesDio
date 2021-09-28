using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Características das séries (Atributos/Campos)
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
		private float Nota { get; set; }
        private bool Excluido {get; set;}

        // O que posso/desejo fazer com a lista de séries? (Métodos/Procedimentos)
		public Serie(int id, Genero genero, string titulo, string descricao, int ano, float nota)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Nota = nota;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
			retorno += "Avaliação da série 'Nota': " + this.Nota + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}
		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}