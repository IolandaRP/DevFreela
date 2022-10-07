using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

        public DevFreelaDbContext()
        {
            Projects = new List<Project>()
            {
                new Project ("Meu projeto APSNET Core 1", "Minha descrição de Projeto 1", 1, 1, 10000),
                new Project ("Meu projeto APSNET Core 2", "Minha descrição de Projeto 2", 1, 1, 20000),
                new Project ("Meu projeto APSNET Core 3", "Minha descrição de Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>()
            {
                new User("Iolanda Rorigues", "iolandarodrigues270@gmail.com", new DateTime(1995,4,4)),
                new User("Robert C Martin", "robert@gmail.com", new DateTime(1952,1,2)),
                new User("Luis Felipe", "luisdev@luisdev.com.br", new DateTime(1992,1,1))
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL Server")
            };
        }


    }
}
