using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakiris
{
    public partial class ClientForm : Form
    {
        IServiceServeur proxy;
        List<Button> buttons;
        int id;
        Map map;
        int tailleDesButtons;

        public ClientForm(IServiceServeur proxy = null, string pseudo = "Anonymous")
        {
            this.proxy = proxy;
            map = new Map(proxy.GetWIDTH(), proxy.GetHEIGHT());
            InitializeComponent();

            buttons = new List<Button>();
            id = -1;
            id = proxy.Login(pseudo);
            tailleDesButtons = 20;

            for (int i = 0; i < map.Size; i++)
            {
                buttons.Add(new Button());
                buttons[i].Location = new Point(map.getX(i) * tailleDesButtons, map.getY(i) * tailleDesButtons);
                buttons[i].Size = new Size(tailleDesButtons, tailleDesButtons);
                buttons[i].Hide();
                Controls.Add(buttons[i]);
            }

            resize();

            timerGetInfoServeur.Enabled = true;
            timerGetInfoServeur.Start();
        }

        private void resize()
        {
            this.Width = (proxy.GetWIDTH() + 1) * 20+200;
            this.Height = (proxy.GetHEIGHT() + 2) * 20;
            panel1.Location = new Point(this.Width-220, 0);
            panel1.Size = new Size(panel1.Size.Width, Height);
        }

        protected override bool ProcessCmdKey(
        ref Message msg,
        Keys keyData)
        {
            if (id != 0)
            {
                switch (Convert.ToInt32(keyData))
                {
                    case 'Z':
                        proxy.moveUP(id - 1);
                        break;
                    case 'S':
                        proxy.moveDOWN(id - 1);
                        break;
                    case 'Q':
                        proxy.moveLEFT(id - 1);
                        break;
                    case 'D':
                        proxy.moveRIGHT(id - 1);
                        break;
                    case 38:
                        proxy.moveUP(id - 1);
                        break;
                    case 40:
                        proxy.moveDOWN(id - 1);
                        break;
                    case 37:
                        proxy.moveLEFT(id - 1);
                        break;
                    case 39:
                        proxy.moveRIGHT(id - 1);
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return true;
        }

        private void timerGetInfoServeur_Tick(object sender, EventArgs e)
        {
            map.reset();
            setWalls();
            setFoods();
            setSnakes();
            SetInfoPlayers();
            draw();
        }

        private void SetInfoPlayers()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Pseudo";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Name = "Score";
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Name = "Temps";
            dataGridView1.Columns[2].Width = 50;
            int start = 0, end = 0, totend = 0;
            string data = proxy.GetInfoPlayers();
            dataGridView1.Rows.Clear();
            dataGridView1.Height = 22 * (proxy.GetNBJOUEUR()+1);
            for (int j = 0; j < proxy.GetNBJOUEUR(); j++)
            {
                data = data.Substring(totend);
                start = 0; 
                end = 0;
                for (int i = start; i < data.Length; i++)
                {
                    if (data[i] == '{')
                        start = i;
                    if (data[i] == '}')
                    {
                        totend = i + 1;
                        end = i;
                        break;
                    }
                }
                string subdata = data.Substring(start, end - start);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == ';')
                    {
                        end = i;
                        break;
                    }
                }
                string pseudo = subdata.Substring(1, end - 1);
                start = end;
                for (int i = start + 1; i < data.Length; i++)
                {
                    if (data[i] == ';')
                    {
                        end = i;
                        break;
                    }
                }
                string score = subdata.Substring(start + 1, end - start - 1);
                start = end;
                for (int i = start + 1; i < data.Length; i++)
                {
                    if (data[i] == '}')
                    {
                        end = i;
                        break;
                    }
                }
                string time = data.Substring(start + 1, end - start -1 );
                dataGridView1.Rows.Add(pseudo,score,time);
            }
        }

        private void draw()
        {
            for (int i = 0; i < map.Size; i++)
            {
                switch (map.getState(i))
                {
                    case State.Blank:
                        buttons[i].Hide();
                        break;
                    case State.Wall:
                        buttons[i].Show();
                        buttons[i].BackColor = Color.Black;
                        break;
                    case State.Bodypart:
                        switch (map.getIDSnake(i))
                        {
                            case 0:
                                buttons[i].BackColor = Color.DarkViolet;
                                break;
                            case 1:
                                buttons[i].BackColor = Color.DarkRed;
                                break;
                            case 2:
                                buttons[i].BackColor = Color.DarkBlue;
                                break;
                            case 3:
                                buttons[i].BackColor = Color.DarkOrange;
                                break;
                        }
                        buttons[i].Show();
                        break;
                    case State.Head:
                        switch (map.getIDSnake(i))
                        {
                            case 0:
                                buttons[i].BackColor = Color.Violet;
                                break;
                            case 1:
                                buttons[i].BackColor = Color.Red;
                                break;
                            case 2:
                                buttons[i].BackColor = Color.Blue;
                                break;
                            case 3:
                                buttons[i].BackColor = Color.Orange;
                                break;
                        }
                        buttons[i].Show();
                        break;
                    case State.Tail:
                        switch (map.getIDSnake(i))
                        {
                            case 0:
                                buttons[i].BackColor = Color.DarkViolet;
                                break;
                            case 1:
                                buttons[i].BackColor = Color.DarkRed;
                                break;
                            case 2:
                                buttons[i].BackColor = Color.DarkBlue;
                                break;
                            case 3:
                                buttons[i].BackColor = Color.DarkOrange;
                                break;
                        }
                        buttons[i].Show();
                        break;
                    case State.Food:
                        buttons[i].Show();
                        buttons[i].BackColor = Color.Green;
                        break;
                    /*case State.NextForTail:
                        buttons[i].Hide();
                        buttons[i].BackColor = Color.White;
                        break;
                    case State.NextForFood:
                        buttons[i].Hide();
                        buttons[i].BackColor = Color.YellowGreen;
                        break;
                    case State.PathToFood:
                        buttons[i].Hide();
                        buttons[i].BackColor = Color.Yellow;
                        break;
                    case State.PathToTail:
                        buttons[i].Show();
                        buttons[i].BackColor = Color.YellowGreen;
                        break;*/
                    default:
                        buttons[i].Show();
                        buttons[i].BackColor = Color.HotPink;
                        break;
                }
            }
        }

        private void setFoods()
        {
            string data = proxy.GetFruit();
            int start = 0, end = 0;
            for (int i = start; i < data.Length; i++)
            {
                if (data[i] == '{')
                    start = i + 1;
                if (data[i] == '}')
                    end = i - 1;
            }
            string subdata = data.Substring(start, end);
            for (int i = 0; i < proxy.GetNBFRUITS(); i++)
            {
                int ok = proxy.GetNBFRUITS();
                int X = Convert.ToInt32(subdata.Substring(0, 3)) / 20;
                int Y = Convert.ToInt32(subdata.Substring(4, 3)) / 20;
                map.setFood(X, Y);
                subdata = subdata.Substring(8);
            }
        }

        private void setSnakes()
        {
            List<Button> ListeCorps = new List<Button>();

            int compteur = ListeCorps.Count;
            List<int> nbCorps = new List<int>();

            while (proxy.GetTOTNBCORPS() != compteur)
            {
                if (proxy.GetTOTNBCORPS() > compteur)
                {
                    ListeCorps.Add(new Button());
                    compteur++;
                }
                else if (proxy.GetTOTNBCORPS() < compteur && compteur > 0)
                {
                    foreach (Button item in ListeCorps)
                    {
                        Controls.Remove(item);
                    }
                    compteur = 0;
                    ListeCorps.Clear();
                }
            }
            string data = proxy.GetData();
            int start = 0, end = 0, totend = 0, X = 0, Y = 0;
            string subdata = "";
            string subX = "";
            string subY = "";
            compteur = 0;
            int nbJoueur = proxy.GetNBJOUEUR();
            for (int j = 0; j < nbJoueur; j++)
            {
                nbCorps.Add(proxy.GetNBCORPS(j));
                data = data.Substring(totend);
                for (int i = start; i < data.Length; i++)
                {
                    if (data[i] == '@')
                        start = i;

                    if (data[i] == '}')
                    {
                        end = i - 1;
                        totend = i + 1;
                        break;
                    }
                }
                if (data != "")
                {
                    subdata = data.Substring(start + 1, end - start);
                    start = 0;
                    end = 0;
                    int id = 0;
                    for (int i = 0; i < subdata.Length; i++)
                    {
                        if (subdata[i] == '|')
                        {
                            end = i;
                            id = Convert.ToInt32(subdata.Substring(start, end));
                            break;
                        }
                    }
                    subX = subdata.Substring(end + 1);
                    for (int k = compteur; k < ListeCorps.Count; k++)
                    {
                        if (data != "")
                        {
                            X = Convert.ToInt32(subX.Substring(0, 3));
                            subY = subX.Substring(4);

                            Y = Convert.ToInt32(subY.Substring(0, 3));

                        }
                        ListeCorps[k].Location = new Point(X, Y);
                        compteur++;
                        if (4 > subY.Length)
                        {
                            break;
                        }
                        else
                            subX = subY.Substring(4);
                    }
                }
            }

            start = 0;
            int nbjoueurs = proxy.GetNBJOUEUR();
            for (int idsnake = 0; idsnake < nbjoueurs; idsnake++)
            {
                int longueur = proxy.GetNBCORPS(idsnake);

                if (start > -1 && start < ListeCorps.Count)
                {
                    map.setHead(ListeCorps[start].Location.X / 20,
                                                ListeCorps[start].Location.Y / 20,
                                                idsnake);
                }

                for (int i = start + 1; i < longueur + start - 1; i++)
                {
                    if (i > -1 && i < ListeCorps.Count)
                    {
                        map.setBodypart(ListeCorps[i].Location.X / 20,
                            ListeCorps[i].Location.Y / 20,
                            idsnake);
                    }
                }

                int corpsId = longueur + start - 1;

                if (corpsId > -1 && corpsId < ListeCorps.Count)
                {
                    map.setTail(ListeCorps[corpsId].Location.X / 20,
                                    ListeCorps[corpsId].Location.Y / 20,
                                    idsnake);
                }

                start += proxy.GetNBCORPS(idsnake);
            }
        }

        private void setWalls()
        {
            for (int i = 0; i < proxy.GetNombreWalls(); i++)
            {
                map.setWall(proxy.GetRangWall(i));
            }
        }
    }

}
