namespace data.BaseModels
{
    public class Genre
    {
        public int Id { get; set; }
        public int DataId { get; set; }
        public string? Name { get; set; }

        public virtual List<Movie> Movies { get; set; } = new();
    }
}
