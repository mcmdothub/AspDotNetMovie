using AspDotNetMovie.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspDotNetMovie.Date
{
    public interface IMovieRepository
    {
        // and include inside all the members you created (GetAllMovies GetMoviesByCategory etc)
        // 
        IEnumerable<Movie> GetAllMovies();

        // generated automaticlly like this
        // object GetAllOrders();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        // step 2: inside DutchRepository you need the implement interface

        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);


        Order GetOrderById(string username, int id);


        bool SaveAll();
        void AddEntity(object model);
    }
}