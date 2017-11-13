using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Dame2._0
{
    public partial class Form1 : Form
    {
        private static Button firstBtn;
        private static string bauer;
        Button[] buttons = new Button[64];
        public Form1()
        {
            InitializeComponent();


            /* ... */
            int y = 0;
            int x = 0;
            int zeile = 1;
            int j = 0;
            int ergebnis = 0;


            for (int i = 0; i < buttons.Length; i++)
            {


                buttons[i] = new Button();
                buttons[i].Left = x;
                buttons[i].Top = y;
                buttons[i].Name = Convert.ToString(i);
                //Text nur während der Testens relevant
                buttons[i].Text = Convert.ToString(i);
                buttons[i].MouseClick += BtnClick;
                ergebnis = x / 80;
                if ((zeile % 2 == 0 & ergebnis % 2 == 0) | zeile % 2 != 0 & ergebnis % 2 != 0)
                {
                    buttons[i].BackColor = Color.Black;
                    buttons[i].Tag = Convert.ToString("black");
                    if (zeile < 4)
                    {
                        buttons[i].Image = Properties.Resources.bauerblau;
                        buttons[i].Tag = Convert.ToString("bauerblau");
                    }

                    if (zeile > 5)
                    {
                        buttons[i].Image = Properties.Resources.bauerrot;
                        buttons[i].Tag = Convert.ToString("bauerrot");
                    }
                }
                else
                {
                    buttons[i].BackColor = Color.White;
                    buttons[i].Enabled = false;
                }



                buttons[i].Height = 80;
                buttons[i].Width = 80;
                buttons[i].Parent = this;

                if (j <= 6)
                {

                    x = x + 80;
                    j++;
                }
                else
                {
                    y = y + 80;
                    j = 0;
                    x = 0;
                    zeile++;
                }
            }
        }



        public void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Debug.WriteLine("Button gedrückt");
            Debug.WriteLine(btn.Name);
            int rw = 0;


            if ("bauerblau" == Convert.ToString(btn.Tag) | "bauerrot" == Convert.ToString(btn.Tag))
            {
                Debug.WriteLine(btn.Tag);

                if (firstBtn == null)
                {

                    Debug.WriteLine(firstBtn);
                    firstBtn = (Button)sender;
                    bauer = Convert.ToString(btn.Tag);

                }
                else if (firstBtn == (Button)sender)
                {
                    //doppelte auswahl des gleichen Steins führt zur abwahl
                    firstBtn = null;
                    bauer = null;
                    return;
                }
            }
            else
            {
                if (firstBtn != null)
                {
                    rw = Convert.ToInt32(firstBtn.Name);
                }
                if (bauer == "bauerblau")
                {
                    //Hier wird die Bewegung eingeschränkt                    
                    if (Convert.ToString(rw + 9) == btn.Name)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";
                    }
                    if (btn.Name == Convert.ToString(rw + 7))
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";
                    }
                    //Ist dies ein Angriff?
                    if (Convert.ToString(rw + 18) == btn.Name && buttons[rw + 9].Tag != bauer)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";

                        //Figur töten
                        buttons[rw + 9].Image = null;
                        buttons[rw + 9].Tag = "Black";

                    }//Ist dies ein Angriff?
                    if (Convert.ToString(rw + 14) == btn.Name && buttons[rw + 7].Tag != bauer)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";

                        //Figur töten
                        buttons[rw + 7].Image = null;
                        buttons[rw + 7].Tag = "Black";
                    }
                    //zurücksetzen der Variabeln
                    firstBtn = null;
                    bauer = "";
                }
                if (bauer == "bauerrot")
                {
                    if (Convert.ToString(rw - 9) == btn.Name)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";
                    }

                    if (Convert.ToString(rw - 7) == btn.Name)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";
                    }

                    //Ist dies ein Angriff?
                    if (Convert.ToString(rw - 18) == btn.Name && buttons[rw - 9].Tag != bauer)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";

                        //Figur töten
                        buttons[rw - 9].Image = null;
                        buttons[rw - 9].Tag = "Black";

                    }//Ist dies ein Angriff?
                    if (Convert.ToString(rw - 14) == btn.Name && buttons[rw - 7].Tag != bauer)
                    {
                        //alten Bauer entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen Bauer einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";

                        //Figur töten
                        buttons[rw - 7].Image = null;
                        buttons[rw - 7].Tag = "Black";
                    }
                    //zurücksetzen der Variabeln
                    bauer = "";
                    firstBtn = null;

                }
            }
        }
    }
}
