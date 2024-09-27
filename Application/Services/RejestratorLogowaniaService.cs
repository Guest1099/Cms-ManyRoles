using Data.Repos;

namespace Application.Services
{
    public class RejestratorLogowaniaService
    {
        private readonly RejestratorLogowaniaRepository rejestratorLogowaniaRepository;

        public RejestratorLogowaniaService(RejestratorLogowaniaRepository rejestratorLogowaniaRepository)
        {
            this.rejestratorLogowaniaRepository = rejestratorLogowaniaRepository;
        }
    }
}
