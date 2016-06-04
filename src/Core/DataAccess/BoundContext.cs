namespace Shoppers.Core.DataAccess
{
    using Microsoft.EntityFrameworkCore;

    public class BoundContext<TContext> : DbContext
        where TContext : DbContext
    {
        
    }
}