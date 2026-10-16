using System;
using System.Collections.Generic;
using System.IO;

namespace Petshop
{
    internal class Program
    {
      //guarda os dados de cada produto.
        struct Produto
        {
            public int Codigo;
            public string Nome;
            public double Valor;
            public int Estoque;
            public string Categoria;
        }
        struct cliente
        {
            public int Codigocliente;
            public string Nomecliente;

            public string cpf;
            public string Gmail;
        }
        struct Pet
        {
            public int Codigo;
            public string Nome;
            public string Raca;
            public double Peso;
            public string Alergia;
            public string Medicamento;
        }

        // STRUCT: guarda os dados de cada venda.
        struct Venda
        {
            public string NomeProduto;
            public int Quantidade;
            public double Total;
            public DateTime Data;
        }

        // STRUCT: guarda os dados de cada agendamento.
        struct Agendamento
        {
            public string NomePet;
            public string Servico;
            public DateTime Data;
            public TimeSpan Horario;
        }

        // guardam os dados enquanto o programa está aberto.
        static List<Produto> produtos = new List<Produto>();
        static List<cliente> Clientes = new List<cliente>();
        static List<Pet> pets = new List<Pet>();
        static List<Venda> vendas = new List<Venda>();
        static List<Agendamento> agendamentos = new List<Agendamento>();

        // MÉTODO PARA MOSTRAR UMA MENSAGEM VERDE DE SUCESSO.
        static void MensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor(); // Volta à cor normal.
        }

        // MÉTODO PARA MOSTRAR UMA MENSAGEM VERMELHA DE ERRO.
        static void MensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        // MÉTODO PARA MOSTRAR UMA MENSAGEM AMARELA DE ATENÇÃO.
        static void MensagemAtencao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        // CADASTRO DE CLIENTE.
        static void Cadastrarcliente()
        {
            cliente novocliente = new cliente();

            // Cria um código com base na quantidade de clientes da lista.
            novocliente.Codigocliente = Clientes.Count + 1;

            Console.WriteLine("Digite seu nome completo:");
            novocliente.Nomecliente = Console.ReadLine();

            Console.WriteLine("Digite seu CPF:");
            novocliente.cpf = Console.ReadLine();

            Console.WriteLine("Digite seu Gmail:");
            novocliente.Gmail = Console.ReadLine();

            // Adiciona o cliente à lista.
            Clientes.Add(novocliente);

            // Monta o texto que será guardado no arquivo.
            string texto =
                "==============================\n" +
                "       CLIENTE CADASTRADO\n" +
                "==============================\n" +
                "Código: " + novocliente.Codigocliente + "\n" +
                "Nome: " + novocliente.Nomecliente + "\n" +
                "CPF: " + novocliente.cpf + "\n" +
                "Gmail: " + novocliente.Gmail + "\n" +
                "==============================\n\n";

            // AppendAllText acrescenta o registro ao final do arquivo.
            File.AppendAllText("ClientesCadastrados.txt", texto);

            MensagemSucesso("Cliente cadastrado com sucesso!");
            Console.WriteLine("Código do cliente: " + novocliente.Codigocliente);
        }

        // CADASTRO DE PET.
        static void CadastrarPet()
        {
            Pet novoPet = new Pet();

            novoPet.Codigo = pets.Count + 1;

            Console.WriteLine("Digite o nome do seu pet:");
            novoPet.Nome = Console.ReadLine();

            Console.WriteLine("Digite a raça do seu pet:");
            novoPet.Raca = Console.ReadLine();

            Console.WriteLine("Digite o peso do seu pet:");
            novoPet.Peso = double.Parse(Console.ReadLine());

            Console.WriteLine("Seu pet possui alergia a algum medicamento? (sim ou nao)");
            novoPet.Alergia = Console.ReadLine().ToLower();

            // Se a resposta for sim, perguntamos qual é o medicamento.
            if (novoPet.Alergia == "sim")
            {
                Console.WriteLine("Digite o nome do medicamento:");
                novoPet.Medicamento = Console.ReadLine();
            }
            else
            {
                novoPet.Alergia = "nao";
                novoPet.Medicamento = "Nenhum";
            }

            // Guarda o pet na lista para poder consultá-lo durante a execução.
            pets.Add(novoPet);

            // Salva o cadastro em arquivo de texto.
            string texto =
                "==============================\n" +
                "          PET CADASTRADO\n" +
                "==============================\n" +
                "Código: " + novoPet.Codigo + "\n" +
                "Nome: " + novoPet.Nome + "\n" +
                "Raça: " + novoPet.Raca + "\n" +
                "Peso: " + novoPet.Peso + "\n" +
                "Alergia: " + novoPet.Alergia + "\n" +
                "Medicamento: " + novoPet.Medicamento + "\n" +
                "==============================\n\n";

            File.AppendAllText("AnimaisCadastrados.txt", texto);

            MensagemSucesso("Pet cadastrado com sucesso!");
        }

