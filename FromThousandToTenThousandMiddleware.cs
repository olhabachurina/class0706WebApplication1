namespace class0706WebApplication1
{
    public class FromThousandToTenThousandMiddleware
    {
        private readonly RequestDelegate _next;

        public FromThousandToTenThousandMiddleware(RequestDelegate next)
        {
           this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (int.TryParse(context.Request.Query["number"], out int number))
            {
                number = Math.Abs(number);
                if (number < 1001 || number > 10000)
                {
                    await _next(context);
                }
                else
                {
                    string response = $@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333; background: linear-gradient(to right, #e0c3fc, #8ec5fc); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                    <marquee>
                        <h1><span style='color: blue;'>Your number is</span> {NumberToWordsHelper.ConvertToWords(number)}</h1>
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
            <body style='font-family: Arial, sans-serif; color: red; background: linear-gradient(to right, #e0c3fc, #8ec5fc); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
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