using GraphQL.Types;

namespace graphQLNetExample.Models
{
    public class NotesSchema : Schema
    {
        public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<NotesQuery>();
        }
    }
}
