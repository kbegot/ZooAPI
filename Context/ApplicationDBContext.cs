using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;

namespace ZooAPI.Context
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {

        }
        public DbSet<Animal> Animals {get; set;}
        public DbSet<Meal> Meals {get; set;}
        public DbSet<Menu> Menus {get; set;}
        public DbSet<Food> Foods {get; set;}
        public DbSet<Provider> Providers {get; set;}
        public DbSet<MenuFood> MenuFoods {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ZooAPI.Entities.Food>()
                .HasOne(f => f.Provider)
                .WithMany(p => p.Foods)
                .HasForeignKey(f => f.ProviderId);

            modelBuilder.Entity<ZooAPI.Entities.MenuFood>()
                .HasKey(mf => new {mf.FoodId, mf.MenuId});

            modelBuilder.Entity<MenuFood>()
                .HasOne (mf => mf.Food)   
                .WithMany(f => f.MenuFoods)
                .HasForeignKey(mf => mf.FoodId);  
                
            modelBuilder.Entity<MenuFood>()
                .HasOne (mf => mf.Menu)   
                .WithMany(me => me.MenuFoods)
                .HasForeignKey(mf => mf.MenuId);         
        }

    }
}
