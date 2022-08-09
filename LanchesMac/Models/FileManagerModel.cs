using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace LanchesMac.Models
{
    public class FileManagerModel
    {
        //Dar acesso a métodos e propriedades para tratar os arquivos 
        public FileInfo[] Files { get; set; }

        //Interface que permite enviar os arquivos, ter acesso a várias informações do arquivo
        public IFormFile IFormFile { get; set; }
        public List<IFormFile> IFormFiles { get; set; }
        public string PathImagesProduto { get; set; }
    }
}