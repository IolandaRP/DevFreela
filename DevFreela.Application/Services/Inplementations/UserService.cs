using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Inplementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var users = _dbContext.Users;

            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            var userViewModel = new UserViewModel(user.FullName, user.Email);

            return userViewModel;
        }
    }
}
