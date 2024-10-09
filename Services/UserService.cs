using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.Entities;

namespace MovieTicketApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMovieTicketRepository<UserMaster> _repo;

        public UserService(IMovieTicketRepository<UserMaster> repo)
        {
            _repo = repo;
        }

        public async Task<bool> IsEmailValidAsync(string email, string password)
        {
            try
            {
                var userList = await _repo.GetAllAsync();
                var myUser = userList.FirstOrDefault(p => p.Email == email && p.Password == password);
                if (myUser != null)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
