using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Media;



namespace secretWordClient
{
    public delegate void test_letter(string str);
    public partial class Form1 : Form
    {
        TcpClient client;
        IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
        NetworkStream nstream;
        BinaryReader reader;
        BinaryWriter writer;
        int count = 0;
        string connect="true";
        string letter;
        string win;
        string lose;

        string word;
        event test_letter chk_letter;
        string input;
        string pl_word;
        string dashed = "";
        char[] wordarr;
        int[] letter_pos;
        bool exist = false;

        private BackgroundWorker Test = new BackgroundWorker();
        private BackgroundWorker BtnTest = new BackgroundWorker();
        private BackgroundWorker Winner = new BackgroundWorker();


        public Form1()
        {
            InitializeComponent();
            LoadLab.Parent = pictureBox1;
            //Subscribe the event
            this.chk_letter += new test_letter(Form1_ChkLtr);
            //For enable and disable Player1&2
            Test.DoWork += Test_DoWork;
            //For Disable Buttons
            BtnTest.DoWork += BtnTest_DoWork;
            Winner.DoWork += Winner_DoWork;
        }

        private void Winner_DoWork(object sender, DoWorkEventArgs e)
        {
            if (letter_pos.All(E => E == 1))
            {
                win = "win";
                writer.Write(win);
                count++;
                writer.Write(count);
                MessageBox.Show("CONGRATS! You Win","Player(2)");

                string message = "  Do you want to play again ?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string title = "Result";
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.No)
                {
                    reader.Close();
                    nstream.Close();
                    client.Close();
                   
                }
                if (result == DialogResult.Yes)
                {
               

                    this.Invoke(new MethodInvoker(delegate () { this.Enabled = true; }));
                    


                }
                


            }
            else if (letter_pos.All(E => E == 1) && reader.ReadString()=="win")
            {
              
                MessageBox.Show("Player(1) Lose!","Player(2)");
            }
        }

        private void BtnTest_DoWork(object sender, DoWorkEventArgs e)
        { 
                switch (letter)
                {
                    case "A":
                        this.Invoke(new MethodInvoker(delegate () { this.button_A.Enabled = false; }));
                        break;
                    case "Q":
                        this.Invoke(new MethodInvoker(delegate () { this.button_Q.Enabled = false; }));
                        break;
                    case "W":
                        this.Invoke(new MethodInvoker(delegate () { this.button_W.Enabled = false; }));
                        break;
                    case "E":
                        this.Invoke(new MethodInvoker(delegate () { this.button_E.Enabled = false; }));
                        break;
                    case "R":
                        this.Invoke(new MethodInvoker(delegate () { this.button_R.Enabled = false; }));
                        break;
                    case "T":
                       this.Invoke(new MethodInvoker(delegate () { this.button_T.Enabled = false; }));
                        break;
                    case "Y":
                        this.Invoke(new MethodInvoker(delegate () { this.button_Y.Enabled = false; }));
                        break;
                    case "U":
                        this.Invoke(new MethodInvoker(delegate () { this.button_U.Enabled = false; }));
                        break;
                    case "I":
                        this.Invoke(new MethodInvoker(delegate () { this.button_I.Enabled = false; }));
                        break;
                    case "O":
                        this.Invoke(new MethodInvoker(delegate () { this.button_O.Enabled = false; }));
                        break;
                    case "P":
                        this.Invoke(new MethodInvoker(delegate () { this.button_P.Enabled = false; }));
                        break;
                    case "S":
                        this.Invoke(new MethodInvoker(delegate () { this.button_S.Enabled = false; }));
                        break;
                    case "D":
                        this.Invoke(new MethodInvoker(delegate () { this.button_D.Enabled = false; }));
                        break;
                    case "F":
                        this.Invoke(new MethodInvoker(delegate () { this.button_F.Enabled = false; }));
                        break;
                    case "G":
                        this.Invoke(new MethodInvoker(delegate () { this.button_G.Enabled = false; }));
                        break;
                    case "H":
                        this.Invoke(new MethodInvoker(delegate () { this.button_H.Enabled = false; }));
                        break;
                    case "J":
                        this.Invoke(new MethodInvoker(delegate () { this.button_J.Enabled = false; }));
                        break;
                    case "K":
                        this.Invoke(new MethodInvoker(delegate () { this.button_K.Enabled = false; }));
                        break;
                    case "L":
                        this.Invoke(new MethodInvoker(delegate () { this.button_L.Enabled = false; }));
                        break;
                    case "Z":
                        this.Invoke(new MethodInvoker(delegate () { this.button_Z.Enabled = false; }));
                        break;
                    case "X":
                        this.Invoke(new MethodInvoker(delegate () { this.button_X.Enabled = false; }));
                        break;
                    case "C":
                        this.Invoke(new MethodInvoker(delegate () { this.button_C.Enabled = false; }));
                        break;
                    case "V":
                        this.Invoke(new MethodInvoker(delegate () { this.button_V.Enabled = false; }));
                        break;
                    case "B":
                        this.Invoke(new MethodInvoker(delegate () { this.button_B.Enabled = false; }));
                        break;
                    case "N":
                        this.Invoke(new MethodInvoker(delegate () { this.button_N.Enabled = false; }));
                        break;
                    case "M":
                        this.Invoke(new MethodInvoker(delegate () { this.button_M.Enabled = false; }));
                        break;
                }
        }

