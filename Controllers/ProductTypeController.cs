using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FINAL_6013532.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using FINAL_6013532.Models;

namespace FINAL_6013532.Controllers{
    public class ProductTypeController : Controller{
        
        private productDbContext _context;
        private UserManager<AppUser> _userManager;

        public ProductTypeController(productDbContext context, UserManager<AppUser> userManager){
            _context = context;
            _userManager = userManager;

        }
        
        [Authorize(Roles="admin")]
        public async Task<IActionResult> Index(){
            try{
            var user = await _userManager.GetUserAsync(HttpContext.User);

                var result = await _context.ProductTypes
                              .Select(x=> new{
                                  typeId = x.productTypeId,
                                  typeName = x.productTypeName,
                              })
                               .ToListAsync();
            ViewBag.productTypes = result;                                              
            return View();
            }//end of try
            catch(Exception ex){
                return Json(new
                {
                    error = 1,
                    message = "true",
                    exception = ex.Message
                });
            }//end of catch
        }//end of function
        
        [HttpGet]
        public IActionResult Add(){
            return View();
        }//end of function

        [HttpPost]     
        public async Task<IActionResult> Add(ProductType types)
        {
               try{
                _context.Add(types);
                await _context.SaveChangesAsync();
                return Json( new {
                              error=0,
                              message = "yes"
                });
               }//end try
               catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception             
        }//end of add function

        //update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json( new {
                              error=1,
                              message = "no",
                              exception= " please define id, and error"                              
                    });
            } 

            var type = await _context.ProductTypes.FindAsync(id);
            
            if (type == null)
            {
                 return Json( new {
                              error=1,
                              message = "no",
                              exception= id.ToString() + " not found"
                    });
            }

             ViewBag.producttype = type;
            return View("edit");
        }//end first edit function that return view

        [HttpPost]
        public async Task<IActionResult> Edit(ProductType types)
        {
             try{
                 //this Products is the table with the reference in the DbContext
                _context.ProductTypes.Update(types);//save in memory
                await _context.SaveChangesAsync();//save and apply change in the db
                //entity framework core
                return Json( new {
                              error=-1,
                              message = "yes"
                });
               }//end try
               catch(Exception ex){
                    return Json( new {
                              error=1,
                              message = "yes",
                              exception = ex.Message
                    });
               }  //end Exception
        }//end of second edit function that will actually edit it

         [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type = await _context.ProductTypes
                //finc the one the user wish to delete
                //by using id as a key
                .FirstOrDefaultAsync(m => m.productTypeId == id);
            if (type == null)
            {
                return NotFound();
            }
            try{
            var that_type = await _context.ProductTypes.FindAsync(id);
            _context.ProductTypes.Remove(that_type);
            await _context.SaveChangesAsync();
            return Json( new {
                              error=-1,
                              message = "yes"
                });
            }//end of try
            catch(Exception ex){
                return Json( new {
                              error=1,
                              message = "yes",
                              exception = ex.Message
                    });
            }//end of catch 
            
        }//end function
    

    }//end of class
}//end of namespace