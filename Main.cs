using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque;


namespace ControleEstoqueMain
{
    class Program
    {

        public static void Main()
        {
            //Declaração das variáveis e dos arrays

            object[][] ListaProdutos = new object[9][];


            int index = 0;
            object Nome;
            object Preco;
            object Ano;
            object Quantidade;
            object QtdeMin;
            object QtdeMax;
            string NomeConsulta = " ";
            string NomeProduto = " ";
            bool result = NomeConsulta.Equals(NomeProduto);

            int Menu;

            do
            {
                Console.WriteLine("[1] Novo\n" + "[2] Listar Produtos\n" + "[3] Consultar Produto\n" +
                "[4] Entrada Estoque\n" + "[5] Saída Estoque\n" + "[6] Checar Quantidades\n" + "[7] Excluir Produto\n" + "[0] Sair\n");

                Menu = Convert.ToInt16(Console.ReadLine());

                switch (Menu)
                {
                    //Cadastro de um produto novo

                    case 1:

                        Console.WriteLine("Informe o nome: ");

                        Nome = Console.ReadLine();

                        Console.WriteLine("Informe o preço: ");

                        Preco = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Informe o ano: ");

                        Ano = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Informe o quantidade mínima: ");

                        QtdeMin = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Informe o quantidade máxima: ");

                        QtdeMax = Convert.ToInt16(Console.ReadLine());

                        ListaProdutos[index] = new object[6];

                        ListaProdutos[index][0] = Nome;
                        ListaProdutos[index][1] = Preco;
                        ListaProdutos[index][2] = Ano;
                        ListaProdutos[index][3] = 0;
                        ListaProdutos[index][4] = QtdeMin;
                        ListaProdutos[index][5] = QtdeMax;

                        index++;

                        break;

                    case 2:

                        //Consulta de todos os produtos cadastrados


                        Console.WriteLine("Registro de produtos:\n");

                        for (int i = 0; i < index; i++)
                        {
                            NomeProduto = ListaProdutos[i][0].ToString();

                            Console.WriteLine(NomeProduto);

                            if (NomeProduto == "vazio")
                            {
                                Console.WriteLine("");
                                break;
                            }

                            else
                            {

                                Console.WriteLine($"Nome: {ListaProdutos[i][0]}\n" +
                                $"Preço: {ListaProdutos[i][1]}\n" +
                                $"Ano: {ListaProdutos[i][2]} \n" +
                                $"Quantidade: {ListaProdutos[i][3]} \n" +
                                $"Quantidade mínima: {ListaProdutos[i][4]} \n" +
                                $"Quantidade máxima: {ListaProdutos[i][5]} \n");
                            }
                        }
                        break;

                    case 3:

                        //Consulta de produto específico
                        // Não identifica vários elementos b

                        while (NomeConsulta == " ")
                        {
                            Console.WriteLine("Consulta de produtos\nInforme o nome do produto:\n");
                            NomeConsulta = Console.ReadLine();
                        }

                        for (int i = 0; i < index; i++)
                        {
                            try { NomeProduto = ListaProdutos[i][0].ToString(); }
                            catch (Exception e) { Console.WriteLine("Null"); }

                            result = NomeConsulta.Equals(NomeProduto);


                            if (NomeProduto == "vazio")
                            {
                                result = false;
                                Console.WriteLine("vazio");
                            }

                            else if (result == true)
                            {
                                Console.WriteLine($"{ListaProdutos[i][0]} encontrado!\n" +
                                $"Preço: {ListaProdutos[i][1]}\n" +
                                $"Ano: {ListaProdutos[i][2]} \n" +
                                $"Quantidade em estoque: {ListaProdutos[i][3]} \n" +
                                $"Quantidade mínima: {ListaProdutos[i][4]} \n" +
                                $"Quantidade máxima: {ListaProdutos[i][5]} \n");
                                NomeConsulta = " ";
                                break;
                            }

                            else if (result == false)
                            {
                                Console.WriteLine("Procurando...\n");
                            }

                        }
                        Console.WriteLine("Pesquisa finalizada.\n");
            
                        break;
            
                    case 4:

                        //Entrada de produto em estoque

                        NomeConsulta = " ";

                        while (NomeConsulta == " ")
                        {
                            Console.WriteLine("Entrada de produto\nInforme o nome do produto:\n");
                            NomeConsulta = Console.ReadLine();
                        }
                        
                        for (int i = 0; i < index; i++)
                        {
              
                            if (NomeConsulta == ListaProdutos[i][0].ToString())
                            {
                                Console.WriteLine($"{ListaProdutos[i][0]} encontrado!\n" +
                                $"Informe a quantidade a dar entrada em estoque:\n");

                                int entrada = Convert.ToInt16(Console.ReadLine());

                                ListaProdutos[i][3] = entrada + Convert.ToInt16(ListaProdutos[i][3]);

                                break;

                            }
                            else
                            {
                                Console.WriteLine("Procurando...\n");
                            }

                        }
                        Console.WriteLine("Pesquisa finalizada.\n");

                        break;
                    
                    case 5:

                        //Saida de produto em estoque

                        int VerificacaoQtde;
                        int Saida;

                        NomeConsulta = " ";

                        while (NomeConsulta == " ")
                        {
                            Console.WriteLine("Saida de produto\nInforme o nome do produto:\n");
                            NomeConsulta = Console.ReadLine();
                        }
                        for (int i = 0; i <= index; i++)
                        {
                            if (NomeConsulta == ListaProdutos[i][0].ToString())
                            {
                                Console.WriteLine($"{ListaProdutos[i][0]} encontrado!\n" +
                                $"Informe a quantidade a dar saída em estoque:\n");

                                Saida = Convert.ToInt16(Console.ReadLine());

                                VerificacaoQtde = Convert.ToInt16(ListaProdutos[i][3]) - Saida;


                                if (VerificacaoQtde < 0)
                                {
                                    Console.WriteLine("Quantidade insuficiente em estoque.");
                                }
                                else
                                {
                                    ListaProdutos[i][3] = Convert.ToInt16(ListaProdutos[i][3]) - Saida;
                                }


                                break;

                            }
                            else
                            {
                                Console.WriteLine("Procurando...\n");
                            }

                        }
                        Console.WriteLine("Pesquisa finalizada.\n");

                        break;

                    case 6:

                        //Checar quantidades mínimas e máximas

                        int QtdeAtual = 0;
                        int QtdeMinProduto = 0;
                        int QtdeMaxProduto = 0;
                        

                        for (int i = 0; i < index; i++)
                        {
                            QtdeAtual = Convert.ToInt16(ListaProdutos[i][3]);

                            QtdeMinProduto = Convert.ToInt16(ListaProdutos[i][4]);

                            QtdeMaxProduto = Convert.ToInt16(ListaProdutos[i][5]);

                            int Saldo = QtdeAtual - QtdeMinProduto;

                            if (QtdeAtual < QtdeMinProduto)
                            {
                                Console.WriteLine($"Produto {ListaProdutos[i][0]} está abaixo do mínimo. A quantidade necessária é de {Saldo * -1}.\n");
                            }
                            else
                            {
                                Console.WriteLine("Quantidades dentro do definido.");
                            }
                        }

                        break;
                    
                    case 7:

                        //index checar se há null, se tiver usar aquele espaço
                        //Gera dois vazios na consulta
                        // não encontra b
                        
                        NomeConsulta = " ";
                                                
                        while (NomeConsulta == " ")
                        {
                            Console.WriteLine("Exclusão de produto\nInforme o nome do produto:\n");
                            NomeConsulta = Console.ReadLine();
                        }

                        for (int i = 0; i <= index; i++)
                        {
                            NomeProduto = ListaProdutos[i][0].ToString(); // Não está ficando o mesmo

                            result = NomeConsulta.Equals(NomeProduto);

                            Console.WriteLine(NomeProduto);
                            
                            if (result == true)
                            {
                                Console.WriteLine($"{ListaProdutos[i][0]} encontrado!\n");
                                
                                ListaProdutos[i][0] = "vazio";
                                
                                Console.WriteLine($"Produto {NomeProduto} foi excluído com sucesso.\n");
                                
                                break;
                            }
                            else if (result == false)
                            {
                                Console.WriteLine("Procurando...\n");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado!\n");
                            }
                        }
                        break;
                }
            }

            while (Menu != 0);
        }
    }

}