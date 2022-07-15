namespace data.BaseModels
{
    public class Language
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; } = new();
    }
}

