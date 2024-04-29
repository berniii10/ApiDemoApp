using ApiDemo.Models;

namespace ApiDemo.Services
{
    public class ModelService
    {
        Model model { get; set; }
        public ModelService(Model _model) {
            model = _model;
        }
    }
}
