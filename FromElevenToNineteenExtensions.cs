namespace class0706WebApplication1
{
    public static class FromElevenToNineteenExtensions
    {
        public static IApplicationBuilder UseFromElevenToNineteen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromElevenToNineteenMiddleware>();
        }
    }
}
