using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//extension library is to create function in the library
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using FINAL_6013532.Data;
using FINAL_6013532.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;

//each of CRUD operation should have two function that respond to the call
//one is the httpget to make the user get the view
//sedond is the post function to alter the data 
//when the data is altered, it is normally that it will react with the UI
//to show the recent data

namespace FINAL_6013532.Controllers
{
    public class ProductController : Controller
    {
        private readonly productDbContext _context;
        private UserManager<AppUser> _UserManager;

        public ProductController(productDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _UserManager = userManager;
        }

        //every function is imported manually without tool

        [Authorize]
        
        public async Task<IActionResult> Index()
        {
            try
            {
                var user = await _UserManager.GetUserAsync(HttpContext.User);//make this to be an object
                bool IamAdmin = await _UserManager.IsInRoleAsync(user, "admin");
                bool IamManager = await _UserManager.IsInRoleAsync(user, "manager");
                bool IamUser = await _UserManager.IsInRoleAsync(user, "user");

                /*.Join( _context.ProductTypes,
                                                i => i.productID,
                                                r => r.productTypeId,
                                                (i,r) => new
                                                {
                                                    i.productID,
                                                    name = i.productName,
                                                    i.qty,
                                                    i.price,
                                                    typeName = r.productTypeName,
                                                }                                                    
                                                )*/

                if (IamAdmin)
                {

                    var result = await _context.Products
                                                .Select(x => new
                                                {
                                                    x.productID,
                                                    name = x.productName,
                                                    x.qty,
                                                    x.price,
                                                    typeId = x.productTypeId,
                                                    typeName = x._type.productTypeName,
                                                })
                                                .ToListAsync();
                    ViewBag.products = result;
                    //Item
                    return View("AdminView");
                }//end of if
                else if (IamManager)
                {
                    var result = await _context.Products
                                                //these following attributes will be put in the form of array
                                                //so the name must be consistent 
                                                //so that when the client side pick up and raw and serialize to see
                                                //it as json and then
                                                //it will be the same variable name
                                                .Select(x => new
                                                {
                                                    x.productID,
                                                    name = x.productName,
                                                    x.qty,
                                                    x.price,
                                                    typeId = x.productTypeId,
                                                    typeName = x._type.productTypeName,
                                                })
                                                .ToListAsync();
                    ViewBag.products = result;
                    return View("ManagerView");
                }//end of else if
                else if (IamUser)
                {

                    var result = await _context.Products
                                                 .Select(x => new
                                                 {
                                                     x.productID,
                                                     name = x.productName,
                                                     qty = x.qty,
                                                     price = x.price,
                                                     typeId = x.productTypeId,
                                                     typeName = x._type.productTypeName,
                                                 })
                                                 .ToListAsync();
                    ViewBag.products = result;
                    return View("UserView");
                }//end of else if
                else
                {
                    return View("Error");
                }//end of else
            }//end of try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "true",
                    exception = ex.Message
                });
            }//end of exception

        }//end of index function

        [Authorize(Roles = "manager")]
        [HttpGet]
        public IActionResult importView()
        {
            return View("ImportView");
        }//end of function import excel for manager

        [HttpPost]
        //IFormFile is the datatype from Microsoft.AspNetCore.Http library;
        public async Task<IActionResult> import1(IFormFile file1)
        {
            //copy the file to the memory and use epplus to work with it content
            //save the content to the database      
            /*var obj = new {
                file1.FileName,
                file1.Length,
            };
            return Json(obj);*/

            //this will be the empty list in the first time
            //it will be used to add product in
            //then add this list into the database
            List<Product> list1 = new List<Product>();

            //empty table 
            /*
            _context.Products.RemoveRange(_context.Products);
            await _context.SaveChangesAsync();//applying to physical database
            //reseting the auto index of the product table
            //don't forget to check the sql statement here
            await _context.Database.ExecuteSqlCommandAsync("ALTER TABLE Products AUTO_INCREMENT = 1");
            */

            //look up for product type
            var lookup = await _context.ProductTypes.ToDictionaryAsync(u => u.productTypeName);

            //we want to make sure that the memory stream is not overflow by using using()
            using (var stream = new MemoryStream())
            {
                //stream is the empty object that reserve for file1 parameter // by copying
                await file1.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    //the one we want to work with
                    //worksheet[] is the function for selecting worksheet starting from 0
                    ExcelWorksheet wk = package.Workbook.Worksheets[0];
                    //get how many line
                    int lines = wk.Dimension.Rows;
                    // i is the line that we want to start working with
                    // line number 1 start with number 1
                    // I want to start working with second line so I put 2
                    for (int i = 2; i <= lines; i++)
                    {
                        //Cells[row,col]
                        string product_name = wk.Cells[i, 2].Value.ToString().Trim();
                        string product_qty = wk.Cells[i, 3].Value.ToString().Trim();
                        string product_price = wk.Cells[i, 4].Value.ToString().Trim();
                        string product_type = wk.Cells[i, 5].Value.ToString().Trim();

                        //create an object that represent a new row in product table
                        Product p = new Product()
                        {
                            productName = product_name,
                            qty = int.Parse(product_qty),
                            price = double.Parse(product_price),
                            productTypeId = lookup[product_type].productTypeId //this function will return the object that match
                            //int.Parse() will convert string number into integer
                            //double.Parse() will convert string number into integer
                            //we have to make it become string above just to be able
                            //to extract them
                        };//end of p object
                        list1.Add(p);
                    }//end of for looping
                }//end of inner using
                //now it is the time to sae the list into the table product type
                //this is the faster way // Async is one of the reason
                await _context.Products.AddRangeAsync(list1);
                await _context.SaveChangesAsync(); //savechangeasync is to actually save it into database
                return Json(new
                {
                    error = -1,
                    msg = "import succeeded"
                });
            }//end of outter using

        }//end of import function


        //get will be called by using url parameter
        //and the system will put httpget by auto (with IactionResult)
        //post will be called by using javascript $.post (jquery)

        //it always be get with the url in the top of browser
        [HttpGet]
        public IActionResult Add()
        {
            //this is to custom the queries from fk data table
            ViewBag.productTypes = _context.ProductTypes.Select(
                x => new { x.productTypeId, x.productTypeName }
            );
            return View();
        }//end of function

        [HttpPost]
        public async Task<IActionResult> Add(Product products)
        {
            try
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return Json(new
                {
                    error = 0,
                    message = "yes"
                });
            }//end try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }  //end Exception             
        }//end of add function


        //Asp .netcore always take parameter name id as a default parameter
        //when there is no actual parameter name
        //however we can still pass parameter name using the following

        // /product/edit?productID=1
        //then pick up productID instead of int? id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Json(new
                {
                    error = 1,
                    message = "no",
                    exception = " please define id, and error"
                });
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return Json(new
                {
                    error = 1,
                    message = "no",
                    exception = id.ToString() + " not found"
                });
            }
            var productTypes = _context.ProductTypes.Select(x => new { x.productTypeId, x.productTypeName });
            ViewBag.productTypes = productTypes;
            ViewBag.select_productType = await productTypes.FirstOrDefaultAsync(
                x => x.productTypeId == product.productTypeId
            );

            ViewBag.product = product;
            return View("Edit");
        }//end first edit function that return view

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            try
            {
                //this Products is the table with the reference in the DbContext

                _context.Products.Update(product);//save in memory
                await _context.SaveChangesAsync();//save and apply change in the db
                //entity framework core
                return Json(new
                {
                    error = -1,
                    message = "yes",
                    just = "totest"
                });
            }//end try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }  //end Exception
        }//end of second edit function that will actually edit it

        [Authorize(Roles = "user")]
        [HttpPost]

        public async Task<IActionResult> edit_byUser(int? id)
        {
            try
            {
               
                    _context.Products.Select(x => new
                    {

                    });
                    return Json(new
                    {
                        error = -1,
                        message = "yes"
                    });
    
            }//end of try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }//end of catch
        }//end of function


        // GET: product/Delete/1
        //      product/delete/productID
        //this is to get the url for delete function
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                //find the one the user wish to delete
                //by using id as a key
                .FirstOrDefaultAsync(m => m.productID == id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                var that_product = await _context.Products.FindAsync(id);
                _context.Products.Remove(that_product);
                await _context.SaveChangesAsync();
                return Json(new
                {
                    error = -1,
                    message = "yes"
                });
            }//end of try
            catch (Exception ex)
            {
                return Json(new
                {
                    error = 1,
                    message = "yes",
                    exception = ex.Message
                });
            }

        }//end function

    }//end of class
}//end of namespace