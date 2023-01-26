using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Classes
{
    public class ImageDetails
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public ImageDetails() { }

        public ImageDetails(string name, string url)
        {
            Name = name; Url = url;
        }
    }

    public class Model
    {
        public List<ImageDetails> ImageSources { get; set; }

        public Model()
        {
            ImageSources = new List<ImageDetails>
            {
                new ImageDetails("Tiger", "https://cdn.britannica.com/85/91385-050-D878D588/Siberian-tiger.jpg"),
                new ImageDetails("Onion", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/1200px-Onion_on_White.JPG"),
                new ImageDetails("Boot", "https://www.shutterstock.com/image-photo/old-boot-over-white-260nw-85797763.jpg"),
                new ImageDetails("Carburettor", "https://www.howacarworks.com/illustration/870/an-su-carburettor.png")
            };
        }
    }
}
