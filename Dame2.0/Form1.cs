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
        private static string spielstein;
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


            if ("bauerblau" == Convert.ToString(btn.Tag) | "bauerrot" == Convert.ToString(btn.Tag) | "damerot" == Convert.ToString(btn.Tag) | "dameblau" == Convert.ToString(btn.Tag))
            {
                Debug.WriteLine(btn.Tag);

                if (firstBtn == null)
                {

                    Debug.WriteLine(firstBtn);
                    firstBtn = (Button)sender;
                    spielstein = Convert.ToString(btn.Tag);

                }
                else if (firstBtn == (Button)sender)
                {
                    //doppelte auswahl des gleichen Steins führt zur abwahl
                    firstBtn = null;
                    spielstein = null;
                    return;
                }
            }
            else
            {
                if (firstBtn != null)
                {
                    rw = Convert.ToInt32(firstBtn.Name);
                }
                if (spielstein == "bauerblau")
                {
                    //Hier wird die Bewegung eingeschränkt                    
                    if (Convert.ToString(rw + 9) == btn.Name)
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";
                    }
                    if (btn.Name == Convert.ToString(rw + 7))
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";
                    }
                    //Ist dies ein Angriff?
                    // Exception abfangen für 55 -> 62
                    if (rw == 55)
                    {
                        rw = 54;
                    }
                    if (Convert.ToString(rw + 18) == btn.Name && buttons[rw + 9].Tag == "bauerrot" || buttons[rw + 9].Tag == "damerot")
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";

                        //Figur töten
                        buttons[rw + 9].Image = null;
                        buttons[rw + 9].Tag = "Black";

                    }//Ist dies ein Angriff?
                    if (Convert.ToString(rw + 14) == btn.Name && buttons[rw + 7].Tag == "bauerrot" || buttons[rw + 7].Tag == "damerot")
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerblau;
                        btn.Tag = "bauerblau";

                        //Figur töten
                        buttons[rw + 7].Image = null;
                        buttons[rw + 7].Tag = "Black";
                    }
                    //zurücksetzen der Variabeln + prüfen auf dame
                    switch (Convert.ToInt64(btn.Name))
                    {
                        case 56:
                        case 58:
                        case 60:
                        case 62:
                            btn.Image = Properties.Resources.dameblau;
                            btn.Tag = "dameblau";
                            break;
                    }
                    firstBtn = null;
                    spielstein = "";
                }
                if (spielstein == "dameblau")
                {
                    //Dame Bewegungsoptionen
                    int diagonal1 = 9;
                    int diagonal2 = 7;
                    bool betrue = false;
                    //Bewegung oben links
                    while (Convert.ToInt32(firstBtn.Name) - diagonal1 != Convert.ToInt32(btn.Name))
                    {
                        if (buttons[Convert.ToInt32(firstBtn.Name) - diagonal1].Tag == "Black")
                        {
                            betrue = true;      
                        }
                        else
                        {
                            betrue = false;
                        }
                        
                        diagonal1 = diagonal1 + 9;

                        
                    }
                    if (betrue == true)
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.dameblau;
                        btn.Tag = "dameblau";
                    }
                    spielstein = "";
                    firstBtn = null;
                }
                if (spielstein == "bauerrot")
                {
                    if (Convert.ToString(rw - 9) == btn.Name)
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";
                    }

                    if (Convert.ToString(rw - 7) == btn.Name)
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";
                    }

                    //Ist dies ein Angriff?
                    //Exception abfangen für 8 -> 1
                    if (rw == 8)
                    {
                        rw = 9;
                    }                        
                    if (Convert.ToString(rw - 18) == btn.Name && buttons[rw - 9].Tag == "bauerblau" || buttons[rw - 9].Tag == "dameblau")
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";

                        //Figur töten
                        buttons[rw - 9].Image = null;
                        buttons[rw - 9].Tag = "Black";

                    }//Ist dies ein Angriff?
                    if (Convert.ToString(rw - 14) == btn.Name && buttons[rw - 7].Tag == "bauerblau" || buttons[rw - 7].Tag == "dameblau")
                    {
                        //alten spielstein entfernen
                        firstBtn.Image = null;
                        firstBtn.Tag = "Black";

                        //neuen spielstein einsetzen
                        btn.Image = Properties.Resources.bauerrot;
                        btn.Tag = "bauerrot";

                        //Figur töten
                        buttons[rw - 7].Image = null;
                        buttons[rw - 7].Tag = "Black";
                    }
                    //zurücksetzen der Variabeln + prüfen auf dame
                    switch (Convert.ToInt64(btn.Name))
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                            btn.Image = Properties.Resources.damerot;
                            btn.Tag = "damerot";
                            break;

                    }
                    spielstein = "";
                    firstBtn = null;

                }
                if (spielstein == "damerot")
                {
                    spielstein = "";
                    firstBtn = null;
                }
            }
        }
    }
}
