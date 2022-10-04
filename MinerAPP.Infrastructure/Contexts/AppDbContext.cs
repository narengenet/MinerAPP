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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Users sina = new Users { Id = Guid.NewGuid(), Name = "Sina", Family = "Jouybari", Cellphone = "09394125130", Username = "sinful", ProfileMediaURL = "uploads/2022/9/sina2.jpg" };
            Users mohsen = new Users { Id = Guid.NewGuid(), Name = "محسن", Family = "پردلان", Cellphone = "09111769591", Username = "vinona", ProfileMediaURL = "uploads/2022/9/99.jpg" };
            Users sepideh = new Users { Id = Guid.NewGuid(), Name = "سپیده", Family = "یاراحمدی", Cellphone = "09163681249", Username = "sepideh", ProfileMediaURL = "uploads/2022/9/photo.jpg" };
            modelBuilder.Entity<Users>().HasData(sina);
            modelBuilder.Entity<Users>().HasData(mohsen);
            modelBuilder.Entity<Users>().HasData(sepideh);
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=1,Owner=sina, Caption="کیش کدپولو", Name="کیش", IsVideo=true, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-56192-4_6008031941360618419.MP4"});
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=2,Owner=mohsen, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-53754-1.mp4_snapshot_01.04_[2022.05.26_09.50.52].jpg" });
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=3,Owner=sepideh, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1582619178545.jpg" });
            //modelBuilder.Entity<Advertise>().HasData(new Advertise { AdvertiseID=4,Owner=sina, Caption="کیش کدپولو", Name="کیش", IsVideo=false, LikeReward=2, ViewReward=4, ViewQuota=100, RemainedViewQuota=100, MediaSourceURL= "uploads/2022/9/1-36433-1.jpg" });


        }
    }
}
