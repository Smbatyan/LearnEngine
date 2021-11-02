namespace LearnEngine.Infrastucture.Settings.MongoSettings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Host { get; set; }
        public string DatabaseName { get; set; }
    }
}
