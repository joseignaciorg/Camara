using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosModel.Model;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace Camara
{
    class UploadFile
    {
        private String url = "http://apicontactosnacho.azurewebsites.net/api/camera";

        public async Task<String> SubirFoto(byte[] file)
        {
            var client=new RestClient();

            var request=new RestRequest();
            request.Method=Method.POST;
            
            var d=new FotosModel() {Data = Convert.ToBase64String(file),id=2};

            request.AddJsonBody(d);

            var r=await client.Execute<string>(request);

            return r.Data;
        }
    }
}
