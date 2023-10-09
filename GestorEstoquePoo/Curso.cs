using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePoo
{
    [System.Serializable]
    class Curso : Produto, Iestoque
    {
        public string autor;
        private int vagas;
        private float frete;

        public Curso(string autor, string nome, float preco)
        {
            this.autor = autor;
            this.nome = nome;
            this.preco = preco;
        }

        public Curso(string? nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Adicionar vagas no curso " + nome);
            Console.WriteLine("Digite a Qtd. que quer dar entrada: ");

            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;

            Console.WriteLine("Entrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Consumir vagas no curso " + nome);
            Console.WriteLine("Digite a Qtd. que quer consumir: ");

            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;

            Console.WriteLine("Saida registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Preco: " + preco);
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("Vagas Restantes: " + vagas);
            Console.WriteLine("==============================================");
        }
    }
}
