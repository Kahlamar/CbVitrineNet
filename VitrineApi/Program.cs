
namespace VitrineApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "D�marrage Microservice OK");

            app.Run();
        }
    }
}
