using System.ComponentModel.DataAnnotations;

namespace Projeto_kanban.Dto
{
    public class CadastroAtividadeDto
    {
        [Required(ErrorMessage = "Digite o título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Digite um status")]
        public int StatusId { get; set; }
    }
}
