using FINAL_6013532.Data;
using FINAL_6013532.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FINAL_6013532.Data{

    public class productDbContext : IdentityDbContext<AppUser,AppRole,string>{

        public productDbContext(DbContextOptions<productDbContext> options):base(options){

        }//end of function //this is the first function that middle man must have 

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }//end of second function that middle man must have 
        
        public DbSet<AppUser> AppUsers {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductType> ProductTypes {get;set;}
        


    }//end of class
}//end of namespace 