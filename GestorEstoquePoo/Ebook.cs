using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePoo
{
    [System.Serializable]
    class Ebook : Produto, Iestoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, string autor, float preco)
        {
            this.autor = nome;
            this.autor = autor;
            this.preco = preco;
        }

        public Ebook(string? nome, float preco, string? autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada nesse produto");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar venda do ebook " + nome);
            Console.WriteLine("Digite a Qtd. que quer dar saida: ");

            int saida = int.Parse(Console.ReadLine());
            vendas += saida;

            Console.WriteLine("Saida registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Preco: " + preco);
            Console.WriteLine("Autor: " + autor);
            Console.WriteLine("Vendas: " + vendas);
            Console.WriteLine("==============================================");
        }
    }
}
