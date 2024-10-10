using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using TheatreTicketApi.Services.Interface;

namespace MovieTicketApi.Services.Implementation
{
    public class TheatreService: ITheatreService
    {
        private readonly IMovieTicketRepository<TheatreMaster> _repo;

        public TheatreService(IMovieTicketRepository<TheatreMaster> repo)
        {
            _repo = repo;
        }

        public async Task<List<TheatreDto>> GetAllTheatreNameAsync()
        {
            try
            {
                var theatres = await _repo.GetAllAsync();
                List<TheatreDto> result = new List<TheatreDto>();
                foreach (var item in theatres)
                {
                    TheatreDto theatreObj = new TheatreDto()
                    {
                        Name = item.Name,
                        Location = item.Location
                    };
                    result.Add(theatreObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<TheatreDto>();
            }
        }

        public async Task<List<TheatreMaster>> GetSpecificTheatreDetailsAsync(List<int> theatreIds)
        {
            try
            {
                var theatres = await _repo.GetAllAsync();
                return theatres.Where(p => theatreIds.Contains(p.Id)).ToList();
            }
            catch (Exception ex)
            {
                return new List<TheatreMaster>();
            }
        }

        public async Task<bool> AddToTheatreAsync(AddTheatreDto theatreDto)
        {
            try
            {
                var theatreObj = new TheatreMaster()
                {
                    Name = theatreDto.Name,
                    Location = theatreDto.Location,
                    Description = theatreDto.Description
                };

                await _repo.AddAsync(theatreObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateTheatreAsync(UpdateTheatreDto theatreDto)
        {
            try
            {
                var threatreObj = new TheatreMaster()
                {
                    Id = theatreDto.Id,
                    Name = theatreDto.Name,
                    Location = theatreDto.Location,
                    Description = theatreDto.Description
                };

                await _repo.UpdateAsync(threatreObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTheatreAsync(int theatreId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(theatreId);
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
