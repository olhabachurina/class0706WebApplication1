namespace class0706WebApplication1
{
    public class FromOneToTenMiddleware
    {
        private readonly RequestDelegate _next;

        public FromOneToTenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];// Получим число из контекста запроса
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);
                string response;

                if (number == 10)
                {
                    // Выдаем окончательный ответ клиенту
                    response = "Your number is ten";
                }
                else
                {
                    string[] Ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                    // Любые числа больше 20, но не кратные 10
                    if (number > 20)
                    {
                        // Записываем в сессионную переменную number результат для компонента FromTwentyToHundredMiddleware
                        context.Session.SetString("number", Ones[number % 10 - 1]);
                        await _next(context); 
                        return;
                    }
                    else
                    {  // Выдаем окончательный ответ клиенту
                        response = "Your number is " + Ones[number - 1];// от 1 до 9
                    }
                }

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync($@"
            <html>
            <body style='font-family: Arial, sans-serif; color: #333; background: linear-gradient(to right, #ff7e5f, #feb47b); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                <marquee>
                    <h1>{response}</h1>
                </marquee>
            </body>
            </html>");
            }
            catch (Exception)
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(@"
            <html>
            <body style='font-family: Arial, sans-serif; color: red; background: linear-gradient(to right, #ff7e5f, #feb47b); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                <marquee>
                    <h1>Incorrect parameter</h1>
                </marquee>
            </body>
            </html>");
            }
        }
    }
}