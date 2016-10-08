using System.Data.Entity;
using Domain.Entities;


namespace Domain
{
    public class TutorialEfDbContext:DbContext
    {
        // base("TutorialEfDbContext") is very important,because the string "TutorialEfDbContext" in it must be the same as connectionStrings name in the config file 
        public TutorialEfDbContext():base("TutorialEfDbContext")
        {
            Configuration.ProxyCreationEnabled = false; //disable proxy
            Configuration.LazyLoadingEnabled = false; //disable lazy load
        }

        //When you want to implement the entity into sql sever as a table, you need to add the Model as property in DbContext
        public DbSet<Student> Student { get; set; }
    }
}
