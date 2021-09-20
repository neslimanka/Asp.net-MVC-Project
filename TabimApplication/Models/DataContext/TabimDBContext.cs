
using TabimApplication.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TabimApplication.Models.DataContext
{
    public class TabimDBContext : DbContext
    {
        public TabimDBContext() : base("TabimDB") 
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestState> RequestState { get; set; }
        public DbSet<Contact> Contact { get; set; }
       
       


    }



}