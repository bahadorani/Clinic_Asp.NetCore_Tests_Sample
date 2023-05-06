using BoDi;
using Clinic.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TechTalk.SpecFlow;

namespace Client.AcceptanceTest
{
    [Binding]
    public class ClinickHooks
    {
        private readonly IObjectContainer _objectContainer;

        public ClinickHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void RegisterServices()
        {
            var factory = GetWebApplicationFactory();
            _objectContainer.RegisterInstanceAs(factory);
        }

        private WebApplicationFactory<Program> GetWebApplicationFactory() =>
               new WebApplicationFactory<Program>()
                   .WithWebHostBuilder(builder =>
                   {
                       builder.ConfigureServices(services =>
                       {
                           var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ProjectContext>));
                           services.Remove(descriptor);
                           services.AddDbContext<ProjectContext>(options =>
                           {
                               options.UseInMemoryDatabase("InMemoryDbForTesting");
                           });
                       });
                   });

    }
}