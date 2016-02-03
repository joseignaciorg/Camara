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

            var st = f.GetStream();
            f.Dispose();//borra el fichero del disco porque como lo subo a la nube no me hace falta en el disco del movil
            var l = st.Length;//guardo longitud de la foto
            byte[] bt=new byte[l];//guardo la longitud de la foto en un array de bytes
            st.Read(bt, 0, bt.Length);

            var upload=new UploadFile();

            await upload.SubirFoto(bt);

            MiFoto.Source = ImageSource.FromStream(() =>
                st);
        }
    }
}
