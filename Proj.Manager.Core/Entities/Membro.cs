using Proj.Manager.Core.Enums;

namespace Proj.Manager.Core.Entities
{
    public sealed class Membro : Entidade
    {
        public Membro(
            string nome, 
            string email, 
            string senha, 
            ECargo cargo)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Cargo = cargo;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public ECargo Cargo { get; private set; }

        public List<Tarefa> Tarefas { get; private set; } = new();
        public List<Projeto> Projetos { get; private set; } = new();

        public void Atualizar(
            string nome,
            string email)
        {
            if (!String.IsNullOrEmpty(nome)) this.Nome = nome;
            if (!String.IsNullOrEmpty(email)) this.Email = email;
        }

        public void AlterarSenha(string senha) => this.Senha = senha;

        public void AlterarCargo(ECargo cargo) => this.Cargo = cargo;
    }
}
