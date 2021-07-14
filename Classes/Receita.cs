using System;

namespace DIO.Receitas
{
    public class Receita : EntidadeBase
    {
        // Atributos
		private Prato Prato { get; set; }
		private string Nome { get; set; }
		private string Modo_de_Preparo { get; set; }
		private string Ingredientes { get; set; }
        private bool Excluido {get; set;}
		private int Nota { get; set; }
		private string Chef { get; set; }

        // Métodos
		public Receita(int id, Prato prato, string nome, string modo_de_preparo, string ingredientes, int nota, string chef)
		{
			this.Id = id;
			this.Prato = prato;
			this.Nome = nome;
			this.Modo_de_Preparo = modo_de_preparo;
			this.Ingredientes = ingredientes;
            this.Excluido = false;
			this.Nota = nota;
			this.Chef = chef;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Prato: " + this.Prato + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Modo de Preparo: " + this.Modo_de_Preparo + Environment.NewLine;
            retorno += "Ingredientes " + this.Ingredientes + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            retorno += "Nota: " + this.Nota + Environment.NewLine;
			retorno += "Chef: " + this.Chef + Environment.NewLine;

			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
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