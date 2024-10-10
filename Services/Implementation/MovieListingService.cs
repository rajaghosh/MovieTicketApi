using MovieTicketApi.DatabaseContext.Repo;
using MovieTicketApi.DTO;
using MovieTicketApi.Entities;
using MovieTicketApi.Services.Interface;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketApi.Services.Implementation
{
    public class MovieListingService : IMovieListingService
    {
        private readonly IMovieTicketRepository<MovieListing> _repo;
        private readonly IMovieService _movieService;
        private readonly ITheatreScreenService _screenService;

        public MovieListingService(IMovieTicketRepository<MovieListing> repo, IMovieService movieService, ITheatreScreenService screenService)
        {
            _repo = repo;
            _movieService = movieService;
            _screenService = screenService;
        }

        public async Task<List<MovieListingDto>> GetAllMovieListingAsync()
        {
            try
            {
                var movies = await _repo.GetAllAsync();

                var movieIds = movies.Select(p => p.MovieId).ToList();
                var screenIds = movies.Select(p => p.ScreenId).ToList();

                Task<List<MovieMaster>> movieDetailsTask = _movieService.GetSpecificMovieDetailsAsync(movieIds);
                Task<List<TheatreScreenTotalDto>> screenDetailsTask = _screenService.GetSpecificTheatreScreenDetailsAsync(screenIds);

                await Task.WhenAll(movieDetailsTask, screenDetailsTask);

                List<MovieMaster> movieDetails = movieDetailsTask.Result;
                List<TheatreScreenTotalDto> screenDetails = screenDetailsTask.Result;


                List<MovieListingDto> result = new List<MovieListingDto>();
                foreach (var item in movies)
                {
                    MovieListingDto movieListingObj = new MovieListingDto()
                    {
                        MovieName = movieDetails.Where(p => p.Id == item.MovieId).FirstOrDefault()?.Name ?? "",
                        TheatreName = screenDetails.Where(p => p.Id == item.MovieId).FirstOrDefault()?.TheatreName ?? "",
                        ScreenName = screenDetails.Where(p => p.Id == item.ScreenId).FirstOrDefault()?.ScreenName ?? "",
                        StartDate_StartTime = item.StartDate.ToString("MM-dd-yyyy") + " and " + item.StartTime.ToString("hh:mm:ss tt"),
                        EndDate_EndTime = item.EndDate.ToString("MM-dd-yyyy") + " and " + item.EndTime.ToString("hh:mm:ss tt"),
                        MovieRunningStatus = item.IsActive == true ? "Running" : "Closed"
                    };
                    result.Add(movieListingObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<MovieListingDto>();
            }
        }

        public async Task<MovieListing> GetSpecificMovieListingDetailsAsync(ListingSearch listingDto)
        {
            try
            {
                var predicate = (MovieListing p) => p.MovieId == listingDto.MovieId
                                                  && p.ScreenId == listingDto.ScreenId;

                var movieListingObj = _repo.Find(predicate).FirstOrDefault();

                if (movieListingObj == null)
                {
                    throw new Exception("No movie scheduled");
                }

                await Task.Delay(0);
                DateTime movieDate = listingDto.MovieStartDateTime;

                if(movieListingObj.StartDate <= movieDate && movieDate <= movieListingObj.EndDate)
                {
                    if (movieListingObj.StartDate.TimeOfDay <= movieDate.TimeOfDay
                        && movieDate.TimeOfDay <= movieListingObj.EndDate.TimeOfDay)
                    {
                        return movieListingObj;
                    }
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddToMovieListingAsync(AddMovieListingDto movieListingDto)
        {
            try
            {
                //Get the movie runtime
                var movieObj = await _movieService.GetSpecificMovieDetailsAsync(new List<int>(movieListingDto.MovieId));
                if (movieObj.Any())
                {
                    int runtime = movieObj.First().RunningMin;

                    DateTime startTime = DateTime.ParseExact(movieListingDto.StartTime, "HH:mm:ss", null);
                    DateTime endTime = startTime.AddMinutes(runtime);

                    var movieListingObj = new MovieListing()
                    {
                        MovieId = movieListingDto.MovieId,
                        ScreenId = movieListingDto.ScreenId,
                        StartDate = movieListingDto.StartDate,
                        EndDate = movieListingDto.EndDate,
                        StartTime = startTime,
                        EndTime = endTime,
                        IsActive = true
                    };

                    await _repo.AddAsync(movieListingObj);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateMovieListingAsync(UpdateMovieListingDto movieListingDto)
        {
            try
            {
                //Get the movie runtime
                var movieObj = await _movieService.GetSpecificMovieDetailsAsync(new List<int>(movieListingDto.MovieId));
                if (movieObj.Any())
                {
                    int runtime = movieObj.First().RunningMin;

                    DateTime startTime = DateTime.ParseExact(movieListingDto.StartTime, "HH:mm:ss", null);
                    DateTime endTime = startTime.AddMinutes(runtime);
                    var movieListingObj = new MovieListing()
                    {
                        Id = movieListingDto.Id,
                        MovieId = movieListingDto.MovieId,
                        ScreenId = movieListingDto.ScreenId,
                        StartDate = movieListingDto.StartDate,
                        EndDate = movieListingDto.EndDate,
                        StartTime = startTime,
                        EndTime = endTime,
                        IsActive = movieListingDto.IsActive
                    };

                    await _repo.UpdateAsync(movieListingObj);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteMovieListingAsync(int movieListingId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(movieListingId);
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
