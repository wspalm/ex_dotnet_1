using Microsoft.AspNetCore.Identity;

namespace FINAL_6013532.Data{

    public class AppRole:IdentityRole{
 
        public AppRole(string Name):base(Name){}
        
    }
}