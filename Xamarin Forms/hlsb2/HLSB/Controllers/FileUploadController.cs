using HLSB.DAL;
using HLSB.Models;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HLSB.Controllers
{
    public class FileUploadController : ApiController
    {
        private HlsbContext db = new HlsbContext();

        [System.Web.Http.HttpPost]
        // api/FileUpload/1 --> to process user form
        // api/FileUpload/2 --> to process product form
        public async Task<IHttpActionResult> ProcessForm(long id)
        {
            if (id == 1)
            {
                var userId = HttpContext.Current.Request.Form["userId"];
                var firstName = HttpContext.Current.Request.Form["firstName"];
                var lastName =HttpContext.Current.Request.Form["lastName"];
                var surName = HttpContext.Current.Request.Form["surname"];
                var emailAddress = HttpContext.Current.Request.Form["emailAddress"];
                var password = HttpContext.Current.Request.Form["password"];
                var isActive = HttpContext.Current.Request.Form["isActive"];
                var image = HttpContext.Current.Request.Files["image"];                

                //Edit
                if (!String.IsNullOrEmpty(userId) && !String.IsNullOrWhiteSpace(userId))
                {
                    byte[] profilePicture = null;
                    if (image != null)
                    {

                        using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files["image"].InputStream))
                        {
                            profilePicture = binaryReader.ReadBytes(HttpContext.Current.Request.Files["image"].ContentLength);
                        }
                    }
                    var usrId = long.Parse(userId);

                    var usrImg = await db.Users
                        .Where(x => x.UserId == usrId)
                        .FirstOrDefaultAsync();

                    User user = new User
                    {
                        UserId = usrId,
                        FirstName = firstName,
                        LastName = lastName,
                        Surname = surName,
                        EmailAddress = emailAddress,
                        Password = password,
                        IsActive = bool.Parse(isActive),
                        ProfilePicture = profilePicture ?? usrImg?.ProfilePicture
                    };

                    await new UsersViewController().Edit(user);
                  
                   return Ok();
                    
                }

                //Create
                if (String.IsNullOrEmpty(userId) || String.IsNullOrWhiteSpace(userId))
                {
                    byte[] profilePicture = null;
                    using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files["image"].InputStream))
                    {
                        profilePicture = binaryReader.ReadBytes(HttpContext.Current.Request.Files["image"].ContentLength);
                    }

                    User user = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Surname = surName,
                        EmailAddress = emailAddress,
                        Password = password,
                        IsActive = bool.Parse(isActive),
                        ProfilePicture = profilePicture
                    };

                    await new UsersViewController().Create(user);

                    return Ok();

                }
            }

            if (id == 2 )
            {
                var productId = HttpContext.Current.Request.Form["productId"];
                var productName = HttpContext.Current.Request.Form["productName"];
                var productDetail = HttpContext.Current.Request.Form["productDetail"];
                var productPrice = HttpContext.Current.Request.Form["productPrice"];
                var image = HttpContext.Current.Request.Files["image"];

                //Edit
                if (!String.IsNullOrEmpty(productId) && !String.IsNullOrWhiteSpace(productId))
                {
                    byte[] productPicture = null;

                    if (image != null)
                    {
                        
                        using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files["image"].InputStream))
                        {
                            productPicture = binaryReader.ReadBytes(HttpContext.Current.Request.Files["image"].ContentLength);
                        }
                    }

                    var prodId = long.Parse(productId);

                    var prodImg = await db.Products
                        .Where(x => x.ProductId == prodId)
                        .FirstOrDefaultAsync();

                    Product product = new Product
                    {
                        ProductId = prodId,
                        ProductName = productName,
                        ProductDetail = productDetail,
                        ProductPrice = String.IsNullOrEmpty(productPrice) ? 0 : double.Parse(productPrice),
                        ProductImage = productPicture ?? prodImg?.ProductImage
                    };

                    await new ProductsViewController().Edit(product);

                    return Ok();

                }

                //Create
                if (String.IsNullOrEmpty(productId) || String.IsNullOrWhiteSpace(productId))
                {
                    byte[] productPicture = null;
                    using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files["image"].InputStream))
                    {
                        productPicture = binaryReader.ReadBytes(HttpContext.Current.Request.Files["image"].ContentLength);
                    }

                    Product product = new Product
                    {
                        ProductName = productName,
                        ProductDetail = productDetail,
                        ProductPrice = double.Parse(productPrice),
                        ProductImage = productPicture
                    };

                    await new ProductsViewController().Create(product);

                    return Ok();
                }
            }

            return BadRequest();
        }

    }
}