using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services.Interface;

namespace MovieTicketApi.Services.Implementation
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

        public async Task<List<UserDto>> GetAllUserNameAsync()
        {
            try
            {
                var users = await _repo.GetAllAsync();
                List<UserDto> result = new List<UserDto>();
                foreach (var item in users)
                {
                    UserDto userObj = new UserDto()
                    {
                        Name = item.Name,
                        Email = item.Email,
                        Location = item.Location
                    };  
                    result.Add(userObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<UserDto>();
            }
        }

        public async Task<List<UserMaster>> GetSpecificUserDetailsAsync(List<int> userIds)
        {
            try
            {
                var users = await _repo.GetAllAsync();
                return users.Where(p => userIds.Contains(p.Id)).ToList();
            }
            catch (Exception ex)
            {
                return new List<UserMaster>();
            }
        }

        public async Task<bool> AddToUserAsync(AddUserDto userDto)
        {
            try
            {
                var userObj = new UserMaster()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Location = userDto.Location
                };

                await _repo.AddAsync(userObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto userDto)
        {
            try
            {
                var userObj = new UserMaster()
                {
                    Id = userDto.Id,
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Location = userDto.Location
                };

                await _repo.UpdateAsync(userObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(userId);
                if (da == null)
                    return false;
                else
                {
                    await _repo.DeleteAsync(da);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
