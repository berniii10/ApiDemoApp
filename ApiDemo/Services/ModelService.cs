using ApiDemo.Models;

namespace ApiDemo.Services
{
    public class ModelService
    {
        Model _model { get; set; }
        public ModelService(Model model) {
            _model = model;
        }

        public bool getAllMovies(ref Model model)
        {
            if (_model == null) return false;
            else
            {
                model = _model;
                return true;
            }
        }

        public bool GetMovie(int id, ref Movie _movie)
        {
            if (_model.movies != null)
            {
                foreach (var movie in _model.movies)
                {
                    if (movie.Id == id)
                    {
                        _movie = movie;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddMovie(ref Movie movie)
        {
            foreach (var _movie in _model.movies)
            {
                if (_movie.Id == movie.Id || _movie.title.Equals(movie.title))
                {
                    movie = _movie;
                    return false;
                }
            }
            _model.movies.Add(movie);
            return true;
        }
    }
}
