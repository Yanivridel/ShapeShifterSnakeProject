using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //for moving form around
using ComponentFactory.Krypton.Toolkit;
using Figures; //our classes
using System.Media; // for music
using System.IO;
using System.Runtime.Serialization; //for save & load
using System.Runtime.Serialization.Formatters.Binary;

namespace SnakeFinalProject
{
    public partial class MainForm : Form
    {
        enum figureName { Circle, Rectangle, Triangle, Rhombus, Square };
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private List<Figure> Snake = new List<Figure>();
        private string direction = "right";
        private settings set = new settings();
        Random rand = new Random();
        Color colorVal = Color.LimeGreen;
        int figureVal = (int)figureName.Circle;
        int movingFlag = 0;


        public MainForm()
        {
            InitializeComponent();
            player.SoundLocation = "SnakeBackgroundMusic.wav";
        }
        ///////////////// START LOAD
        private void MainForm_Load(object sender, EventArgs e)
        {
            ButtonsPanel.Focus();
            MenuPanel.Size = new Size(1122, 582);
            MenuPanel.Location = new Point(0, 70);
            DesignPanel.Size = new Size(1122, 582);
            DesignPanel.Location = new Point(0, 70);
            GamePanel.Size = new Size(1122, 582);
            GamePanel.Location = new Point(0, 70);
            RulesPanel.Size = new Size(1122, 582);
            RulesPanel.Location = new Point(0, 70);
            MenuPanel.Visible = true;
            this.player.PlayLooping();
            AudioOffPic.Location = AudioOnPic.Location = new Point(640, 22);
        }
        ///////////////// END LOAD

