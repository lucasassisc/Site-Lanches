using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
