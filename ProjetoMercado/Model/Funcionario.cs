using System;
namespace Supermarket.model;

public class Funcionario : Pessoa
{
    public string  Cargo   { get; private set; }
    public decimal Salario { get; private set; }

    public Funcionario(string nome, string cpf, string cargo, decimal salario)
        : base(nome, cpf)
    {
        if (salario <= 0) throw new ArgumentException("Salário deve ser positivo.");
        Cargo   = cargo;
        Salario = salario;
    }

    public override string Identificar() =>
        $"Funcionário: {Nome} | Cargo: {Cargo} | Salário: R$ {Salario:F2}";


}