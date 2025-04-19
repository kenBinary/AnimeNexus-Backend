using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer;

namespace backend.AnimeNexus.API.Features.Producer.Interfaces
{
    public interface IProducerService
    {
        Task<ProducerDataFullResponse?> GetAnimeProducerById(int id);
        Task<ProducerListResponse?> GetAnimeProducers(ProducerSearchQueryParameters queryParameters);
    }
}