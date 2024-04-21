
using Microsoft.Extensions.Configuration;

namespace CapaDatos
{
    public static class Connection
    {
        public static string ConnectionString() 
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root=builder.Build();
            var CN = root.GetConnectionString("DefaultConnection");
            return CN;
        
        }
    }
}
