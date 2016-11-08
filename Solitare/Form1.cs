using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solitare
{
    public partial class Form1 : Form
    {
        #region Global Variables
        PictureBox[] cardDeck = new PictureBox[52];
        PictureBox[] foundation = new PictureBox[4];
        PictureBox draw = new PictureBox();
        PictureBox[] tableau = new PictureBox[7];
        PictureBox[] _mc = new PictureBox[13];
        string[,] _moves = new string[2, 0];
        bool _autoPlay = false;
        bool _cheat = false;
        bool _endGameStop = false;
        bool _rightClick = false;
        bool _timerEnabled = false;
        bool _reset = false;
        bool _setTab = false;
        Image backOfCard = Properties.Resources.clouds;
        int _cardMoveSpeed = 10;
        int _time = 0;
        int _score = 0;
        int _drawPileRefresh = 0;
        int _mx = 0;
        int _my = 0;
        int _cx = 0;
        int _cy = 0;
        int _endGame = -1;
        int[] _moveX = new int[13];
        int[] _moveY = new int[13];
        int[] _drawPile = new int[53];
        int[] _flipPile = new int[25];
        int[,] _foundationPile = new int[4,14];
        int[,] _tableauPile = new int[7,20];
        int[] _leftPosition = new int[7];
        #endregion
        public Form1(string file)
        {
            InitializeComponent();
            DoubleBuffered = true;
            for (int i = 0; i < 7; i++)
            {
                _leftPosition[i] = 40 * (i + 1) / 8 + 90 * i;
            }
            scoreLabel.Text = "Score: " + _score.ToString();
            timeLabel.Text = "Time: " + _time.ToString();
            timeLabel.Visible = Properties.Settings.Default.showTimer;
            scoreLabel.Visible = (Properties.Settings.Default.standardScoring || Properties.Settings.Default.vegasScoring);
            statusStrip1.Visible = Properties.Settings.Default.showStatus;
            if (Properties.Settings.Default.cardBack != "" && System.IO.File.Exists(Properties.Settings.Default.cardBack))
            {
                backOfCard = MakeBackOfCard(Properties.Settings.Default.cardBack);
            }
            ((System.ComponentModel.ISupportInitialize)(draw)).BeginInit();
            draw.Location = new System.Drawing.Point(_leftPosition[0], 30);
            draw.Name = "draw";
            draw.Size = new System.Drawing.Size(90, 130);
            draw.Image = Properties.Resources.drawPileO;
            draw.TabIndex = 0;
            draw.TabStop = false;
            draw.MouseDown += new MouseEventHandler(draw_MouseDown);
            Controls.Add(draw);
            ((System.ComponentModel.ISupportInitialize)(draw)).EndInit();
            for (int i = 0; i < 4; i++)
            {
                foundation[i] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(foundation[i])).BeginInit();
                foundation[i].Location = new System.Drawing.Point(_leftPosition[i + 3], 30);
                foundation[i].Name = "foundation[" + i.ToString() + "]";
                foundation[i].Size = new System.Drawing.Size(90, 130);
                foundation[i].Image = Properties.Resources.foundation;
                foundation[i].TabIndex = 0;
                foundation[i].TabStop = false;
                foundation[i].MouseDown += new MouseEventHandler(picBox_MouseDown);
                Controls.Add(foundation[i]);
                ((System.ComponentModel.ISupportInitialize)(foundation[i])).EndInit();
            }
            for (int i = 0; i < 7; i++)
            {
                tableau[i] = new PictureBox();
                ((System.ComponentModel.ISupportInitialize)(tableau[i])).BeginInit();
                tableau[i].Location = new System.Drawing.Point(_leftPosition[i], 170);
                tableau[i].Name = "tableau[" + i.ToString() + "]";
                tableau[i].Size = new System.Drawing.Size(90, 130);
                tableau[i].Image = Properties.Resources.tableau;
                tableau[i].TabIndex = 0;
                tableau[i].TabStop = false;
                tableau[i].MouseDown +=new MouseEventHandler(picBox_MouseDown);
                Controls.Add(tableau[i]);
                ((System.ComponentModel.ISupportInitialize)(tableau[i])).EndInit();
            }
            for (int i = 0; i < 25; i++)
            {
                _flipPile[i] = -1;
            }
            for (int i = 0; i < 52; i++)
            {
                _drawPile[i] = i;
                cardDeck[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(cardDeck[i])).BeginInit();
                cardDeck[i].Location = new System.Drawing.Point(_leftPosition[0], 30);
                cardDeck[i].Name = "cardDeck[" + i.ToString() + "]";
                cardDeck[i].Size = new System.Drawing.Size(90, 130);
                cardDeck[i].Image = backOfCard;
                cardDeck[i].TabIndex = 0;
                cardDeck[i].TabStop = false;
                cardDeck[i].Tag = i.ToString("00") + "Draw";
                cardDeck[i].MouseDown += new MouseEventHandler(CardMouseDown);
                Controls.Add(cardDeck[i]);
                ((System.ComponentModel.ISupportInitialize)(cardDeck[i])).EndInit();
            }
            _drawPile[52] = 52;
            _flipPile[24] = 0;
            #region Initialize Images
            cardDeck[0].InitialImage = Properties.Resources._0;
            cardDeck[1].InitialImage = Properties.Resources._1;
            cardDeck[2].InitialImage = Properties.Resources._2;
            cardDeck[3].InitialImage = Properties.Resources._3;
            cardDeck[4].InitialImage = Properties.Resources._4;
            cardDeck[5].InitialImage = Properties.Resources._5;
            cardDeck[6].InitialImage = Properties.Resources._6;
            cardDeck[7].InitialImage = Properties.Resources._7;
            cardDeck[8].InitialImage = Properties.Resources._8;
            cardDeck[9].InitialImage = Properties.Resources._9;
            cardDeck[10].InitialImage = Properties.Resources._10;
            cardDeck[11].InitialImage = Properties.Resources._11;
            cardDeck[12].InitialImage = Properties.Resources._12;
            cardDeck[13].InitialImage = Properties.Resources._13;
            cardDeck[14].InitialImage = Properties.Resources._14;
            cardDeck[15].InitialImage = Properties.Resources._15;
            cardDeck[16].InitialImage = Properties.Resources._16;
            cardDeck[17].InitialImage = Properties.Resources._17;
            cardDeck[18].InitialImage = Properties.Resources._18;
            cardDeck[19].InitialImage = Properties.Resources._19;
            cardDeck[20].InitialImage = Properties.Resources._20;
            cardDeck[21].InitialImage = Properties.Resources._21;
            cardDeck[22].InitialImage = Properties.Resources._22;
            cardDeck[23].InitialImage = Properties.Resources._23;
            cardDeck[24].InitialImage = Properties.Resources._24;
            cardDeck[25].InitialImage = Properties.Resources._25;
            cardDeck[26].InitialImage = Properties.Resources._26;
            cardDeck[27].InitialImage = Properties.Resources._27;
            cardDeck[28].InitialImage = Properties.Resources._28;
            cardDeck[29].InitialImage = Properties.Resources._29;
            cardDeck[30].InitialImage = Properties.Resources._30;
            cardDeck[31].InitialImage = Properties.Resources._31;
            cardDeck[32].InitialImage = Properties.Resources._32;
            cardDeck[33].InitialImage = Properties.Resources._33;
            cardDeck[34].InitialImage = Properties.Resources._34;
            cardDeck[35].InitialImage = Properties.Resources._35;
            cardDeck[36].InitialImage = Properties.Resources._36;
            cardDeck[37].InitialImage = Properties.Resources._37;
            cardDeck[38].InitialImage = Properties.Resources._38;
            cardDeck[39].InitialImage = Properties.Resources._39;
            cardDeck[40].InitialImage = Properties.Resources._40;
            cardDeck[41].InitialImage = Properties.Resources._41;
            cardDeck[42].InitialImage = Properties.Resources._42;
            cardDeck[43].InitialImage = Properties.Resources._43;
            cardDeck[44].InitialImage = Properties.Resources._44;
            cardDeck[45].InitialImage = Properties.Resources._45;
            cardDeck[46].InitialImage = Properties.Resources._46;
            cardDeck[47].InitialImage = Properties.Resources._47;
            cardDeck[48].InitialImage = Properties.Resources._48;
            cardDeck[49].InitialImage = Properties.Resources._49;
            cardDeck[50].InitialImage = Properties.Resources._50;
            cardDeck[51].InitialImage = Properties.Resources._51;
            #endregion
            /*//end quickly
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    _tableauPile[i, j] = -1;
                }
                _tableauPile[i, 19] = 0;
            }
            _foundationPile[0, 13] = 13;
            _foundationPile[1, 13] = 13;
            _foundationPile[2, 13] = 13;
            _foundationPile[3, 13] = 12;
            for (int i = 0; i < 51; i++)
            {
                _foundationPile[i / 13, i % 13] = i;
                cardDeck[i].Top = 30;
                cardDeck[i].Left = _leftPosition[i / 13 + 3];
                cardDeck[i].Tag = i.ToString("00") + "Foundation" + (i / 13).ToString();
                cardDeck[i].Image = cardDeck[i].InitialImage;
                cardDeck[i].BringToFront();
            }
            cardDeck[51].Top = 170;
            cardDeck[51].Left = _leftPosition[6];
            cardDeck[51].Tag = "51TableauS6";
            cardDeck[51].Image = cardDeck[51].InitialImage;
            cardDeck[51].BringToFront();
            _tableauPile[6, 19] = 1;
            _tableauPile[6, 0] = 51;
            /*///end quickly
            if (System.IO.File.Exists(file))
                OpenGame(file);
            else
                NewGame();
        }
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_setTab)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = i; j < 7; j++)
                    {
                        cardDeck[_tableauPile[j, i]].Hide();
                        cardDeck[_tableauPile[j, i]].BringToFront();
                        if (j == i)
                            cardDeck[_tableauPile[j, i]].Image = cardDeck[_tableauPile[j, i]].InitialImage;
                        cardDeck[_tableauPile[j, i]].Top = 170 + i * 5;
                        cardDeck[_tableauPile[j, i]].Left = _leftPosition[j];
                        cardDeck[_tableauPile[j, i]].Show();
                    }
                }
                _setTab = false;
                SetTableau();
                return;
            }
            else if (_reset)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 52; i++)
                {
                    cardDeck[i].Hide();
                    cardDeck[i].Image = backOfCard;
                    cardDeck[i].Top = 30;
                    cardDeck[i].Left = _leftPosition[0];
                    cardDeck[i].Show();
                }
                _reset = false;
                ResetCards();
                return;
            }
            else if (_endGame != -1)
            {
                _endGameStop = true;
                return;
            }
            else if (e.Button == MouseButtons.Right && !cardMoveTimer.Enabled)
            {
                rightClick();
            }
        }
        private void draw_MouseDown(object sender, MouseEventArgs e)
        {
            if (_setTab)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = i; j < 7; j++)
                    {
                        cardDeck[_tableauPile[j, i]].Hide();
                        cardDeck[_tableauPile[j, i]].BringToFront();
                        if (j == i)
                            cardDeck[_tableauPile[j, i]].Image = cardDeck[_tableauPile[j, i]].InitialImage;
                        cardDeck[_tableauPile[j, i]].Top = 170 + i * 5;
                        cardDeck[_tableauPile[j, i]].Left = _leftPosition[j];
                        cardDeck[_tableauPile[j, i]].Show();
                    }
                }
                _setTab = false;
                SetTableau();
                return;
            }
            else if (_reset)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 52; i++)
                {
                    cardDeck[i].Hide();
                    cardDeck[i].Image = backOfCard;
                    cardDeck[i].Top = 30;
                    cardDeck[i].Left = _leftPosition[0];
                    cardDeck[i].Show();
                }
                _reset = false;
                ResetCards();
                return;
            }
            else if (_endGame != -1)
            {
                _endGameStop = true;
                return;
            }
            else if (e.Button == MouseButtons.Right && !cardMoveTimer.Enabled)
            {
                rightClick();
            }
            else
            {
                _drawPileRefresh++;
                if (Properties.Settings.Default.standardScoring && _drawPileRefresh > 2)
                {
                    _score -= 20;
                    if (_score < 0)
                        _score = 0;
                    scoreLabel.Text = "Score: " + _score;
                }
                if(Properties.Settings.Default.vegasScoring && _drawPileRefresh > 1)
                {
                    draw.Image = Properties.Resources.drawPileX;
                }
                if (Properties.Settings.Default.vegasScoring && _drawPileRefresh > 2)
                {
                    return;
                }
                string moveFrom = "";
                string moveTo = "";
                for (int i = 0; i < 25; i++)
                {
                    if (_flipPile[24] != 0)
                    {
                        _flipPile[24]--;
                        _drawPile[52]++;
                        _drawPile[i] = _flipPile[_flipPile[24]];
                        cardDeck[_drawPile[i]].Image = backOfCard;
                        cardDeck[_drawPile[i]].Left = _leftPosition[0];
                        cardDeck[_drawPile[i]].Top = 30;
                        cardDeck[_drawPile[i]].BringToFront();
                        moveFrom += "|" + cardDeck[_drawPile[i]].Tag.ToString();
                        cardDeck[_drawPile[i]].Tag = _drawPile[i].ToString("00") + "Draw";
                        moveTo += "|" + cardDeck[_drawPile[i]].Tag.ToString();
                        _flipPile[_flipPile[24]] = -1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (moveFrom != "")
                {
                    string[] moves = moveFrom.Substring(1).Split('|');
                    moveFrom = "";
                    //reverse order of commands
                    for (int i = moves.Length - 1; i >= 0; i--)
                    {
                        moveFrom += "|" + moves[i];
                    }
                    moveFrom = moveFrom.Substring(1);
                    moves = moveTo.Substring(1).Split('|');
                    moveTo = "";
                    for (int i = moves.Length - 1; i >= 0; i--)
                    {
                        moveTo += "|" + moves[i];
                    }
                    moveTo = moveTo.Substring(1);
                    addMove(moveFrom, moveTo);
                }
            }
        }
        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Point p = PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < 13; i++)
            {
                if (_mc[i] != null)
                {
                    if (_mc[i].Top != _cy && _mc[i].Left != _cx)
                        _mc[i].Image = _mc[i].InitialImage;
                    _mc[i].Left = p.X - _mx;
                    _mc[i].Top = p.Y - _my + 15 * i;
                }
                else if (i == 0)
                {
                    e.Effect = DragDropEffects.None;
                    break;
                }
                else
                    break;
            }
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (_mc[0] != null)
            {
                bool cardMoved = false;
                int card = Convert.ToInt32(((string)_mc[0].Tag).Substring(0, 2));
                int[] priority = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    priority[i] = 0;
                }
                int[] percentCover = new int[11];
                for (int i = 0; i < 7; i++)
                {
                    //which cards _mc[0] over
                    if(i < 4)
                    {
                        percentCover[i] = 0;
                        if (_foundationPile[i, 13] > 0 && _foundationPile[i, _foundationPile[i, 13] - 1] != card)
                        {
                            percentCover[i] = percentOverCard(_mc[0], cardDeck[_foundationPile[i, _foundationPile[i, 13] - 1]]);
                        }
                        else
                        {
                            percentCover[i] = percentOverCard(_mc[0], foundation[i]);
                        }
                    }
                    percentCover[i + 4] = 0;
                        if (_tableauPile[i, 19] > 0 && ((string)cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]].Tag).Contains("TableauS") && _tableauPile[i, _tableauPile[i, 19] - 1] != card)
                        {
                            percentCover[i + 4] = percentOverCard(_mc[0], cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]]);
                        }
                        else if (_tableauPile[i, 19] == 0)
                        {
                            percentCover[i + 4] = percentOverCard(_mc[0], tableau[i]);
                        }
                }
                for (int i = 0; i < 4; i++)
                {
                    int temp = 0;
                    for (int j = 0; j < 11; j++)
                    {
                        if (percentCover[j] > percentCover[temp])
                            temp = j;
                        //prioritize
                    }
                    if (percentCover[temp] != 0)
                    {
                        priority[i] = temp + 1;
                        percentCover[temp] = 0;
                    }
                }
                for (int i = 0; i < 4 && !cardMoved; i++)
                {
                    if (priority[i] == 0)
                        break;
                    //check if _mc[0] can go there
                    if (priority[i] < 5)
                    {
                        if (_foundationPile[priority[i] - 1, 13] != 13 && ((card % 13 == 0 && _foundationPile[priority[i] - 1, 13] == 0) || (_foundationPile[priority[i] - 1, 13] != 0 && card == _foundationPile[priority[i] - 1, _foundationPile[priority[i] - 1, 13] - 1] + 1)))
                        {
                            cardMoved = true;
                            moveToFoundation(priority[i] - 1);
                            if (_endGame != -1)
                                return;

                        }
                    }
                    else
                    {
                        switch (card / 13)
                        {
                            case 0:
                                if ((_tableauPile[priority[i] - 5, 19] == 0 && card % 13 == 12) || (_tableauPile[priority[i] - 5, 19] != 0 && (_tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card + 14 || _tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card + 40)))
                                {
                                    cardMoved = true;
                                    moveToTableau(priority[i] - 5);
                                }
                                break;
                            case 1:
                                if ((_tableauPile[priority[i] - 5, 19] == 0 && card % 13 == 12) || (_tableauPile[priority[i] - 5, 19] != 0 && (_tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card - 12 || _tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card + 14)))
                                {
                                    cardMoved = true;
                                    moveToTableau(priority[i] - 5);
                                }
                                break;
                            case 2:
                                if ((_tableauPile[priority[i] - 5, 19] == 0 && card % 13 == 12) || (_tableauPile[priority[i] - 5, 19] != 0 && (_tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card - 12 || _tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card + 14)))
                                {
                                    cardMoved = true;
                                    moveToTableau(priority[i] - 5);
                                }
                                break;
                            case 3:
                                if ((_tableauPile[priority[i] - 5, 19] == 0 && card % 13 == 12) || (_tableauPile[priority[i] - 5, 19] != 0 && (_tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card - 38 || _tableauPile[priority[i] - 5, _tableauPile[priority[i] - 5, 19] - 1] == card - 12)))
                                {
                                    cardMoved = true;
                                    moveToTableau(priority[i] - 5);
                                }
                                break;
                        }
                    }
                }
                if (!cardMoved)
                {
                    _my = _mc[0].Top;
                    _mx = _mc[0].Left;
                    for (int i = 0; i < 13; i++)
                    {
                        if (_mc[i] != null)
                        {
                            _moveX[i] = _cx;
                            _moveY[i] = _cy + 15 * i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    _cx = 0;
                    _cy = 0;
                    cardMoveTimer.Enabled = true;
                }
            }
        }
        private void Form1_DragLeave(object sender, EventArgs e)
        {
            Form1_DragDrop(null, null);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_setTab)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = i; j < 7; j++)
                    {
                        cardDeck[_tableauPile[j, i]].Hide();
                        cardDeck[_tableauPile[j, i]].BringToFront();
                        if (j == i)
                            cardDeck[_tableauPile[j, i]].Image = cardDeck[_tableauPile[j, i]].InitialImage;
                        cardDeck[_tableauPile[j, i]].Top = 170 + i * 5;
                        cardDeck[_tableauPile[j, i]].Left = _leftPosition[j];
                        cardDeck[_tableauPile[j, i]].Show();
                    }
                }
                _setTab = false;
                SetTableau();
                return;
            }
            else if (_reset)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 52; i++)
                {
                    cardDeck[i].Hide();
                    cardDeck[i].Image = backOfCard;
                    cardDeck[i].Top = 30;
                    cardDeck[i].Left = _leftPosition[0];
                    cardDeck[i].Show();
                }
                _reset = false;
                ResetCards();
                return;
            }
            else if (_endGame != -1)
            {
                _endGameStop = true;
                return;
            }
            else if (e.Button == MouseButtons.Right && !cardMoveTimer.Enabled)
            {
                rightClick();
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                time.Enabled = false;
            else if(_timerEnabled)
                time.Enabled = true;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void CardMouseDown(object sender, MouseEventArgs e)
        {
            if (_setTab)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = i; j < 7; j++)
                    {
                        cardDeck[_tableauPile[j, i]].Hide();
                        cardDeck[_tableauPile[j, i]].BringToFront();
                        if(j == i)
                            cardDeck[_tableauPile[j, i]].Image = cardDeck[_tableauPile[j, i]].InitialImage;
                        cardDeck[_tableauPile[j, i]].Top = 170 + i * 5;
                        cardDeck[_tableauPile[j, i]].Left = _leftPosition[j];
                        cardDeck[_tableauPile[j, i]].Show();
                    }
                }
                _setTab = false;
                SetTableau();
                return;
            }
            else if (_reset)
            {
                cardMoveTimer.Enabled = false;
                for (int i = 0; i < 52; i++)
                {
                    cardDeck[i].Hide();
                    cardDeck[i].Image = backOfCard;
                    cardDeck[i].Top = 30;
                    cardDeck[i].Left = _leftPosition[0];
                    cardDeck[i].Show();
                }
                _reset = false;
                ResetCards();
                return;
            }
            else if (cardMoveTimer.Enabled)
                return;
            else if (_endGame != -1)
            {
                _endGameStop = true;
                return;
            }
            else if (e.Button == MouseButtons.Right)
            {
                rightClick();
                return;
            }
            else if (e.Clicks == 2)
            {
                if (CheckIfCardCanMove((PictureBox)sender, false, false))
                    return;
            }
            _mc[0] = (PictureBox)sender;
            int card = Convert.ToInt32(((string)_mc[0].Tag).Substring(0, 2));
            if (((string)_mc[0].Tag).Contains("Flip"))
            {
                if (_mc[0] == cardDeck[_flipPile[_flipPile[24] - 1]])
                {
                    //_mc[0].Image = _mc[0].InitialImage;
                    _mc[0].BringToFront();
                    _mx = e.X;
                    _my = e.Y;
                    _cx = _mc[0].Left;
                    _cy = _mc[0].Top;
                    //Make Sure You Make this.AllowDrop = True;
                    DoDragDrop(_mc, DragDropEffects.All);
                }
            }
            else if (((string)_mc[0].Tag).Contains("Draw"))
            {
                time.Enabled = true;
                int j = 0;
                string moveFrom = "";
                string moveTo = "";
                for (; j < Properties.Settings.Default.drawCards; j++)
                {
                    if (_drawPile[52] == 0)
                        break;
                    _mc[0] = cardDeck[_drawPile[_drawPile[52] - 1]];
                    _mc[0].Image = _mc[0].InitialImage;
                    _mc[0].BringToFront();
                    _mc[0].Left = _leftPosition[1] + j * 20;
                    moveFrom += "|" + (string)_mc[0].Tag;
                    _mc[0].Tag = ((string)_mc[0].Tag).Substring(0, 2) + "Flip" + _mc[0].Left;
                    moveTo += "|" + (string)_mc[0].Tag;
                    _flipPile[_flipPile[24]++] = _drawPile[_drawPile[52] - 1];
                    _drawPile[--_drawPile[52]] = -1;
                }
                moveFrom = moveFrom.Substring(1);
                moveTo = moveTo.Substring(1);
                string temp = "";
                for (int i = 0; i < moveFrom.Split('|').Length; i++)
                {
                    temp += "|" + moveFrom.Split('|')[moveFrom.Split('|').Length - 1 - i];
                }
                moveFrom = temp.Substring(1);
                temp = "";
                for (int i = 0; i < moveTo.Split('|').Length; i++)
                {
                    temp += "|" + moveTo.Split('|')[moveTo.Split('|').Length - 1 - i];
                }
                moveTo = temp.Substring(1);
                addMove(moveFrom, moveTo);
                for (int i = 0; i < _flipPile[24] - j; i++)
                {
                    cardDeck[_flipPile[i]].Left = _leftPosition[1];
                }
                if (_cheat)
                {
                    Cheat();
                }
            }
            else if (((string)_mc[0].Tag).Contains("Foundation"))
            {
                //_mc[0].Image = _mc[0].InitialImage;
                _mc[0].BringToFront();
                _mx = e.X;
                _my = e.Y;
                _cx = _mc[0].Left;
                _cy = _mc[0].Top;
                //Make Sure You Make this.AllowDrop = True;
                DoDragDrop(_mc, DragDropEffects.All);
            }
            else if (((string)_mc[0].Tag).Contains("TableauS"))
            {
                time.Enabled = true;
                int t = Convert.ToInt32(((string)_mc[0].Tag).Substring(10));
                bool grabCards = false;
                int j = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (_tableauPile[t, i] == card)
                        grabCards = true;
                    else if (_tableauPile[t, i] == -1)
                        break;
                    if (grabCards)
                    {
                        _mc[j] = cardDeck[_tableauPile[t, i]];
                        //_mc[j].Image = _mc[j].InitialImage;
                        _mc[j].BringToFront();
                        j++;
                    }
                }
                _mx = e.X;
                _my = e.Y;
                _cx = _mc[0].Left;
                _cy = _mc[0].Top;
                //Make Sure You Make this.AllowDrop = True;
                DoDragDrop(_mc, DragDropEffects.All);
            }
            else if (((string)_mc[0].Tag).Contains("TableauD"))
            {
                int pile = Convert.ToInt32(((string)_mc[0].Tag).Substring(10));
                if (_tableauPile[pile, _tableauPile[pile, 19] - 1] == card)
                {
                    if(Properties.Settings.Default.standardScoring)
                    {
                        _score += 5;
                        scoreLabel.Text = "Score: " + _score;
                    }
                    _mc[0].Image = _mc[0].InitialImage;
                    string moveFrom = (string)_mc[0].Tag;
                    _mc[0].Tag = ((string)_mc[0].Tag).Substring(0, 2) + "TableauS" + pile;
                    addMove(moveFrom, (string)_mc[0].Tag);
                    _mc[0] = null;
                    if (_cheat)
                    {
                        Cheat();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tag Error");
            }
        }
        private bool CheckIfCardCanMove(PictureBox sender, bool hint, bool NoMoves)
        {
            if (_cheat && !((string)sender.Tag).Contains("Draw") && !((string)sender.Tag).Contains("TableauD"))
            {
                sender.Image = sender.InitialImage;
            }
            if (((string)sender.Tag).Contains("TableauD") || (!NoMoves && ((string)sender.Tag).Contains("Flip") && sender != cardDeck[_flipPile[_flipPile[24] - 1]]))
            {
                return false;
            }
            _mc[0] = sender;
            int tPile = -1;
            int cardPlace = -1;
            int card = Convert.ToInt32(((string)_mc[0].Tag).Substring(0, 2));
            if (((string)_mc[0].Tag).Contains("TableauS"))
            {
                tPile = Convert.ToInt32(((string)_mc[0].Tag).Substring(10));

                bool grabCards = false;
                int j = 0;
                for (int i = 0; i < _tableauPile[tPile, 19]; i++)
                {
                    if (_tableauPile[tPile, i] == card)
                    {
                        cardPlace = i;
                        grabCards = true;
                    }
                    if (grabCards)
                    {
                        _mc[j] = cardDeck[_tableauPile[tPile, i]];
                        _mc[j].BringToFront();
                        j++;
                    }
                }
            }
            if ((tPile == -1 || _tableauPile[tPile, _tableauPile[tPile, 19] - 1] == card) && (((string)_mc[0].Tag).Contains("Flip") || ((string)_mc[0].Tag).Contains("TableauS") || (NoMoves && ((string)_mc[0].Tag).Contains("Draw"))))
            {
                for (int i = 0; i < 4; i++)
                {
                    //Move to foundation
                    if (_foundationPile[i, 13] != 13 && ((card % 13 == 0 && _foundationPile[i, 13] == 0) || (_foundationPile[i, 13] != 0 && card == _foundationPile[i, _foundationPile[i, 13] - 1] + 1)))
                    {
                        if (hint)
                        {
                            if (_foundationPile[i, 13] == 0 && ((string)_mc[0].Tag).Contains("Foundation"))
                                return false;
                            else
                                return true;
                        }
                        moveToFoundation(i);
                        return true;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                switch (card / 13)
                {
                    case 0:
                        if ((_tableauPile[i, 19] == 0 && card % 13 == 12) || (_tableauPile[i, 19] != 0 && card % 13 != 12 && ((string)cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]].Tag).Contains("TableauS") && (_tableauPile[i, _tableauPile[i, 19] - 1] == card + 14 || _tableauPile[i, _tableauPile[i, 19] - 1] == card + 40)))
                        {
                            if (hint)
                            {
                                if (_tableauPile[i, 19] == 0)
                                {
                                    //if _mc[0] == king and is on ground
                                    if (((string)_mc[0].Tag).Contains("Tableau") && _tableauPile[tPile, 0] == card)
                                        return false;
                                }
                                else
                                {
                                    //if _mc[0] already on card
                                    if (((string)_mc[0].Tag).Contains("Tableau") && cardPlace > 0 && ((string)cardDeck[_tableauPile[tPile, cardPlace - 1]].Tag).Contains("TableauS") && (_tableauPile[tPile, cardPlace - 1] == card + 14 || _tableauPile[tPile, cardPlace - 1] == card + 40))
                                        return false;
                                }
                                return true;
                            }
                            moveToTableau(i);
                            return true;
                        }
                        break;
                    case 1:
                        if ((_tableauPile[i, 19] == 0 && card % 13 == 12) || (_tableauPile[i, 19] != 0 && card % 13 != 12 && ((string)cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]].Tag).Contains("TableauS") && (_tableauPile[i, _tableauPile[i, 19] - 1] == card - 12 || _tableauPile[i, _tableauPile[i, 19] - 1] == card + 14)))
                        {
                            if (hint)
                            {
                                if (_tableauPile[i, 19] == 0)
                                {
                                    if (((string)_mc[0].Tag).Contains("Tableau") && _tableauPile[tPile, 0] == card)
                                        return false;
                                }
                                else
                                {
                                    //if _mc[0] already on card
                                    if (((string)_mc[0].Tag).Contains("Tableau") && cardPlace > 0 && ((string)cardDeck[_tableauPile[tPile, cardPlace - 1]].Tag).Contains("TableauS") && (_tableauPile[tPile, cardPlace - 1] == card + 14 || _tableauPile[tPile, cardPlace - 1] == card - 12))
                                        return false;
                                }
                                return true;
                            }
                            moveToTableau(i);
                            return true;
                        }
                        break;
                    case 2:
                        if ((_tableauPile[i, 19] == 0 && card % 13 == 12) || (_tableauPile[i, 19] != 0 && card % 13 != 12 && ((string)cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]].Tag).Contains("TableauS") && (_tableauPile[i, _tableauPile[i, 19] - 1] == card - 12 || _tableauPile[i, _tableauPile[i, 19] - 1] == card + 14)))
                        {
                            if (hint)
                            {
                                if (_tableauPile[i, 19] == 0)
                                {
                                    if (((string)_mc[0].Tag).Contains("Tableau") && _tableauPile[tPile, 0] == card)
                                        return false;
                                }
                                else
                                {
                                    //if _mc[0] already on card
                                    if (((string)_mc[0].Tag).Contains("Tableau") && cardPlace != 0 && ((string)cardDeck[_tableauPile[tPile, cardPlace - 1]].Tag).Contains("TableauS") && (_tableauPile[tPile, cardPlace - 1] == card + 14 || _tableauPile[tPile, cardPlace - 1] == card - 12))
                                        return false;
                                }
                                return true;
                            }
                            moveToTableau(i);
                            return true;
                        }
                        break;
                    case 3:
                        if ((_tableauPile[i, 19] == 0 && card % 13 == 12) || (_tableauPile[i, 19] != 0 && card % 13 != 12 && ((string)cardDeck[_tableauPile[i, _tableauPile[i, 19] - 1]].Tag).Contains("TableauS") && (_tableauPile[i, _tableauPile[i, 19] - 1] == card - 38 || _tableauPile[i, _tableauPile[i, 19] - 1] == card - 12)))
                        {
                            if (hint)
                            {
                                if (_tableauPile[i, 19] == 0)
                                {
                                    if (((string)_mc[0].Tag).Contains("Tableau") && _tableauPile[tPile, 0] == card)
                                        return false;
                                }
                                else
                                {
                                    //if _mc[0] already on card
                                    if (((string)_mc[0].Tag).Contains("Tableau") && cardPlace != 0 && ((string)cardDeck[_tableauPile[tPile, cardPlace - 1]].Tag).Contains("TableauS") && (_tableauPile[tPile, cardPlace - 1] == card - 38 || _tableauPile[tPile, cardPlace - 1] == card - 12))
                                        return false;
                                }
                                return true;
                            }
                            moveToTableau(i);
                            return true;
                        }
                        break;
                }
            }
            return false;
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool cumu = Properties.Settings.Default.cumulativeScoring;
            bool vegas = Properties.Settings.Default.vegasScoring;
            bool standard = Properties.Settings.Default.standardScoring;
            bool showTimer = Properties.Settings.Default.showTimer;
            bool showStatus = Properties.Settings.Default.showStatus;
            int cardDraw = Properties.Settings.Default.drawCards;
            Options op = new Options();
            op.ShowDialog();
            if (Properties.Settings.Default.cardBack != "")
                backOfCard = MakeBackOfCard(Properties.Settings.Default.cardBack);
            else
                backOfCard = Properties.Resources.clouds;
            for (int i = 0; i < 52; i++)
            {
                if (((string)cardDeck[i].Tag).Contains("Draw") || ((string)cardDeck[i].Tag).Contains("TableauD"))
                    cardDeck[i].Image = backOfCard;
            }
            if (Properties.Settings.Default.drawCards != cardDraw || vegas != Properties.Settings.Default.vegasScoring || standard != Properties.Settings.Default.standardScoring || (cumu != Properties.Settings.Default.cumulativeScoring && vegas))
            {
                if (vegas != Properties.Settings.Default.vegasScoring)
                    _score = 0;
                NewGame();
            }
            statusStrip1.Visible = Properties.Settings.Default.showStatus;
            timeLabel.Visible = Properties.Settings.Default.showTimer;
            scoreLabel.Visible = (Properties.Settings.Default.standardScoring || Properties.Settings.Default.vegasScoring);
        }
        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_cheat)
                findMove(true, false);
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_moves.Length > 0 && _endGame == -1)
            {
                string[] moveFrom = _moves[1, _moves.Length / 2 - 1].Split('|');
                string[] moveTo = _moves[0, _moves.Length / 2 - 1].Split('|');
                string[,] temp = _moves;
                _moves = new string[2, _moves.Length / 2 - 1];
                for (int i = 0; i < _moves.Length / 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        _moves[j, i] = temp[j, i];
                    }
                }
                bool drawRefresh = false;
                for (int i = 0; i < moveFrom.Length; i++)
                {
                    int card = Convert.ToInt32(moveFrom[i].Substring(0, 2));
                    if (moveTo[i].Contains("Draw"))
                    {
                        cardDeck[card].BringToFront();
                        cardDeck[card].Hide();
                        cardDeck[card].Left = _leftPosition[0];
                        cardDeck[card].Image = backOfCard;
                        cardDeck[card].Show();
                        _drawPile[_drawPile[52]++] = card;
                        _flipPile[--_flipPile[24]] = -1;
                    }
                    else if (moveTo[i].Contains("Flip"))
                    {
                        cardDeck[card].Hide();
                        cardDeck[card].Image = cardDeck[card].InitialImage;
                        cardDeck[card].Top = 30;
                        cardDeck[card].Left = _leftPosition[1];
                        cardDeck[card].BringToFront();
                        cardDeck[card].Show();
                        _flipPile[_flipPile[24]++] = card;
                        if (moveFrom[i].Contains("Foundation"))
                        {
                            int pile = Convert.ToInt32(moveFrom[i].Substring(12));
                            _foundationPile[pile, --_foundationPile[pile, 13]] = -1;
                            if (Properties.Settings.Default.standardScoring)
                            {
                                _score = (_score - 10 > 0 ? _score - 10 : 0);
                                scoreLabel.Text = "Score: " + _score;
                            }
                            else if (Properties.Settings.Default.vegasScoring)
                            {
                                _score -= 5;
                                if (_score < 0)
                                {
                                    scoreLabel.Text = "Money: $(" + Math.Abs(_score) + ")";
                                }
                                else
                                {
                                    scoreLabel.Text = "Money: $" + _score;
                                }
                            }
                        }
                        else if (moveFrom[i].Contains("Tableau"))
                        {
                            int pile = Convert.ToInt32(moveFrom[i].Substring(10));
                            _tableauPile[pile, --_tableauPile[pile, 19]] = -1;
                            _score = (_score - 5 > 0 ? _score - 5 : 0);
                            scoreLabel.Text = "Score: " + _score;
                        }
                        else
                        {
                            _drawPile[--_drawPile[52]] = -1;
                            if (!drawRefresh)
                            {
                                if (Properties.Settings.Default.standardScoring && _drawPileRefresh > 2)
                                {
                                    _score += 20;
                                    scoreLabel.Text = "Score: " + _score;
                                }
                                _drawPileRefresh--;
                                drawRefresh = true;
                            }
                        }
                    }
                    else if (moveTo[i].Contains("TableauD"))
                    {
                        cardDeck[card].Image = backOfCard;
                        if (Properties.Settings.Default.standardScoring)
                        {
                            _score = (_score - 5 > 0 ? _score - 5 : 0);
                            scoreLabel.Text = "Score: " + _score;
                        }
                    }
                    else if (moveTo[i].Contains("Foundation"))
                    {
                        int pile = Convert.ToInt32(moveTo[i].Substring(12));
                        cardDeck[card].Hide();
                        cardDeck[card].Top = 30;
                        cardDeck[card].Left = _leftPosition[pile + 3];
                        cardDeck[card].BringToFront();
                        cardDeck[card].Show();
                        _foundationPile[pile, _foundationPile[pile, 13]++] = card;
                        if (moveFrom[i].Contains("Foundation"))
                        {
                            pile = Convert.ToInt32(moveFrom[i].Substring(12));
                            _foundationPile[pile, --_foundationPile[pile, 13]] = -1;
                        }
                        else
                        {
                            pile = Convert.ToInt32(moveFrom[i].Substring(10));
                            _tableauPile[pile, --_tableauPile[pile, 19]] = -1;
                            if (Properties.Settings.Default.standardScoring)
                            {
                                _score += 15;
                                scoreLabel.Text = "Score: " + _score;
                            }
                            else if (Properties.Settings.Default.vegasScoring)
                            {
                                _score += 5;
                                if (_score < 0)
                                {
                                    scoreLabel.Text = "Money: $(" + Math.Abs(_score) + ")";
                                }
                                else
                                {
                                    scoreLabel.Text = "Money: $" + _score;
                                }
                            }
                        }
                    }
                    else if (moveTo[i].Contains("TableauS"))
                    {
                        int pile = Convert.ToInt32(moveTo[i].Substring(10));
                        cardDeck[card].Hide();
                        int top = 170;
                        for (int j = 0; j < _tableauPile[pile, 19]; j++)
                        {
                            if (((string)cardDeck[_tableauPile[pile, j]].Tag).Contains("TableauD"))
                            {
                                top += 5;
                            }
                            else
                            {
                                top += 15;
                            }
                        }
                        cardDeck[card].Top = top;
                        cardDeck[card].Left = _leftPosition[pile];
                        cardDeck[card].BringToFront();
                        cardDeck[card].Show();
                        _tableauPile[pile, _tableauPile[pile, 19]++] = card;
                        if (moveFrom[i].Contains("Foundation"))
                        {
                            pile = Convert.ToInt32(moveFrom[i].Substring(12));
                            _foundationPile[pile, --_foundationPile[pile, 13]] = -1;
                            if (Properties.Settings.Default.standardScoring)
                            {
                                _score = (_score - 10 > 0 ? _score - 10 : 0);
                                scoreLabel.Text = "Score: " + _score;
                            }
                            else if (Properties.Settings.Default.vegasScoring)
                            {
                                _score -= 5;
                                if (_score < 0)
                                {
                                    scoreLabel.Text = "Money: $(" + Math.Abs(_score) + ")";
                                }
                                else
                                {
                                    scoreLabel.Text = "Money: $" + _score;
                                }
                            }
                        }
                        else
                        {
                            pile = Convert.ToInt32(moveFrom[i].Substring(10));
                            _tableauPile[pile, --_tableauPile[pile, 19]] = -1;
                        }
                    }
                    cardDeck[card].Tag = moveTo[i];
                }
                if ((moveTo[0].Contains("Flip") || moveTo[0].Contains("Draw")) && _flipPile[24] > 1 && Properties.Settings.Default.drawCards == 3)
                {
                    for (int i = 0; i < _flipPile[24]; i++)
                    {
                        cardDeck[_flipPile[i]].Left = _leftPosition[1];
                    }
                    if (Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6)) != _leftPosition[1])
                    {
                        cardDeck[_flipPile[_flipPile[24] - 1]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6));
                        cardDeck[_flipPile[_flipPile[24] - 2]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 2]].Tag).Substring(6));
                    }
                }
            }
            if (_cheat)
                Cheat();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cheat = !_cheat;
            cheatToolStripMenuItem.Checked = !cheatToolStripMenuItem.Checked;
            if (_cheat)
            {
                hintToolStripMenuItem.Enabled = false;
                Cheat();
            }
            else
            {
                hintToolStripMenuItem.Enabled = true;
                for (int i = 0; i < 52; i++)
                {
                    if (((string)cardDeck[i].Tag).Contains("Draw") || ((string)cardDeck[i].Tag).Contains("TableauD"))
                    {
                        cardDeck[i].Image = backOfCard;
                    }
                    else
                    {
                        cardDeck[i].Image = cardDeck[i].InitialImage;
                    }
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_endGame == -1)
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveGame(saveFileDialog1.FileName);
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenGame(openFileDialog1.FileName);
            }
        }
        private void autoPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _autoPlay = !_autoPlay;
            autoPlayToolStripMenuItem.Checked = _autoPlay;
            if (_autoPlay)
            {
                AutoPlay();
            }
        }
        private void InvertTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 52; i++)
            {
                if (((string)cardDeck[i].Tag).Contains("TableauS") || ((string)cardDeck[i].Tag).Contains("Foundation") || ((string)cardDeck[i].Tag).Contains("Flip"))
                {
                    cardDeck[i].Image = cardDeck[i].InitialImage;
                }
            }
            InvertTimer.Enabled = false;
        }
        private void endTimer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            while (i < 13 && _mc[i] != null)
            {
                _mc[i].Left += _moveX[i];
                _mc[i].Top += _moveY[i];
                i++;
            }
            i = 0;
            bool stop = true;
            while (i < 13 && _mc[i] != null)
            {
                if (_mc[i].Top > -150 && _mc[i].Top < ClientSize.Height + 20 && _mc[i].Left > -110 && _mc[i].Left < ClientSize.Width + 20)
                {
                    stop = false;
                }
                else
                {
                    _mc[i].Hide();
                }
                i++;
            }
            if (stop)
            {
                endTimer.Enabled = false;
                endGame();
            }
        }
        private void time_Tick(object sender, EventArgs e)
        {
            _timerEnabled = true;
            _time++;
            timeLabel.Text = "Time: " + _time.ToString();
            if (Properties.Settings.Default.showTimer && _time % 10 == 0 && Properties.Settings.Default.standardScoring)
            {
                _score -= 2;
                if (_score < 0)
                    _score = 0;
                scoreLabel.Text = "Score: " + _score.ToString();
            }
        }
        private void cardMoveTimer_Tick(object sender, EventArgs e)
        {
            if (_mc[0] != null && _mc[1] == null)
                _mc[0].BringToFront();
            if (_cy == 0 && _cx == 0)
            {
                _cx = ((_moveX[0] - _mx) / _cardMoveSpeed == 0 ? (_moveX[0] - _mx < 0 ? -1 : (_moveX[0] - _mx > 0 ? 1 : 0)) : (_moveX[0] - _mx) / _cardMoveSpeed);
                _cy = ((_moveY[0] - _my) / _cardMoveSpeed == 0 ? (_moveY[0] - _my < 0 ? -1 : (_moveY[0] - _my > 0 ? 1 : 0)) : (_moveY[0] - _my) / _cardMoveSpeed);
            }
            for (int i = 0; i < 13; i++)
            {
                if (_mc[i] == null)
                    break;
                else
                {
                    _mc[i].Hide();
                    if (Math.Abs(_mc[i].Top - _moveY[i]) > Math.Abs(_cy))
                        _mc[i].Top += _cy;
                    else
                        _mc[i].Top = _moveY[i];
                    if (Math.Abs(_mc[i].Left - _moveX[i]) > Math.Abs(_cx))
                        _mc[i].Left += _cx;
                    else
                        _mc[i].Left = _moveX[i];
                    _mc[i].Show();
                    _mc[i].Update();
                }
            }
            if (_mc[0] == null || (_mc[0].Top == _moveY[0] && _mc[0].Left == _moveX[0]))
            {
                cardMoveTimer.Enabled = false;
                if (NoMoreMoves())
                {
                    MessageBox.Show("There aren't any more legal moves.", "No More Moves");
                }
                for (int i = 0; i < 13; i++)
                {
                    _mc[i] = null;
                }
                if (!Done())
                {
                    if (_rightClick)
                    {
                        _rightClick = false;
                        rightClick();
                    }
                    else if (_reset)
                    {
                        _reset = false;
                        ResetCards();
                    }
                    else if (_setTab)
                    {
                        _setTab = false;
                        SetTableau();
                    }
                    else if (_cheat)
                    {
                        Cheat();
                    }
                }
            }
        }
        private Image MakeBackOfCard(string imgLoc)
        {
            Bitmap bm = new Bitmap(imgLoc);
            Bitmap nbm = new Bitmap(90, 130);
            using (Graphics g = Graphics.FromImage(nbm))
                g.DrawImage(bm, 0, 0, 90, 130);
            for (int i = 1; i < 89; i++)
            {
                nbm.SetPixel(i, 0, Color.Black);
                nbm.SetPixel(i, 129, Color.Black);
            }
            for (int i = 1; i < 129; i++)
            {
                nbm.SetPixel(0, i, Color.Black);
                nbm.SetPixel(89, i, Color.Black);
            }
            nbm.SetPixel(1, 1, Color.Black);
            nbm.SetPixel(88, 1, Color.Black);
            nbm.SetPixel(1, 128, Color.Black);
            nbm.SetPixel(88, 128, Color.Black);
            nbm.SetPixel(0, 0, Color.Green);
            nbm.SetPixel(89, 0, Color.Green);
            nbm.SetPixel(0, 129, Color.Green);
            nbm.SetPixel(89, 129, Color.Green);            
            return nbm;
        }
        private void NewGame()
        {
            Shuffle();
            if (Properties.Settings.Default.standardScoring || Properties.Settings.Default.vegasScoring && !Properties.Settings.Default.cumulativeScoring)
            {
                _score = 0;
                scoreLabel.Text = "Score: " + _score;
            }
            if (Properties.Settings.Default.vegasScoring)
            {
                _score -= 52;
                if (_score >= 0)
                    scoreLabel.Text = "Money: $" + _score;
                else
                    scoreLabel.Text = "Money: $(" + Math.Abs(_score).ToString() + ")";
            }
            time.Enabled = false;
            _timerEnabled = false;
            _time = 0;
            timeLabel.Text = "Time: " + _time;
            _moves = new string[2, 0];
            _drawPileRefresh = 0;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (i == 0)
                    {
                        i = j;
                        //cardDeck[_drawPile[_drawPile[52] - 1]].Image = cardDeck[_drawPile[_drawPile[52] - 1]].InitialImage;
                        cardDeck[_drawPile[_drawPile[52] - 1]].Tag = _drawPile[_drawPile[52] - 1].ToString("00") + "TableauS" + i.ToString();
                    }
                    else
                    {
                        cardDeck[_drawPile[_drawPile[52] - 1]].Tag = _drawPile[_drawPile[52] - 1].ToString("00") + "TableauD" + i.ToString();
                    }
                    //cardDeck[_drawPile[_drawPile[52] - 1]].Left = _leftPosition[i];
                    //cardDeck[_drawPile[_drawPile[52] - 1]].Top = 170 + j * 5;
                    cardDeck[_drawPile[_drawPile[52] - 1]].BringToFront();
                    _tableauPile[i, j] = _drawPile[_drawPile[52] - 1];
                    _tableauPile[i, 19]++;
                    _drawPile[_drawPile[52] - 1] = -1;
                    _drawPile[52]--;
                }
            }
            SetTableau();
        }
        private void Shuffle()
        {
            for (int i = 0; i < 13; i++)
            {
                _mc[i] = null;
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    _tableauPile[i, j] = -1;
                }
                _tableauPile[i, 19] = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    _foundationPile[i, j] = -1;
                }
                _foundationPile[i, 13] = 0;
            }
            for (int i = 0; i < 24; i++)
            {
                _flipPile[i] = -1;
            }
            for (int i = 0; i < 52; i++)
            {
                cardDeck[i].Image = backOfCard;
                cardDeck[i].Top = 30;
                cardDeck[i].Left = _leftPosition[0];
                cardDeck[i].Tag = i.ToString("00") + "Draw";
                _drawPile[i] = i;
            }
            _drawPile[52] = 52;
            _flipPile[24] = 0;
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int r = rand.Next(52);
                    int temp = _drawPile[i];
                    _drawPile[i] = _drawPile[r];
                    _drawPile[r] = temp;
                }
            }
            for (int i = 0; i < 52; i++)
            {
                cardDeck[_drawPile[i]].BringToFront();
            }
        }
        private int percentOverCard(PictureBox card1, PictureBox card2)
        {
            if (Math.Abs(card1.Left - card2.Left) > 90 || Math.Abs(card1.Top - card2.Top) > 130)
                return 0;
            double percent = ((90 - Math.Abs(card1.Left - card2.Left)) / 90.0) * ((130 - Math.Abs(card1.Top - card2.Top)) / 130.0);
            if (percent < 0)
                percent = 0;
            return (int)Math.Round(percent * 100);
        }
        private void moveToTableau(int pile)
        {
            if (Properties.Settings.Default.standardScoring)
            {
                if (((string)_mc[0].Tag).Contains("Flip"))
                {
                    _score += 5;
                }
                if (((string)_mc[0].Tag).Contains("Foundation"))
                {
                    _score = (_score - 15 < 0 ? 0 : _score - 15);
                }
                scoreLabel.Text = "Score: " + _score;
            }
            if (Properties.Settings.Default.vegasScoring)
            {
                if (((string)_mc[0].Tag).Contains("Foundation"))
                {
                    _score -= 5;
                }
                if (_score >= 0)
                    scoreLabel.Text = "Money: $" + _score;
                else
                    scoreLabel.Text = "Money: $(" + Math.Abs(_score).ToString() + ")";
            }
            //move cards there
            _cx = 0;
            _cy = 0;
            _mx = _mc[0].Left;
            _my = _mc[0].Top;
            for (int j = _tableauPile[pile, 19]; j - _tableauPile[pile, 19] < 13 && _mc[j - _tableauPile[pile, 19]] != null; j++)
            {
                _moveX[j - _tableauPile[pile, 19]] = _leftPosition[pile];
                if (Convert.ToInt32(((string)_mc[j - _tableauPile[pile, 19]].Tag).Substring(0, 2)) % 13 == 12)
                {
                    _moveY[j - _tableauPile[pile, 19]] = 170;
                }
                else if (j - _tableauPile[pile, 19] == 0)
                {
                    _moveY[j - _tableauPile[pile, 19]] = cardDeck[_tableauPile[pile, _tableauPile[pile, 19] - 1]].Top + 15;
                }
                else
                {
                    _moveY[j - _tableauPile[pile, 19]] = _moveY[j - _tableauPile[pile, 19] - 1] + 15;
                }
            }
            //add cards to pile
            string moveFrom = "";
            string moveTo = "";
            int tPile = -1;
            for (int j = 0; j < 13 && _mc[j] != null; j++)
            {
                _tableauPile[pile, _tableauPile[pile, 19]] = Convert.ToInt32(((string)_mc[j].Tag).Substring(0,2));
                _tableauPile[pile, 19]++;
                //take cards off old pile
                if (((string)_mc[j].Tag).Contains("Tableau"))
                {
                    tPile = Convert.ToInt32(((string)_mc[j].Tag).Substring(10));
                    _tableauPile[tPile, _tableauPile[tPile, 19] - 1] = -1;
                    _tableauPile[tPile, 19]--;

                }
                else if (((string)_mc[j].Tag).Contains("Flip"))
                {
                    _flipPile[_flipPile[24] - 1] = -1;
                    _flipPile[24]--;
                    if (_flipPile[24] > 1 && Properties.Settings.Default.drawCards == 3 && Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6)) != _leftPosition[1])
                    {
                        cardDeck[_flipPile[_flipPile[24] - 1]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6));
                        cardDeck[_flipPile[_flipPile[24] - 2]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 2]].Tag).Substring(6));
                    }
                }
                else if (((string)_mc[j].Tag).Contains("Foundation"))
                {
                    int fPile = Convert.ToInt32(((string)_mc[j].Tag).Substring(12));
                    _foundationPile[fPile, _foundationPile[fPile, 13] - 1] = -1;
                    _foundationPile[fPile, 13]--;
                }
                moveFrom += "|" + (string)_mc[j].Tag;
                _mc[j].Tag = ((string)_mc[j].Tag).Substring(0, 2) + "TableauS" + pile.ToString();
                moveTo += "|" + (string)_mc[j].Tag;
            }
            if (tPile != -1 && Properties.Settings.Default.autoFlip && _tableauPile[tPile, 19] != 0 && ((string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag).Contains("TableauD"))
            {
                if (Properties.Settings.Default.standardScoring)
                {
                    _score += 5;
                    scoreLabel.Text = "Score: " + _score;
                }
                cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Image = cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].InitialImage;
                moveFrom = "|" + (string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag + moveFrom;
                cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag = _tableauPile[tPile, _tableauPile[tPile, 19] - 1].ToString("00") + "TableauS" + tPile.ToString();
                moveTo = "|" + (string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag + moveTo;
            }
            moveFrom = moveFrom.Substring(1);
            moveTo = moveTo.Substring(1);
            addMove(moveFrom, moveTo);
            _cardMoveSpeed = 10;
            cardMoveTimer.Enabled = true;
        }
        private void moveToFoundation(int pile)
        {
            if (!((string)_mc[0].Tag).Contains("Foundation"))
            {
                if (Properties.Settings.Default.standardScoring)
                {
                    _score += 10;
                    scoreLabel.Text = "Score: " + _score;
                }
                if (Properties.Settings.Default.vegasScoring)
                {
                    _score += 5;
                    if (_score >= 0)
                        scoreLabel.Text = "Money: $" + _score;
                    else
                        scoreLabel.Text = "Money: $(" + Math.Abs(_score).ToString() + ")";
                }
            }
            int card = Convert.ToInt32(((string)_mc[0].Tag).Substring(0, 2));
            // move card
            _cx = 0;
            _cy = 0;
            _mx = _mc[0].Left;
            _my = _mc[0].Top;
            _moveX[0] = _leftPosition[pile + 3];
            _moveY[0] = 30;
            //addcard to pile
            _foundationPile[pile, _foundationPile[pile, 13]] = card;
            _foundationPile[pile, 13]++;
            //take card off of old pile
            int tPile = -1;
            if (((string)_mc[0].Tag).Contains("Tableau"))
            {
                tPile = Convert.ToInt32(((string)_mc[0].Tag).Substring(10));
                _tableauPile[tPile, _tableauPile[tPile, 19] - 1] = -1;
                _tableauPile[tPile, 19]--;
            }
            else if (((string)_mc[0].Tag).Contains("Flip"))
            {
                _flipPile[_flipPile[24] - 1] = -1;
                _flipPile[24]--;
                if (_flipPile[24] > 1 && Properties.Settings.Default.drawCards == 3 && Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6)) != _leftPosition[1])
                {
                    cardDeck[_flipPile[_flipPile[24] - 1]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 1]].Tag).Substring(6));
                    cardDeck[_flipPile[_flipPile[24] - 2]].Left = Convert.ToInt32(((string)cardDeck[_flipPile[_flipPile[24] - 2]].Tag).Substring(6));
                }
            }
            else if (((string)_mc[0].Tag).Contains("Foundation"))
            {
                int fPile = Convert.ToInt32(((string)_mc[0].Tag).Substring(12));
                _foundationPile[fPile, 0] = -1;
                _foundationPile[fPile, 13]--;
            }
            string moveFrom = (string)_mc[0].Tag;
            _mc[0].Tag = ((string)_mc[0].Tag).Substring(0, 2) + "Foundation" + (pile).ToString();
            string moveTo = (string)_mc[0].Tag;
            if (tPile != -1 && Properties.Settings.Default.autoFlip && _tableauPile[tPile, 19] != 0 && ((string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag).Contains("TableauD"))
            {
                if (Properties.Settings.Default.standardScoring)
                {
                    _score += 5;
                    scoreLabel.Text = "Score: " + _score;
                }
                cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Image = cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].InitialImage;
                moveFrom = (string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag + "|" + moveFrom;
                cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag = _tableauPile[tPile, _tableauPile[tPile, 19] - 1].ToString("00") + "TableauS" + tPile.ToString();
                moveTo = (string)cardDeck[_tableauPile[tPile, _tableauPile[tPile, 19] - 1]].Tag + "|" + moveTo;
            }
            addMove(moveFrom, moveTo);
            _cardMoveSpeed = 10;
            cardMoveTimer.Enabled = true;
        }
        private bool NoMoreMoves()
        {
            return false;
            /*for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (_tableauPile[i, j] == -1)
                        break;
                    if (((string)cardDeck[_tableauPile[i, j]].Tag).Contains("TableauS") && CheckIfCardCanMove(cardDeck[_tableauPile[i, j]], true, true))
                    {
                        return false;
                    }
                }
            }
            /*for (int i = 0; i < 4; i++)
            {
                if (_foundationPile[i, 19] != 0 && CardDoubleClick(cardDeck[_foundationPile[i, _foundationPile[i, 19] - 1]], true))
                {
                    //check if it will help
                    return false;
                }
            }/
            if (_flipPile[24] != 0 && CheckIfCardCanMove(cardDeck[_flipPile[24] - 1], true, true))
            {
                return false;
            }
            if(_drawPile[52] != 0)
            {
                int cardPlace = Properties.Settings.Default.drawCards;
                while (cardPlace < _drawPile[52])
                {
                    if(CheckIfCardCanMove(cardDeck[_drawPile[_drawPile[52] - cardPlace]], true, true))
                    {
                        return false;
                    }
                    cardPlace += Properties.Settings.Default.drawCards;
                }
                if (CheckIfCardCanMove(cardDeck[_drawPile[0]], true, true))
                {
                    return false;
                }
                cardPlace = Properties.Settings.Default.drawCards - 1;
                while (cardPlace < _flipPile[24] - 1)
                {
                    if (CheckIfCardCanMove(cardDeck[_flipPile[cardPlace]], true, true))
                    {
                        return false;
                    }
                    cardPlace += Properties.Settings.Default.drawCards;
                }
                cardPlace = cardPlace - _flipPile[24] - 1;
                while (cardPlace < _drawPile[52])
                {
                    if (CheckIfCardCanMove(cardDeck[_drawPile[_drawPile[52] - cardPlace]], true, true))
                    {
                        return false;
                    }
                    cardPlace += Properties.Settings.Default.drawCards;
                }
            }
            return true;*/
        }
        private void addMove(string moveFrom, string moveTo)
        {
            string[,] temp = new string[2, _moves.Length / 2];
            for (int i = 0; i < _moves.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    temp[j, i] = _moves[j, i];
                }
            }
            _moves = new string[2, _moves.Length / 2 + 1];
            for (int i = 0; i < temp.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    _moves[j, i] = temp[j, i];
                }
            }
            _moves[0, _moves.Length / 2 - 1] = moveFrom;
            _moves[1, _moves.Length / 2 - 1] = moveTo;
        }
        private void findMove(bool hint, bool cheat)
        {
            for (int i = 0; i < 96; i++)
            {
                if (i < 91)
                {
                    if (_tableauPile[i / 13, 19] != 0)
                    {
                        if (_tableauPile[i / 13, 19] - 1 - i % 13 > -1 && ((string)cardDeck[_tableauPile[i / 13, _tableauPile[i / 13, 19] - 1 - i % 13]].Tag).Contains("TableauS"))
                        {
                            _mc[0] = cardDeck[_tableauPile[i / 13, _tableauPile[i / 13, 19] - 1 - i % 13]];
                        }
                        else
                        {
                            i = (i / 13 + 1) * 13 - 1;
                        }
                    }
                    else
                    {
                        i = (i / 13 + 1) * 13 - 1;
                    }
                }
                else if (i == 91 && _flipPile[24] != 0)
                {
                    _mc[0] = cardDeck[_flipPile[_flipPile[24] - 1]];
                }
                else if (i > 91 && _foundationPile[i - 92, 13] != 0)
                {
                    _mc[0] = cardDeck[_foundationPile[i - 92, _foundationPile[i - 92, 13] - 1]];
                }
                if (hint && _mc[0] != null && CheckIfCardCanMove(_mc[0], true, false))
                {
                    _mc[0].Image = Invert(_mc[0].Image);
                    _mc[0] = null;
                }
                else
                {
                    for (int j = 0; j < 13; j++)
                    {
                        _mc[j] = null;
                    }
                }
            }
            if (!_cheat)
                InvertTimer.Enabled = true;
        }
        private bool Done()
        {
            for (int i = 0; i < 4; i++)
            {
                if (_foundationPile[i, 13] != 13)
                    return false;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cardDeck[_foundationPile[i, j]].Image = cardDeck[_foundationPile[i, j]].InitialImage;
                }
            }
            _endGame = (new Random()).Next(4);
            endGame();
            return true;
        }
        private void Cheat()
        {
            for (int i = 0; i < 52; i++)
            {
                if (((string)cardDeck[i].Tag).Contains("TableauS") || ((string)cardDeck[i].Tag).Contains("Foundation") || ((string)cardDeck[i].Tag).Contains("Flip"))
                {
                    cardDeck[i].Image = cardDeck[i].InitialImage;
                }
            }
            findMove(true, true);
        }
        private void rightClick()
        {
            bool cardMoved = false;
            for (int i = 0; i < 4; i++)
            {
                int card = -1;
                if (_foundationPile[i, 13] == 13)
                {
                    continue;
                }
                else if (_foundationPile[i, 13] == 0)
                {
                    if (_flipPile[24] > 0 && _flipPile[_flipPile[24] - 1] % 13 == 0)
                    {
                        card = _flipPile[_flipPile[24] - 1];
                        cardMoved = true;
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (_tableauPile[j, 19] > 0)
                            {
                                card = _tableauPile[j, _tableauPile[j, 19] - 1];
                                if (card % 13 == 0 && ((string)cardDeck[card].Tag).Contains("TableauS"))
                                {
                                    cardMoved = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    card = _foundationPile[i, _foundationPile[i, 13] - 1] + 1;
                    if (_flipPile[24] > 0 && _flipPile[_flipPile[24] - 1] == card)
                    {
                        cardMoved = true;
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (_tableauPile[j, 19] > 0 && card == _tableauPile[j, _tableauPile[j, 19] - 1] && ((string)cardDeck[card].Tag).Contains("TableauS"))
                            {
                                cardMoved = true;
                            }
                        }
                    }
                }
                if (cardMoved)
                {
                    _mc[0] = cardDeck[card];
                    _mc[0].Image = _mc[0].InitialImage;
                    int tPile = -1;
                    if (((string)_mc[0].Tag).Contains("TableauS"))
                    {
                        tPile = Convert.ToInt32(((string)_mc[0].Tag).Substring(10));
                    }
                    _rightClick = true;
                    moveToFoundation(i);
                    if (_endGame != -1)
                        return;
                    break;
                }
            }
            if (!cardMoved && _cheat)
                Cheat();
        }
        private Image Invert(Image img)
        {
            Bitmap bm = new Bitmap(img);
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Color clr = bm.GetPixel(i, j);
                    clr = Color.FromArgb(clr.A, 255 - clr.R, 255 - clr.G, 255 - clr.B);
                    bm.SetPixel(i, j, clr);
                }
            }
            return bm;
        }
        private Image Colors(Image img)
        {
            Bitmap bm = new Bitmap(img);
            Random rand = new Random();
            int r = rand.Next(3);
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Color clr = bm.GetPixel(i, j);
                    if (r == 0)
                        clr = Color.FromArgb(clr.A, (clr.R + 100 > 255) ? 255 : clr.R + 100, clr.G, clr.B);
                    if (r == 1)
                        clr = Color.FromArgb(clr.A, clr.R, (clr.G + 100 > 255) ? 255 : clr.G + 100, clr.B);
                    if (r == 2)
                        clr = Color.FromArgb(clr.A, clr.R, clr.G, (clr.B + 100 > 255) ? 255 : clr.B + 100);
                    bm.SetPixel(i, j, clr);
                }
            }
            return bm;
        }
        private void endGame()
        {
            _rightClick = false;
            switch (_endGame)
            {
                case 0:
                    if (_mc[0] == null)
                    {
                        _mc[0] = cardDeck[_foundationPile[0, 12]];
                        _mc[0].BringToFront();
                        _mc[0].Image = Colors(Invert(_mc[0].Image));
                        _foundationPile[0, 13]--;
                        Random rand = new Random();
                        do
                        {
                            _moveX[0] = rand.Next(-4, 5) * 10;
                            _moveY[0] = rand.Next(-4, 5) * 10;
                        } while (_moveX[0] == 0 && _moveY[0] == 0);
                        endTimer.Enabled = true;
                    }
                    else if (!_endGameStop && _foundationPile[3, 13] != 0)
                    {
                        int pile = Convert.ToInt32(((string)_mc[0].Tag).Substring(12));
                        if (pile == 3)
                        {
                            _mc[0] = cardDeck[_foundationPile[0, --_foundationPile[0, 13]]];
                        }
                        else
                        {
                            _mc[0] = cardDeck[_foundationPile[pile + 1, --_foundationPile[pile + 1, 13]]];
                        }
                        _mc[0].BringToFront();
                        _mc[0].Image = Colors(Invert(_mc[0].Image));
                        Random rand = new Random();
                        do
                        {
                            _moveX[0] = rand.Next(-4, 5) * 10;
                            _moveY[0] = rand.Next(-4, 5) * 10;
                        } while (_moveX[0] == 0 && _moveY[0] == 0);
                        endTimer.Enabled = true;
                    }
                    else
                    {
                        _mc[0] = null;
                        _endGame = -1;
                        _endGameStop = false;
                        if (MessageBox.Show("New Game?", "You Won!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            ResetCards();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    break;
                case 1:
                    if (!_endGameStop && _foundationPile[0, 13] != 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _mc[i] = cardDeck[_foundationPile[i, --_foundationPile[i, 13]]];
                            _mc[i].BringToFront();
                            _mc[i].Image = Colors(Invert(_mc[i].Image));
                            Random rand = new Random();
                            do
                            {
                                _moveX[i] = rand.Next(-4, 5) * 10;
                                _moveY[i] = rand.Next(-4, 5) * 10;
                            } while (_moveX[i] == 0 && _moveY[i] == 0);
                        }
                        endTimer.Enabled = true;
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _mc[i] = null;
                        }
                        _endGame = -1;
                        _endGameStop = false;
                        if (MessageBox.Show("New Game?", "You Won!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            ResetCards();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    break;
                case 2:
                    if (_mc[0] == null)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            _mc[i] = cardDeck[_foundationPile[0, i]];
                            _mc[i].BringToFront();
                            _mc[i].Image = Colors(Invert(_mc[i].Image));
                            Random rand = new Random();
                            do
                            {
                                _moveX[i] = rand.Next(-4, 5) * 10;
                                _moveY[i] = rand.Next(-4, 5) * 10;
                            } while (_moveX[i] == 0 && _moveY[i] == 0);
                        }
                        _foundationPile[0, 13] = 0;
                        endTimer.Enabled = true;
                    }
                    else if (!_endGameStop && _foundationPile[3, 13] != 0)
                    {
                        int pile = Convert.ToInt32(((string)_mc[0].Tag).Substring(12)) + 1;
                        for (int i = 0; i < 13; i++)
                        {
                            _mc[i] = cardDeck[_foundationPile[pile, i]];
                            _mc[i].BringToFront();
                            _mc[i].Image = Colors(Invert(_mc[i].Image));
                            Random rand = new Random();
                            do
                            {
                                _moveX[i] = rand.Next(-4, 5) * 10;
                                _moveY[i] = rand.Next(-4, 5) * 10;
                            } while (_moveX[i] == 0 && _moveY[i] == 0);
                        }
                        _foundationPile[pile, 13] = 0;
                        endTimer.Enabled = true;
                    }
                    else
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            _mc[i] = null;
                        }
                        _endGame = -1;
                        _endGameStop = false;
                        if (MessageBox.Show("New Game?", "You Won!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            ResetCards();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    break;
                case 3:
                    if (_mc[0] == null)
                    {
                        _mc[0] = cardDeck[_foundationPile[0, 12]];
                        _mc[0].BringToFront();
                        _mc[0].Image = Colors(Invert(_mc[0].Image));
                        _foundationPile[0, 13]--;
                        Random rand = new Random();
                        do
                        {
                            _moveX[0] = rand.Next(-4, 5) * 10;
                            _moveY[0] = rand.Next(-4, 5) * 10;
                        } while (_moveX[0] == 0 && _moveY[0] == 0);
                        endTimer.Enabled = true;
                    }
                    else if (!_endGameStop && _mc[0] != cardDeck[_foundationPile[3, 0]])
                    {
                        int pile = Convert.ToInt32(((string)_mc[0].Tag).Substring(12));
                        int card = Convert.ToInt32(((string)_mc[0].Tag).Substring(0, 2));
                        if (card % 13 == 0)
                        {
                            _mc[0] = cardDeck[_foundationPile[pile + 1, --_foundationPile[pile + 1, 13]]];
                        }
                        else
                        {
                            _mc[0] = cardDeck[card - 1];
                        }
                        _mc[0].BringToFront();
                        _mc[0].Image = Colors(Invert(_mc[0].Image));
                        Random rand = new Random();
                        do
                        {
                            _moveX[0] = rand.Next(-4, 5) * 10;
                            _moveY[0] = rand.Next(-4, 5) * 10;
                        } while (_moveX[0] == 0 && _moveY[0] == 0);
                        endTimer.Enabled = true;
                    }
                    else
                    {
                        _mc[0] = null;
                        _endGame = -1;
                        _endGameStop = false;
                        if (MessageBox.Show("New Game?", "You Won!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            ResetCards();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    break;
            }
        }
        private void OpenGame(string file)
        {
            System.IO.StreamReader fileR = new System.IO.StreamReader(file);
            string line = fileR.ReadLine();//Properties.Settings.Default.cardBack + "|" + Properties.Settings.Default.cumulativeScoring + "|" + Properties.Settings.Default.drawCards + "|" + Properties.Settings.Default.showStatus + "|" + Properties.Settings.Default.showTimer + "|" + Properties.Settings.Default.standardScoring + "|" + Properties.Settings.Default.vegasScoring);
            Properties.Settings.Default.autoFlip = (line.Split('|')[0] == "True");
            Properties.Settings.Default.cardBack = line.Split('|')[1];
            Properties.Settings.Default.cumulativeScoring = (line.Split('|')[2] == "True");
            Properties.Settings.Default.drawCards = Convert.ToInt32(line.Split('|')[3]);
            Properties.Settings.Default.showStatus = (line.Split('|')[4] == "True");
            Properties.Settings.Default.showTimer = (line.Split('|')[5] == "True");
            Properties.Settings.Default.standardScoring = (line.Split('|')[6] == "True");
            Properties.Settings.Default.vegasScoring = (line.Split('|')[7] == "True");
            Properties.Settings.Default.Save();
            if (System.IO.File.Exists(Properties.Settings.Default.cardBack))
                backOfCard = MakeBackOfCard(Properties.Settings.Default.cardBack);
            else
                backOfCard = Properties.Resources.clouds;
            line = fileR.ReadLine();//_cheat + "|" + _time + "|" + _score + "|" + _drawPileRefresh + "|" + _moves.Length);
            _cheat = (line.Split('|')[0] == "True");
            cheatToolStripMenuItem.Checked = _cheat;
            _time = Convert.ToInt32(line.Split('|')[1]);
            _score = Convert.ToInt32(line.Split('|')[2]);
            _drawPileRefresh = Convert.ToInt32(line.Split('|')[3]);
            _autoPlay = (line.Split('|')[4] == "True");
            _moves = new string[2, Convert.ToInt32(line.Split('|')[5])];
            for (int i = 0; i < _moves.Length / 2; i++)
            {
                line = fileR.ReadLine();//_moves[0, i] + ";" + _moves[1, i]);
                _moves[0, i] = line.Split(';')[0];
                _moves[1, i] = line.Split(';')[1];
            }
            for (int i = 0; i < 53; i++)
            {
                line = fileR.ReadLine();//_drawPile[i]);
                _drawPile[i] = Convert.ToInt32(line);
                if (i < 52 && _drawPile[i] > -1)
                    cardDeck[_drawPile[i]].BringToFront();
            }
            for (int i = 0; i < 25; i++)
            {
                line = fileR.ReadLine();//_flipPile[i]);
                _flipPile[i] = Convert.ToInt32(line);
                if (i < 24 && _flipPile[i] > -1)
                    cardDeck[_flipPile[i]].BringToFront();
            }
            for (int i = 0; i < 14; i++)
            {
                line = fileR.ReadLine();//_foundationPile[0, i] + "|" + _foundationPile[1, i] + "|" + _foundationPile[2, i] + "|" + _foundationPile[3, i]);
                for (int j = 0; j < 4; j++)
                {
                    _foundationPile[j, i] = Convert.ToInt32(line.Split('|')[j]);
                    if (i < 13 && _foundationPile[j, i] > -1)
                        cardDeck[_foundationPile[j, i]].BringToFront();
                }
            }
            for (int i = 0; i < 20; i++)
            {
                line = fileR.ReadLine();//_tableauPile[0, i] + "|" + _tableauPile[1, i] + "|" + _tableauPile[2, i] + "|" + _tableauPile[3, i] + "|" + _tableauPile[4, i] + "|" + _tableauPile[5, i] + "|" + _tableauPile[6, i]);
                for (int j = 0; j < 7; j++)
                {
                    _tableauPile[j, i] = Convert.ToInt32(line.Split('|')[j]);
                    if (i < 19 && _tableauPile[j, i] > -1)
                        cardDeck[_tableauPile[j, i]].BringToFront();
                }
            }
            for (int i = 0; i < 52; i++)
            {
                line = fileR.ReadLine();//cardDeck[i].Top + "|" + cardDeck[i].Left + "|" + cardDeck[i].Tag.ToString());
                cardDeck[i].Hide();
                cardDeck[i].Top = Convert.ToInt32(line.Split('|')[0]);
                cardDeck[i].Left = Convert.ToInt32(line.Split('|')[1]);
                cardDeck[i].Show();
                cardDeck[i].Tag = line.Split('|')[2];
                if (((string)cardDeck[i].Tag).Contains("Draw") || ((string)cardDeck[i].Tag).Contains("TableauD"))
                {
                    cardDeck[i].Image = backOfCard;
                }
                else
                {
                    cardDeck[i].Image = cardDeck[i].InitialImage;
                }
            }
            fileR.Close();
            if (_cheat)
            {
                Cheat();
            }
        }
        private void SaveGame(string file)
        {
            System.IO.StreamWriter fileW = new System.IO.StreamWriter(file, false);
            fileW.WriteLine(Properties.Settings.Default.autoFlip + "|" + Properties.Settings.Default.cardBack + "|" + Properties.Settings.Default.cumulativeScoring + "|" + Properties.Settings.Default.drawCards + "|" + Properties.Settings.Default.showStatus + "|" + Properties.Settings.Default.showTimer + "|" + Properties.Settings.Default.standardScoring + "|" + Properties.Settings.Default.vegasScoring);
            fileW.WriteLine(_cheat + "|" + _time + "|" + _score + "|" + _drawPileRefresh + "|" + _autoPlay + "|" + (_moves.Length / 2));
            for (int i = 0; i < _moves.Length / 2; i++)
            {
                fileW.WriteLine(_moves[0, i] + ";" + _moves[1, i]);
            }
            for (int i = 0; i < 53; i++)
            {
                fileW.WriteLine(_drawPile[i]);
            }
            for (int i = 0; i < 25; i++)
            {
                fileW.WriteLine(_flipPile[i]);
            }
            for (int i = 0; i < 14; i++)
            {
                fileW.WriteLine(_foundationPile[0, i] + "|" + _foundationPile[1, i] + "|" + _foundationPile[2, i] + "|" + _foundationPile[3, i]);
            }
            for (int i = 0; i < 20; i++)
            {
                fileW.WriteLine(_tableauPile[0, i] + "|" + _tableauPile[1, i] + "|" + _tableauPile[2, i] + "|" + _tableauPile[3, i] + "|" + _tableauPile[4, i] + "|" + _tableauPile[5, i] + "|" + _tableauPile[6, i]);
            }
            for (int i = 0; i < 52; i++)
            {
                fileW.WriteLine(cardDeck[i].Top + "|" + cardDeck[i].Left + "|" + cardDeck[i].Tag.ToString());
            }
            fileW.Close();
        }
        private void AutoPlay()
        {
            //auto play
        }
        private void ResetCards()
        {
            _cardMoveSpeed = 3;
            for (int i = 0; i < 52; i++)
            {
                if (cardDeck[i].Top != 30 || cardDeck[i].Left != _leftPosition[0])
                {
                    _reset = true;
                    _mc[0] = cardDeck[i];
                    _mc[0].Image = _mc[0].InitialImage;
                    _cx = 0;
                    _cy = 0;
                    _mx = _mc[0].Left;
                    _my = _mc[0].Top;
                    _moveX[0] = _leftPosition[0];
                    _moveY[0] = 30;
                    cardMoveTimer.Enabled = true;
                    break;
                }
                else
                {
                    cardDeck[i].Image = backOfCard;
                }
            }
            if (!_reset)
            {
                NewGame();
            }
        }
        private void SetTableau()
        {
            _cardMoveSpeed = 4;
            for (int i = 0; i < 7; i++)
            {
                for (int j = i; j < 7; j++)
                {
                    if(cardDeck[_tableauPile[j,i]].Top == 30 && cardDeck[_tableauPile[j,i]].Left == _leftPosition[0])
                    {
                        _setTab = true;
                        _mc[0] = cardDeck[_tableauPile[j, i]];
                        if (j == i)
                        {
                            _mc[0].Image = _mc[0].InitialImage;
                        }
                        _cx = 0;
                        _cy = 0;
                        _mx = _mc[0].Left;
                        _my = _mc[0].Top;
                        _moveX[0] = _leftPosition[j];
                        _moveY[0] = 170 + i * 5;
                        _cardMoveSpeed = 4;
                        cardMoveTimer.Enabled = true;
                        goto end;
                    }
                }
            }
            end:
            if (!_setTab && _cheat)
            {
                Cheat();
            }
        }
    }
}
/* check if no moves left
 * auto play
*/