using EF014.CreateDropAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EF014.CreateDropAPI
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Database will be created if it does not exist
                await context.Database.EnsureCreatedAsync();

                var sqlScript = context.Database.GenerateCreateScript();

                await Task.Delay(30000);

                // Database will be deleted if it does exist
                await context.Database.EnsureDeletedAsync();
            }
        }
    }
}

