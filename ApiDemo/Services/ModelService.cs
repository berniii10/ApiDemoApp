using ApiDemo.Models;

namespace ApiDemo.Services
{
    public class ModelService
    {
        Model model { get; set; }
        public ModelService(Model _model) {
            model = _model;
        }

        public bool GetMovie(int id, ref Movie _movie)
        {
            if (model.movies != null)
            {
                foreach (var movie in model.movies)
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
