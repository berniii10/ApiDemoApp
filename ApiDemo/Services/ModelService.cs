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
    }
}