        // CADASTRO DE PRODUTO.
        static void CadastrarProduto()
        {
            Produto novoProduto = new Produto();

            novoProduto.Codigo = produtos.Count + 1;

            Console.WriteLine("Digite o nome do produto:");
            novoProduto.Nome = Console.ReadLine();

            Console.WriteLine("Digite o valor unitário do produto:");
            novoProduto.Valor = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade em estoque:");
            novoProduto.Estoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a categoria do produto:");
            novoProduto.Categoria = Console.ReadLine();

            // Adiciona o produto à lista.
            produtos.Add(novoProduto);

            // Salva os dados do produto em um arquivo.
            string texto =
                "==============================\n" +
                "       PRODUTO CADASTRADO\n" +
                "==============================\n" +
                "Código: " + novoProduto.Codigo + "\n" +
                "Nome: " + novoProduto.Nome + "\n" +
                "Valor: R$ " + novoProduto.Valor + "\n" +
                "Estoque: " + novoProduto.Estoque + "\n" +
                "Categoria: " + novoProduto.Categoria + "\n" +
                "==============================\n\n";

            // O nome do arquivo termina em .txt.
            File.AppendAllText("ProdutosCadastrados.txt", texto);

            MensagemSucesso("Produto cadastrado com sucesso!");
            Console.WriteLine("Código do produto: " + novoProduto.Codigo);
        }

