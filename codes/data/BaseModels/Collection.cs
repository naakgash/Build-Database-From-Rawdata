namespace data.BaseModels
{
    public class Collection
    {
        public int Id { get; set; }
        public int DataId { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }

        public virtual List<Movie> Movies { get; set; } = new();
    }
}
