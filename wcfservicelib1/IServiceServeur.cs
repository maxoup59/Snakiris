using System.ServiceModel;

namespace Snakiris
{
    // Le contrat de service est l’entité qui va :
    // Etre échangée entre le serveur et le client ;
    //P ermettre au client de savoir quelles sont les méthodes proposées par le service et comment les appeler.
    // L’élaboration d’un contrat de service s’effectue au travers des 3 métadonnées suivantes :
    // ServiceContract
    // OperationContract
    // DataMember
    [ServiceContract]
    public interface IServiceServeur
    {
        [OperationContract]
        int Login(string pseudo);
        [OperationContract]
        string GetData();
        [OperationContract]
        string GetInfoPlayers();
        [OperationContract]
        string GetFruit();
        [OperationContract]
        int GetNBJOUEUR();
        [OperationContract]
        int GetNBFRUITS();
        [OperationContract]
        void moveUP(int id);
        [OperationContract]
        void moveDOWN(int id);
        [OperationContract]
        void moveLEFT(int id);
        [OperationContract]
        void moveRIGHT(int id);
        [OperationContract]
        int GetTOTNBCORPS();
        [OperationContract]
        int GetNBCORPS(int id);
        [OperationContract]
        int GetNombreWalls();
        [OperationContract]
        int GetRangWall(int i);
        [OperationContract]
        void Restart();
        [OperationContract]
        void SetMAPS(string maps);
        [OperationContract]
        string GetText();
        [OperationContract]
        int GetHEIGHT();
        [OperationContract]
        int GetWIDTH();
        [OperationContract]
        bool isAccessible();
    }
}
