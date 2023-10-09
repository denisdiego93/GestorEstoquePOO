using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestorEstoquePoo
{
    class Program
    {
        static List<Iestoque> produtos = new List<Iestoque>();
        enum Menu {Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args) {

            Carregar();

            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n" +
                    "5-Registrar Saída\n6-Sair");
                
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }

            Console.ReadLine();
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produto");
            Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);

            switch(escolhaInt)
            {
                case 1:
                    CadastrarPfisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPfisico()
        {
            Console.WriteLine("Cadastro de produto físico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);

            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastro de Ebook");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);

            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastro de curso");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            Curso cs = new Curso(nome, preco, frete);
            produtos.Add(cs);

            Salvar();
        }

        static void Salvar() {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

       static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try { 
                produtos = (List<Iestoque>)encoder.Deserialize(stream);
                
                if (produtos == null)
                {
                    produtos =new List<Iestoque>();
                }
            } catch (Exception ex)
            {
                produtos = new List<Iestoque>();
            }
            stream.Close();
        }

        static void Listagem()
        {
            int id = 0;
            Console.WriteLine("Lista de produtos");
            foreach (Iestoque produto in produtos)
            {
                Console.WriteLine("ID: " + id);
                produto.Exibir();
                id++;
            }
            if (produtos.Count == 0)
            {
                Console.WriteLine("Listagem vazia, pressione enter para voltar para o menu inicial");
            }
            Console.ReadLine(); 
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o Id do produto a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o Id do produto a ser dar entrada: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o Id do produto a ser dar saida: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
    }
}