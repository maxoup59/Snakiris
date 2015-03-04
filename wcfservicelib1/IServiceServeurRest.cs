using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Snakiris
{
    [ServiceContract]
    public interface IServiceServeurRest
    {
        [OperationContract]
        [Description("Login")]
        [WebGet(UriTemplate = "/Login", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int Login();
        [OperationContract]
        [Description("moveUP")]
        [WebGet(UriTemplate = "/moveUP/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void moveUP(string id);
        [OperationContract]
        [Description("moveDOWN")]
        [WebGet(UriTemplate = "/moveDOWN/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void moveDOWN(string id);
        [OperationContract]
        [Description("moveLEFT")]
        [WebGet(UriTemplate = "/moveLEFT/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void moveLEFT(string id);
        [OperationContract]
        [Description("moveRIGHT")]
        [WebGet(UriTemplate = "/moveRIGHT/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void moveRIGHT(string id);
    }
}

