using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Features.Producer.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer;

namespace backend.AnimeNexus.API.Features.Producer.Services
{
    public class ProducerService : IProducerService
    {

        private readonly IJikanApiClient _jikanApiClient;
        private readonly ILogger<ProducerService> _logger;

        public ProducerService(IJikanApiClient jikanApiClient, ILogger<ProducerService> logger)
        {
            _jikanApiClient = jikanApiClient ?? throw new ArgumentNullException(nameof(jikanApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ProducerDataFullResponse?> GetAnimeProducerById(int id)
        {
            _logger.LogInformation("Getting producer details");

            return await _jikanApiClient.GetAnimeProducerById(id);
        }

        public async Task<ProducerListResponse?> GetAnimeProducers(ProducerSearchQueryParameters queryParameters)
        {
            _logger.LogInformation("Fetching producers with parameters: {parameters}", queryParameters);

            return await _jikanApiClient.GetAnimeProducers(queryParameters);
        }
    }
}