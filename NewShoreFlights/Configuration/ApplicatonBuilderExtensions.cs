namespace NewShoreFlights.Configuration
{
    public static class ApplicatonBuilderExtensions
    {

        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
