using FloriculturaFlores.Models;
using FloriculturaFlores.Context;

namespace FloriculturaFlores.Areas.Admin.Servicos
{
    public class GraficoVendasService
    {
        private readonly AppDbContext context;

        public GraficoVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public List<CoroaGrafico> GetVendasCoroas(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var coroas = (from pd in context.PedidoDetalhes
                          join l in context.Coroas on pd.CoroaId equals l.CoroaId
                          where pd.Pedido.PedidoEnviado >= data
                          group pd by new { pd.CoroaId, l.Nome }
                           into g
                          select new
                          {
                              CoroaNome = g.Key.Nome,
                              CoroasQuantidade = g.Sum(q => q.Quantidade),
                              CoroasValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                          });

            var lista = new List<CoroaGrafico>();

            foreach (var item in coroas)
            {
                var coroa = new CoroaGrafico();
                coroa.CoroaNome = item.CoroaNome;
                coroa.CoroasQuantidade = item.CoroasQuantidade;
                coroa.CoroasValorTotal = item.CoroasValorTotal;
                lista.Add(coroa);
            }
            return lista;
        }
    }
}