        ////////////////////////////////// START BUTTONS CLICKS  /////////////////////
        private void MainButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void DesignSnakeButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void GameButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void RulesButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void StartNewGameButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void LoadButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void SaveButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void ColorDesignButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void StartGameButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
        }
        private void LowButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
            HighButton.Checked = false;
            MedButton.Checked = false;
            GameTimer.Interval = 150;
        }
        private void MedButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
            HighButton.Checked = false;
            LowButton.Checked = false;
            GameTimer.Interval = 100;
        }
        private void HighButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
            LowButton.Checked = false;
            MedButton.Checked = false;
            GameTimer.Interval = 50;
        }
        private void DisableColorChoosen()
        {
            YellowButton.Checked = false;
            RedButton.Checked = false;
            BlueButton.Checked = false;
            PinkButton.Checked = false;
            PurpleButton.Checked = false;
            DarkGoldButton.Checked = false;
            BlackButton.Checked = false;
            GrayBlueButton.Checked = false;
            CyanButton.Checked = false;
            PinkBrownButton.Checked = false;
            DrakBlueButton.Checked = false;
        }
        private void PauseResumeButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonsPanel.Focus();
            if (PauseResumeButton.Text == "Pause")
            {
                GameTimer.Enabled = false;
                PauseResumeButton.Text = "Resume";
            }
            else
            {
                GameTimer.Enabled = true;
                PauseResumeButton.Text = "Pause";
            }
        }
        private void RedButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            RedButton.Checked = true;
            colorVal = Color.Firebrick;
            ButtonsPanel.Focus();
        }
        private void BlueButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            BlueButton.Checked = true;
            colorVal = Color.DarkSlateGray;
            ButtonsPanel.Focus();
        }
        private void GreenButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            GreenButton.Checked = true;
            colorVal = Color.LimeGreen;
            ButtonsPanel.Focus();
        }
        private void YellowButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.Yellow;
            ButtonsPanel.Focus();
        }
        private void PurpleButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.DarkViolet;
            ButtonsPanel.Focus();
        }
        private void PinkButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.LightCoral;
            ButtonsPanel.Focus();
        }
        private void DarkGoldButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.DarkGoldenrod;
            ButtonsPanel.Focus();
        }
        private void CyanButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.Cyan;
            ButtonsPanel.Focus();
        }
        private void GrayBlueButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.MediumSeaGreen;
            ButtonsPanel.Focus();
        }
        private void BlackButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.Black;
            ButtonsPanel.Focus();
        }
        private void DrakBlueButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.MidnightBlue;
            ButtonsPanel.Focus();
        }
        private void PinkBrownButton_MouseUp(object sender, MouseEventArgs e)
        {
            DisableColorChoosen();
            YellowButton.Checked = true;
            colorVal = Color.RosyBrown;
            ButtonsPanel.Focus();
        }
        private void ExitPicBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainButton_Click(object sender, EventArgs e)
        {
            MenuPanel.Visible = true;
            DesignPanel.Visible = false;
            GamePanel.Visible = false;
            RulesPanel.Visible = false;
            if (GameTimer.Enabled == true) PauseResumeButton.Text = "Resume";
            GameTimer.Enabled = false;
        }
        private void DesignSnakeButton_Click(object sender, EventArgs e)
        {
            DesignPanel.Visible = true;
            RulesPanel.Visible = false;
            MenuPanel.Visible = false;
            GamePanel.Visible = false;
            CircleRadioButton.Checked = true;
            if (GameTimer.Enabled == true) PauseResumeButton.Text = "Resume";
            GameTimer.Enabled = false;
        }
        private void RulesButton_Click(object sender, EventArgs e)
        {
            RulesPanel.Visible = true;
            MenuPanel.Visible = false;
            DesignPanel.Visible = false;
            GamePanel.Visible = false;
            if (GameTimer.Enabled == true) PauseResumeButton.Text = "Resume";
            GameTimer.Enabled = false;
        }
        private void GameButton_Click(object sender, EventArgs e)
        {
            GamePanel.Visible = true;
            DesignPanel.Visible = false;
            MenuPanel.Visible = false;
            RulesPanel.Visible = false;
        }
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (GameAreaPic.BackColor == colorVal)
            {
                ButtonsPanel.Focus();
                MessageBox.Show("Cannot choose background and snake same color !");
                return;
            }
            GamePanel.Visible = true;
            DesignPanel.Visible = false;
            MenuPanel.Visible = false;
            StartGameButton.Text = "Restart";
            this.Focus();
            RestartGame();
        }
        private void StartNewGameButton_Click(object sender, EventArgs e)
        {
            DesignSnakeButton.Enabled = true;
            DesignSnakeButton_Click(sender, e);
        }
        ////////////////////////////////// END BUTTONS CLICKS  //////////////////////

        /////////////////////////For Moving Form With Menu Panel ////////////////////
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void ButtonsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        //////////////////////////////End Moving Form /////////////////////////////////////
       
        ////////////////////////////// START OTHERS /////////////////////////////////////
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'W' && direction != "down") direction = "up";
            else if (e.KeyValue == 'S'  && direction != "up") direction = "down";
            else if (e.KeyValue == 'A'  && direction != "right") direction = "left";
            else if (e.KeyValue == 'D'  && direction != "left") direction = "right";
        }
        private bool IsInApple(Figure head)
        {
            double appleX = GreenApple.Location.X + GreenApple.Width / 2;
            double appleY = GreenApple.Location.Y + GreenApple.Height / 2;
            double disx = Math.Abs(head.X - appleX); disx *= disx;
            double disy = Math.Abs(head.Y - appleY); disy *= disy;
            double dis = Math.Sqrt(disx + disy);
            if (dis < 23)
            {
                return true;
            }
            return false;
        }
        private void GameAreaPic_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            for (int i = 0; i < Snake.Count; i++)
            {
                Snake[i].Draw(canvas,i);
            }
        }
        private void BackgroundColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BackgroundColorComboBox.SelectedItem.ToString() == "white")
            {
                GreenApple.BackColor = GameAreaPic.BackColor = Color.White;
            }
            else if (BackgroundColorComboBox.SelectedItem.ToString() == "gray")
            {
                GreenApple.BackColor = GameAreaPic.BackColor = Color.Gray;
            }
            else if (BackgroundColorComboBox.SelectedItem.ToString() == "pink")
            {
                GreenApple.BackColor = GameAreaPic.BackColor = Color.Pink;
            }
            else
            {
                GreenApple.BackColor = GameAreaPic.BackColor = Color.LightBlue;
            }
        }
        private void AudioOffPic_Click(object sender, EventArgs e)
        {
            player.Play();
            AudioOnPic.Visible = true;
            AudioOffPic.Visible = false;
        }
        private void AudioOnPic_Click(object sender, EventArgs e)
        {
            player.Stop();
            AudioOnPic.Visible = false;
            AudioOffPic.Visible = true;
        }
        private void ColorDesignButton_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colorVal = e.Color;
        }
        ////////////////////////////// END OTHERS /////////////////////////////////////

        ////////////////////////////////// START GAME FUNCTIONS  //////////////////////////////////
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (direction)
                    {
                        case "left":
                            Snake[0].X -= 20;
                            break;
                        case "right":
                            Snake[0].X += 20;
                            break;
                        case "down":
                            Snake[0].Y += 20;
                            break;
                        case "up":
                            Snake[0].Y -= 20;
                            break;
                    }

                    if (Snake[i].X < GameAreaPic.Location.X)
                    {
                        Snake[i].X = GameAreaPic.Width + GameAreaPic.Location.X - 12;
                    }
                    if (Snake[i].X > GameAreaPic.Location.X + GameAreaPic.Width - 12)
                    {
                        Snake[i].X = GameAreaPic.Location.X - 12;
                    }
                    if (Snake[i].Y < GameAreaPic.Location.Y)
                    {
                        Snake[i].Y = GameAreaPic.Height + GameAreaPic.Location.Y - 12;
                    }
                    if (Snake[i].Y > GameAreaPic.Location.Y + GameAreaPic.Height - 12)
                    {
                        Snake[i].Y = GameAreaPic.Location.Y;
                    }

                    if (IsInApple(Snake[i]))
                    {
                        EatFood();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (
                            Math.Abs(Snake[i].X -Snake[j].X) < 10
                            && Math.Abs(Snake[i].Y - Snake[j].Y) < 10)
                        {
                            GameOver();
                        }
                    }

                }
                else //Not Head
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            GameAreaPic.Invalidate(); //Calls Paint

        }
        private void RestartGame()
        {
            Snake.Clear();
            GameButton.Enabled = true;
            SaveButton.Enabled = true;
            PauseResumeButton.Text = "Pause";
            YellowButton.Checked = true;
            direction = "right";
            GameTimer.Enabled = true;
            set.score = 0;
            ScoreNumLabel.Text = "0";


            if (figureVal == (int)figureName.Circle)
            {
                myCircle head = new myCircle(colorVal);
                head.X = (int)(head.X / 20) * 20 + GameAreaPic.Location.X;
                head.Y = (int)(head.Y / 20) * 20 + GameAreaPic.Location.Y;
                Snake.Add(head);
                for (int i = 0; i < 3; i++)
                {
                    myCircle body = new myCircle(colorVal);
                    body.X = (int)(body.X / 20) * 20 + GameAreaPic.Location.X;
                    body.Y = (int)(body.Y / 20) * 20 + GameAreaPic.Location.Y;
                    Snake.Add(body);
                }
            }
            else if (figureVal == (int)figureName.Rectangle)
            {
                myRectangle head = new myRectangle(colorVal);
                head.X = (int)(head.X / 20) * 20 + GameAreaPic.Location.X;
                head.Y = (int)(head.Y / 20) * 20 + GameAreaPic.Location.Y;
                Snake.Add(head);
                for (int i = 0; i < 3; i++)
                {
                    myRectangle body = new myRectangle(colorVal);
                    body.X = (int)(body.X / 20) * 20 + GameAreaPic.Location.X;
                    body.Y = (int)(body.Y / 20) * 20 + GameAreaPic.Location.Y;
                    Snake.Add(body);
                }
            }
            else if (figureVal == (int)figureName.Triangle)
            {
                myTriangle head = new myTriangle(colorVal);
                head.X = (int)(head.X / 20) * 20 + GameAreaPic.Location.X;
                head.Y = (int)(head.Y / 20) * 20 + GameAreaPic.Location.Y;
                Snake.Add(head);
                for (int i = 0; i < 3; i++)
                {
                    myTriangle body = new myTriangle(colorVal);
                    body.X = (int)(body.X / 20) * 20 + GameAreaPic.Location.X;
                    body.Y = (int)(body.Y / 20) * 20 + GameAreaPic.Location.Y;
                    Snake.Add(body);
                }
            }
            else if (figureVal == (int)figureName.Square)
            {
                mySquare head = new mySquare(colorVal);
                head.X = (int)(head.X / 20) * 20 + GameAreaPic.Location.X;
                head.Y = (int)(head.Y / 20) * 20 + GameAreaPic.Location.Y;
                Snake.Add(head);
                for (int i = 0; i < 3; i++)
                {
                    mySquare body = new mySquare(colorVal);
                    body.X = (int)(body.X / 20) * 20 + GameAreaPic.Location.X;
                    body.Y = (int)(body.Y / 20) * 20 + GameAreaPic.Location.Y;
                    Snake.Add(body);
                }
            }
            else if (figureVal == (int)figureName.Rhombus)
            {
                myRhombus head = new myRhombus(colorVal);
                head.X = (int)(head.X / 20) * 20 + GameAreaPic.Location.X;
                head.Y = (int)(head.Y / 20) * 20 + GameAreaPic.Location.Y;
                Snake.Add(head);
                for (int i = 0; i < 3; i++)
                {
                    myRhombus body = new myRhombus(colorVal);
                    body.X = (int)(body.X / 20) * 20 + GameAreaPic.Location.X;
                    body.Y = (int)(body.Y / 20) * 20 + GameAreaPic.Location.Y;
                    Snake.Add(body);
                }
            }
            

            GreenApple.Size = new Size(20, 20);
             Point p = new Point(rand.Next(GameAreaPic.Location.X, GameAreaPic.Location.X + GameAreaPic.Width - GreenApple.Width),
                                            rand.Next(GameAreaPic.Location.Y, GameAreaPic.Location.Y + GameAreaPic.Height - GreenApple.Height));

            p.X = (int)(p.X / 20) * 20 + 10;
            p.Y = (int)(p.Y / 20) * 20 + 10;
            GreenApple.Location = p;
            colorVal = Color.Yellow;
            figureVal = (int)figureName.Circle;
        }
        private void GameOver()
        {
            GameTimer.Stop();
            if (set.score > set.record)
            {
                set.record = set.score;
                RecordNumLabel.Text = set.record.ToString();
            }
            DialogResult d;
            d = MessageBox.Show("Game Over","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            if(d == DialogResult.OK)
            {
                movingFlag = 0;
                SaveButton.Enabled = true;
                GameButton.Enabled = false;
                GamePanel.Visible = false;
                MenuPanel.Visible = false;
                RulesPanel.Visible = false;
                DesignPanel.Visible = true;
                figureVal = (int)figureName.Circle;
                CircleRadioButton.Checked = true;
                CircleButton2.Checked = true;
                colorVal = Color.LimeGreen;
            }
            
        }
        private void EatFood()
        {
            set.score += 10;
            ScoreNumLabel.Text = set.score.ToString();

            if (figureVal == (int)figureName.Circle)
            {
                myCircle head = new myCircle(colorVal, Snake[Snake.Count - 1].X, Snake[Snake.Count - 1].Y);
                Snake.Add(head);
            }
            else if (figureVal == (int)figureName.Rectangle)
            {
                myRectangle head = new myRectangle(colorVal, Snake[Snake.Count - 1].X, Snake[Snake.Count - 1].Y);
                Snake.Add(head);

            }
            else if (figureVal == (int)figureName.Triangle)
            {
                myTriangle head = new myTriangle(colorVal, Snake[Snake.Count - 1].X, Snake[Snake.Count - 1].Y);
                Snake.Add(head);

            }
            else if (figureVal == (int)figureName.Square)
            {
                mySquare head = new mySquare(colorVal, Snake[Snake.Count - 1].X, Snake[Snake.Count - 1].Y);
                Snake.Add(head);

            }
            else if (figureVal == (int)figureName.Rhombus)
            {
                myRhombus head = new myRhombus(colorVal, Snake[Snake.Count - 1].X, Snake[Snake.Count - 1].Y);
                Snake.Add(head);
            }

            Point p = new Point(rand.Next(GameAreaPic.Location.X, GameAreaPic.Location.X + GameAreaPic.Width - GreenApple.Width),
                                            rand.Next(GameAreaPic.Location.Y, GameAreaPic.Location.Y + GameAreaPic.Height - GreenApple.Height));
            p.X = (int)(p.X / 20) * 20 + 10;
            p.Y = (int)(p.Y / 20) * 20 + 10;
            GreenApple.Location = p;
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (IsInApple(Snake[i]))
                {
                    p.X = rand.Next(GameAreaPic.Location.X, GameAreaPic.Location.X + GameAreaPic.Width - GameAreaPic.Width);
                    p.Y = rand.Next(GameAreaPic.Location.Y, GameAreaPic.Location.Y + GameAreaPic.Height - GreenApple.Height);
                    p.X = (int)(p.X / 20) * 20 + 10;
                    p.Y = (int)(p.Y / 20) * 20 + 10;
                    GreenApple.Location = p;
                    i = Snake.Count - 1;
                }
            }
            //Sound
        }
        ////////////////////////////////// END GAME FUNCTIONS  ////////////////////////////////////

        ////////////////////////////////// START FIGURE SELECT  ///////////////////////////////////
        //                                    Second Panel
        private void CircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Circle;
        }
        private void TriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Triangle;
        }
        private void SquareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Square;
        }
        private void RhombusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Rhombus;
        }
        private void RectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Rectangle;
        }
        //                                   Third Panel
        private void CircleButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Circle;
            ButtonsPanel.Focus();

        }
        private void TriangleButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Triangle;
        }
        private void SquareButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Square;
        }
        private void RhombusButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Rhombus;
        }
        private void RectangleButton2_CheckedChanged(object sender, EventArgs e)
        {
            figureVal = (int)figureName.Rectangle;
        }
        ////////////////////////////////// END FIGURE SELECT  ///////////////////////////////////////

        ////////////////////////////////// START MOUSE CLICKS ///////////////////////////////////////
        private void GameAreaPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameTimer.Enabled == true) return;
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (Snake[i].IsInside(e.X, e.Y))
                    {
                        if (figureVal == (int)figureName.Circle)
                        {
                            myCircle head = new myCircle(colorVal, Snake[i].X, Snake[i].Y);
                            Snake.Insert(i, head);
                        }
                        else if (figureVal == (int)figureName.Rectangle)
                        {
                            myRectangle head = new myRectangle(colorVal, Snake[i].X, Snake[i].Y);
                            Snake.Insert(i, head);

                        }
                        else if (figureVal == (int)figureName.Triangle)
                        {
                            myTriangle head = new myTriangle(colorVal, Snake[i].X, Snake[i].Y);
                            Snake.Insert(i, head);

                        }
                        else if (figureVal == (int)figureName.Square)
                        {
                            mySquare head = new mySquare(colorVal, Snake[i].X, Snake[i].Y);
                            Snake.Insert(i, head);

                        }
                        else if (figureVal == (int)figureName.Rhombus)
                        {
                            myRhombus head = new myRhombus(colorVal, Snake[i].X, Snake[i].Y);
                            Snake.Insert(i, head);
                        }
                        Snake.Remove(Snake[i + 1]);
                        break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Snake.Count != 2)
                {
                    for (int i = 0; i < Snake.Count; i++)
                    {
                        if (Snake[i].IsInside(e.X, e.Y))
                        {
                            for (int j = Snake.Count - 1; j > i; j--)
                            {
                                Snake[j].X = Snake[j - 1].X;
                                Snake[j].Y = Snake[j - 1].Y;
                            }
                            Snake.Remove(Snake[i]);
                            break;
                        }
                    }
                }
            }
            GameAreaPic.Invalidate();
        }
        ////////////////////////////////// END MOUSE CLICKS /////////////////////////////////////////

        ////////////////////////////////// START MOUSE MOVING ///////////////////////////////////////
        private void GameAreaPic_MouseDown(object sender, MouseEventArgs e)
        {
            if (GameTimer.Enabled == false && Snake[0].IsInside(e.X, e.Y))
            {
                movingFlag = 1;
            }
        }
        private void GameAreaPic_MouseUp(object sender, MouseEventArgs e)
        {
            movingFlag = 0;
        }
        private void GameAreaPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingFlag == 1)
            {
                if ((int)(e.X / 20) * 20 + 10 < GameAreaPic.Location.X + GameAreaPic.Width
                    && (int)(e.Y / 20) * 20 + 10 < GameAreaPic.Location.Y + GameAreaPic.Height
                    && e.X > GameAreaPic.Location.X && e.Y > GameAreaPic.Location.Y)
                {
                    int newX = (int)(e.X / 20) * 20 + GameAreaPic.Location.X;
                    int newY = (int)(e.Y / 20) * 20 + GameAreaPic.Location.Y;
                    if (Math.Abs(Snake[0].X - newX) > 10 || Math.Abs(Snake[0].Y - newY) > 10)
                    {
                        if (Snake[0].X - newX > 0) direction = "left";
                        else if (Snake[0].X - newX < 0) direction = "right";
                        else if (Snake[0].Y - newY > 0) direction = "up";
                        else if (Snake[0].Y - newY < 0) direction = "down";
                        for (int i = Snake.Count-1; i > 0; i--)
                        {
                            Snake[i].X = Snake[i - 1].X;
                            Snake[i].Y = Snake[i - 1].Y;
                        }
                        Snake[0].X = newX;
                        Snake[0].Y = newY;
                        if (IsInApple(Snake[0]))
                        {
                            EatFood();
                        }
                        for (int j = 1; j < Snake.Count; j++)
                        {
                            if (
                            Math.Abs(Snake[0].X - Snake[j].X) < 10
                            && Math.Abs(Snake[0].Y - Snake[j].Y) < 10)
                            {
                                GameOver();
                            }
                        }
                    }
                    GameAreaPic.Invalidate();
                }
            }
        }

        ////////////////////////////////// END MOUSE MOVING /////////////////////////////////////////

        ////////////////////////////////// START SAVE LOAD //////////////////////////////////////////
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, Snake);
                    formatter.Serialize(stream, set);
                }
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DesignSnakeButton.Enabled = true;
                GameButton.Enabled = true;
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                Snake = (List<Figure>)binaryFormatter.Deserialize(stream);
                set = (settings)binaryFormatter.Deserialize(stream);
                pictureBox1.Invalidate();
                GreenApple.Size = new Size(20, 20);
                RecordNumLabel.Text = set.record.ToString();
                ScoreNumLabel.Text = set.score.ToString();
                GamePanel.Visible = true;
                MenuPanel.Visible = false;
                RulesPanel.Visible = false;
                DesignPanel.Visible = false;
                PauseResumeButton.Text = "Resume";
                StartGameButton.Text = "Restart";
            }
        }
        ////////////////////////////////// END SAVE LOAD ////////////////////////////////////////////

    }
}
