using Microsoft.AspNetCore.Identity;

namespace FINAL_6013532.Data{

    public class AppUser:IdentityUser{

        public string first_name {get;set;}
        public string last_name {get;set;}
        
        
        
    }//end of class
}//end of namespace