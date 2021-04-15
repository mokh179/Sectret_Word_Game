using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessWordProject
{
    public delegate void CheckLetter(string letter);
    public partial class Form1 : Form
    {
        string str;
        // An event that is invoked everytime when any letter is guessed
        event CheckLetter chkLetter;
        string input;
        string missedLetters = "";
        //A word which is to find
        string wordToFind;
        //Current status of the found letters in the word
        string wordToDisplay = "";
        //Character array of word
        char[] wordToFindArray;
        // postion of the word 
        int[] wordToFindLettersPosition;
        bool IsLetterFound = false;
        //Random number generator class to get word randomly from the word list
        Random rndm = new Random(0);
        //Collection of word
        List<string> wordList = new List<string>();
        // A list of index positions to keep track which word is already choosen 
        List<int> wordsIndexAlreadyPlayed = new List<int>();
        int missedLetterCount = 0;
        public Form1()
        {
            InitializeComponent();
            //Subscribe the event
            this.chkLetter += new CheckLetter(Form1_ChkLtr);
        }

        private void RestartTheGame()
        {
            try
            {
                // wordToFind = GetNewWordFromPool();
                wordToFind = wordToFind.ToUpper();
                wordToFindArray = wordToFind.ToCharArray();

                wordToFindLettersPosition = new int[wordToFind.Length];

                //Resetting other counters and variables
                input = "";
                wordToDisplay = "";
                for (int i = 0; i < wordToFind.Length; i++)
                {
                    wordToDisplay += "-";
                }

                missedLetters = "";
                missedLetterCount = 0;

                label_Word.Text = wordToDisplay.ToUpper();
                //label_MissedLetters.Text = missedLetters;
                //label_MissedLtrCnt.Text = maxChance.ToString();
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //Event handler
        private void Form1_ChkLtr(string currentInputletter)
        {
            try
            {
                if (true)
                {

                    IsLetterFound = false;
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (currentInputletter[0] == wordToFindArray[i])
                        {
                            wordToFindLettersPosition[i] = 1;
                            IsLetterFound = true;

                        }
                    }

                    if (IsLetterFound == false)
                    {
                        missedLetters += currentInputletter + ", ";

                        missedLetterCount++;
                        //label_MissedLtrCnt.Text = (maxChance - missedLetterCount).ToString();
                    }

                    wordToDisplay = "";
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (wordToFindLettersPosition[i] == 1)
                        {
                            wordToDisplay += wordToFindArray[i].ToString();
                        }
                        else
                        {
                            wordToDisplay += "-";
                        }
                    }

                    label_Word.Text = wordToDisplay.ToUpper();
                    // label_MissedLetters.Text = missedLetters;

                    if (wordToFindLettersPosition.All(e => e == 1))
                    {
                        MessageBox.Show("CONGRATS! YOU GOT THE WORD.", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestartTheGame();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, you lost the game" + "\nThe correct word was: " + wordToFind, "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestartTheGame();
                }
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button_A_Click(object sender, EventArgs e)
        {
            input = "A";
            chkLetter(input);
            button_A.Enabled = false;
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            input = "B";
            chkLetter(input);
            button_B.Enabled = false;
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            input = "C";
            chkLetter(input);
            button_C.Enabled = false;
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            input = "D";
            chkLetter(input);
            button_D.Enabled = false;
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            input = "E";
            chkLetter(input);
            button_E.Enabled = false;
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            input = "F";
            chkLetter(input);
            button_F.Enabled = false;
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            input = "G";
            chkLetter(input);
            button_G.Enabled = false;
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            input = "H";
            chkLetter(input);
            button_H.Enabled = false;
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            input = "I";
            chkLetter(input);
            button_I.Enabled = false;
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            input = "J";
            chkLetter(input);
            button_J.Enabled = false;
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            input = "K";
            chkLetter(input);
            button_K.Enabled = false;
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            input = "L";
            chkLetter(input);
            button_L.Enabled = false;
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            input = "M";
            chkLetter(input);
            button_M.Enabled = false;
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            input = "N";
            chkLetter(input);
            button_N.Enabled = false;
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            input = "O";
            chkLetter(input);
            button_O.Enabled = false;
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            input = "P";
            chkLetter(input);
            button_P.Enabled = false;
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            input = "Q";
            chkLetter(input);
            button_Q.Enabled = false;
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            input = "R";
            chkLetter(input);
            button_R.Enabled = false;
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            input = "S";
            chkLetter(input);
            button_S.Enabled = false;
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            input = "T";
            chkLetter(input);
            button_T.Enabled = false;
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            input = "U";
            chkLetter(input);
            button_U.Enabled = false;
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            input = "V";
            chkLetter(input);
            button_V.Enabled = false;
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            input = "W";
            chkLetter(input);
            button_W.Enabled = false;
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            input = "X";
            chkLetter(input);
            button_X.Enabled = false;
        }

        private void button_Y_Click(object sender, EventArgs e)
        {
            input = "Y";
            chkLetter(input);
            button_Y.Enabled = false;
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            input = "Z";
            chkLetter(input);
            button_Z.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category_level cl = new Category_level();
            DialogResult result;
            result = cl.ShowDialog();
            if (result == DialogResult.OK)
            {
                str = cl.textBox;
                wordToFind = str.Trim();
                button1.Visible = false;
            }
            MessageBox.Show(str);
            RestartTheGame();
        }
        
    
    }
}

