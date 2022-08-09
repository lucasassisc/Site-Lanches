using LanchesMac.Models;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }




        //método Invoke síncrono que retorna um IViewComponentResult.
        public IViewComponentResult Invoke() 
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
  
   /*         
            var itens = new List<CarrinhoCompraItem>()
            {
                new CarrinhoCompraItem(),
                new CarrinhoCompraItem()
            };
    */ 
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVm = new CarrinhoCompraViewModel()
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };
            return View(carrinhoCompraVm);

        }
    }
}
