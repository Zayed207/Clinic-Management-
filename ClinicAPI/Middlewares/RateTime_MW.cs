namespace ClinicAPI.Middlewares
{
    public class RateTime_MW
    {

       
            public static ushort Counter = 0;
            public static DateTime _lastDate = DateTime.Now;
            private RequestDelegate _next;

            public RateTime_MW(RequestDelegate next)
            {
                _next = next;
            }

        

            public async Task Invoke(HttpContext context)
            {

                ++Counter;
                if (DateTime.Now.Subtract(_lastDate).Seconds > 10)
                {

                    Counter = 1;
                    _lastDate = DateTime.Now;
                    await _next(context);

                }
                else
                {

                    if (Counter > 5)
                    {
                        await context.Response.WriteAsync("Ya da33ef");
                    }
                }
            }
        }
    
}
