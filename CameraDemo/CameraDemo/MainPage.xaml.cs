using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CameraDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			TakePhoto.Clicked += TakePhoto_Clicked;
		}

		private async void TakePhoto_Clicked(object sender, EventArgs e)
		{
			var cameraOptions = new StoreCameraMediaOptions();
			cameraOptions.PhotoSize = PhotoSize.Small;
			cameraOptions.SaveToAlbum = true;

			//var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
			var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(cameraOptions);


			if (photo != null )
			{
				PhotoTag.Source = ImageSource.FromStream(() =>
				{
					return photo.GetStream();
				});
			}
        }
    }
}
