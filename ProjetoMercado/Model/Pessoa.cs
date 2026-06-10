using System;
namespace Supermarket.model;

//model (c#)== classe(java)
//nas classe, usa namespace Supermarket.model
//dps coloca: Using Supermarket.model, na main

public abstract class Pessoa
{
    public string Nome {
        get;
        protected set;
    }

    public string CPF {
        get;
        protected set;
    }

    protected Pessoa(string nome, string cpf)
    {
        if (string.IsNullOrWhiteSpace(nome)) 
            throw new ArgumentException("Nome obrigatório.");
        if (cpf.Length != 11)               
            throw new ArgumentException("CPF deve ter 11 dígitos.");
        Nome = nome;
        CPF  = cpf;
    }

    public virtual string Identificar() => $"Pessoa: {Nome} | CPF: {CPF}";
    public override string ToString() => Identificar();
}