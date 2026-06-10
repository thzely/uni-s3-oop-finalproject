using System;
namespace Supermarket.model;

public class Cliente : Pessoa
{
    public string Email {
        get; 
        private set; 
        }

    public int Pontosfid { 
        get;
        private set;
        }

    public Cliente(string nome, string cpf, string email)
        : base(nome, cpf)
    {
        Email = email;
        Pontosfid = 0;
    }

    public Cliente(string nome, string cpf, string email, int pontosIniciais)
        : this(nome, cpf, email)
    {
        if (pontosIniciais < 0) throw new ArgumentException("Pontos não podem ser negativos.");
        Pontosfid = pontosIniciais;
    }

    public override string Identificar() =>
        $"Cliente: {Nome} | E-mail: {Email} | Pontos: {Pontosfid}";

    public void AdicionarPontos(int pontos) => Pontosfid += pontos;

    public decimal ResgatarPontos(int pontos){
        if (pontos < 100)
            throw new InvalidOperationException("Resgate mínimo: 100 pontos.");
        if (pontos > Pontosfid)
            throw new InvalidOperationException(
                $"Saldo insuficiente. Você tem {Pontosfid} pontos.");

        Pontosfid -= pontos;
        decimal desconto = pontos * 0.10m;
        Console.WriteLine($"  {Nome}: {pontos} pts resgatados." +
                          $" Desconto: R$ {desconto:F2}. Saldo: {Pontosfid} pts.");

        return desconto;
    }
}