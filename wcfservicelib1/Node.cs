
namespace Snakiris
{
    enum State
    {
        Blank,
        Wall,
        Food,
        Bodypart,
        Head,
        Tail
    };
    class Node
    {
        public int x;
        public int y;
        public bool isVisited;
        public State state;
        public int distance;
        public int playerId;
        public Node(int x, int y, State state)
        {
            this.x = x;
            this.y = y;
            this.state = state;
            isVisited = false;
            distance = -1;
            this.playerId = -1;
        }
    }
}
