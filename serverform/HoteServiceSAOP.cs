using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Snakiris
{
    class HoteServiceSAOP
    {
        ServiceHost hote = null;

        public HoteServiceSAOP()
        {

        }
        public void Start(string filename, int nbJoueurs, int nbFruits, int nbBot ,int initialSize)
        {
            string adresseBase = "http://localhost:80/Snakiris"; 
            string adresseService = adresseBase + "/ServiceServeur";

            Uri oAddresseService = new Uri(adresseService);
            Uri oAdresseMex = new Uri(adresseBase + "/mexDuServiceServeur");

            ServiceServeur test = new ServiceServeur(filename, nbJoueurs, nbFruits, nbBot, initialSize);
            hote = new ServiceHost(test, oAddresseService);

            hote.AddServiceEndpoint(typeof(IServiceServeur), new BasicHttpBinding(), "");
            ServiceMetadataBehavior srvMex = new ServiceMetadataBehavior();

            srvMex.HttpGetEnabled = true;
            srvMex.HttpGetUrl = oAdresseMex;

            hote.Description.Behaviors.Add(srvMex); 
            hote.Open();
        }
        public void Stop()
        {
            hote.Close();
        }
    }
}
