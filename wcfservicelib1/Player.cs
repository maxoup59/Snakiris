
namespace Snakiris
{
    class Player
    {

        string pseudo;
        public Player()
        {

            pseudo = "Anonymous";
        }
        public string Pseudo
        {
            get
            {
                return pseudo;
            }
            set
            {
                pseudo = value;
            }
        }

    }
}
