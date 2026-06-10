using System;
namespace Supermarket.model;

public class ItemVenda
{
    public Produto Produto {
        get;
        private set;
        }

    public int Quantidade {
        get;
        private set;
        }

    public decimal PrecoUnit {
        get;
        private set;
        }

    public decimal Subtotal => PrecoUnit * Quantidade;

    public ItemVenda(Produto produto, int quantidade)
    {
        if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser positiva.");
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnit = produto.Preco;
    }

    public override string ToString() =>
        $"  {Produto.Nome,-28} x{Quantidade,3}  @ R$ {PrecoUnit:F2}  = R$ {Subtotal:F2}";
}