using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class TarefasDoProjeto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;

        public TarefasDoProjeto(Tarefa tarefa)
        {
            this.Nome = tarefa.Nome;
            this.Id = tarefa.Id;
        }
    }

    public class ProjetoViewModel
    {
        public Guid Id { get; set; }
        public Guid GerenteId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataPrazo { get; set; }
        public DateTime? DataTermino { get; set; } = null;
        public EStatusProjeto Status { get; set; } = EStatusProjeto.NaoIniciado;
        public string DescricaoStatus { get { return this.Status.RetornarDescricao(); } }

        public List<TarefasDoProjeto> Tarefas { get; set; } = new();

        public ProjetoViewModel(Projeto projeto)
        {
            this.Id = projeto.Id;
            this.GerenteId = projeto.GerenteId;
            this.Nome = projeto.Nome;
            this.Descricao = projeto.Descricao;
            this.DataInicio = projeto.DataInicio;
            this.DataPrazo = projeto.DataPrazo;
            this.DataTermino = projeto.DataTermino;
            this.Status = projeto.Status;

            this.CarregarTarefas(projeto);
        }

        public static List<ProjetoViewModel> ListaDeProjetos(List<Projeto> projetos)
        {

            var projetoViewModelList = new List<ProjetoViewModel>();
            projetos.ForEach(p => projetoViewModelList.Add(new ProjetoViewModel(p)));

            return projetoViewModelList;
        }

        public void CarregarTarefas(Projeto projeto) 
            => projeto.Tarefas.ForEach(tarefa => this.Tarefas.Add(new TarefasDoProjeto(tarefa)));
    }
}
