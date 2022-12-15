using Microsoft.EntityFrameworkCore;
using MinerAPP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Users> Users { get; set; }
        public DbSet<UsersLogins> UsersLogins{ get; set; }
        public DbSet<StaticDictionaries> StaticDictionaries{ get; set; }
        public DbSet<Transactions> Transactions{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Users sina = new Users { Id = Guid.NewGuid(), Name = "Sina", Family = "Jouybari", Cellphone = "00989394125130", Email="sarparast_r@yahoo.com", Username = "sinful", ProfileMediaURL = "uploads/2022/9/sina2.jpg", WalletAddress="TJ12333333333333323333333333333333" };
            //Users mohsen = new Users { Id = Guid.NewGuid(), Name = "محسن", Family = "پردلان", Cellphone = "00989111769591", Username = "vinona", Email="vinona@yahoo.com", ProfileMediaURL = "uploads/2022/9/99.jpg" };
            //Users sepideh = new Users { Id = Guid.NewGuid(), Name = "سپیده", Family = "یاراحمدی", Cellphone = "00989166666666", Username = "sepideh", Email="sep@yahoo.com", ProfileMediaURL = "uploads/2022/9/photo.jpg" };
            modelBuilder.Entity<Users>().HasData(sina);
            //modelBuilder.Entity<Users>().HasData(mohsen);
            //modelBuilder.Entity<Users>().HasData(sepideh);


            StaticDictionaries theQR = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "theqr", TheValue = "https://localhost:7249/images/sina.jpg" };
            StaticDictionaries theWallet = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "thewallet", TheValue = "TJ1000000000000000000000000000000" };
            StaticDictionaries inviterReward = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "inviterreward", TheValue = "0.1" };
            StaticDictionaries depositHelp = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "deposithelp", TheValue = "Deposit Helpppppppppppppppppp" };
            StaticDictionaries withdrawHelp = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "withdrawhelp", TheValue = "Withdraw Helpppppppppppppppppp" };
            StaticDictionaries transactionHelp = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "transactionhelp", TheValue = "Transaction Helpppppppppppppppppp" };
            StaticDictionaries accountHelp = new StaticDictionaries { Id = Guid.NewGuid(), TheName = "accounthelp", TheValue = "Account Helpppppppppppppppppp" };

            modelBuilder.Entity<StaticDictionaries>().HasData(theQR);
            modelBuilder.Entity<StaticDictionaries>().HasData(theWallet);
            modelBuilder.Entity<StaticDictionaries>().HasData(inviterReward);
            modelBuilder.Entity<StaticDictionaries>().HasData(depositHelp);
            modelBuilder.Entity<StaticDictionaries>().HasData(withdrawHelp);
            modelBuilder.Entity<StaticDictionaries>().HasData(transactionHelp);
            modelBuilder.Entity<StaticDictionaries>().HasData(accountHelp);
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=1,Owner=sina, Caption="کیش کدپولو", Name="کیش", IsVideo=true, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-56192-4_6008031941360618419.MP4"});
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=2,Owner=mohsen, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-53754-1.mp4_snapshot_01.04_[2022.05.26_09.50.52].jpg" });
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=3,Owner=sepideh, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1582619178545.jpg" });
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=4,Owner=sina, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-36433-1.jpg" });


        }
    }
}
