using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otpornici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int br1 = 0, br2 = 0, br3 = 0, temp = 0, zadnji = 4, prije = 0;
        double multi = 1, racun = 0, tol = 20;
        string textTemp = "";

        Color[] prveTri = { Color.Black , Color.Brown,Color.Red,Color.Orange,Color.Yellow,
        Color.Green,Color.Blue,Color.Pink,Color.Gray,Color.White};

        Color[] mul = {Color.Silver,Color.Gold,Color.Black , Color.Brown,Color.Red,Color.Orange,Color.Yellow,
        Color.Green,Color.Blue,Color.Pink};

        Color[] tole = {Color.Silver,Color.Gold,Color.Brown,Color.Red,
        Color.Green,Color.Blue,Color.Pink,Color.Gray};

        Color[] tem = { Color.Brown, Color.Red, Color.Orange, Color.Yellow };

        Point[] lokacije = new Point[7];
        Point[] labeli = new Point[7];
        Point zadnje;

        private void Save()
        {
            lokacije[0] = comboBox1.Location;
            lokacije[1] = comboBox2.Location;
            lokacije[2] = comboBox3.Location;
            lokacije[3] = comboBox4.Location;
            lokacije[4] = comboBox5.Location;
            lokacije[5] = comboBox6.Location;

            labeli[0] = label2.Location;
            labeli[1] = label3.Location;
            labeli[2] = label4.Location;
            labeli[3] = label5.Location;
            labeli[4] = label6.Location;
            labeli[5] = label7.Location;
        }

        private void dodaj(ComboBox comboBox)
        {
            comboBox.Items.Add("Black");
            comboBox.Items.Add("Brown");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Orange");
            comboBox.Items.Add("Yellow");
            comboBox.Items.Add("Green");
            comboBox.Items.Add("Blue");
            comboBox.Items.Add("Pink");
            comboBox.Items.Add("Grey");
            comboBox.Items.Add("White");
        }

        private void dodajMulti(ComboBox comboBox)
        {
            comboBox.Items.Add("Silver");
            comboBox.Items.Add("Gold");
            comboBox.Items.Add("Black");
            comboBox.Items.Add("Brown");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Orange");
            comboBox.Items.Add("Yellow");
            comboBox.Items.Add("Green");
            comboBox.Items.Add("Blue");
            comboBox.Items.Add("Pink");
        }

        private void dodajTol(ComboBox comboBox)
        {
            comboBox.Items.Add("Silver");
            comboBox.Items.Add("Gold");
            comboBox.Items.Add("Brown");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Green");
            comboBox.Items.Add("Blue");
            comboBox.Items.Add("Pink");
            comboBox.Items.Add("Grey");
        }

        private void dodajTemp(ComboBox comboBox)
        {
            comboBox.Items.Add("Brown");
            comboBox.Items.Add("Red");
            comboBox.Items.Add("Orange");
            comboBox.Items.Add("Yellow");
        }

        private void Bands(ComboBox comboBox)
        {
            comboBox.Items.Add("4");
            comboBox.Items.Add("5");
            comboBox.Items.Add("6");
        }

        private void izracunaj()
        {
            if (zadnji != 4) racun = (br1 * 100 + br2 * 10 + br3) * multi;
            else racun = (br1 * 10 + br2) * multi;

            if (multi >= 1000000)
            {
                textBox1.Text = "Resistor: " + (racun / 1000000).ToString() + "M Ohms " + tol.ToString() + "%" + textTemp;
            }
            else if (multi >= 1000)
            {
                textBox1.Text = "Resistor: " + (racun / 1000).ToString() + "k Ohms " + tol.ToString() + "%" + textTemp;
            }
            else
            {
                textBox1.Text = "Resistor: " + racun.ToString() + " Ohms " + tol.ToString() + "%" + textTemp;
            }

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 0)
            {
                prije = 0;

                textTemp = "";
                comboBox3.Enabled = false;
                comboBox3.Visible = false;
                comboBox6.Enabled = false;
                comboBox6.Visible = false;
                label7.Enabled = false;
                label7.Visible = false;
                label4.Enabled = false;
                label4.Visible = false;
                textBox7.Visible = false;
                textBox7.Enabled = false;
                textBox4.Visible = false;
                textBox4.Enabled = false;

                zadnje = textBox5.Location;

                textBox5.Location = textBox4.Location;
                textBox6.Location = new Point(textBox6.Location.X - 5, textBox6.Location.Y);

                comboBox4.Location = lokacije[2];
                comboBox5.Location = lokacije[3];

                label5.Location = labeli[2];
                label6.Location = labeli[3];

                if (zadnji == 5) this.Size = new Size(this.Size.Width, this.Size.Height - 80);
                else if (zadnji == 6) this.Size = new Size(this.Size.Width, this.Size.Height - 160);
                zadnji = 4;
            }
            else if (comboBox7.SelectedIndex == 1)
            {
                prije = 1;

                textTemp = "";
                comboBox6.Enabled = false;
                comboBox6.Visible = false;
                label7.Enabled = false;
                label7.Visible = false;
                comboBox3.Enabled = true;
                comboBox3.Visible = true;
                label4.Visible = true;
                label4.Enabled = true;
                comboBox4.Location = lokacije[3];
                comboBox5.Location = lokacije[4];
                label5.Location = labeli[3];
                label6.Location = labeli[4];
                textBox7.Visible = false;
                textBox7.Enabled = false;
                if (comboBox3.Text != "")
                {
                    textBox4.Visible = true;
                    textBox4.Enabled = true;
                }

                if (textBox5.Location != zadnje)
                    textBox6.Location = new Point(textBox6.Location.X + 5, textBox6.Location.Y);
                textBox5.Location = zadnje;

                if (zadnji == 4) this.Size = new Size(this.Size.Width, this.Size.Height + 80);
                else if (zadnji == 6) this.Size = new Size(this.Size.Width, this.Size.Height - 80);
                zadnji = 5;
            }
            else if (comboBox7.SelectedIndex == 2)
            {
                prije = 2;

                textTemp = "\n Temp. Coeff. 0ppm";
                comboBox3.Enabled = true;
                comboBox3.Visible = true;
                label4.Visible = true;
                label4.Enabled = true;
                comboBox6.Enabled = true;
                comboBox6.Visible = true;
                label7.Enabled = true;
                label7.Visible = true;
                if (comboBox6.Text != "")
                {
                    textBox7.Visible = true;
                    textBox7.Enabled = true;
                }
                if (comboBox3.Text != "")
                {
                    textBox4.Visible = true;
                    textBox4.Enabled = true;
                }

                if (textBox5.Location != zadnje)
                    textBox6.Location = new Point(textBox6.Location.X + 5, textBox6.Location.Y);
                textBox5.Location = zadnje;

                comboBox4.Location = lokacije[3];
                comboBox5.Location = lokacije[4];
                label5.Location = labeli[3];
                label6.Location = labeli[4];

                if (zadnji == 5) this.Size = new Size(this.Size.Width, this.Size.Height + 80);
                else if (zadnji == 4) this.Size = new Size(this.Size.Width, this.Size.Height + 160);
                zadnji = 6;
            }
            izracunaj();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Visible = true;

            textBox7.BackColor = tem[comboBox6.SelectedIndex];

            if (comboBox6.SelectedIndex == 0) temp = 100;
            else if (comboBox6.SelectedIndex == 1) temp = 50;
            else if (comboBox6.SelectedIndex == 2) temp = 15;
            else if (comboBox6.SelectedIndex == 3) temp = 25;

            textTemp = "\n Temp. Coeff. " + temp.ToString() + "ppm";
            izracunaj();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Visible = true;

            textBox6.BackColor = tole[comboBox5.SelectedIndex];

            if ( comboBox5.SelectedIndex == 0) tol = 10;
            else if (comboBox5.SelectedIndex == 1) tol = 5;
            else if (comboBox5.SelectedIndex == 2) tol = 1;
            else if (comboBox5.SelectedIndex == 3) tol = 2;
            else if (comboBox5.SelectedIndex == 4) tol = 0.5;
            else if (comboBox5.SelectedIndex == 5) tol = 0.25;
            else if (comboBox5.SelectedIndex == 6) tol = 0.1;
            else if (comboBox5.SelectedIndex == 7) tol = 0.05;
            izracunaj();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Visible = true;

            textBox5.BackColor = mul[comboBox4.SelectedIndex];

            multi = 0.01 * Math.Pow(10, Convert.ToDouble(comboBox4.SelectedIndex));

            izracunaj();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Visible = true;

            br3 = comboBox3.SelectedIndex;

            textBox4.BackColor = prveTri[br3];

            izracunaj();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;

            br2 = comboBox2.SelectedIndex;

            textBox3.BackColor = prveTri[br2];

            izracunaj();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;

            br1 = comboBox1.SelectedIndex;

            textBox2.BackColor = prveTri[br1];

            izracunaj();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dodaj(comboBox1);
            dodaj(comboBox2);
            dodaj(comboBox3);

            dodajMulti(comboBox4);

            dodajTol(comboBox5);

            dodajTemp(comboBox6);

            Bands(comboBox7);

            Save();

            comboBox7.SelectedIndex = 0;
        }
    }
}
