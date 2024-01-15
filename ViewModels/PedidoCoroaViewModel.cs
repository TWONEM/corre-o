using FloriculturaFlores.Models;

namespace FloriculturaFlores.ViewModels
{
    public class PedidoCoroaViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
