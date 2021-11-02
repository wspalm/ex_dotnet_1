

using System;
using System.ComponentModel.DataAnnotations;

namespace FINAL_6013532.Models{

    public class ProductType {
        [Key]
        public int productTypeId {get;set;}        
        public string productTypeName {get;set;}

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        //public List<Destination> destination {get;set;}
    }//end of producttype class
}//end of namespace