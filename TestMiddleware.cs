using Chapter18.Models;
namespace Chapter18 {
    public class TestMiddleware {
        private RequestDelegate nextDelegate;
        public TestMiddleware(RequestDelegate next) {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context, DataContext dataContext) {
            if (context.Request.Path == "/test") {
                await context.Response.WriteAsync(
                    $"There are {dataContext.Books.Count()} books\n");
                await context.Response.WriteAsync(
                    $"There are {dataContext.Classifications.Count()} classifications\n");
                await context.Response.WriteAsync(
                    $"There are {dataContext.Publishers.Count()} publishers\n");
            } else {
                await nextDelegate(context);
            }
        }
    }
}
