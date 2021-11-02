
using System;
using System.ComponentModel.DataAnnotations;

namespace FINAL_6013532.Models{

    public class Human{
        [Key]
        public int ID {get;set;} //this will be primary key
        public string Name {get;set;}
        public string Surrname {get;set;}
        public int height {get;set;}
        public int weight {get;set;}


       

       
    }//end of product class
}//end of namespace 