using Omdb.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omdb.API
{
  
    public interface IOmdbRepository
    {
        Task<MovieResponse> Search(string title);
    }
}
