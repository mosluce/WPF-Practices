using ListSample.Data;
using ListSample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ListSample
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = new ListSampleDbContext())
            {

                if (db.Products.Count() == 0) { 
                    db.Products.Add(new Product
                    {
                        Name = "牛奶",
                        Price = 500
                    });

                    db.Products.Add(new Product
                    {
                        Name = "可樂",
                        Price = 30
                    });

                    db.Products.Add(new Product
                    {
                        Name = "麵包",
                        Price = 25
                    });

                    db.SaveChanges();
                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
