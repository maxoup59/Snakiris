using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Snakiris
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class ServiceServeurRest : IServiceServeurRest
    {
        IServiceServeur proxy = null;
        public ServiceServeurRest()
        {
            string adresse = "http://localhost:80/Snakiris/ServiceServeur";
            EndpointAddress endpointAdress = new EndpointAddress(adresse);
            proxy = ChannelFactory<IServiceServeur>.CreateChannel(new BasicHttpBinding(), endpointAdress);
        }
        public bool isAccessible()
        {
            return true;
        }
        public int Login()
        {
            return proxy.Login("Mobile Player");
        }
        public void moveUP(string id)
        {
            proxy.moveUP(Convert.ToInt32(id) - 1);
        }
        public void moveDOWN(string id)
        {
            proxy.moveDOWN(Convert.ToInt32(id) - 1);
        }
        public void moveLEFT(string id)
        {
            proxy.moveLEFT(Convert.ToInt32(id) - 1);
        }
        public void moveRIGHT(string id)
        {
            proxy.moveRIGHT(Convert.ToInt32(id) - 1);
        }
    }
}
