using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Core.Entities
{
    public sealed class Member : Entity
    {
        public Member()
        {
            
        }
        public Member(
            Name name, 
            Email email, 
            Password password, 
            Role role)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        public Name Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Password Password { get; private set; } = null!;
        public Role Role { get; private set; }

        public List<Task> Tasks { get; private set; } = new();
        public List<Project> Projects { get; private set; } = new();

        public void Update(
            Name? name = null,
            Email? email = null)
        {
            if (name != null) this.Name = name;
            if (email != null) this.Email = email;
        }

        public void ChangePassword(Password password) => this.Password = password;

        public void ChangeRole(Role role) => this.Role = role;
    }
}
