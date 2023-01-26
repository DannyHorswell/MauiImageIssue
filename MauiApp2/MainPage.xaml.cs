using MauiApp2.Classes;
using System.Net;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
    HttpClient _httpClient = new HttpClient();
    Random random = new Random();

    int timesClicked = 0;

    bool imagesDownloaded = false;

    public MainPage()
	{
        InitializeComponent();

        this.BindingContext = MauiProgram.AppModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Make sure we have all images stored locally
        if (!imagesDownloaded)
        {
            await DownloadImagesLocally();

            imagesDownloaded = true;
        }

        ImageCollectionView.ItemsSource = null;

        // Reorder images
        var list = new List<ImageDetails>();

        var num = MauiProgram.AppModel.ImageSources.Count;

        for (int count=0; count< num; count++)
        {
            var index = random.Next(0, MauiProgram.AppModel.ImageSources.Count);

            var image = MauiProgram.AppModel.ImageSources[index];
            list.Add(image);

            MauiProgram.AppModel.ImageSources.Remove(image);
        }

        MauiProgram.AppModel.ImageSources = list;

        ImageCollectionView.ItemsSource = MauiProgram.AppModel.ImageSources;

        timesClicked++;

        TimesClicked.Text = timesClicked.ToString();
    }

    #region Medthods to copy remote images locally
    public async Task<bool> DownloadFileAsync(string absoluteLocation, string url)
    {
        bool ret;
        try
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };

            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var rs = response.Content.ReadAsStream())
                {
                    using (var str = File.OpenWrite(absoluteLocation))
                    {
                        rs.CopyTo(str);
                        str.Close();
                    }

                    rs.Close();
                }
            }

            ret = response.StatusCode == HttpStatusCode.OK;

            return ret;
        }
        catch
        {
            ret = false;
        }

        return ret;
    }

    public string ImageLocalAbsoluteLocation(ImageDetails image)
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{image.Name}");
    }

    async Task DownloadImagesLocally()
    {
        foreach (var image in MauiProgram.AppModel.ImageSources)
        {
            await DownloadFileAsync(ImageLocalAbsoluteLocation(image), image.Url);
        }
    }
    #endregion
}

