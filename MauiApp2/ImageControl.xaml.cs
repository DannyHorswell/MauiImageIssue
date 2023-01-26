using MauiApp2.Classes;
using System.Net;

namespace MauiApp2;

public partial class ImageControl : ContentView
{
	public ImageControl()
	{
        this.BindingContextChanged += ImageControl_BindingContextChanged;   
		InitializeComponent();
    }

    private void ImageControl_BindingContextChanged(object sender, EventArgs args)
    {
        var control = sender as ImageControl;
        var imageDetails = this.BindingContext as ImageDetails;

        #region load the local image into a memory stream
        FileName.Text = imageDetails.Name;
        var imageLocalFileLocation = ImageLocalAbsoluteLocation(imageDetails);

        var fs = File.OpenRead(imageLocalFileLocation);

        var byteArray = ReadStreamToByteArray(fs);
        var stream = new MemoryStream(byteArray);
        var imageSource = ImageSource.FromStream(() => stream);

        fs.Close();
        #endregion

        control.TheImage.Source = imageSource;
    }

    #region Helpers
    public static byte[] ReadStreamToByteArray(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];

        using (var ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }

    public static string ImageLocalAbsoluteLocation(ImageDetails image)
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{image.Name}");
    }
    #endregion

}

