using MongoDB.Driver;
using RPA.AeC.Domain.Entities;

namespace RPA.AeC.API.Infra.Persistence.MongoDB.DBContext
{
    public class MongoDBContext
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase Database { get; }

        public MongoDBContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };

                    var mongoClient = new MongoClient(settings);
                    Database = mongoClient.GetDatabase(DatabaseName);
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar");
            }
        }

        public IMongoCollection<SearchedResult> SearchedResult
        {
            get
            {
                return Database.GetCollection<SearchedResult>("SearchedResult");
            }
        }
    }
}