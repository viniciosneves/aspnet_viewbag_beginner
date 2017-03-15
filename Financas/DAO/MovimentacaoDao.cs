using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class MovimentacaoDao
    {
        private FinancasContext context;

        public MovimentacaoDao(FinancasContext context)
        {

            this.context = context;
        }

        public void Adiciona(Movimentacao movimentacao)
        {

            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {

            return context.Movimentacoes.ToList();
        }
    }
}