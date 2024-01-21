using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Server.Services
{
    public static class DbService
    {
        public static void MigrationApplicantion(IApplicationBuilder app)
        {
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    serviceScope.ServiceProvider.GetService<BlazorProjectAPIDbContext>().Database.Migrate();
            //}
        }
    }
}
