
namespace Snakiris
{
    class Snake
    {
        bool Initialposition = false;
        bool Secondposition = false;
        public bool InitialPosition
        {
            get { return Initialposition; }
            set { Initialposition = value; }
        }
        public bool SecondPosition
        {
            get { return Secondposition; }
            set { Secondposition = value; }
        }
    }

}
