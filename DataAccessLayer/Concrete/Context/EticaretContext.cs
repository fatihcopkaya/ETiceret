using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccessLayer.Concrete.Context
{
    public class EticaretContext : DbContext
    {
       
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnetDeveloper = "server=localhost;port=3306;database=Eticaret;user=root;password=123456;Charset=utf8;";
         
            optionsBuilder.UseLazyLoadingProxies()
                .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings =>
                {
                    warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
                });
        }
        
    }
}