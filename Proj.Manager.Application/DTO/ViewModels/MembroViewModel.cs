using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class TarefasDoMembro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;

        public TarefasDoMembro(Tarefa tarefa)
        {
            this.Nome = tarefa.Nome;
            this.Id = tarefa.Id;
        }
    }

    public class ProjetosDoMembro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;

        public ProjetosDoMembro(Projeto projeto)
        {
            this.Nome = projeto.Nome;
            this.Id = projeto.Id;
        }
    }

    public class MembroViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ECargo Cargo { get; set; }
        public string DescricaoCargo { get { return this.Cargo.RetornarDescricao();  } }

        public List<TarefasDoMembro> Tarefas { get; set; } = new();
        public List<ProjetosDoMembro> Projetos { get; set; } = new();

        public MembroViewModel(Membro membro)
        {
            this.Id = membro.Id;
            this.Nome = membro.Nome;
            this.Email = membro.Email;
            this.Cargo = membro.Cargo;

            this.CarregarProjetos(membro);
            this.CarregarTarefas(membro);
        }

        public static List<MembroViewModel> ListaDeMembros(List<Membro> membros)
        {
            var membroViewModelList = new List<MembroViewModel>();
            membros.ForEach(m => membroViewModelList.Add(new MembroViewModel(m)));

            return membroViewModelList;
        }

        private void CarregarProjetos(Membro membro) 
            => membro.Projetos.ForEach(projeto => this.Projetos.Add(new ProjetosDoMembro(projeto)));

        private void CarregarTarefas(Membro membro)
            => membro.Tarefas.ForEach(tarefa => this.Tarefas.Add(new TarefasDoMembro(tarefa)));
    }
}
