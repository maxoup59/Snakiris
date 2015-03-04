using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Snakiris
{
    class HoteServiceREST
    {
        WebServiceHost hote = null;
        public HoteServiceREST()
        {

        }
        public void Start()
        {
            string adresseBase = "http://localhost:80/";

            ServiceServeurRest service = new ServiceServeurRest();
            WebHttpBinding binding = new WebHttpBinding();
            WebHttpBehavior behavior = new WebHttpBehavior();

            hote = new WebServiceHost(service, new Uri(adresseBase));
            hote.AddServiceEndpoint(typeof(IServiceServeurRest), binding, "");

            hote.Open();
        }
        public void Stop()
        {
            hote.Close();
        }
    }
}
