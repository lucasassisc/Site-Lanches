using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        //Definiu uma propriedade somente leitura, que vai retornar uma coleção de objetos Categorias
        //IEnumerable Funciona apenas como leitura. Somente percorre a coleção sequencialmente
        //IEnumerable Expõe um enumerador que dá suporte a uma iteração simples em uma coleção não genérica
        IEnumerable<Categoria> Categorias { get; }
    }
}
