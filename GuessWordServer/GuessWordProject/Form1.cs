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
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Media;

namespace GuessWordProject
{
    public delegate void CheckLetter(string letter);
    public partial class Form1 : Form
    {

        TcpListener server;
        IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
        NetworkStream nstream;
        BinaryWriter writer;
        BinaryReader reader;
        int count = 0;
        int score = 0;
        Socket conn;
        Category_level cat_lev = new Category_level();
        string connect;
        string letter;
        string win;        
        string word;
        event CheckLetter chk_letter;
        string input;
        string pl_word;
        string app_word = "";
        //Character array of word
        char[] wordarr;
        int[] letter_pos;
        bool IsLetterFound = false;
        //backgroudWorkers
        private BackgroundWorker Test = new BackgroundWorker();
        private BackgroundWorker BtnTest = new BackgroundWorker();
        private BackgroundWorker Winner = new BackgroundWorker();

        bool running;

        public Form1()
        {
            InitializeComponent();

            //Subscribe the event
            this.chk_letter += new CheckLetter(check);
            //For enable and disable Player1&2
            Test.DoWork += Test_DoWork;
            //For Disable Buttons
            BtnTest.DoWork += BtnTest_DoWork;
            Winner.DoWork += Winner_DoWork;
           

        }

        private void Winner_DoWork(object sender, DoWorkEventArgs e)
        {
            //Test If All Characters in Position
            if (letter_pos.All(E => E == 1))
            {
                win = "win";
                writer.Write(win);
             
                MessageBox.Show("CONGRATS! you Win","Player(1)");
                score++;
                this.Invoke(new MethodInvoker(delegate () { button1.Visible = true; }));
               
            }
            else if (letter_pos.All(x => x == 1) && reader.ReadString()=="win")
            {
                
                MessageBox.Show("Player2 Lose!","Player(1)");
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

            if (IsLetterFound == false)
            {
                MessageBox.Show("Player2 Turn");
                this.Invoke(new MethodInvoker(delegate () { this.Enabled = false; }));
                connect = "false";
                writer.Write(connect);
            }
            if(IsLetterFound == true)
            {
                this.Invoke(new MethodInvoker(delegate () { this.Enabled = true; }));
            }
        }

        
        //reset keypad and disable each when generate_game
       
       private void ButtonEnable(Control rootControl, Action<Control> action)
        {
            foreach (Control childControl in rootControl.Controls)
            {
                ButtonEnable(childControl, action);
                action(childControl);
            }
        }


        //Genarate game
        private void gen_game()
        {
            try
            {
                ButtonEnable(this, ctrl => ctrl.Enabled = true);
                pl_word = pl_word.ToUpper();
                wordarr = pl_word.ToCharArray();
                letter_pos = new int[pl_word.Length];

                input = "";
                app_word = "";
                for (int i = 0; i < pl_word.Length; i++)
                {
                    app_word += "-";
                }

                label_Word.Text = app_word.ToUpper();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something occured","Player(1)");
            }
        }

        //Restart New Game
        private void play()
        {
            DialogResult result;
            result = cat_lev.ShowDialog();
            if (result == DialogResult.OK)
            {
                word = cat_lev.textBox;
                pl_word = word.Trim();
                button1.Visible = false;
                running = true;
                //MessageBox.Show(word);
                gen_game();
            }
            else if(result == DialogResult.Cancel)
            {
                running = false;
                if (conn==null)
                {
                    server.Stop();
                }
                else
                {
                    running = false;
                    conn.Shutdown(SocketShutdown.Both);
                    server.Stop();
                }
                
            }
            Thread t = new Thread(new ThreadStart(listen));
            t.Start();
        }
        public void listen()
        {
            this.Invoke(new MethodInvoker(delegate () { this.groupBox1.Enabled = false; }));

           
            Thread t2;

            while (running)
            {
                try
                {
                    conn = server.AcceptSocket();
                }
                catch (Exception ex)
                {

                    break;
                }
               

                nstream = new NetworkStream(conn);
                writer = new BinaryWriter(nstream);
                reader = new BinaryReader(nstream);
                this.Invoke(new MethodInvoker(delegate () { writer.Write("The category is " + cat_lev.Combobox1.Text.Trim() + " The level is " + cat_lev.Combobox2.Text.Trim()); }));
                //this.Invoke(new MethodInvoker(delegate () { label2.Text = cat_lev.Combobox1.Text.Trim(); }));
                //this.Invoke(new MethodInvoker(delegate () { label3.Text = cat_lev.Combobox2.Text.Trim(); }));
                this.Invoke(new MethodInvoker(delegate () { this.groupBox1.Enabled = true; }));
                this.Invoke(new MethodInvoker(delegate () { writer.Write(pl_word); }));
                t2 = new Thread(new ThreadStart(work));
                t2.Start();

            }
        }
        private void work()
        {
            try
            {
                if (conn.Connected)
                {
                    while (running)
                    {
                        try
                        {
                            letter = reader.ReadString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Player(2) is Disconnected", "Player(1)");
                            throw;
                        }
                      
                        if (letter == "false" || letter == "")
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.Enabled = true;
                            }));

                        }
                        else if (letter == "win")
                        {
                            MessageBox.Show("You  lose", "Player(1)");
                            this.Invoke(new MethodInvoker(delegate () { this.Enabled = true; }));
                            this.Invoke(new MethodInvoker(delegate () { play(); }));
                            this.Invoke(new MethodInvoker(delegate () { ButtonEnable(this, ctrl => ctrl.Enabled = true); }));
                            this.Invoke(new MethodInvoker(delegate () { button1.Visible = true; }));
                            count = reader.ReadInt32();


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

            }
            catch (IOException)
            {

                MessageBox.Show("Player(2) is Disconnected", "Player(1)");
            }
        }
        //handler
        //check if char exist in word and reapeating time
        private void check(string chr)
        {
            try
            {
                if (true)
                {

                    IsLetterFound = false;
                    for (int i = 0; i < wordarr.Length; i++)
                    {
                        if (chr[0] == wordarr[i])
                        {
                            letter_pos[i] = 1;
                            IsLetterFound = true;
                        }
                        if (!BtnTest.IsBusy)
                        BtnTest.RunWorkerAsync();
                    }
                    app_word = "";
                    for (int i = 0; i < wordarr.Length; i++)
                    {
                        if (letter_pos[i] == 1)
                        {
                            app_word += wordarr[i].ToString();
                        }
                        else
                        {
                            app_word += "-";
                        }
                    }

                    label_Word.Text = app_word.ToUpper();
                }
                else
                {
                    gen_game();
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry an error occured", "Player(1)");
            }
        }

        #region chars
      

        private void button_A_Click(object sender, EventArgs e)
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
            BtnTest.RunWorkerAsync();
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
            if (!Winner.IsBusy)
                Winner.RunWorkerAsync();
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
            play();
        }

      

 
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new TcpListener(ip,9000);
            server.Start();
            this.groupBox1.Enabled = false;
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\track1.wav";
            sp.PlayLooping();
           

        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            string path = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream(path+"\\score.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Player(1): " + (score));
            sw.WriteLine("Player(2): " + (count));
            sw.WriteLine("Playing date: " + d);
            MessageBox.Show("Player(1):  " + score + "  Player(2): " + count,"Score");
            sw.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\track1.wav";
            sp.PlayLooping();
            TrackMute.Visible = true;
            TrackPlay.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\track1.wav";
            sp.Stop();
            TrackMute.Visible = false;
            TrackPlay.Visible = true;
        }

       
    }

   
}

