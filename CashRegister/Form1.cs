//Kristianna Huber
//March 2018
//A cash register program for a fast food diner that will take a customer’s order, process the cost, and calculate the change, prints a receipt.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace CashRegister
{
    public partial class Form1 : Form
    {
        //Constants
        const double EARINGS = 0.99;
        const double NECKLACE = 2.49;
        const double RINGS = 1.89;
        const double TAX = 0.13;

        //Variables
        double subtotal = 0;
        double taxOnly = 0;
        double taxIncluded = 0;
        double tendered = 0;
        double changeGiven = 0;
        int earingsPurchased = 0;
        int necklacesPurchased = 0;
        int ringsPurchased = 0;
        double rings = 0;
        double earings = 0;
        double necklaces = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateTotalButton_Click(object sender, EventArgs e)
        {
            try
            {
                earingsPurchased = Convert.ToInt16(earingsNumberImput.Text);
            }
            catch
            {
                outPutLabel.Text = "You must enter only Numbers";
                return;
            }

            try
            {
                necklacesPurchased = Convert.ToInt16(necklaceNumberImput.Text);
            }
            catch
            {
                outPutLabel.Text = "You must enter only Numbers";
                return;
            }

            try
            {
                ringsPurchased = Convert.ToInt16(ringsNumberImput.Text);
            }
            catch
            {
                outPutLabel.Text = "You must enter only Numbers";
                return;
            }

            //Calculate Subtotal before tax
            subtotal = EARINGS * earingsPurchased + RINGS * ringsPurchased + NECKLACE * necklacesPurchased;
            subTotalNumber.Text = " " + subtotal.ToString("C");

            //Calculate Tax
            taxOnly = subtotal * TAX;
            taxLabelNumber.Text = " " + taxOnly.ToString("C");

            //Calculate the total including tax
            taxIncluded = taxOnly + subtotal;
            totalLabelNumbers.Text = " " + taxIncluded.ToString("C");
        }

        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            //Get the amount tendered
            try
            {
                tendered = Convert.ToInt16(tenderedNumberImput.Text);
            }
            catch
            {
                outPutLabel.Text = "You must enter only Numbers";
                return;
            }
            changeGiven = tendered - taxIncluded;

            //Calculate the change
            changeLabelNumbers.Text = " " + changeGiven.ToString("C"); 
        }

        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            Graphics g = receiptLabel.CreateGraphics();
            Font drawFont = new Font("Consolas", 9, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            receiptLabel.Visible = true;
            rings = RINGS * ringsPurchased;
            necklaces = NECKLACE * necklacesPurchased;
            earings = EARINGS * earingsPurchased;

            //draw Receipt one line at a time with sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.printer);
            player.Play();
            Thread.Sleep(100);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            g.DrawString("Tax", drawFont, drawBrush, 5, 105);
            g.DrawString(" " + taxOnly.ToString("C"), drawFont, drawBrush, 127, 105);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            g.DrawString("Tax", drawFont, drawBrush, 5, 105);
            g.DrawString(" " + taxOnly.ToString("C"), drawFont, drawBrush, 127, 105);
            g.DrawString("Total", drawFont, drawBrush, 5, 120);
            g.DrawString(" " + taxIncluded.ToString("C"), drawFont, drawBrush, 127, 120);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            g.DrawString("Tax", drawFont, drawBrush, 5, 105);
            g.DrawString(" " + taxOnly.ToString("C"), drawFont, drawBrush, 127, 105);
            g.DrawString("Total", drawFont, drawBrush, 5, 120);
            g.DrawString(" " + taxIncluded.ToString("C"), drawFont, drawBrush, 127, 120);
            g.DrawString("Tendered", drawFont, drawBrush, 5, 150);
            g.DrawString(" " + tendered.ToString("C"), drawFont, drawBrush, 127, 150);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            g.DrawString("Tax", drawFont, drawBrush, 5, 105);
            g.DrawString(" " + taxOnly.ToString("C"), drawFont, drawBrush, 127, 105);
            g.DrawString("Total", drawFont, drawBrush, 5, 120);
            g.DrawString(" " + taxIncluded.ToString("C"), drawFont, drawBrush, 127, 120);
            g.DrawString("Tendered", drawFont, drawBrush, 5, 150);
            g.DrawString(" " + tendered.ToString("C"), drawFont, drawBrush, 127, 150);
            g.DrawString("Change", drawFont, drawBrush, 5, 175);
            g.DrawString(" " + changeGiven.ToString("C"), drawFont, drawBrush, 127, 175);
            player.Play();
            Thread.Sleep(1000);
            this.Refresh();
            g.DrawString("Receipt", drawFont, drawBrush, 100, 1);
            g.DrawString("Earings", drawFont, drawBrush, 5, 30);
            g.DrawString(" " + earings.ToString("C"), drawFont, drawBrush, 127, 30);
            g.DrawString("Rings", drawFont, drawBrush, 5, 45);
            g.DrawString(" " + rings.ToString("C"), drawFont, drawBrush, 127, 45);
            g.DrawString("Necklaces", drawFont, drawBrush, 5, 60);
            g.DrawString(" " + necklaces.ToString("C"), drawFont, drawBrush, 127, 60);
            g.DrawString("Subtotal", drawFont, drawBrush, 5, 90);
            g.DrawString(" " + subtotal.ToString("C"), drawFont, drawBrush, 127, 90);
            g.DrawString("Tax", drawFont, drawBrush, 5, 105);
            g.DrawString(" " + taxOnly.ToString("C"), drawFont, drawBrush, 127, 105);
            g.DrawString("Total", drawFont, drawBrush, 5, 120);
            g.DrawString(" " + taxIncluded.ToString("C"), drawFont, drawBrush, 127, 120);
            g.DrawString("Tendered", drawFont, drawBrush, 5, 150);
            g.DrawString(" " + tendered.ToString("C"), drawFont, drawBrush, 127, 150);
            g.DrawString("Change", drawFont, drawBrush, 5, 175);
            g.DrawString(" " + changeGiven.ToString("C"), drawFont, drawBrush, 127, 175);
            g.DrawString("Please come again", drawFont, drawBrush, 5, 222);
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //Reset 
            earingsNumberImput.Clear();
            necklaceNumberImput.Clear();
            ringsNumberImput.Clear();
            tenderedNumberImput.Clear();
            subTotalNumber.Text = " ";
            taxLabelNumber.Text = " ";
            changeLabelNumbers.Text = " ";
            totalLabelNumbers.Text = " ";
            receiptLabel.Text = " ";
            outPutLabel.Text = " ";

            //Reset variables back to 0
            subtotal = 0;
            taxOnly = 0;
            taxIncluded = 0;
            tendered = 0;
            changeGiven = 0;
            earingsPurchased = 0;
            necklacesPurchased = 0;
            ringsPurchased = 0;
            rings = 0;
            earings = 0;
            necklaces = 0;
        }
    }
}
