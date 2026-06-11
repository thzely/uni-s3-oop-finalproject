using System;
using Supermarket.model;
class Program{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var mercado = new Supermercado("SuperMercado Central", "12345678000195");

        Console.WriteLine("=== CADASTRO DE FUNCIONÁRIOS ===");
        var operador1 = new Funcionario("Ana Lima", "11122233344", "Caixa", 2200m);
        var operador2 = new Funcionario("Bruno Souza", "55566677788", "Gerente", 5500m);
        mercado.CadastrarFuncionario(operador1);
        mercado.CadastrarFuncionario(operador2);

        Console.WriteLine("\n=== REAJUSTE SALARIAL ===");
        operador1.ReajustarSalario(15);
        operador2.ReajustarSalario(10);

        Console.WriteLine("\n=== CADASTRO DE PRODUTOS ===");
        var arroz = new Produto("Arroz Tipo 1 5kg", 18.90m, 50,  "Mercearia");
        var feijao = new Produto("Feijão Preto 1kg", 8.50m, 80,  "Mercearia");
        var leite = new Produto("Leite Integral 1L", 5.20m, 120, "Laticínios");
        var frango = new Produto("Frango Resfriado kg", 14.99m, 30,  "Açougue");
        var refri = new Produto("Refrigerante 2L", 9.00m, 60,  "Bebidas");
        var biscoito = new Produto("Biscoito Recheado", 3.50m, 200, "Mercearia");
        mercado.CadastrarProduto(arroz);
        mercado.CadastrarProduto(feijao);
        mercado.CadastrarProduto(leite);
        mercado.CadastrarProduto(frango);
        mercado.CadastrarProduto(refri);
        mercado.CadastrarProduto(biscoito);

        Console.WriteLine("\n=== ATUALIZAÇÃO DE PREÇO ===");
        arroz.Atualizar(20.50m);
        Console.WriteLine($"  Arroz atualizado: {arroz}");
        frango.Atualizar(16.50m, 28);
        Console.WriteLine($"  Frango atualizado: {frango}");

        Console.WriteLine("\n=== CLIENTES ===");
        var clienteA = new Cliente("Carlos Mendes", "99988877766", "carlos@email.com", 500);
        var clienteB = new Cliente("Diana Ferreira", "33322211100", "diana@email.com");
        Console.WriteLine($"  {clienteA.Identificar()}");
        Console.WriteLine($"  {clienteB.Identificar()}");

        Console.WriteLine("\n=== VENDA 1 – Carlos Mendes ===");
        var venda1 = mercado.AbrirVenda(clienteA, operador1);
        venda1.AdicionarItem(arroz, 2);
        venda1.AdicionarItem(feijao, 3);
        venda1.AdicionarItem(leite, 4);
        venda1.AdicionarItem(frango, 2);
        venda1.Finalizar(pontosParaResgatar: 200);

        Console.WriteLine("=== VENDA 2 – Diana Ferreira ===");
        var venda2 = mercado.AbrirVenda(clienteB, operador2);
        venda2.AdicionarItem(refri, 3);
        venda2.AdicionarItem(biscoito, 5);
        venda2.AdicionarItem(leite, 2);
        venda2.Finalizar();

        Console.WriteLine("=== RESGATE EXTRA DE PONTOS – Carlos ===");
        clienteA.ResgatarPontos(100);

        Console.WriteLine("=== RELATÓRIO DO DIA ===");
        mercado.RelatorioVendasDia();

        Console.WriteLine("=== ESTADO FINAL DOS CLIENTES ===");
        Console.WriteLine($"  {clienteA.Identificar()}");
        Console.WriteLine($"  {clienteB.Identificar()}");
    }
}
