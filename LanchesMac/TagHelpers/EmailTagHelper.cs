using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LanchesMac.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Montando link pro e-mail e setando o conteudo. 
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto" + Endereco);
            output.Content.SetContent(Conteudo);

        }
    }
}
