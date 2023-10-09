using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GestorEstoquePoo
{
    [System.Serializable]
    class ProdutoFisico : Produto, Iestoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete) { 
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Adicionar entrada no estoque de produtos" + nome);
            Console.WriteLine("Digite a Qtd. que quer dar entrada: ");

            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;

            Console.WriteLine("Entrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Adicionar saida no estoque de produtos" + nome);
            Console.WriteLine("Digite a Qtd. que quer dar saida: ");

            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;

            Console.WriteLine("Saida registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Preco: " + preco);
            Console.WriteLine("Frete: " + frete);
            Console.WriteLine("Estoque: " + estoque);
            Console.WriteLine("==============================================");
        }
    }
}
