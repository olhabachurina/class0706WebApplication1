namespace class0706WebApplication1
{
    public class FromTwentyToHundredMiddleware
    {
        private readonly RequestDelegate _next;

        public FromTwentyToHundredMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"]; // Получим число из контекста запроса
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);

                if (number < 20)
                {
                    await _next.Invoke(context); // Контекст запроса передаем следующему компоненту
                }
                else if (number > 100)
                {
                    // Выдаем окончательный ответ клиенту
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Number greater than one hundred");
                }
                else if (number == 100)
                {
                    // Выдаем окончательный ответ клиенту
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Your number is one hundred");
                }
                else if (number == 20)
                {
                    // Выдаем окончательный ответ клиенту
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Your number is twenty");
                }
                else
                {
                    string[] Tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                    if (number % 10 == 0)
                    {
                        // Выдаем окончательный ответ клиенту
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("Your number is " + Tens[number / 10 - 2]);
                    }
                    else
                    {
                        await _next.Invoke(context); // Контекст запроса передаем следующему компоненту
                        string? result = context.Session.GetString("number"); // Получим число от компонента FromOneToTenMiddleware

                        // Выдаем окончательный ответ клиенту
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync($@"
                    <html>
                    <body style='font-family: Arial, sans-serif; color: #333; background: linear-gradient(to right, #f7e99e, #f1c40f); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                        <marquee>
                            <h1><span style='color: blue;'>Your number is {Tens[number / 10 - 2]} {result}</span></h1>
                        </marquee>
                    </body>
                    </html>");
                    }
                }
            }
            catch (Exception)
            {
                // Выдаем окончательный ответ клиенту
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(@"
            <html>
            <body style='font-family: Arial, sans-serif; color: red; background: linear-gradient(to right, #f7e99e, #f1c40f); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                <marquee>
                    <h1>Incorrect parameter</h1>
                </marquee>
            </body>
           </html>");
            }
        }
    }
}