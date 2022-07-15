namespace data.BaseModels
{
    public class Company
    {
        public int Id { get; set; }
        public int DataId { get; set; }
        public string Name { get; set; }

        public virtual List<Movie> Movies { get; set; } = new();
    }
}
