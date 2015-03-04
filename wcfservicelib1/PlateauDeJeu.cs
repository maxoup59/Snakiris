using System;
using System.Collections.Generic;

namespace Snakiris
{
    class PlateauDeJeu
    {
        List<int> PositionFruitX; //Liste contenant la position des fruits
        List<int> PositionFruitY;

        List<int> PositionWallX;//Liste contenant les positions des murs
        List<int> PositionWallY;
        List<int> RangWall;


        Random RandFruit; //Création d'un nombre aléatoire pour les positions d'un fruit

        /// <summary>
        /// //////////////
        /// </summary>

        List<int> PositionInitX;
        List<int> PositionInitY;
        List<int> PositionInitHX;
        List<int> PositionInitHY;

        List<int> DirectionX;
        List<int> DirectionY;

        string FileName;
        int rows = 13;
        int column = 29;

        public PlateauDeJeu(int nbFruits = 1)
        {
            PositionWallX = new List<int>(); //Initialisation de la liste des positions des murs
            PositionWallY = new List<int>();

            RangWall = new List<int>();

            PositionFruitX = new List<int>(); //Initialisation de la liste des positions des fruits
            PositionFruitY = new List<int>();
            for (int i = 0; i < nbFruits; i++)
            {
                PositionFruitX.Add(0);
                PositionFruitY.Add(0);
            }


            RandFruit = new Random(); //Initialisation du Random

            for (int i = 0; i < PositionFruitX.Count; i++)
            {
                RandomFruit(i);
            }

            DirectionX = new List<int>();
            DirectionY = new List<int>();

            PositionInitX = new List<int>();
            PositionInitY = new List<int>();
            PositionInitHX = new List<int>();
            PositionInitHY = new List<int>();

            PositionInitX.Add(20);
            PositionInitY.Add(20);
            PositionInitX.Add(40);
            PositionInitY.Add(20);
            PositionInitX.Add(60);
            PositionInitY.Add(20);
            PositionInitX.Add(80);
            PositionInitY.Add(20);

            PositionInitHX.Add(20);
            PositionInitHY.Add(0);
            PositionInitHX.Add(40);
            PositionInitHY.Add(0);
            PositionInitHX.Add(60);
            PositionInitHY.Add(0);
            PositionInitHX.Add(80);
            PositionInitHY.Add(0);

            DirectionX.Add(0);
            DirectionY.Add(-1);
            DirectionX.Add(0);
            DirectionY.Add(-1);
            DirectionX.Add(0);
            DirectionY.Add(-1);
            DirectionX.Add(0);
            DirectionY.Add(-1);

            ImportWalls();
        }
        void ImportWalls()
        {
            RangWall.Clear();
            PositionWallX.Clear();
            PositionWallY.Clear();
            if (string.IsNullOrEmpty(FileName))
                FileName = "Maps/bim.map";
            string lines = System.IO.File.ReadAllText(FileName);

            int start = 0, end = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == '|')
                {
                    start = i;
                    break;
                }
            }
            rows = Convert.ToInt32(lines.Substring(0, start));
            for (int i = start; i < lines.Length; i++)
            {
                if (lines[i] == '|')
                {
                    end = i;
                    break;
                }
            }
            start += 1;
            column = Convert.ToInt32(lines.Substring(start, end));
            lines = lines.Substring(start + end + 1);

