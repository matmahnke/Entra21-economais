using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BusinessLogicalLayer
{
    public class Base64Converter
    {
        public string ImageFileToBase64(string imageDirectory)
        {
            string base64ImageRepresentation = "";
            
                byte[] imageArray = System.IO.File.ReadAllBytes(@"" + imageDirectory);
                base64ImageRepresentation = Convert.ToBase64String(imageArray);
            

            return base64ImageRepresentation;
        }
        public Image Base64ToImage(string base64String)
        {
            Image image = null;
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                image = Image.FromStream(ms, true);
                return image;
            }
        }
        public string ImageToBase64(System.Drawing.Image image)
        {
            ImageConverter converter = new ImageConverter();
            byte[] imageArray = (byte[])converter.ConvertTo(image, typeof(byte[]));
            string base64 = Convert.ToBase64String(imageArray);
            return base64;
        }
    }
}
