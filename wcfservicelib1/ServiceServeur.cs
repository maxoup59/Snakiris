using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Timers;

namespace Snakiris
{
    // Implémentation de l'interface du service
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
    public class ServiceServeur : IServiceServeur
    {
        List<Snake> snakes = new List<Snake>();
        List<Player> players = new List<Player>();
        Timer timerMouvement = new Timer();
        PlateauDeJeu plateauDeJeux;
        int nbJoueurs = 0;
        int nbBot = 1; //BIM
        int initialSize = 2;

        Node[][] nodes; // BIM

        DateTime timeOfStart;

        int time = 0;
        string filename = "";
        public ServiceServeur(string filename = "", int nbjoueurs = 1, int nbFruits = 1, int nbBot = 0, int initialSize = 2)
        {
            this.nbBot = nbBot;
            this.initialSize = initialSize;
            timerMouvement = new Timer(1000); //BIM //Création d'une instance de Timer et Reglage de l'interval du Timer
            timerMouvement.Enabled = true; //Activation du Timer
            timerMouvement.Elapsed += new ElapsedEventHandler(OnElapsedTimerMouvement);
            timerMouvement.Stop();
            plateauDeJeux = new PlateauDeJeu(nbFruits);
            this.filename = filename;
            plateauDeJeux.SetFileName(filename);
            nbJoueurs = nbjoueurs + nbBot; //BIM

            for (int i = 0; i < nbBot; i++) // BIM
            {
                Login("bot"+(i+1).ToString());
            }
        }

        public int GetNombreWalls()
        {
            return plateauDeJeux.GetNombreWalls();
        }

        public int GetRangWall(int nb)
        {
            return plateauDeJeux.GetRangWall(nb);
        }

        public string GetText()
        {
            string text = "EN ATTENTE DE " + Convert.ToInt32(nbJoueurs - snakes.Count) + " JOUEUR(S)";
            if (nbJoueurs - snakes.Count == 0)
                text = "";
            switch (time / 150)
            {
                case 1:
                    text = "3";
                    break;
                case 2:
                    text = "2";
                    break;
                case 3:
                    text = "1";
                    break;
                default:
                    break;
            }
            return text;
        }
        public int Login(string pseudo)
        {
            int retour = 0;
            if (snakes.Count < nbJoueurs)
            {
                snakes.Add(new Snake());
                snakes[snakes.Count - 1].SetPositionX(0, plateauDeJeux.GetPositionInitHX(snakes.Count));
                snakes[snakes.Count - 1].SetPositionY(0, plateauDeJeux.GetPositionInitHY(snakes.Count));
                snakes[snakes.Count - 1].SetPositionX(1, plateauDeJeux.GetPositionInitX(snakes.Count));
                snakes[snakes.Count - 1].SetPositionY(1, plateauDeJeux.GetPositionInitY(snakes.Count));
                snakes[snakes.Count - 1].DirectionX = plateauDeJeux.GetDirectionX(snakes.Count);
                snakes[snakes.Count - 1].DirectionY = plateauDeJeux.GetDirectionY(snakes.Count);
                snakes[snakes.Count - 1].SetInitialSize(initialSize);

                players.Add(new Player());
                players[snakes.Count - 1].Pseudo = pseudo;
                retour = snakes.Count;
                if (snakes.Count == nbJoueurs)
                {
                    timerMouvement.Start();
                }
            }
            return retour;
        }
        public void Restart()
        {
            int count = snakes.Count;
            snakes.Clear();
            PlateauDeJeu Partie = new PlateauDeJeu();
            Partie.SetFileName(filename);
            time = 0;
            timerMouvement.Interval = 1000; // BIM

            while (snakes.Count < count)
            {
                snakes.Add(new Snake());
                snakes[snakes.Count - 1].SetPositionX(0, Partie.GetPositionInitHX(snakes.Count));
                snakes[snakes.Count - 1].SetPositionY(0, Partie.GetPositionInitHY(snakes.Count));
                snakes[snakes.Count - 1].SetPositionX(1, Partie.GetPositionInitX(snakes.Count));
                snakes[snakes.Count - 1].SetPositionY(1, Partie.GetPositionInitY(snakes.Count));
                snakes[snakes.Count - 1].DirectionX = Partie.GetDirectionX(snakes.Count);
                snakes[snakes.Count - 1].DirectionY = Partie.GetDirectionY(snakes.Count);
                snakes[snakes.Count - 1].SetInitialSize(initialSize);
            }
            if (snakes.Count == nbJoueurs)
            {
                timerMouvement.Start();
            }
        }

