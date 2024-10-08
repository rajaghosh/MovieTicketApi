using MovieTicketApi.DatabaseContext;
using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using System.Net;

namespace MovieTicketApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieTicketRepository<MovieMaster> _repo;

        public MovieService(IMovieTicketRepository<MovieMaster> repo)
        {
            _repo = repo;
        }

        public async Task<List<MovieDto>> GetAllMovieNameAsync()
        {
            try
            {
                var movies = await _repo.GetAllAsync();
                List<MovieDto> result = new List<MovieDto>();
                foreach (var item in movies)
                {
                    MovieDto movieObj = new MovieDto()
                    {
                        Name = item.Name,
                        Language = item.Language,
                        RunTime = item.RunningMin
                    };
                    result.Add(movieObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<MovieDto>();
            }
        }

        public async Task<bool> AddToMovieAsync(AddMovieDto movieDto)
        {
            try
            {
                var movieObj = new MovieMaster()
                {
                    Name = movieDto.Name,
                    Language = movieDto.Language,
                    Description = movieDto.Description,
                    RunningMin = movieDto.RunTime
                };

                await _repo.AddAsync(movieObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto)
        {
            try
            {
                var movieObj = new MovieMaster()
                {
                    Id = movieDto.Id,
                    Name = movieDto.Name,
                    Language = movieDto.Language,
                    Description = movieDto.Description,
                    RunningMin = movieDto.RunTime
                };

                await _repo.UpdateAsync(movieObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(movieId);
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
