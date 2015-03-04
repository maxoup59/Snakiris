using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snakiris
{
    class Snake
    {
        List<int> PositionX; //Liste contenant la position en X du snake
        List<int> PositionY;
        int MyDirectionX; //Création d'une variable direction pour indiquer le sens de déplacement
        int MyDirectionY;
        int score;
        bool GameOVER;
        int PositionInitX;
        int PositionInitY;
        int PositionInitHX;
        int PositionInitHY;

        TimeSpan timeOfDead;

        public Snake()
        {
            PositionX = new List<int>(); //Initialisation de la liste des positions de chaque partie du corps du Snake
            PositionY = new List<int>();

            GameOVER = false;
            score = 0;
            MyDirectionX = -1;
            MyDirectionY = 0;

            PositionInitX = 0;
            PositionInitY = 0;
            PositionInitHX = 0;
            PositionInitHY = 0;

            PositionX.Add(0);//Initialisation de la position de la tête du Snake
            PositionY.Add(0);
            PositionX.Add(0);
            PositionY.Add(0);
        }
        public void SetInitialSize(int initialSize)
        {
            while (PositionX.Count < initialSize)
            {
                PositionX.Add(0);
                PositionY.Add(0);
            }
        }
        public int GetPositionX(int index)
        {
            return PositionX[index];
        }
        public int GetPositionY(int index)
        {
            return PositionY[index];
        }
        public void SetPositionX(int index, int value)
        {
            PositionX[index] = value;
        }
        public void SetPositionY(int index, int value)
        {
            PositionY[index] = value;
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public TimeSpan TimeOfDead
        {
            get
            {
                return timeOfDead;
            }
            set
            {
                timeOfDead = value;
            }
        }
        public int DirectionX
        {
            get
            {
                return MyDirectionX;
            }
            set
            {
                MyDirectionX = value;
            }
        }
        public int DirectionY
        {
            get
            {
                return MyDirectionY;
            }
            set
            {
                MyDirectionY = value;
            }
        }

        public bool GameOver
        {
            get
            {
                return GameOVER;
            }
            set
            {
                GameOVER = value;
            }
        }
        public int GetCount()
        {
            return PositionX.Count;
        }
        public void eat()
        {
            PositionX.Add(PositionX[0]);
            PositionY.Add(PositionY[0]);
        }
        public int InitPositionHX
        {
            get { return PositionInitHX; }
            set { PositionInitHX = value; }
        }
        public int InitPositionHY
        {
            get { return PositionInitHY; }
            set { PositionInitHY = value; }
        }
        public int InitPositionSY
        {
            get { return PositionInitY; }
            set { PositionInitY = value; }
        }
        public int InitPositionSX
        {
            get { return PositionInitX; }
            set { PositionInitX = value; }
        }
    }
}
