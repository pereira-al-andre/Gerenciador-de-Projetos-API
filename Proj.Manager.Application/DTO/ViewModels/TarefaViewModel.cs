using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class MembroDaTarefa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;

        public MembroDaTarefa(Membro membro)
        {
            this.Nome = membro.Nome;
            this.Id = membro.Id;
        }
    }

    public class TarefaViewModel
    {
        public Guid Id { get; set; }
        public Guid ProjetoId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataPrazo { get; set; }
        public DateTime? DataTermino { get; set; } = null;
        public EStatusTarefa Status { get; set; } = EStatusTarefa.NaoIniciado;
        public string DescricaoStatus { get { return this.Status.RetornarDescricao(); } }
        public List<MembroDaTarefa> Membros { get; set; } = new();


        public TarefaViewModel(Tarefa tarefa)
        {
            this.Id = tarefa.Id;
            this.ProjetoId = tarefa.ProjetoId;
            this.Nome = tarefa.Nome;
            this.Descricao = tarefa.Descricao;
            this.DataInicio = tarefa.DataInicio;
            this.DataPrazo = tarefa.DataPrazo;
            this.DataTermino = tarefa.DataTermino;
            this.Status = tarefa.Status;

            this.CarregarMembros(tarefa);
           
        }
        public static List<TarefaViewModel> ListaDeTarefas(List<Tarefa> tarefas)
        {

            var tarefaViewModelList = new List<TarefaViewModel>();

            tarefas.ForEach(t => tarefaViewModelList.Add(new TarefaViewModel(t)));

            return tarefaViewModelList;
        }
        private void CarregarMembros(Tarefa tarefa) 
            => tarefa.Membros.ForEach(membro => this.Membros.Add(new MembroDaTarefa(membro)));
    }
}