        // REALIZAR VENDA.
        static void RealizarVenda()
        {
            int codprod, quant;

            Console.WriteLine("Digite o código do produto:");
            codprod = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade desejada:");
            quant = int.Parse(Console.ReadLine());

            Produto produtoEncontrado = new Produto();
            bool encontrado = false;

            // Percorre a lista para procurar o produto pelo código.
            foreach (Produto produto in produtos)
            {
                if (produto.Codigo == codprod)
                {
                    produtoEncontrado = produto;
                    encontrado = true;
                    break; // Para a busca quando encontra o produto.
                }
            }

            // Se não encontrou, não continua a venda.
            if (!encontrado)
            {
                MensagemErro("Produto não encontrado!");
                return;
            }

            // Não permite vender quantidade zero ou negativa.
            if (quant <= 0)
            {
                MensagemErro("Digite uma quantidade maior que zero!");
                return;
            }

            // Confere se existe estoque suficiente.
            if (quant > produtoEncontrado.Estoque)
            {
                MensagemErro("Estoque insuficiente!");
                Console.WriteLine("Estoque disponível: " + produtoEncontrado.Estoque);
                return;
            }

            // Calcula o total da venda.
            double total = produtoEncontrado.Valor * quant;

            // Diminui a quantidade vendida do estoque.
            produtoEncontrado.Estoque = produtoEncontrado.Estoque - quant;

            // Atualiza o produto que está guardado na lista.
            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Codigo == codprod)
                {
                    produtos[i] = produtoEncontrado;
                    break;
                }
            }

            // Cria o registro da venda, incluindo data e hora.
            Venda novaVenda = new Venda();
            novaVenda.NomeProduto = produtoEncontrado.Nome;
            novaVenda.Quantidade = quant;
            novaVenda.Total = total;
            novaVenda.Data = DateTime.Now;

            // Guarda a venda na lista.
            vendas.Add(novaVenda);

            // Salva a venda no arquivo.
            string texto =
                "==============================\n" +
                "          VENDA REALIZADA\n" +
                "==============================\n" +
                "Produto: " + novaVenda.NomeProduto + "\n" +
                "Quantidade: " + novaVenda.Quantidade + "\n" +
                "Valor unitário: R$ " + produtoEncontrado.Valor + "\n" +
                "Total da venda: R$ " + novaVenda.Total + "\n" +
                "Data e hora: " + novaVenda.Data + "\n" +
                "Estoque restante: " + produtoEncontrado.Estoque + "\n" +
                "==============================\n\n";

            File.AppendAllText("vendas.txt", texto);

            MensagemSucesso("Venda realizada com sucesso!");
            Console.WriteLine("Total da venda: R$ " + total);
            Console.WriteLine("Estoque restante: " + produtoEncontrado.Estoque);
        }

        // AGENDAR SERVIÇO.
        static void AgendarServico()
        {
            Agendamento novoAgendamento = new Agendamento();

            Console.WriteLine("Digite o nome do pet:");
            novoAgendamento.NomePet = Console.ReadLine();

            Console.WriteLine("Digite o serviço desejado:");
            novoAgendamento.Servico = Console.ReadLine();

            Console.WriteLine("Digite a data do serviço (dd/MM/yyyy):");
            novoAgendamento.Data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite o horário (ex: 14:30):");
            novoAgendamento.Horario = TimeSpan.Parse(Console.ReadLine());

      
            agendamentos.Add(novoAgendamento);

            string texto =
                "==============================\n" +
                "       SERVIÇO AGENDADO\n" +
                "==============================\n" +
                "Pet: " + novoAgendamento.NomePet + "\n" +
                "Serviço: " + novoAgendamento.Servico + "\n" +
                "Data: " + novoAgendamento.Data.ToShortDateString() + "\n" +
                "Horário: " + novoAgendamento.Horario + "\n" +
                "==============================\n\n";

            File.AppendAllText("Agendamentos.txt", texto);

            MensagemSucesso("Agendamento realizado com sucesso!");
        }

        // CONSULTAR OU EXCLUIR PET.
        static void Consultarexcluir()
        {
            Console.WriteLine("[1] Consultar pet");
            Console.WriteLine("[2] Excluir pet");
            int op = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do pet:");
            string nomepet = Console.ReadLine();

            bool encontrado = false;

            // Procura o pet na lista pelo nome.
            for (int i = 0; i < pets.Count; i++)
            {
                if (pets[i].Nome.ToLower() == nomepet.ToLower())
                {
                    encontrado = true;

                    if (op == 1)
                    {
                        
                        Console.WriteLine("==============================");
                        Console.WriteLine("         DADOS DO PET");
                        Console.WriteLine("==============================");
                        Console.WriteLine("Código: " + pets[i].Codigo);
                        Console.WriteLine("Nome: " + pets[i].Nome);
                        Console.WriteLine("Raça: " + pets[i].Raca);
                        Console.WriteLine("Peso: " + pets[i].Peso);
                        Console.WriteLine("Alergia: " + pets[i].Alergia);
                        Console.WriteLine("Medicamento: " + pets[i].Medicamento);
                    }
                    else if (op == 2)
                    {
                       
                        MensagemAtencao("Deseja realmente excluir o pet? (sim ou nao)");
                        string confirmacao = Console.ReadLine().ToLower();

                        if (confirmacao == "sim")
                        {
                            // Remove o pet da lista durante esta execução.
                            pets.RemoveAt(i);
                            MensagemSucesso("Pet excluído da lista!");
                            MensagemAtencao("A exclusão ainda não foi atualizada no arquivo de texto.");
                        }
                        else
                        {
                            Console.WriteLine("Exclusão cancelada.");
                        }
                    }
                    else
                    {
                        MensagemErro("Opção inválida!");
                    }

                    break;
                }
            }

            if (!encontrado)
            {
                MensagemErro("Pet não encontrado!");
            }
        }

        // RELATÓRIO DAS VENDAS REALIZADAS NESTA EXECUÇÃO.
        static void Relatorio()
        {
            double totalVendas = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==============================");
            Console.WriteLine("       RELATÓRIO DE VENDAS");
            Console.WriteLine("==============================");
            Console.ResetColor();

            // Se a lista estiver vazia, não há vendas nesta execução.
            if (vendas.Count == 0)
            {
                MensagemAtencao("Nenhuma venda realizada nesta execução.");
                return;
            }

            // Exibe as vendas e soma os valores.
            foreach (Venda venda in vendas)
            {
                Console.WriteLine("Produto: " + venda.NomeProduto);
                Console.WriteLine("Quantidade: " + venda.Quantidade);
                Console.WriteLine("Total: R$ " + venda.Total);
                Console.WriteLine("Data e hora: " + venda.Data);
                Console.WriteLine("------------------------------");

                totalVendas = totalVendas + venda.Total;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TOTAL VENDIDO: R$ " + totalVendas);
            Console.ResetColor();
        }

        // MENSAGEM DE ENCERRAMENTO.
        static void Sair()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Volte sempre ao Petshop Isa e Gabi!");
            Console.ResetColor();
        }

        // MÉTODO PRINCIPAL: EXIBE O MENU E CHAMA AS FUNÇÕES.
        static void Main(string[] args)
        {
            int op;

            do
            {
                // Deixa o título do menu em ciano.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================================");
                Console.WriteLine("============= PETSHOP ISA E GABI ============");
                Console.WriteLine("=============================================");
                Console.WriteLine("               MENU PRINCIPAL");
                Console.ResetColor();

                Console.WriteLine("[1] Cadastrar Cliente");
                Console.WriteLine("[2] Cadastrar Pet");
                Console.WriteLine("[3] Cadastrar Produto");
                Console.WriteLine("[4] Realizar Venda");
                Console.WriteLine("[5] Agendar Serviço");
                Console.WriteLine("[6] Consultar ou Excluir Pet");
                Console.WriteLine("[7] Relatório de Vendas");
                Console.WriteLine("[8] Sair");
                Console.WriteLine("=============================================");
                Console.Write("Digite uma opção: ");

                op = int.Parse(Console.ReadLine());

                // O switch chama o método conforme a opção escolhida.
                switch (op)
                {
                    case 1:
                        Cadastrarcliente();
                        break;

                    case 2:
                        CadastrarPet();
                        break;

                    case 3:
                        CadastrarProduto();
                        break;

                    case 4:
                        RealizarVenda();
                        break;

                    case 5:
                        AgendarServico();
                        break;

                    case 6:
                        Consultarexcluir();
                        break;

                    case 7:
                        Relatorio();
                        break;

                    case 8:
                        Sair();
                        break;

                    default:
                        MensagemErro("Opção inválida!");
                        break;
                }

                // Pausa para dar tempo de ler o resultado antes de voltar ao meny
                if (op != 8)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para voltar ao menu.");
                    Console.ReadLine();
                }

            } while (op != 8);
        }
    }
}
