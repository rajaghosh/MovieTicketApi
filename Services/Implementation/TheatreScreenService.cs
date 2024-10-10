using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services.Interface;
using TheatreTicketApi.Services.Interface;

namespace MovieTicketApi.Services.Implementation
{
    public class TheatreScreenService : ITheatreScreenService
    {
        private readonly IMovieTicketRepository<TheatreScreen> _repo;
        private readonly ITheatreService _theatreService;

        public TheatreScreenService(IMovieTicketRepository<TheatreScreen> repo, ITheatreService theatreService)
        {
            _repo = repo;
            _theatreService = theatreService;
        }

        public async Task<List<TheatreScreenDto>> GetAllTheatreScreenAsync()
        {
            try
            {
                var theatreScreens = await _repo.GetAllAsync();
                List<TheatreScreenDto> result = new List<TheatreScreenDto>();

                var allTheatreIds = theatreScreens.Select(p => p.TheatreId).ToList();
                var allTheatreDetails = await _theatreService.GetSpecificTheatreDetailsAsync(allTheatreIds);

                foreach (var item in theatreScreens)
                {
                    TheatreScreenDto theatreScreenObj = new TheatreScreenDto()
                    {
                        TheatreName = allTheatreDetails.Where(p => p.Id == item.TheatreId).FirstOrDefault()?.Name ?? "",
                        ScreenName = item.ScreenName,
                        Rows = item.Rows,
                        SeatNos = item.SeatNos
                    };
                    result.Add(theatreScreenObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<TheatreScreenDto>();
            }
        }

        public async Task<List<TheatreScreenTotalDto>> GetSpecificTheatreScreenDetailsAsync(List<int> theatreScreenIds)
        {
            try
            {
                var theatreScreens = await _repo.GetAllAsync();
                var allTheatreIds = theatreScreens.Where(p => theatreScreenIds.Contains(p.Id)).Select(p=>p.TheatreId).ToList(); 
                var allTheatreDetails = await _theatreService.GetSpecificTheatreDetailsAsync(allTheatreIds);

                List<TheatreScreenTotalDto> result = new List<TheatreScreenTotalDto>();
                foreach (var item in theatreScreens)
                {
                    TheatreScreenTotalDto theatreScreenObj = new TheatreScreenTotalDto()
                    {
                        Id = item.Id,
                        TheatreName = allTheatreDetails.Where(p => p.Id == item.TheatreId).FirstOrDefault()?.Name ?? "",
                        ScreenName = item.ScreenName,
                        Rows = item.Rows,
                        SeatNos = item.SeatNos
                    };
                    result.Add(theatreScreenObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<TheatreScreenTotalDto>();
            }
        }

        public async Task<bool> AddToTheatreScreenAsync(AddTheatreScreenDto theatreScreenDto)
        {

            try
            {
                var theatreScreenObj = new TheatreScreen()
                {
                    TheatreId = theatreScreenDto.TheatreId,
                    ScreenName = theatreScreenDto.ScreenName,
                    Rows = theatreScreenDto.Rows,
                    SeatNos = theatreScreenDto.SeatNos
                };

                await _repo.AddAsync(theatreScreenObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateTheatreScreenAsync(UpdateTheatreScreenDto theatreScreenDto)
        {
            try
            {
                var theatreScreenObj = new TheatreScreen()
                {
                    Id = theatreScreenDto.Id,
                    TheatreId = theatreScreenDto.TheatreId,
                    ScreenName = theatreScreenDto.ScreenName,
                    Rows = theatreScreenDto.Rows,
                    SeatNos = theatreScreenDto.SeatNos
                };

                await _repo.UpdateAsync(theatreScreenObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTheatreScreenAsync(int theatreScreenId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(theatreScreenId);
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