            for (int i = 0; i < rows * column; i++)
            {
                if (lines[i] == '1')
                {
                    PositionWallX.Add((i % column) * 20); // Obtention de la position en X et Y
                    PositionWallY.Add((i / column) * 20);
                    RangWall.Add(i);
                }
                else if (lines[i] == '2')
                {
                    PositionInitHX[0] = ((i % column) * 20);
                    PositionInitHY[0] = ((i / column) * 20);
                    if (lines[i + 1] == '3')
                    {
                        DirectionX[0] = -1;
                        DirectionY[0] = 0;
                    }
                    else if (lines[i - 1] == '3')
                    {
                        DirectionX[0] = 1;
                        DirectionY[0] = 0;
                    }
                    else if (lines[i + column] == '3')
                    {
                        DirectionX[0] = 0;
                        DirectionY[0] = -1;
                    }
                    else if (lines[i - column] == '3')
                    {
                        DirectionX[0] = 0;
                        DirectionY[0] = 1;
                    }
                }
                else if (lines[i] == '3')
                {
                    PositionInitX[0] = ((i % column) * 20);
                    PositionInitY[0] = ((i / column) * 20);
                }
                else if (lines[i] == '4')
                {
                    PositionInitHX[1] = ((i % column) * 20);
                    PositionInitHY[1] = ((i / column) * 20);
                    if (lines[i + 1] == '5')
                    {
                        DirectionX[1] = -1;
                        DirectionY[1] = 0;
                    }
                    else if (lines[i - 1] == '5')
                    {
                        DirectionX[1] = 1;
                        DirectionY[1] = 0;
                    }
                    else if (lines[i + column] == '5')
                    {
                        DirectionX[1] = 0;
                        DirectionY[1] = -1;
                    }
                    else if (lines[i - column] == '5')
                    {
                        DirectionX[1] = 0;
                        DirectionY[1] = 1;
                    }
                }
                else if (lines[i] == '5')
                {
                    PositionInitX[1] = ((i % column) * 20);
                    PositionInitY[1] = ((i / column) * 20);
                }
                else if (lines[i] == '6')
                {
                    PositionInitHX[2] = ((i % column) * 20);
                    PositionInitHY[2] = ((i / column) * 20);
                    if (lines[i + 1] == '7')
                    {
                        DirectionX[2] = -1;
                        DirectionY[2] = 0;
                    }
                    else if (lines[i - 1] == '7')
                    {
                        DirectionX[2] = 1;
                        DirectionY[2] = 0;
                    }
                    else if (lines[i + column] == '7')
                    {
                        DirectionX[2] = 0;
                        DirectionY[2] = -1;
                    }
                    else if (lines[i - column] == '7')
                    {
                        DirectionX[2] = 0;
                        DirectionY[2] = 1;
                    }
                }
                else if (lines[i] == '7')
                {
                    PositionInitX[2] = ((i % column) * 20);
                    PositionInitY[2] = ((i / column) * 20);
                }
                else if (lines[i] == '8')
                {
                    PositionInitHX[3] = ((i % column) * 20);
                    PositionInitHY[3] = ((i / column) * 20);
                    if (lines[i + 1] == '9')
                    {
                        DirectionX[3] = -1;
                        DirectionY[3] = 0;
                    }
                    else if (lines[i - 1] == '9')
                    {
                        DirectionX[3] = 1;
                        DirectionY[3] = 0;
                    }
                    else if (lines[i + column] == '9')
                    {
                        DirectionX[3] = 0;
                        DirectionY[3] = -1;
                    }
                    else if (lines[i - column] == '9')
                    {
                        DirectionX[3] = 0;
                        DirectionY[3] = 1;
                    }
                }
                else if (lines[i] == '9')
                {
                    PositionInitX[3] = ((i % column) * 20);
                    PositionInitY[3] = ((i / column) * 20);
                }
            }
        }

        void RandomFruit(int index) //Choisi une position aléatoire pour l'emplacement des fruits
        {
            PositionFruitX[index] = ((RandFruit.Next((Width * 20 - 20) / 20) * 20)); //Génération de la position en X
            PositionFruitY[index] = ((RandFruit.Next((Height * 20 - 60) / 20) * 20));
            for (int i = 0; i < PositionWallX.Count; i++)
            {
                if ((PositionFruitX[index] == PositionWallX[i] && PositionFruitY[index] == PositionWallY[i]))
                {
                    PositionFruitX[index] = ((RandFruit.Next((Width * 20 - 20) / 20) * 20)); //Génération de la position en X
                    PositionFruitY[index] = ((RandFruit.Next((Height * 20 - 60) / 20) * 20));
                    i = 0;
                }
            }

        }
        public int GetPositionFruitX(int index) //Accesseur pour la Position en X du fruit
        {
            return PositionFruitX[index];
        }
        public int GetPositionFruitY(int index) //Accesseur pour la Position en Y du fruit
        {
            return PositionFruitY[index];
        }
        public int GetNombreFruits() //Accesseur pour la Position en Y de chaque partie du Snake
        {
            return PositionFruitX.Count;
        }
        public void CallRandomFruit(int index)
        {
            RandomFruit(index);
        }
        public int GetNombreWalls() //Accesseur pour la Position en Y de chaque partie du Snake
        {
            return RangWall.Count;
        }
        public int GetPositionWallsX(int index)
        {
            return PositionWallX[index];
        }
        public int GetPositionWallsY(int index)
        {
            return PositionWallY[index];
        }
        public int GetRangWall(int nb) //Accesseur pour la Position en Y de chaque partie du Snake
        {
            return RangWall[nb];
        }
        public int GetPositionInitX(int id)
        {
            return PositionInitX[id - 1];
        }
        public int GetPositionInitY(int id)
        {
            return PositionInitY[id - 1];
        }
        public int GetPositionInitHX(int id)
        {
            return PositionInitHX[id - 1];
        }
        public int GetPositionInitHY(int id)
        {
            return PositionInitHY[id - 1];
        }
        public int GetDirectionX(int id)
        {
            return DirectionX[id - 1];
        }
        public int GetDirectionY(int id)
        {
            return DirectionY[id - 1];
        }
        public void SetFileName(string filename)
        {
            this.FileName = filename;
            ImportWalls();
            for (int i = 0; i < PositionFruitX.Count; i++)
            {
                RandomFruit(i);
            }
        }
        public int Height
        {
            get
            {
                return rows;
            }
        }
        public int Width
        {
            get
            {
                return column;
            }
        }



    }
}
