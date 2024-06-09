namespace class0706WebApplication1
{
    public class FromHundredToThousandMiddleware
    {
        private readonly RequestDelegate _next;

        public FromHundredToThousandMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"]; // Получаем число из параметров запроса
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number); 

                if (number < 101)
                {
                    await _next.Invoke(context); // Передаем запрос следующему компоненту middleware
                }
                else if (number > 1000)
                {
                    // Отправляем клиенту текстовый ответ
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Number greater than one thousand");
                }
                else
                {
                    // Формируем HTML-ответ с текстом
                    string response = $@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333; background: linear-gradient(to right, #89f7fe, #66a6ff); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                    <marquee>
                        <h1><span style='color: blue;'>Your number is {NumberToWordsHelper.ConvertToWords(number)}</span></h1>
                    </marquee>
                </body>
                </html>";

                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(response);
                }
            }
            catch (Exception)
            {
                // Отправляем HTML-ответ с сообщением об ошибке
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(@"
            <html>
            <body style='font-family: Arial, sans-serif; color: red; background: linear-gradient(to right, #89f7fe, #66a6ff); padding: 20px; border: 1px solid #ccc; border-radius: 10px;'>
                <marquee>
                    <h1>Incorrect parameter</h1>
                </marquee>
            </body>
            </html>");
            }
        }
    }
}