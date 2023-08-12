
using learn_specification.interfaces;

namespace learn_specification.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<ITagsService, TagsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            return services;
        }
    }
}