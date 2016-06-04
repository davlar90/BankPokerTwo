using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace BankPokerTwo
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            lblPot.Parent = pbTable;
            lblPot.BackColor = Color.Transparent;
        }

        public void ShowFlop()
        {
            
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            string[] resources = thisExe.GetManifestResourceNames();


            object flopFirst = Properties.Resources.ResourceManager.GetObject(Table.FlopFirst);
            object flopSecond = Properties.Resources.ResourceManager.GetObject(Table.FlopSecond);
            object flopThird = Properties.Resources.ResourceManager.GetObject(Table.FlopThird);


            pbFlop1.Image = (Image)flopFirst;
            pbFlop2.Image = (Image)flopSecond;
            pbFlop3.Image = (Image)flopThird;

            pbFlop1.Visible = true;
            pbFlop2.Visible = true;
            pbFlop3.Visible = true;

            pbFlop1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFlop2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFlop3.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        public void ShowDealtCards() // Temporär funktion att visa allas tilldelade kort.
        {
            int dealerPos = Table.DealerPos + 1;
            int sbPos = Table.SmallPos + 1;
            int bbPos = Table.BigPos +1;
        
            
            for (int i = 0; i < Player.players.Length; i++)
            {
                int seat = i + 1;
                Player p = new Player();
                p = Player.players[i];
                
                System.Reflection.Assembly thisExe;
                thisExe = System.Reflection.Assembly.GetExecutingAssembly();
                string[] resources = thisExe.GetManifestResourceNames();

                object fc = Properties.Resources.ResourceManager.GetObject(p.FirstCard);
                object sc = Properties.Resources.ResourceManager.GetObject(p.SecondCard);
                //object flopFirst = Properties.Resources.ResourceManager.GetObject(Table.FlopFirst);
                //object flopSecond = Properties.Resources.ResourceManager.GetObject(Table.FlopSecond);
                //object flopThird = Properties.Resources.ResourceManager.GetObject(Table.FlopThird);
                //object turn = Properties.Resources.ResourceManager.GetObject(Table.Turn);
                //object river = Properties.Resources.ResourceManager.GetObject(Table.River);
                object dealerImg = Properties.Resources.ResourceManager.GetObject("dealer");
                object smallBlind = Properties.Resources.ResourceManager.GetObject("small");
                object bigBlind = Properties.Resources.ResourceManager.GetObject("big");
                //pbFlop1.Image = (Image)flopFirst;
                //pbFlop2.Image = (Image)flopSecond;
                //pbFlop3.Image = (Image)flopThird;
                //pbTurn.Image = (Image)turn;
                //pbRiver.Image = (Image)river;
                //pbFlop1.Visible = true;
                //pbFlop2.Visible = true;
                //pbFlop3.Visible = true;
                pbTurn.Visible = true;
                pbRiver.Visible = true;
                //pbFlop1.SizeMode = PictureBoxSizeMode.StretchImage;
                //pbFlop2.SizeMode = PictureBoxSizeMode.StretchImage;
                //pbFlop3.SizeMode = PictureBoxSizeMode.StretchImage;
                //pbTurn.SizeMode = PictureBoxSizeMode.StretchImage;
                //pbRiver.SizeMode = PictureBoxSizeMode.StretchImage;


                ((PictureBox)this.Controls["pbDealer" + dealerPos]).Image = (Image)dealerImg;
                ((PictureBox)this.Controls["pbDealer" + dealerPos]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)this.Controls["pbDealer" + dealerPos]).Visible = true;

                ((PictureBox)this.Controls["pbSmall" + sbPos.ToString()]).Image = (Image)smallBlind;
                ((PictureBox)this.Controls["pbSmall" + sbPos.ToString()]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)this.Controls["pbSmall" + sbPos.ToString()]).Visible = true;

                ((PictureBox)this.Controls["pbBig" + bbPos.ToString()]).Image = (Image)bigBlind;
                ((PictureBox)this.Controls["pbBig" + bbPos.ToString()]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)this.Controls["pbBig" + bbPos.ToString()]).Visible = true;

                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card1"]).Image = (Image)fc;
                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card2"]).Image = (Image)sc;
                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card1"]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card2"]).SizeMode = PictureBoxSizeMode.StretchImage;
                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card1"]).Visible = true;
                ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card2"]).Visible = true;

                int test = i + 1;
                


           
                ((Label)this.Controls["lblPlayer" + test.ToString()]).Text = p.Chips.ToString();
            }
            
        }


        private void btn_addPlayer_Click(object sender, EventArgs e)
        {
            if (tbEnterPlayerName.Text != "")
            {
                Player.AddPlayers(tbEnterPlayerName.Text);
                tbEnterPlayerName.Clear();
                listBoxPlayers.Items.Clear();

                
            }

            else MessageBox.Show("Please enter a Player name!");

        }

        private void listBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUserID.Text = "Playerhand: " + Player.players[listBoxPlayers.SelectedIndex].FirstCard + " " +
                Player.players[listBoxPlayers.SelectedIndex].SecondCard + " Dealer? :" + Player.players[listBoxPlayers.SelectedIndex].IsDealer.ToString() +
                " Player POS: " + Player.players[listBoxPlayers.SelectedIndex].IsPlayerTurn.ToString() + "     " + Player.players[listBoxPlayers.SelectedIndex].Chips.ToString();
            
        }



        private void btnDeal_Click(object sender, EventArgs e)
        {
            
            this.Controls.Clear();
            this.InitializeComponent();

            lblPot.Parent = pbTable;
            lblPot.BackColor = Color.Transparent;

            string sb = Table.SmallBlindSize.ToString();
            string bb = Table.BigBlindSize.ToString();
            double sbDouble = 0;
            double bbDouble = 0;
            double.TryParse(bb, out bbDouble);
            double.TryParse(sb, out sbDouble);

            bbDouble = bbDouble + sbDouble;
            lblPot.Text = bbDouble.ToString();

            lbCards.Items.AddRange(Dealer.dealersDeck);
            if (Table.Turns == 0) Dealer.ChoseDealer();
            Dealer.DealCardsPlayers();

            for (int i = 0; i < Player.players.Length; i++)
            {
                if (Player.players[i] != null) listBoxPlayers.Items.Add(Player.players[i].UserName);
            }

            ShowDealtCards();

        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Dealer.ShuffleDeck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFold_Click(object sender, EventArgs e)
        {


            Dealer.DealFlop();
            ShowFlop();

            

        //     ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card1"]).Visible = false;
        //    ((PictureBox)this.Controls["pbSeat" + seat.ToString() + "Card2"]).Visible = false;

        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            Player.PlayerMoveCall(Table.PlayersTurn);
            ShowDealtCards();
            lblPot.Text = Table.Pot.ToString();
        }



        private void btnBet_Click(object sender, EventArgs e)
        {

            
            string bet = tbBet.Text;
            double betAmmount = 0;
            double.TryParse(bet, out betAmmount);

            betAmmount = double.Parse(bet, CultureInfo.InvariantCulture);

            Player.PlayerMoveBet(Table.PlayersTurn, betAmmount);

            ShowDealtCards();
            lblPot.Text = Table.Pot.ToString();
        }
    }
}
