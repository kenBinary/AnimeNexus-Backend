namespace backend.AnimeNexus.API.Domain.DTOs.Request
{
    using System.ComponentModel.DataAnnotations;

    /*
    0: mal_id
    1: count
    2: favorites
    3: established
    */
    public enum ProducersQueryOrderBy
    {
        [Display(Name = "mal_id")]
        MalId,
        [Display(Name = "count")]
        Count,
        [Display(Name = "favorites")]
        Favorites,
        [Display(Name = "established")]
        Established
    }

    /*
    0: desc
    1: asc
    */
    public enum SearchQuerySort
    {
        [Display(Name = "desc")]
        Desc,
        [Display(Name = "asc")]
        Asc
    }

    public class ProducerSearchQueryParameters
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page must be a positive integer.")]
        public int? Page { get; set; }

        [Range(1, 25, ErrorMessage = "Limit must be between 1 and 25")]
        public int? Limit { get; set; }
        // search for anime by their name e.g mappa, kyoto, jc staff
        public string? Q { get; set; }

        [EnumDataType(typeof(ProducersQueryOrderBy), ErrorMessage = "Invalid value for order_by.")]
        public ProducersQueryOrderBy? OrderBy { get; set; }

        [EnumDataType(typeof(SearchQuerySort), ErrorMessage = "Invalid value for sort.")]
        public SearchQuerySort? Sort { get; set; }

        // Filters results to producers whose names start with the specified letter

        [StringLength(1, MinimumLength = 1, ErrorMessage = "Letter must be a single character.")]
        public string? Letter { get; set; }
    }
}