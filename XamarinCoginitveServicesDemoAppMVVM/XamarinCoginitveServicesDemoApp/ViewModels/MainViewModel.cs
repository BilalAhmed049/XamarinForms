using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;
using XamarinUniversity.Interfaces;

namespace XamarinCoginitveServicesDemoApp
{
	public class MainViewModel: SimpleViewModel
	{
		IDependencyService _serviceLocator;
		ICognitiveClient _cognitiveClient;
		public ICommand AddNewImage { get; private set; }

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


		public MainViewModel() : this(new XamarinUniversity.Services.DependencyServiceWrapper())
		{
			
		}

		public MainViewModel(IDependencyService serviceLocator)
		{
			_serviceLocator = serviceLocator;
			_cognitiveClient = _serviceLocator.Get<ICognitiveClient>();
			AddNewImage = new Command(async () => await OnAddNewImage());
		}


		 async Task OnAddNewImage()
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
