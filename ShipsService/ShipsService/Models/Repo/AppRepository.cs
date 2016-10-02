using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipsService.Models.Repo
{

    interface IRepository
    {
        ApplicationDbContext Context { get; set; }        
    }

    public class AppRepository : IDisposable, IRepository
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public AppRepository()
        {

        }

        public ApplicationDbContext Context
        {
            get { return db; }
            set { db = value; }
        }

        public void Dispose()
        {
            
        }
        // определение методов
    }
}