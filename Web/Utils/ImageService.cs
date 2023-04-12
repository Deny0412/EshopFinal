using Microsoft.Extensions.Hosting;
using Web.Models;

namespace Web.Utils
{
    public class ImageService : IDisposable
    {
        private readonly MyContext _context;

        private readonly IWebHostEnvironment _hostEnvironment;
        public ImageService(MyContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        //pri pouzivani using () {} se po ukonceni vyvola metoda dispose
        public void Dispose()
        {
            _context.SaveChanges();
        }

        public void Upload(Product product, IList<IFormFile> listImages)
        {
            foreach (IFormFile img in listImages)
            {
                Upload(product, img,2);
            }
        }

        public void Upload(Product product, IFormFile img,int priority)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (img == null)
            {
                return;
            }
            List<Image> images = _context.Images.ToList();
            if (priority==1)
            {
                foreach (Image item in images)
                {
                    if (item.product_id == product.id && item.priority == 1)
                    {
                        _context.Images.Remove(item);
                        string delete = wwwRootPath + item.path;
                        System.IO.File.Delete(delete);
                    }
                    
                }
            }
            if (priority==2)
            {

            }
            
            
            
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(wwwRootPath, @"images\products\");
            var extension = Path.GetExtension(img.FileName);

            using (Stream stream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                img.CopyTo(stream);
            }
            Image image = new Image
            {
                id = 0,
                product_id = product.id,
                path = @"\images\products\" + fileName + extension,
                priority = priority,
            };

            _context.Images.Add(image);
        }
    }
}
