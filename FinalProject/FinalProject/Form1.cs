//That Ton, CIST 2342 Final Project
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public const double egg = 1.84;
        public const double beer = 14.48;
        public const double iceCream = 6.97;
        public const double toothPaste = 2.97;
        public const double onion = 2.44;
        public double eggQuantity, beerQuantity, iceCreamQuantity, toothPasteQuantity, onionQuantity, total, totalQuantities;
        public SoundPlayer winSound = new SoundPlayer(@"D:\Study\CIST2342\FinalProject\win.wav");
        public SoundPlayer loseSound = new SoundPlayer(@"D:\Study\CIST2342\FinalProject\crying.wav");

        public Form1()
        {
            InitializeComponent();
            resetButton.Enabled = false;
        }

        private void RuleButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The contestant is shown five grocery items. The goal of the game is to buy a total of between $20 and $22. To do this, you will choose an item, and how many of that item you wants to buy. The price is revealed, multiplied by the quantity of the purchase, which itself is rung up on a cash register. If the total is less than $20, you may choose another item and how much of it, which is added to their total. This continues until you has spent over $20 or used up all five grocery items. The player loses by spending over $22 or by spending less than $20 after using all five items. If you succeeds in spending between $20-$22, you wins the prize.");
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            if (eggInput.Text == "")
                eggQuantity = 0;
            else
                eggQuantity = Convert.ToDouble(eggInput.Text);

            if (beerInput.Text == "")
                beerQuantity = 0;
            else
                beerQuantity = Convert.ToDouble(beerInput.Text);

            if (iceCreamInput.Text == "")
                iceCreamQuantity = 0;
            else
                iceCreamQuantity = Convert.ToDouble(iceCreamInput.Text);

            if (toothpasteInput.Text == "")
                toothPasteQuantity = 0;
            else
                toothPasteQuantity = Convert.ToDouble(toothpasteInput.Text);

            if (onionInput.Text == "")
                onionQuantity = 0;
            else
                onionQuantity = Convert.ToDouble(onionInput.Text);

            total = eggQuantity * egg + beerQuantity * beer + iceCreamQuantity * iceCream + toothPasteQuantity * toothPaste + onionQuantity * onion;
            totalQuantities = eggQuantity + beerQuantity + iceCreamQuantity + toothPasteQuantity + onionQuantity;
            totalBox.Text = "$" + total;

            if (total < 20 && totalQuantities < 5)
                MessageBox.Show("Your total is less than $20, you have $" + (20 - total) + " remaining and " + (5-totalQuantities) + " more items to choose. Please add more item!");
            else if (total > 22)
            {
                checkOutButton.Enabled = false;
                resetButton.Enabled = true;
                resetButton.BackColor = Color.Red;
                loseSound.Play();
                MessageBox.Show("Your total is over $22, you lose!!!");              
            }
            else if (total > 20 && total < 22 && totalQuantities <= 5)
            {
                checkOutButton.Enabled = false;
                resetButton.Enabled = true;
                resetButton.BackColor = Color.Red;
                winSound.Play();
                MessageBox.Show("Congratulation!!! You win $1000!!!");                                                   
            }

            if (totalQuantities > 5)
            {
                checkOutButton.Enabled = false;
                resetButton.Enabled = true;
                resetButton.BackColor = Color.Red;
                loseSound.Play();
                MessageBox.Show("You have chosen more than five items, you lose!!!");                                       
            }
            else if (total < 20 && totalQuantities == 5)
            {
                checkOutButton.Enabled = false;
                resetButton.Enabled = true;
                resetButton.BackColor = Color.Red;
                loseSound.Play();
                MessageBox.Show("You have chosen five items and your total is less than $20, you lose!!!");                                          
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            eggInput.Text = String.Empty;
            beerInput.Text = String.Empty;
            iceCreamInput.Text = String.Empty;
            toothpasteInput.Text = String.Empty;
            onionInput.Text = String.Empty;
            totalBox.Text = String.Empty;
            checkOutButton.Enabled = true;
            winSound.Stop();
            loseSound.Stop();
            resetButton.Enabled = false;
            resetButton.ResetBackColor();
        }
    }
}