        private void OnElapsedTimerMouvement(object source, ElapsedEventArgs e)
        {
            int nbrmort = 0;//BIM
            time += 150;
            if (time / 150 == 3) //BIM
            {
                timerMouvement.Interval = 150;
                timeOfStart = DateTime.Now;
            }
            else if (time / 150 > 3)
            {
                foreach (Snake snake in snakes)
                {
                    if (!snake.GameOver)
                    {
                        for (int i = snake.GetCount() - 1; i > 0; i--)
                        {
                            snake.SetPositionX(i, snake.GetPositionX(i - 1));
                            snake.SetPositionY(i, snake.GetPositionY(i - 1));
                        }
                        snake.SetPositionX(0, snake.GetPositionX(0) + 20 * snake.DirectionX);
                        snake.SetPositionY(0, snake.GetPositionY(0) + 20 * snake.DirectionY);
                        snake.TimeOfDead = DateTime.Now - timeOfStart;
                    }
                    else//BIM
                    {
                        nbrmort++;
                    }
                }
                if (nbrmort == nbJoueurs)//BIM
                {
                    Restart();
                }
                checkANDCorrect();
                //BIM, IA bitch !!!! 
                bimiabitch();
            }
        }



        void checkANDCorrect() //Vérifie si le Snake est bien dans l'écran, sinon il corrige sa position
        {
            foreach (Snake item in snakes)
            {
                if (((item.GetPositionX(0)) > plateauDeJeux.Width * 20 - 20) || (((item.GetPositionX(0)) < 0) || (((item.GetPositionY(0)) + 60 > plateauDeJeux.Height * 20) || (((item.GetPositionY(0)) < 0)))))
                {
                    if ((item.GetPositionX(0)) > plateauDeJeux.Width * 20 - 20)
                    {
                        item.SetPositionX(0, 0);
                    }
                    else if ((item.GetPositionX(0)) < 0)
                    {
                        item.SetPositionX(0, plateauDeJeux.Width * 20 - 20);
                    }
                    else if ((item.GetPositionY(0)) < 0)
                    {
                        item.SetPositionY(0, plateauDeJeux.Height * 20 - 20);
                    }
                    else if ((item.GetPositionY(0)) > plateauDeJeux.Height * 20 - 20)
                    {
                        item.SetPositionY(0, 0);
                    }
                }
                for (int i = item.GetCount() - 1; i > 0; i--)
                {
                    if ((item.GetPositionX(0) == (item.GetPositionX(i)) && ((item.GetPositionY(0) == (item.GetPositionY(i))))))
                    {
                        item.GameOver = true;
                    }
                }
                for (int i = 0; i < plateauDeJeux.GetNombreFruits(); i++)
                {
                    if ((item.GetPositionX(0) == plateauDeJeux.GetPositionFruitX(i)) && (item.GetPositionY(0) == plateauDeJeux.GetPositionFruitY(i)))
                    {
                        item.eat();
                        item.Score += 10;
                        plateauDeJeux.CallRandomFruit(i);
                    }
                }
                for (int i = plateauDeJeux.GetNombreWalls() - 1; i >= 0; i--)
                {
                    if ((item.GetPositionX(0) == plateauDeJeux.GetPositionWallsX(i)) && (item.GetPositionY(0) == plateauDeJeux.GetPositionWallsY(i)))
                    {
                        item.GameOver = true;
                    }
                }
                for (int j = 0; j < plateauDeJeux.GetNombreFruits(); j++)
                {
                    for (int i = 1; i < item.GetCount(); i++)
                    {
                        if ((item.GetPositionX(i) == plateauDeJeux.GetPositionFruitX(j) && item.GetPositionY(i) == plateauDeJeux.GetPositionFruitY(j)))
                        {
                            plateauDeJeux.CallRandomFruit(j);
                            i--;
                        }
                    }
                }

            }
            for (int j = 0; j < snakes.Count; j++)
            {
                for (int k = 0; k < snakes.Count; k++)
                {
                    for (int i = 0; i < snakes[k].GetCount(); i++)
                    {
                        if ((snakes[j].GetPositionX(0) == (snakes[k].GetPositionX(i)) && ((snakes[j].GetPositionY(0) == (snakes[k].GetPositionY(i))) && (j != k))))
                        {
                            snakes[j].GameOver = true;
                        }
                    }
                }
            }
        }
        public string GetInfoPlayers()
        {
            string data = "";
            for(int i = 0 ; i< snakes.Count ; i++)
            {
                data += '{';
                data += players[i].Pseudo;
                data += ';';
                data += snakes[i].Score;
                data += ';';
                data += Math.Round(snakes[i].TimeOfDead.TotalSeconds);
                data += '}';
            }
            return data;
        }
        public string GetFruit()
        {
            string data = "";
            data += "{";
            for (int i = 0; i < plateauDeJeux.GetNombreFruits(); i++)
            {
                int temp = plateauDeJeux.GetPositionFruitX(i);
                if (temp < 100 && temp > 9)
                    data += "0";
                else if (temp < 10 && temp >= 0)
                    data += "00";
                data += temp;
                data += "|";
                temp = plateauDeJeux.GetPositionFruitY(i);
                if (temp < 100 && temp > 9)
                    data += "0";
                else if (temp < 10 && temp >= 0)
                    data += "00";
                data += temp;
                data += "|";
            }
            data += "}";
            return data;
        }
        public string GetData()
        {
            string data = "";
            for (int i = 0; i < snakes.Count; i++)
            {
                data += "{";
                data += "@";
                data += i.ToString();
                for (int j = 0; j < snakes[i].GetCount(); j++)
                {

                    data += "|";
                    int temp = snakes[i].GetPositionX(j);
                    if (temp < 100 && temp > 9)
                        data += "0";
                    else if (temp < 10 && temp >= 0)
                        data += "00";

                    data += temp;

                    data += "|";

                    temp = snakes[i].GetPositionY(j);
                    if (temp < 100 && temp > 9)
                        data += "0";
                    else if (temp < 10)
                        data += "00";
                    data += temp;
                }
                data += "}";
            }
            return data;
        }
        public int GetNBJOUEUR()
        {
            return snakes.Count;
        }
        public void moveUP(int id)
        {
            if (snakes[id].DirectionX != 0 && snakes[id].DirectionY != 1)
            {
                snakes[id].DirectionX = 0;
                snakes[id].DirectionY = -1;
            }
        }
        public void moveDOWN(int id)
        {
            if (snakes[id].DirectionX != 0 && snakes[id].DirectionY != -1)
            {
                snakes[id].DirectionX = 0;
                snakes[id].DirectionY = 1;
            }
        }
        public void moveLEFT(int id)
        {
            if (snakes[id].DirectionX != 1 && snakes[id].DirectionY != 0)
            {
                snakes[id].DirectionX = -1;
                snakes[id].DirectionY = 0;
            }
        }
        public void moveRIGHT(int id)
        {
            if (snakes[id].DirectionX != -1 && snakes[id].DirectionY != 0)
            {
                snakes[id].DirectionX = 1;
                snakes[id].DirectionY = 0;
            }
        }
        public int GetTOTNBCORPS()
        {
            int compteur = 0;
            foreach (Snake item in snakes)
            {
                compteur += item.GetCount();
            }
            return compteur;
        }
        public int GetNBCORPS(int id)
        {
            return snakes[id].GetCount();
        }
        public int GetNBFRUITS()
        {
            return plateauDeJeux.GetNombreFruits();
        }
        public void SetMAPS(string maps)
        {
            plateauDeJeux.SetFileName(maps);
        }
        public int GetHEIGHT()
        {
            return plateauDeJeux.Height;
        }
        public int GetWIDTH()
        {
            return plateauDeJeux.Width;
        }
        public bool isAccessible()
        {
            return true;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////



        public void bimiabitch()
        {
            int width = GetWIDTH();
            int height = GetHEIGHT();
            nodes = new Node[width][];
            List<Node> foods = new List<Node>();
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node[height];
            }
            nodes[0][0] = new Node(0, 0, State.Blank);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    nodes[x][y] = new Node(x, y, State.Blank);
                }

            }
            for (int i = 0; i < plateauDeJeux.GetNombreWalls(); i++)
            {
                nodes[plateauDeJeux.GetPositionWallsX(i) / 20][plateauDeJeux.GetPositionWallsY(i) / 20].state = State.Wall;
            }
            for (int i = 0; i < plateauDeJeux.GetNombreFruits(); i++)
            {
                nodes[plateauDeJeux.GetPositionFruitX(i) / 20][plateauDeJeux.GetPositionFruitY(i) / 20].state = State.Food;
                foods.Add(new Node(plateauDeJeux.GetPositionFruitX(i) / 20, plateauDeJeux.GetPositionFruitY(i) / 20, State.Food));
            }
            for (int i = 0; i < nbJoueurs; i++)
            {
                int size = snakes[i].GetCount();

                nodes[snakes[i].GetPositionX(0) / 20][snakes[i].GetPositionY(0) / 20].state = State.Head;
                nodes[snakes[i].GetPositionX(0) / 20][snakes[i].GetPositionY(0) / 20].playerId = i;

                for (int j = 1; j < size - 1; j++)
                {
                    nodes[snakes[i].GetPositionX(j) / 20][snakes[i].GetPositionY(j) / 20].state = State.Bodypart;
                    nodes[snakes[i].GetPositionX(j) / 20][snakes[i].GetPositionY(j) / 20].playerId = i;
                }
                nodes[snakes[i].GetPositionX(size - 1) / 20][snakes[i].GetPositionY(size - 1) / 20].state = State.Tail;
                nodes[snakes[i].GetPositionX(size - 1) / 20][snakes[i].GetPositionY(size - 1) / 20].playerId = i;
            }
            for (int i = 0; i < nbBot; i++)
            {
                Node headNode = nodes[snakes[i].GetPositionX(0) / 20][snakes[i].GetPositionY(0) / 20];
                Node tailNode = nodes[snakes[i].GetPositionX(snakes[i].GetCount() - 1) / 20][snakes[i].GetPositionY(snakes[i].GetCount() - 1) / 20];


                int distanceMin = 1000000;
                int id = 0;

                for (int k = 0; k < foods.Count; k++)
                {
                    int distance = getLentghPath(headNode, foods[k]);
                    if (distance < distanceMin)
                    {
                        id = k;
                        distanceMin = distance;
                    }
                }

                Node foodNode = foods[id];





                Node nextNode = getNextNode(headNode, foodNode, i);



                // tail access ?? 
                if (getLentghPath(nextNode, tailNode) == 1000000)
                    nextNode = getNextNode(headNode, tailNode, i);



                int dir = getDirectionNode1ToNode2(headNode, nextNode);
                switch (dir)
                {
                    case 0:
                        snakes[i].DirectionX = 0;
                        snakes[i].DirectionY = -1;
                        break;
                    case 1:
                        snakes[i].DirectionX = 1;
                        snakes[i].DirectionY = 0;
                        break;
                    case 2:
                        snakes[i].DirectionX = 0;
                        snakes[i].DirectionY = 1;
                        break;
                    case 3:
                        snakes[i].DirectionX = -1;
                        snakes[i].DirectionY = 0;
                        break;
                }
            }
        }

        private int getLentghPath(Node nodeA, Node nodeB)
        {
            Node currentNode = nodeA;
            Node goalNode = nodeB;
            Node[][] map = nodes;
            List<Node> neighborNodes = new List<Node>();

            for (int x = 0; x < GetWIDTH(); x++)
            {
                for (int y = 0; y < GetHEIGHT(); y++)
                {
                    map[x][y].distance = 1000000;
                    switch (map[x][y].state)
                    {
                        case State.Wall:
                            map[x][y].isVisited = true;
                            break;
                        case State.Blank:
                            map[x][y].isVisited = false;
                            break;
                        case State.Food:
                            map[x][y].isVisited = false;
                            break;
                        case State.Bodypart:
                            map[x][y].isVisited = true;
                            break;
                        case State.Head:
                            map[x][y].isVisited = true;
                            break;
                        case State.Tail:
                            map[x][y].isVisited = true;
                            break;
                    }
                }
            }
            map[currentNode.x][currentNode.y].isVisited = false;
            map[goalNode.x][goalNode.y].isVisited = false;
            currentNode.distance = 0;

            //  Find a path.
            int min = 0;
            bool go = true;
            while (go)
            {
                neighborNodes.Clear();

                if (!map[(currentNode.x + 1) % GetWIDTH()][currentNode.y].isVisited)
                    neighborNodes.Add(map[(currentNode.x + 1) % GetWIDTH()][currentNode.y]);
                if (!map[(currentNode.x - 1 + GetWIDTH()) % GetWIDTH()][currentNode.y].isVisited)
                    neighborNodes.Add(map[(currentNode.x - 1 + GetWIDTH()) % GetWIDTH()][currentNode.y]);
                if (!map[currentNode.x][(currentNode.y + 1) % GetHEIGHT()].isVisited)
                    neighborNodes.Add(map[currentNode.x][(currentNode.y + 1) % GetHEIGHT()]);
                if (!map[currentNode.x][(currentNode.y - 1 + GetHEIGHT()) % GetHEIGHT()].isVisited)
                    neighborNodes.Add(map[currentNode.x][(currentNode.y - 1 + GetHEIGHT()) % GetHEIGHT()]);

                foreach (Node node in neighborNodes)
                {
                    if (currentNode.distance + 1 < node.distance)
                    {
                        node.distance = currentNode.distance + 1;
                    }
                }
                currentNode.isVisited = true;
                min = 1000000;
                for (int i = 0; i < GetWIDTH(); i++)
                {
                    for (int j = 0; j < GetHEIGHT(); j++)
                    {
                        if (!map[i][j].isVisited && map[i][j].distance < min)
                        {
                            min = map[i][j].distance;
                            currentNode = map[i][j];
                        }
                    }
                }
                if ((currentNode.x == goalNode.x && currentNode.y == goalNode.y) || min == 1000000)
                    go = false;
            }

            return min;
        }



        private Node getNextNode(Node nodeA, Node nodeB, int playerId)
        {

            Node currentNode = nodeA;
            Node goalNode = nodeB;
            Node nextNode = new Node(-1, -1, State.Blank);

            List<Node> neighborNodes = new List<Node>();
            Node[][] map = nodes;

            for (int x = 0; x < GetWIDTH(); x++)
            {
                for (int y = 0; y < GetHEIGHT(); y++)
                {
                    map[x][y].distance = 1000000;


                    switch (map[x][y].state)
                    {
                        case State.Wall:
                            map[x][y].isVisited = true;
                            break;
                        case State.Blank:
                            map[x][y].isVisited = false;
                            break;
                        case State.Food:
                            map[x][y].isVisited = false;
                            break;
                        case State.Bodypart:
                            map[x][y].isVisited = true;
                            break;
                        case State.Head:
                            map[x][y].isVisited = true;
                            break;
                        case State.Tail:
                            map[x][y].isVisited = true;
                            break;
                    }
                }
            }
            map[currentNode.x][currentNode.y].isVisited = false;
            map[goalNode.x][goalNode.y].isVisited = false;
            currentNode.distance = 0;







            //////




            int min = 0;
            bool go = true;
            while (go)
            {
                neighborNodes.Clear();

                if (!map[(currentNode.x + 1) % GetWIDTH()][currentNode.y].isVisited)
                    neighborNodes.Add(map[(currentNode.x + 1) % GetWIDTH()][currentNode.y]);
                if (!map[(currentNode.x - 1 + GetWIDTH()) % GetWIDTH()][currentNode.y].isVisited)
                    neighborNodes.Add(map[(currentNode.x - 1 + GetWIDTH()) % GetWIDTH()][currentNode.y]);
                if (!map[currentNode.x][(currentNode.y + 1) % GetHEIGHT()].isVisited)
                    neighborNodes.Add(map[currentNode.x][(currentNode.y + 1) % GetHEIGHT()]);
                if (!map[currentNode.x][(currentNode.y - 1 + GetHEIGHT()) % GetHEIGHT()].isVisited)
                    neighborNodes.Add(map[currentNode.x][(currentNode.y - 1 + GetHEIGHT()) % GetHEIGHT()]);

                foreach (Node node in neighborNodes)
                {
                    if (currentNode.distance + 1 < node.distance)
                    {
                        node.distance = currentNode.distance + 1;
                    }
                }
                currentNode.isVisited = true;




                min = 1000000;
                for (int i = 0; i < GetWIDTH(); i++)
                {
                    for (int j = 0; j < GetHEIGHT(); j++)
                    {
                        if (!map[i][j].isVisited && map[i][j].distance < min)
                        {
                            min = map[i][j].distance;
                            currentNode = map[i][j];
                        }
                    }
                }


                if ((currentNode.x == goalNode.x && currentNode.y == goalNode.y) || min == 1000000)
                    go = false;
            }



            //////



            List<Point> coordinates = new List<Point>();
            for (int i = currentNode.distance; i > 1; i--)
            {
                neighborNodes.Clear();

                neighborNodes.Add(map[(currentNode.x + 1) % GetWIDTH()][currentNode.y]);
                neighborNodes.Add(map[(currentNode.x - 1 + GetWIDTH()) % GetWIDTH()][currentNode.y]);
                neighborNodes.Add(map[currentNode.x][((currentNode.y + 1) % GetHEIGHT())]);
                neighborNodes.Add(map[currentNode.x][((currentNode.y - 1 + GetHEIGHT()) % GetHEIGHT())]);
                foreach (Node node in neighborNodes)
                {
                    if (currentNode.distance > node.distance)
                        currentNode = node;
                }
                coordinates.Add(new Point(currentNode.x, currentNode.y));

                //plateauDeJeux.addFruit(currentNode.x, currentNode.y);

            }
            coordinates.Reverse();
            neighborNodes.Clear();
            neighborNodes.Add(map[(nodeA.x + 1) % GetWIDTH()][nodeA.y]);
            neighborNodes.Add(map[(nodeA.x - 1 + GetWIDTH()) % GetWIDTH()][nodeA.y]);
            neighborNodes.Add(map[nodeA.x][((nodeA.y + 1) % GetHEIGHT())]);
            neighborNodes.Add(map[nodeA.x][((nodeA.y - 1 + GetHEIGHT()) % GetHEIGHT())]);
            for (int i = 0; i < 4; i++)
            {
                if (coordinates.Count > 0)
                {
                    if (neighborNodes[i].x == coordinates[0].X
                        && neighborNodes[i].y == coordinates[0].Y)
                    {
                        nextNode = neighborNodes[i];
                    }
                }
                else
                {
                    if (neighborNodes[i].x == goalNode.x
                        && neighborNodes[i].y == goalNode.y)
                    {
                        nextNode = neighborNodes[i];
                    }
                }
            }/**/
            return nextNode;
        }


        private int getDirectionNode1ToNode2(Node node1, Node node2)
        {
            int dir = -1;
            if (node1.x == node2.x)
            {
                if (node1.y == (node2.y + 1) % GetHEIGHT())
                    dir = 0;
                else
                    dir = 2;
            }
            else if (node1.y == node2.y)
            {
                if (node1.x == (node2.x + 1) % GetWIDTH())
                    dir = 3;
                else
                    dir = 1;
            }

            /*if (dir == -1)
                dir = 0;*/

            return dir;
        }
    }
}
