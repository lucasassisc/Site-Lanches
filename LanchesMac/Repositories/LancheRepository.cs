using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _contexto;

        public LancheRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        //Implementando o IEnumerable que vai trazer uma coleção de lanches, e incluido também as Categorias. 
        public IEnumerable<Lanche> Lanches => _contexto.Lanches.Include(c => c.Categoria);

        //Implementando o IEnumerable que vai trazer uma coleção de lanches, e o where fez a condição onde a propriedade seja igual a lanche preferido
        // e no fim também incluiu também as Categorias
        public IEnumerable<Lanche> LanchesPreferidos => _contexto.Lanches.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _contexto.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
