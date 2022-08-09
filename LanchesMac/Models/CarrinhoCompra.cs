

using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        //Utilizando a instância de dependência para acessar os dados do banco de dados 
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }

        //Obtem uma lista de itens do carrinho de compra 
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        //Foi definido esse metodo como estatico para podermos invocar esse metodo sem ter uma instância da classe, e ja obtemos um carrinho através do metodo
        // E é registrado na classe startup. 
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Define uma sessão  
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;


            //Obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<AppDbContext>();

            //Obtem ou gera o Id do carrinho 
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            //retornar o carrinho com o contexto e o Id atributo ou obtido 
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            // Verifica se o ID e o Carrinho de Compra já existe
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();

        }
        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;
            if (carrinhoCompraItem != null)
            {
                // E se tiver mais de 1 qtde, vai ser decrementado tirando 1 por 1 
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    // Agora se tiver apenas 1 remove do carrinho de compras
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems =
                 _context.CarrinhoCompraItens
                 .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                 .Include(s => s.Lanche)
                 .ToList());

        }

        public void LimparCarinho()
        {
            // Localizar no banco de dados todos os carrinhos de compra, onde o carrinho de compra id for igual o que quero excluir.
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho =>
                carrinho.CarrinhoCompraId == CarrinhoCompraId);

            //Remove os itens do carrinho de compra que foi selecionado 
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

            //Persistir no banco de dados 
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                // o calculo do total é feito para o carrinho especifico selecionado 
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
