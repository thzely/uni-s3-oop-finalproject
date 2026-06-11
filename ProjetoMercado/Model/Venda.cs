using System;
using System.Collections.Generic;
using System.Linq;
namespace Supermarket.model;

public class Venda
{
    public int Id {
        get;
        private set; 
    }
    public DateTime DataHora {
        get;
        private set;
    }
    public Cliente Cliente {
        get; 
        private set; 
    }
    public Funcionario Operador {
        get; 
        private set; 
    }
    public List<ItemVenda> Itens {
        get; 
        private set; 
    }
    public bool Finalizada {
        get; 
        private set; 
    }
    public decimal Desconto {
        get; 
        private set;
    }

    private static int _seq = 1000;

    public Venda(Cliente cliente, Funcionario operador){
        Id       = ++_seq;
        DataHora = DateTime.Now;
        Cliente  = cliente;
        Operador = operador;
        Itens    = new List<ItemVenda>();
    }

    public void AdicionarItem(Produto produto, int quantidade){
        if (Finalizada) throw new InvalidOperationException("Venda já finalizada.");
        produto.BaixarEstoque(quantidade);
        Itens.Add(new ItemVenda(produto, quantidade));
        Console.WriteLine($"    + {produto.Nome} x{quantidade}");
    }

    public decimal TotalBruto   => Itens.Sum(i => i.Subtotal);
    public decimal TotalLiquido => TotalBruto - Desconto;

    public void Finalizar(int pontosParaResgatar = 0){
        if (Finalizada)   throw new InvalidOperationException("Venda já foi finalizada.");
        if (!Itens.Any()) throw new InvalidOperationException("Venda sem itens.");

        if (pontosParaResgatar > 0)
            Desconto = Cliente.ResgatarPontos(pontosParaResgatar);

        int pontosGanhos = (int)(TotalLiquido / 5m);
        Cliente.AdicionarPontos(pontosGanhos);

        Finalizada = true;

        Console.WriteLine($"\n  {'─',46}");
        Console.WriteLine($"  CUPOM FISCAL  –  Venda #{Id}");
        Console.WriteLine($"  Data    : {DataHora:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"  Cliente : {Cliente.Nome}");
        Console.WriteLine($"  Operador: {Operador.Nome}");
        Console.WriteLine($"  {'─',46}");
        foreach (var item in Itens) Console.WriteLine(item);
        Console.WriteLine($"  {'─',46}");
        Console.WriteLine($"  Total Bruto  : R$ {TotalBruto:F2}");
        if (Desconto > 0)
            Console.WriteLine($"  Desconto Pts : R$ {Desconto:F2}");
        Console.WriteLine($"  TOTAL FINAL  : R$ {TotalLiquido:F2}");
        Console.WriteLine($"  Pts ganhos   : +{pontosGanhos}  (saldo: {Cliente.Pontosfid} pts)");
        Console.WriteLine($"  {'─',46}\n");
    }
}