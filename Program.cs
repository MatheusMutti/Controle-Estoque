using System;
using System.Runtime.CompilerServices;
using ControleEstoqueMain;

namespace ControleEstoque
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Ano { get; set; }
        public int QtdeMin { get; set; }
        public int QtdeMax { get; set; }
        
        public Produto(string Nome, double Preco, int Ano, int QtdeMin, int QtdeMax)
        {

            this.Nome = Nome;
            this.Preco = Preco;
            this.Ano = Ano;
            this.QtdeMin = QtdeMin;
            this.QtdeMax = QtdeMax;
        }
        public override string ToString()
        {
            return Nome.ToString();
        }
    }
}












