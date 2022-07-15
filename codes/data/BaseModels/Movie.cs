namespace data.BaseModels
{
    public class Movie
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public virtual List<Collection> Collections { get; set; } = new();
        public long Budget { get; set; }
        public virtual List<Genre> Genres { get; set; } = new();
        public string? Homepage { get; set; }
        public long DataId { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public virtual List<Country> Countries { get; set; } = new();
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public decimal? Runtime { get; set; }
        public virtual List<Language> SpokenLanguages { get; set; } = new();
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
    }
}