        //For enable and disable Player1&2
        private void Test_DoWork(object sender, DoWorkEventArgs e)
        {
            
                if (exist == false)
                {
                    MessageBox.Show("Player1 Turn","Player(2)");
                    this.Invoke(new MethodInvoker(delegate () { this.Enabled = false; }));
                    connect = "false";
                    writer.Write(connect);
                }
                if (exist == true)
                {
                   this.Invoke(new MethodInvoker(delegate () { this.Enabled = true; }));
                }
        }

        
       
        private void ButtonEnable(Control rootControl, Action<Control> action)
        {
            foreach (Control childControl in rootControl.Controls)
            {
                ButtonEnable(childControl, action);
                action(childControl);
            }
        }
        private void gen_game()
        {
            try
            {
                ButtonEnable(this, ctrl => ctrl.Enabled = true);
              
                pl_word = pl_word.ToUpper();
                wordarr = pl_word.ToCharArray();
                letter_pos = new int[pl_word.Length];
                //Resetting other counters and variables
                input = "";
                dashed = "";
                for (int i = 0; i < pl_word.Length; i++)
                {
                    dashed += "-";
                }

              

                label_Word.Text = dashed.ToUpper();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Wrong Occured", "Player(2)");
            }
        }

        //Event handler
        private void Form1_ChkLtr(string chr)
        {
            try
            {
                if (true)
                {
                    exist = false;

                    if(wordarr!=null)
                    {
                        for (int i = 0; i < wordarr.Length; i++)
                        {
                            if (chr[0] == wordarr[i])
                            {
                                letter_pos[i] = 1;
                                exist = true;
                            }
                            if (!BtnTest.IsBusy)
                                BtnTest.RunWorkerAsync();
                        }
                    }
                    else
                    {

                        MessageBox.Show("You  Refused to join", "Player(2)");
                        this.Close();
                    }

                    dashed = "";
                    for (int i = 0; i < wordarr.Length; i++)
                    {
                        if (letter_pos[i] == 1)
                        {
                            dashed += wordarr[i].ToString();
                        }
                        else
                        {
                            dashed += "-";
                        }
                    }

                    label_Word.Text = dashed.ToUpper();
                   
                }
                else
                {
                    gen_game();
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong  Occured","Player(2)");
            }
        }
        #region chars
        private void button_A_Click_1(object sender, EventArgs e)
        {
            input = "A";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_A.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            input = "B";            
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_B.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            input = "C";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_C.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            input = "D";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_D.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            input = "E";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_E.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            input = "F";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_F.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            input = "G";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_G.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            input = "H";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_H.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            input = "I";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_I.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            input = "J";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_J.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            input = "K";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_K.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            input = "L";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_L.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            input = "M";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_M.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            input = "N";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_N.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            input = "O";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_O.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            input = "P";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_P.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            input = "Q";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_Q.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            input = "R";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_R.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            input = "S";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_S.Enabled = false;
            Test.RunWorkerAsync();
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            input = "T";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_T.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

            private void button_U_Click(object sender, EventArgs e)
        {
            input = "U";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_U.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            input = "V";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_V.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            input = "W";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_W.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            input = "X";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_X.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_Y_Click(object sender, EventArgs e)
        {       
            input = "Y";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_Y.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            input = "Z";
            this.Invoke(new MethodInvoker(delegate () { writer.Write(input); }));
            chk_letter(input);
            button_Z.Enabled = false;
            Test.RunWorkerAsync();
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
        }
#endregion
        private void button1_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(ip, 9000);
            nstream = client.GetStream();
            reader = new BinaryReader(nstream);
            writer = new BinaryWriter(nstream);
            string str = reader.ReadString();
            String word = reader.ReadString();
            pl_word = word;
            string message = str;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string title = "Play ?";
            DialogResult result = MessageBox.Show(message,title, buttons);
           // label2.Text = message;
            if (result == DialogResult.No)
            {
                reader.Close();
                nstream.Close();
                client.Close();
            }
            if (result == DialogResult.Yes)
            {
                gen_game();
            }
 
            Thread t = new Thread(new ThreadStart(work));
            t.Start();
            this.panel1.Enabled = true;
            this.groupBox1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = @".\track1.wav";
            //sp.PlayLooping();
        }

        private void work()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.Enabled = false;
            }));
            try
            {
                while (true)
                {
                        letter = reader.ReadString();
                        if (letter=="false")
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.Enabled = true;
                            }));                      
                        }
                    else if (letter == "win")
                    {
                        //MessageBox.Show(" Client  lose");

                        string message = "Player(2) lose \n Do you want to play again ?" ;
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        string title = "Result";
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.No)
                        {
                            reader.Close();
                            nstream.Close();
                            client.Close();
                        }
                        if (result == DialogResult.Yes)
                        {
                         
                            
                            this.Invoke(new MethodInvoker(delegate () { this.Enabled = true; }));                

                        }

                    }
                    
                        else 
                        {
                            this.label_Word.Invoke(new MethodInvoker(delegate ()
                            {
                                chk_letter(letter);
                            }));
                        
                        }
                    
                    
                }               
            }
            catch (ObjectDisposedException ex)
            {

                MessageBox.Show("You refused","Player(2)");
            }
            catch (IOException)
            {
                MessageBox.Show("You are not connected","Player(2)");
            }
        }

        private void TrackPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\track1.wav";
            sp.PlayLooping();
            TrackMute.Visible = true;
            TrackPlay.Visible = false;
        }

        private void TrackMute_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\track1.wav";
            sp.Stop();
            TrackMute.Visible = false;
            TrackPlay.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Dispose();
            LoadLab.Dispose();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = @".\track1.wav";
            //sp.PlayLooping();
        }
    }
}

