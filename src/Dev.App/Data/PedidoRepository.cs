using Dev.App.Models;

namespace Dev.App.Data
{
  public class PedidoRepository : IPedidoRepository
  {
    public Pedido ObterPedido()
    {
      return new Pedido();
    }
  }

  public interface IPedidoRepository
  {
    Pedido ObterPedido();
  }
}