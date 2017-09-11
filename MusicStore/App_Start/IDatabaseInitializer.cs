using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.App_Start
{
    public interface IDatabaseInitializer<in TContext> where TContext : global::System.Data.Entity.DbContext
    {
        // Summary:
        //     Executes the strategy to initialize the database for the given context.
        // Parameters:
        //   context: The context.
        void InitializeDatabase(TContext context);
    }
}