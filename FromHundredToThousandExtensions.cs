namespace class0706WebApplication1
{
    public static class FromHundredToThousandExtensions
    {
        public static IApplicationBuilder UseFromHundredToThousand(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromHundredToThousandMiddleware>();
        }
    }
}
