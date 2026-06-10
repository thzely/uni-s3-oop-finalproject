using System;
namespace Supermarket.model;

public class Funcionario : Pessoa
{
    public string Cargo {
        get;
        private set;
        }

    public decimal Salario {
        get;
        private set;
        }

    public Funcionario(string nome, string cpf, string cargo, decimal salario)
        : base(nome, cpf)
    {
        if (salario <= 0) throw new ArgumentException("Salário deve ser positivo.");
        Cargo = cargo;
        Salario = salario;
    }

    public override string Identificar() =>
        $"Funcionário: {Nome} | Cargo: {Cargo} | Salário: R$ {Salario:F2}";

    public override string Identificar() =>
        $"Funcionário: {Nome} | Cargo: {Cargo} | Salário: R$ {Salario:F2}";

    public void ReajustarSalario(decimal percentual)
    {
        if (percentual <= 0 || percentual > 30)
            throw new InvalidOperationException("Reajuste deve estar entre 0% e 30%.");

        decimal aumento = Salario * (percentual / 100m);
        Salario += aumento;
        Console.WriteLine($"  {Nome}: reajuste de {percentual}%. Novo salário: R$ {Salario:F2}");
    }
}