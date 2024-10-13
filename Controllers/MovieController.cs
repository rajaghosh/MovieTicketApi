using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.DTO;
using MovieTicketApi.Helper;
using MovieTicketApi.LoggerFactory;
using MovieTicketApi.Models;
using MovieTicketApi.Services.Interface;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        //private readonly ILoggerFactory _loggerFactory;
        //private readonly ICustomLoggerFactory _loggerFactory;

        private readonly ICustomLogger _logger;


        //private readonly ILoggerObjContract _logger;
        public MovieController(IMovieService movieService, ICustomLogger logger) //ICustomLoggerFactory loggerFactory)
        {
            _movieService = movieService;
            _logger = logger;


            //_loggerFactory = loggerFactory;


            //_logger = _loggerFactory.CreateLogger(LoggerType.FileLog);

        }

        [HttpGet("GetAllMovie")]
        public async Task<List<MovieDto>> GetAll()
        {
            _logger.InfoLog("Started123.....");
            var movies = await _movieService.GetAllMovieNameAsync();
            return movies;
        }

        [HttpPost("AddNewMovie")]
        public async Task<ResponseDto<string>> PostMovie([FromBody] AddMovieDto movieDto)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            try
            {
                //_logger.LogInformation("Operation Started");
                var res = await _movieService.AddToMovieAsync(movieDto);
                //_logger.LogInformation("Result Received");

                if (res)
                {
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Added Successfully";
                }
                else
                {
                    resp.StatusCode = HttpStatusCode.InternalServerError;
                    resp.Result = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }

        [HttpPut("UpdateMovie")]
        public async Task<ResponseDto<string>> PutMovie([FromBody] UpdateMovieDto movieDto)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            try
            {
                var res = await _movieService.UpdateMovieAsync(movieDto);

                if (res)
                {
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Updated Successfully";
                }
                else
                {
                    resp.StatusCode = HttpStatusCode.InternalServerError;
                    resp.Result = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }

        [HttpDelete("DeleteMovie")]
        public async Task<ResponseDto<string>> Delete([FromQuery][Required] int movieId)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            try
            {
                var res = await _movieService.DeleteMovieAsync(movieId);

                if (res)
                {
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Deleted Successfully";
                }
                else
                {
                    resp.StatusCode = HttpStatusCode.InternalServerError;
                    resp.Result = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }
    }
}


