using AspDotNetMovie.DbContexts;
using AspDotNetMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Omdb.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AspDotNetMovie.Date
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AspDotNetMovieDbContext _ctx;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(AspDotNetMovieDbContext ctx,ILogger<MovieRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
        // simpe API for geting data
        // create some calls that return data
        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                // use the _ctx (context) to return them
                return _ctx.Orders
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Movie)
                           .ToList();

            }
            else
            {
                return _ctx.Orders
                           .ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {

                return _ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Movie)
                           .ToList();

            }
            else
            {
                return _ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .ToList();
            }
        }


        // create some calls that return data
        public IEnumerable<Movie> GetAllMovies()
        {
            try
            {
                _logger.LogInformation("GetAllMovies was called");

                return _ctx.Movies?
                           .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all movies: {ex}");
                return null;
            }
        }


        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Movie)
                       .Where(o => o.Id == id && o.User.UserName == username)
                       .FirstOrDefault();
        }

        

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }


        public void AddEntity(object model)
        {
            throw new NotImplementedException();
        }
    }
}
