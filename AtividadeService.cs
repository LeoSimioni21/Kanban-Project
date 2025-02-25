using Projeto_kanban.Models;
using Projeto_kanban.Dto;
using Projeto_kanban.Data;
using Microsoft.EntityFrameworkCore;

namespace Projeto_kanban.Service.Atividade
{
    public class AtividadeService : AtividadeInterface
    {

       private readonly AppDbContext _context;
       public AtividadeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<AtividadeModel>> BuscarAtividade()
        {
            try
            {
                var atividades = await _context.Atividades.Include(x => x.Status).ToListAsync();
                return atividades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatusModel>> BuscarStatus()
        {
            try
            {
                var status = await _context.Status.ToListAsync();
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto)
        {
            try
            {
                Random rand = new Random();

                var atividade = new AtividadeModel()
                {
                    Titulo = cadastroAtividadeDto.Titulo,
                    Descricao = cadastroAtividadeDto.Descricao,
                    StatusId = cadastroAtividadeDto.StatusId,
                    Matricula = rand.Next(1000, 1000000)
                };

                _context.Atividades.Add(atividade);
                await _context.SaveChangesAsync();

                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> Deletar(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividades.FindAsync(atividadeId);

                if (atividade == null)
                {
                    throw new Exception("Atividade não encontrada.");
                }
                _context.Atividades.Remove(atividade);
                await _context.SaveChangesAsync();

                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> MudarCard(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividades.FindAsync(atividadeId);
                atividade.StatusId++;
                _context.Update(atividade);
                await _context.SaveChangesAsync();
                return atividade;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> MudarCardAnterior(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividades.FindAsync(atividadeId);
                atividade.StatusId--;
                _context.Update(atividade);
                await _context.SaveChangesAsync();
                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
