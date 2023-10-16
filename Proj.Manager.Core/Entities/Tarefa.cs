using Proj.Manager.Core.Enums;

namespace Proj.Manager.Core.Entities
{
    public sealed class Tarefa : Entidade
    {
        public Tarefa()
        {
            
        }
        public Tarefa(
            Guid projetoId,
            string nome, 
            string descricao, 
            DateTime dataInicio, 
            DateTime? dataPrazo)
        {
            this.ProjetoId = projetoId;
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataInicio = dataInicio;

            this.DataPrazo = dataPrazo == null ? dataInicio.AddDays(15) : dataPrazo.Value;

            this.Membros = new List<Membro>();
        }

        public Guid ProjetoId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataPrazo { get; private set; }
        public DateTime? DataTermino { get; private set; } = null;
        public EStatusTarefa Status { get; private set; } = EStatusTarefa.NaoIniciado;
        public List<Membro> Membros { get; private set; } = null!;
        public Projeto Projeto { get; private set; } = null!;
        

        public void Atualizar(
           string nome,
           string descricao,
           DateTime dataPrazo)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataPrazo = dataPrazo;
        }

        public void AdicionarMembros(Membro membro)
        {
            this.Membros.Add(membro);
        }

        public void RemoveMembro(Membro membro)
        {
            this.Membros.Remove(membro);
        }

        public void Deletar()
        {
            this.Status = EStatusTarefa.Deletada;
            this.DataTermino = DateTime.Now;
        }

        public void Finalizar()
        {
            this.Status = EStatusTarefa.Finalizada;
            this.DataTermino = DateTime.Now;
        }

        public void Cancelar()
        {
            this.Status = EStatusTarefa.Cancelada;
            this.DataTermino = DateTime.Now;
        }

        public void MarcarEmAndamento()
        {
            this.Status = EStatusTarefa.EmAndamento;
        }
    }
}
