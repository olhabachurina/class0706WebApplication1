namespace class0706WebApplication1
{
    public class FromTenThousandToHundredThousandMiddleware
    {
        private readonly RequestDelegate _next;

        public FromTenThousandToHundredThousandMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (int.TryParse(context.Request.Query["number"], out int number))
            {
                number = Math.Abs(number);
                if (number < 10001 || number > 100000)
                {
                    await _next(context);
                }
                else
                {
                    string response = $@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333; background: linear-gradient(to right, #f3e5ab, #e6c68b); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                    <marquee>
                        <h1><span style='color: blue;'>Your number is {NumberToWordsHelper.ConvertToWords(number)}</span></h1>
                    </marquee>
                </body>
                </html>";
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(response);
                }
            }
            else
            {
                string response = @"
            <html>
            <body style='font-family: Arial, sans-serif; color: red; background: linear-gradient(to right, #f3e5ab, #e6c68b); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                <marquee>
                    <h1>Incorrect parameter</h1>
                </marquee>
            </body>
            </html>";
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(response);
            }
        }
    }
}