using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; } //data de criação 
        public DateTime? StartedAt { get; private set; } //data de início
        public DateTime? FinishedAt { get; private set; } //data de finalização
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if(Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update (string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

    }
}
