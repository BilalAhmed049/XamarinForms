using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Plugin.Media;
using Xamarin.Forms;

namespace MvvmAppDemo
{
	public class DetailsViewModel: ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ICognitiveClient _cognitiveClient;

		ImageSource _myImageSource;
		public ImageSource MyImageSource
		{
			get
			{
				if (_myImageSource == null)
				{
					return Device.OnPlatform(
			iOS: ImageSource.FromFile("Images/picture.png"),
			Android: ImageSource.FromFile("picture.png"),
			WinPhone: ImageSource.FromFile("Images/wpicture.png"));
				}
				return _myImageSource;
			}

			set
			{
			    Set(ref _myImageSource, value);
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
			    Set(ref _imageDescription, value);
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
			    Set(ref _progressVisible, value);
			}
		}

		Person _person;
		public Person Person
		{
			get
			{
				return _person;
			}

			set
			{
			    Set(ref _person, value);
			}
		}

		public ICommand AddNewImage { get; private set; }


		public DetailsViewModel(INavigationService navigationService, ICognitiveClient cognitiveClient)
		{
			_navigationService = navigationService;
			_cognitiveClient = cognitiveClient;
			Messenger.Default.Register<Person>(this, person =>
			{
				Person = person;
			});
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

						Person person = new Person()
						{
							Name = "Bill",
							Surname = "Gates",
							Information = result.Description.Tags
						};

						foreach (string tag in person.Information)
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
