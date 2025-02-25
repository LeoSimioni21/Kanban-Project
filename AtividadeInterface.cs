using Projeto_kanban.Dto;
using Projeto_kanban.Models;

namespace Projeto_kanban.Service.Atividade
{
    public interface AtividadeInterface
    {
        Task<List<AtividadeModel>> BuscarAtividade();
        Task<List<StatusModel>> BuscarStatus();
        Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto);
        Task<AtividadeModel> MudarCard(int atividadeId);
        Task<AtividadeModel> MudarCardAnterior(int atividadeId);

        Task<AtividadeModel> Deletar(int atividadeId);

        

    }
}
