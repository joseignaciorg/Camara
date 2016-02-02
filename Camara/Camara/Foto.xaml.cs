using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Camara
{
    public partial class Foto : ContentPage
    {
        public Foto()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var f = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "Fotos",
                Name = "mifoto.jpg"
            });//el takephotoasync abre la camara

            if (f != null)
            {

                MiFoto.Source = ImageSource.FromStream(() =>
                {
                    var st = f.GetStream();
                    f.Dispose();
                    return st;
                });
            }
        }
    }
}
