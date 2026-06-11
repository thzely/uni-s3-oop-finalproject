using System;
using System.Collections.Generic;
using System.Linq;
namespace Supermarket.model;

public class Supermercado
{
    public string Nome {
        get;
        private set;
    }
    public string CNPJ {
        get;
        private set;
    }
    private List<Produto> _produtos = new();
    private List<Funcionario> _funcs    = new();
    private List<Venda> _vendas   = new();

    public Supermercado(string nome, string cnpj){
        Nome = nome;
        CNPJ = cnpj;
        Console.WriteLine($"Supermercado '{Nome}' (CNPJ: {cnpj}) inicializado.\n");
    }
    public void CadastrarProduto(Produto p){
        _produtos.Add(p);
        Console.WriteLine($"  Produto cadastrado : {p}");
    }
    public void CadastrarFuncionario(Funcionario f){
        _funcs.Add(f);
        Console.WriteLine($"  Funcionário cadastrado: {f.Identificar()}");
    }

    public Venda AbrirVenda(Cliente cliente, Funcionario operador){
        var v = new Venda(cliente, operador);
        _vendas.Add(v);
        Console.WriteLine($"\n>> Venda #{v.Id} aberta | Cliente: {cliente.Nome} | Operador: {operador.Nome}");
        return v;
    }

    public void RelatorioVendasDia(){
        var hoje  = _vendas.Where(v => v.Finalizada && v.DataHora.Date == DateTime.Today).ToList();
        decimal total = hoje.Sum(v => v.TotalLiquido);

        Console.WriteLine($"  {'═',46}");
        Console.WriteLine($"  RELATÓRIO DE VENDAS – {DateTime.Today:dd/MM/yyyy}");
        Console.WriteLine($"  Vendas finalizadas  : {hoje.Count}");
        Console.WriteLine($"  Faturamento do dia  : R$ {total:F2}");
        Console.WriteLine($"  {'─',46}");

        foreach (var v in hoje)
            Console.WriteLine($"  Venda #{v.Id} | {v.Cliente.Nome,-20} | R$ {v.TotalLiquido:F2}");

        Console.WriteLine($"  {'═',46}\n");
    }
}