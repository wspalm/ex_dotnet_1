
using System;
using System.ComponentModel.DataAnnotations;

namespace FINAL_6013532.Models{

    public class Product{
        [Key]
        public int productID {get;set;} //this will be primary key
        public string productName {get;set;}
        public int qty {get;set;}
        public double price {get;set;}


        public int productTypeId {get;set;}
        public ProductType _type {get;set;} //this is to do the two inter related data

       
    }//end of product class
}//end of namespace 