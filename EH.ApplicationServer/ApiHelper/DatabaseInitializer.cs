using EH.Entities;
using System.Threading.Tasks;

namespace EH.ApplicationServer.ApiHelper
{
    public class DatabaseInitializer
    {
        public static async Task DatabaseInitialize(AppDbContext dbContext)
        {
            //Asynchronously ensures that the database for the context exists. If it exists,
            //no action is taken. If it does not exist then the database and all its schema
            //are created. If the database exists, then no effort is made to ensure it is compatible
            //with the model for this context.
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
