using System.Collections.Generic;

namespace Snakiris
{


    class Map
    {
        int width;
        int height;
        List<Node> caseStatut;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            caseStatut = new List<Node>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    caseStatut.Add(new Node(x, y, State.Blank));
                }
            }
        }

        public int Size
        {
            get { return caseStatut.Count; }
        }

        public int getX(int buttonId)
        {
            int x = buttonId % width;
            return x;
        }

        public int getY(int buttonId)
        {
            int y = buttonId / width;
            return y;
        }


        public State getState(int id)
        {
            return caseStatut[id].state;
        }





        public void setWall(int id)
        {
            if (id >= 0 && id < caseStatut.Count)
            {
                caseStatut[id].state = State.Wall;
            }
        }

        public void setFood(int x, int y)
        {
            if (x + y * width >= 0 && x + y * width < caseStatut.Count)
                caseStatut[x + y * width].state = State.Food;
        }

        public void setBodypart(int x, int y, int playerId)
        {
            if (x + y * width >= 0 && x + y * width < caseStatut.Count)
                caseStatut[x + y * width].state = State.Bodypart;
            caseStatut[x + y * width].playerId = playerId;
        }

        public void setHead(int x, int y, int playerId)
        {
            int idNode = x + y * width;
            if (idNode > -1 && idNode < width * height)
            {
                caseStatut[x + y * width].state = State.Head;
                caseStatut[x + y * width].playerId = playerId;
            }
        }

        public void setTail(int x, int y, int playerId)
        {
            int idNode = x + y * width;
            if (idNode > -1 && idNode < width * height)
            {
                caseStatut[x + y * width].state = State.Tail;
                caseStatut[idNode].playerId = playerId;
            }

        }


        public int getIDSnake(int buttonId)
        {
            return caseStatut[buttonId].playerId;
        }

        public void reset()
        {
            for (int i = 0; i < caseStatut.Count; i++)
            {
                caseStatut[i].state = State.Blank;
            }
        }
    }
}
