namespace NestedListSample.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using NestedListSample.Models;

    public partial class NestedListSampleDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        public NestedListSampleDbContext()
            : base("name=NestedListSampleDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
