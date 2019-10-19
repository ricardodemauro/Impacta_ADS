namespace AlunosApi.Models
{
    public class AlunosDatabaseSettings : IDatabaseSettings
    {
        public string AlunosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string AlunosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}