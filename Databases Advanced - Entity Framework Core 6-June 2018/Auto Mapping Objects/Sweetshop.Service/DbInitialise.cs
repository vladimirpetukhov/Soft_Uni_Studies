namespace Sweetshop.Service
{
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Contracts;

    public class DbInitialise:IDbInitialise
    {
        private readonly SweetshopContext sweetshopContext;

        public DbInitialise(SweetshopContext context)
        {
            sweetshopContext = context;
        }

        public void InitialiseDb()
        {
            sweetshopContext.Database.Migrate();
        }
    }
}
