using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakiris
{
    public partial class MapEditor : Form
    {
        List<Button> walls;

        List<Snake> ListeDeJoueurs;

        string cheminFichierOuvert;
        int rows;
        int column;

        public MapEditor()
        {
            InitializeComponent();
            walls = new List<Button>();
            ListeDeJoueurs = new List<Snake>();

            ListeDeJoueurs.Add(new Snake());
            ListeDeJoueurs.Add(new Snake());
            ListeDeJoueurs.Add(new Snake());
            ListeDeJoueurs.Add(new Snake());

            rows = 13;
            column = 29;
            this.Width = column * 20 + 120;
            panel1.Location = new Point(this.Width - 115, panel1.Location.Y);
            InitialisationGrid();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        void InitialisationGrid()
        {
            foreach (Button item in walls)
            {
                Controls.Remove(item);
            }
            walls.Clear();
            int compteur = 0;
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < column; i++)
                {
                    walls.Add(new Button());
                    walls[compteur].Location = new Point(20 * i, 20 * j);
                    walls[compteur].Size = new Size(20, 20);
                    walls[compteur].MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickWalls);
                    walls[compteur].BackColor = Color.White;
                    Controls.Add(walls[compteur]);
                    compteur++;
                }
            }
        }
        void OnClickWalls(Object sender, MouseEventArgs e)
        {
            Button ButtonClicked = (Button)sender;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (ButtonClicked.BackColor == Color.Black)
                    {
                        ButtonClicked.BackColor = Color.White;
                    }
                    else if (ButtonClicked.BackColor == Color.White)
                    {
                        ButtonClicked.BackColor = Color.Black;
                    }
                    else if (ButtonClicked.BackColor == Color.DarkRed)
                    {
                        if (!ListeDeJoueurs[0].SecondPosition)
                        {
                            for (int i = 0; i < walls.Count; i++)
                            {
                                walls[i].Enabled = true;
                            }

                            Charger("map.temp");

                            ListeDeJoueurs[0].SecondPosition = true;
                            System.IO.FileInfo fi = new System.IO.FileInfo("map.temp");
                            fi.Delete();
                            ButtonClicked.BackColor = Color.DarkRed;
                        }
                    }
                    else if (ButtonClicked.BackColor == Color.DeepPink)
                    {
                        if (!ListeDeJoueurs[3].SecondPosition)
                        {
                            for (int i = 0; i < walls.Count; i++)
                            {
                                walls[i].Enabled = true;
                            }
                            Charger("map.temp");

                            ButtonClicked.BackColor = Color.DeepPink;
                            ListeDeJoueurs[3].SecondPosition = true;
                            System.IO.FileInfo fi = new System.IO.FileInfo("map.temp");
                            fi.Delete();
                        }
                    }
                    else if (ButtonClicked.BackColor == Color.DarkBlue)
                    {
                        if (!ListeDeJoueurs[1].SecondPosition)
                        {
                            for (int i = 0; i < walls.Count; i++)
                            {
                                walls[i].Enabled = true;
                            }
                            Charger("map.temp");
                            ButtonClicked.BackColor = Color.DarkBlue;
                            ListeDeJoueurs[1].SecondPosition = true;
                            System.IO.FileInfo fi = new System.IO.FileInfo("map.temp");
                            fi.Delete();
                        }
                    }
                    else if (ButtonClicked.BackColor == Color.GreenYellow)
                    {
                        if (!ListeDeJoueurs[2].SecondPosition)
                        {
                            for (int i = 0; i < walls.Count; i++)
                            {
                                walls[i].Enabled = true;
                            }
                            Charger("map.temp");
                            ButtonClicked.BackColor = Color.GreenYellow;
                            ListeDeJoueurs[2].SecondPosition = true;
                            System.IO.FileInfo fi = new System.IO.FileInfo("map.temp");
                            fi.Delete();
                        }
                    }

                    break;
                case MouseButtons.Right:
                    int index = 0;
                    if (ButtonClicked.BackColor == Color.Blue && (ListeDeJoueurs[1].SecondPosition))
                    {
                        ButtonClicked.BackColor = Color.White;
                        ListeDeJoueurs[1].InitialPosition = false;
                        foreach (Button item in walls)
                        {
                            if (item.BackColor == Color.DarkBlue)
                                item.BackColor = Color.White;
                        }
                        ListeDeJoueurs[1].SecondPosition = false;
                        break;
                    }
                    else if (ButtonClicked.BackColor == Color.Yellow && (ListeDeJoueurs[2].SecondPosition))
                    {
                        ButtonClicked.BackColor = Color.White;
                        ListeDeJoueurs[2].InitialPosition = false;
                        foreach (Button item in walls)
                        {
                            if (item.BackColor == Color.GreenYellow)
                                item.BackColor = Color.White;
                        }
                        ListeDeJoueurs[2].SecondPosition = false;
                        break;
                    }
                    else if (ButtonClicked.BackColor == Color.Pink && (ListeDeJoueurs[3].SecondPosition))
                    {
                        ButtonClicked.BackColor = Color.White;
                        ListeDeJoueurs[3].InitialPosition = false;
                        foreach (Button item in walls)
                        {
                            if (item.BackColor == Color.DeepPink)
                                item.BackColor = Color.White;
                        }
                        ListeDeJoueurs[3].SecondPosition = false;
                        break;
                    }
                    else if (ButtonClicked.BackColor == Color.Red && (ListeDeJoueurs[0].SecondPosition))
                    {
                        ButtonClicked.BackColor = Color.White;
                        ListeDeJoueurs[0].InitialPosition = false;
                        foreach (Button item in walls)
                        {
                            if (item.BackColor == Color.DarkRed)
                                item.BackColor = Color.White;
                        }
                        ListeDeJoueurs[0].SecondPosition = false;
                        break;
                    }
                    else if (ListeDeJoueurs[0].InitialPosition && ListeDeJoueurs[1].InitialPosition && ListeDeJoueurs[0].SecondPosition && ListeDeJoueurs[1].SecondPosition && !ListeDeJoueurs[2].InitialPosition && (ButtonClicked.BackColor == Color.White))
                    {
                        ButtonClicked.BackColor = Color.Yellow;
                        ListeDeJoueurs[2].InitialPosition = true;
                        for (int i = 0; i < walls.Count; i++)
                        {
                            walls[i].Enabled = false;
                            if (walls[i].Equals(ButtonClicked))
                            {
                                index = i;
                            }
                        }
                        Sauvegarder("map.temp");
                        walls[index].Enabled = true;
                        ColorRightClick(index, Color.GreenYellow);

                    }
                    else if (ListeDeJoueurs[0].InitialPosition && ListeDeJoueurs[1].InitialPosition && ListeDeJoueurs[0].SecondPosition && ListeDeJoueurs[1].SecondPosition && ListeDeJoueurs[2].InitialPosition && !ListeDeJoueurs[3].InitialPosition && ListeDeJoueurs[2].SecondPosition && (ButtonClicked.BackColor == Color.White))
                    {
                        ButtonClicked.BackColor = Color.Pink;
                        ListeDeJoueurs[3].InitialPosition = true;
                        for (int i = 0; i < walls.Count; i++)
                        {
                            walls[i].Enabled = false;
                            if (walls[i].Equals(ButtonClicked))
                            {
                                index = i;
                            }
                        }
                        Sauvegarder("map.temp");
                        walls[index].Enabled = true;
                        ColorRightClick(index, Color.DeepPink);

                    }
                    else if (ListeDeJoueurs[0].InitialPosition && !ListeDeJoueurs[1].InitialPosition && ListeDeJoueurs[0].SecondPosition && (ButtonClicked.BackColor == Color.White))
                    {
                        ButtonClicked.BackColor = Color.Blue;
                        ListeDeJoueurs[1].InitialPosition = true;
                        for (int i = 0; i < walls.Count; i++)
                        {
                            walls[i].Enabled = false;
                            if (walls[i].Equals(ButtonClicked))
                            {
                                index = i;
                            }
                        }
                        Sauvegarder("map.temp");
                        walls[index].Enabled = true;
                        ColorRightClick(index, Color.DarkBlue);
                    }
                    else if ((!ListeDeJoueurs[0].InitialPosition) && (ButtonClicked.BackColor == Color.White))
                    {
                        ButtonClicked.BackColor = Color.Red;
                        ListeDeJoueurs[0].InitialPosition = true;
                        for (int i = 0; i < walls.Count; i++)
                        {
                            walls[i].Enabled = false;
                            if (walls[i].Equals(ButtonClicked))
                            {
                                index = i;
                            }
                        }
                        Sauvegarder("map.temp");
                        walls[index].Enabled = true;
                        ColorRightClick(index, Color.DarkRed);
                    }
                    break;
            }
        }

        private void Sauvegarder(string Filename)
        {
            cheminFichierOuvert = Filename;
            if (!string.IsNullOrEmpty(cheminFichierOuvert))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(cheminFichierOuvert);
                fi.Delete();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(cheminFichierOuvert, true))
                {
                    file.Write(rows);
                    file.Write("|");
                    file.Write(column);
                    file.Write("|");
                    for (int i = 0; i < walls.Count; i++)
                    {
                        if (walls[i].BackColor == Color.Black)
                        {
                            file.Write("1");
                        }
                        else if (walls[i].BackColor == Color.White)
                            file.Write("0");
                        else if (walls[i].BackColor == Color.Red)
                            file.Write("2");
                        else if (walls[i].BackColor == Color.DarkRed)
                            file.Write("3");
                        else if (walls[i].BackColor == Color.Blue)
                            file.Write("4");
                        else if (walls[i].BackColor == Color.DarkBlue)
                            file.Write("5");
                        else if (walls[i].BackColor == Color.Yellow)
                            file.Write("6");
                        else if (walls[i].BackColor == Color.GreenYellow)
                            file.Write("7");
                        else if (walls[i].BackColor == Color.Pink)
                            file.Write("8");
                        else if (walls[i].BackColor == Color.DeepPink)
                            file.Write("9");
                    }
                }
            }
        }
        void Charger(string Filename)
        {
            string lines = System.IO.File.ReadAllText(Filename);
            cheminFichierOuvert = Filename;
            int start = 0, end = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == '|')
                {
                    start = i;
                    break;
                }
            }
            if (rows != Convert.ToInt32(lines.Substring(0, start)))
            {
                rows = Convert.ToInt32(lines.Substring(0, start));
            }
            for (int i = start; i < lines.Length; i++)
            {
                if (lines[i] == '|')
                {
                    end = i;
                    break;
                }
            }
            start += 1;
            if (column != Convert.ToInt32(lines.Substring(start, end)))
            {
                column = Convert.ToInt32(lines.Substring(start, end));
            }

            SetHeight(rows);
            SetWidth(column);
            if (Filename != "map.temp")
                InitialisationGrid();
            numericUpDown1.Value = Convert.ToDecimal(rows);
            numericUpDown2.Value = Convert.ToDecimal(column);
            lines = lines.Substring(start + end + 1);
            for (int i = 0; i < walls.Count; i++)
            {
                if (lines[i] == '0')
                    walls[i].BackColor = Color.White;
                else if (lines[i] == '1')
                    walls[i].BackColor = Color.Black;
                else if (lines[i] == '2')
                {
                    walls[i].BackColor = Color.Red;
                    ListeDeJoueurs[0].InitialPosition = true;
                }
                else if (lines[i] == '3')
                {
                    walls[i].BackColor = Color.DarkRed;
                    ListeDeJoueurs[0].SecondPosition = true;
                }
                else if (lines[i] == '4')
                {
                    walls[i].BackColor = Color.Blue;
                    ListeDeJoueurs[1].InitialPosition = true;
                }
                else if (lines[i] == '5')
                {
                    walls[i].BackColor = Color.DarkBlue;
                    ListeDeJoueurs[1].SecondPosition = true;
                }
                else if (lines[i] == '6')
                {
                    walls[i].BackColor = Color.Yellow;
                    ListeDeJoueurs[2].InitialPosition = true;
                }
                else if (lines[i] == '7')
                {
                    walls[i].BackColor = Color.GreenYellow;
                    ListeDeJoueurs[2].SecondPosition = true;
                }
                else if (lines[i] == '8')
                {
                    walls[i].BackColor = Color.Pink;
                    ListeDeJoueurs[3].InitialPosition = true;
                }
                else if (lines[i] == '9')
                {
                    walls[i].BackColor = Color.DeepPink;
                    ListeDeJoueurs[3].SecondPosition = true;
                }
            }
        }

        void Nouveau()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].BackColor = Color.White;
                walls[i].Enabled = true;
            }
            ListeDeJoueurs[0].InitialPosition = false;
            ListeDeJoueurs[0].SecondPosition = false;
            ListeDeJoueurs[1].InitialPosition = false;
            ListeDeJoueurs[1].SecondPosition = false;
            ListeDeJoueurs[2].InitialPosition = false;
            ListeDeJoueurs[2].SecondPosition = false;
            ListeDeJoueurs[3].InitialPosition = false;
            ListeDeJoueurs[3].SecondPosition = false;
            cheminFichierOuvert = "";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"\Maps";
            saveFileDialog1.Filter = "MAP files (*.map)|*.map";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Sauvegarder(saveFileDialog1.FileName);
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"\Maps";
            openFileDialog1.Filter = "Map files|*.map";
            openFileDialog1.Title = "Select a MAP File";
            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"\Maps");
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Charger(openFileDialog1.FileName);
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            SetHeight(Convert.ToInt32(numericUpDown1.Value));
            SetWidth(Convert.ToInt32(numericUpDown2.Value));
            Nouveau();
            InitialisationGrid();
        }
        private void ColorRightClick(int index, Color couleur)
        {
            if (index % column != 0)
            {
                walls[index - 1].BackColor = couleur;
                walls[index - 1].Enabled = true;
            }
            if (index % column != column - 1)
            {
                walls[index + 1].BackColor = couleur;
                walls[index + 1].Enabled = true;
            }
            if (index - column > 0)
            {
                walls[index - column].BackColor = couleur;
                walls[index - column].Enabled = true;
            }
            if (index < rows * (column - 1))
            {
                walls[index + column].BackColor = couleur;
                walls[index + column].Enabled = true;
            }
        }
        public void SetHeight(int Height)
        {
            this.Height = Height * 20 + 40;
            rows = Height;
        }
        public void SetWidth(int Width)
        {
            column = Width;
            this.Width = Width * 20 + 120;
            panel1.Location = new Point(this.Width - 115, panel1.Location.Y);
        }
    }
}
