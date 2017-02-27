using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CognitiveServicesDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async Task<AnalysisResult> GetImageDescription(Stream imageStream)
        {
            VisionServiceClient visionClient = new VisionServiceClient("YOUR KEY HERE");
            VisualFeature[] features = { VisualFeature.Tags };
            return await visionClient.AnalyzeImageAsync(imageStream, features.ToList(), null);
        }

        private async Task SelectPicture()
        {
           if(CrossMedia.Current.IsPickPhotoSupported)
            {
                var image = await CrossMedia.Current.PickPhotoAsync();
                MyImage.Source = ImageSource.FromStream(() =>
                {
                    return image.GetStream();
                });
                MyActivityIndicator.IsRunning = true;
                try
                {
                    var result = await GetImageDescription(image.GetStream());
                    foreach(var tag in result.Tags)
                    {
                        MyLabel.Text = MyLabel.Text + tag.Name + "\n";
                    }
                }
                catch(ClientException ex)
                {
                    MyLabel.Text = ex.Message;
                }
                MyActivityIndicator.IsRunning = false;
            }
        }

        async void Handle_Click(object sender, EventArgs e)
        {
            await SelectPicture();
        }
    }
}
