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

namespace Dame2._0
{
    public partial class Form1 : Form
    {
        private static Button firstBtn;
        private static string bauer;
        public Form1()
        {
            InitializeComponent();
            Button[] buttons = new Button[64]; //als Feld deklarieren!

            /* ... */
            int y = 0;
            int x = 0;
            int zeile = 1;
            int j = 0;
            int ergebnis = 0;
            
            
            for (int i = 0; i < buttons.Length; i++) //im Konstruktor der Form nach InitializeComponent() aufrufen
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

        


        private void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Debug.WriteLine("Button gedrückt");
            Debug.WriteLine(btn.Name);
            
            
            String temp = "";


            if ("bauerblau" == btn.Tag | "bauerrot" == btn.Tag)
            {
                Debug.WriteLine(btn.Tag);
                
                if (firstBtn == null)
                {
                    
                    Debug.WriteLine(firstBtn);
                    firstBtn = (Button) sender;
                    bauer = Convert.ToString(btn.Tag);
                }
                
            
            }
            else
            {
                if (bauer == "bauerblau")
                {
                    //alten Bauer entfernen
                    firstBtn.Image = null;
                    firstBtn.Tag = "Black";

                    //neuen Bauer einsetzen
                    btn.Image = Properties.Resources.bauerblau;
                    btn.Tag = "bauerblau";

                    //zurücksetzen der Variabeln
                    firstBtn = null;                   
                    bauer = "";
                    
                }
                if (bauer == "bauerrot")
                {
                    //alten Bauer entfernen
                    firstBtn.Image = null;
                    firstBtn.Tag = "Black";

                    //neuen Bauer einsetzen
                    btn.Image = Properties.Resources.bauerrot;
                    firstBtn = null;

                    //zurücksetzen der Variabeln
                    bauer = "";
                    btn.Tag = "bauerrot";
                }
                
             

            }


            
            
        }

    }
}
