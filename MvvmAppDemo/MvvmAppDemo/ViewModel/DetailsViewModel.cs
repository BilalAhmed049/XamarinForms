using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Plugin.Media;
using Xamarin.Forms;

namespace MvvmAppDemo
{
	public class DetailsViewModel: ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private ICognitiveClient _cognitiveClient;

		ImageSource _myImafeSource;
		public ImageSource MyImageSource
		{
			get
			{
				if (_myImafeSource == null)
				{
					return Device.OnPlatform(
			iOS: ImageSource.FromFile("Images/picture.png"),
			Android: ImageSource.FromFile("picture.png"),
			WinPhone: ImageSource.FromFile("Images/wpicture.png"));
				}
				return _myImafeSource;
			}

			set
			{
				_myImafeSource = value;
				RaisePropertyChanged();
			}
		}

		string _imageDescription;
		public string ImageDescription
		{
			get
			{
				return _imageDescription;
			}

			set
			{
				_imageDescription = value;
				RaisePropertyChanged();
			}
		}

		bool _progressVisible;
		public bool ProgressVisible
		{
			get
			{
				return _progressVisible;
			}

			set
			{
				_progressVisible = value;
				RaisePropertyChanged();
			}
		}

		public ICommand AddNewImage { get; private set; }



		public DetailsViewModel(INavigationService navigationService, ICognitiveClient cognitiveClient)
		{
			_navigationService = navigationService;
			_cognitiveClient = cognitiveClient;
			AddNewImage = new Command(async () => await OnAddNewImage());
		}

		private async Task OnAddNewImage()
		{
			ImageDescription = string.Empty;
			if (CrossMedia.Current.IsPickPhotoSupported)
			{
				var image = await CrossMedia.Current.PickPhotoAsync();
				if (image != null)
				{
					var stream = image.GetStream();
					MyImageSource = ImageSource.FromStream(() =>
					{
						return stream;
					});
					try
					{
						ProgressVisible = true;
						var result = await _cognitiveClient.GetImageDescription(image.GetStream());
						image.Dispose();
						foreach (string tag in result.Description.Tags)
						{
							ImageDescription = ImageDescription + "\n" + tag;
						}
					}
					catch (Microsoft.ProjectOxford.Vision.ClientException ex)
					{
						ImageDescription = ex.Message;
					}
					ProgressVisible = false;
				}
			}
		}
	}
}
