namespace class0706WebApplication1
{
    public static class FromThousandToTenThousandExtensions
    {
        public static IApplicationBuilder UseFromThousandToTenThousand(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromThousandToTenThousandMiddleware>();
        }
    }
}