using System;
namespace Supermarket.model;

public class Produto
{
    public int Id {
        get;
        private set;
        }

    public string Nome {
        get;
        private set;
        }

    public decimal Preco {
        get;
        private set;
        }

    public int Estoque {
        get;
        private set;
        }

    public string Categoria {
        get;
        private set;
        }

    private static int _contador = 1;

    public Produto(string nome, decimal preco, int estoque, string categoria)
    {
        if (preco   <= 0) throw new ArgumentException("Preço deve ser positivo.");
        if (estoque <  0) throw new ArgumentException("Estoque não pode ser negativo.");
        Id = _contador++;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        Categoria = categoria;
    }

    public void Atualizar(decimal novoPreco) => Atualizar(novoPreco, Estoque);

    public void Atualizar(decimal novoPreco, int novoEstoque)
    {
        if (novoPreco   <= 0) throw new ArgumentException("Preço inválido.");
        if (novoEstoque <  0) throw new ArgumentException("Estoque inválido.");
        Preco = novoPreco;
        Estoque = novoEstoque;
    }

    public void BaixarEstoque(int qtd)
    {
        if (qtd > Estoque)
            throw new InvalidOperationException(
                $"Estoque insuficiente para '{Nome}'. Disponível: {Estoque}.");
        Estoque -= qtd;
    }

    public override string ToString() =>
        $"[#{Id}] {Nome} | R$ {Preco:F2} | Estoque: {Estoque} | {Categoria}";
}