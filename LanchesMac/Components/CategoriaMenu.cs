using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _icategoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _icategoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke() 
        {
            var categorias = _icategoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);
        }
    }
}
