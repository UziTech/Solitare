namespace Solitare
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.draw1Cards = new System.Windows.Forms.RadioButton();
            this.draw3Cards = new System.Windows.Forms.RadioButton();
            this.ok = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.noScoring = new System.Windows.Forms.RadioButton();
            this.vegas = new System.Windows.Forms.RadioButton();
            this.standard = new System.Windows.Forms.RadioButton();
            this.showTimer = new System.Windows.Forms.CheckBox();
            this.showStatus = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.cumulative = new System.Windows.Forms.CheckBox();
            this.autoFlip = new System.Windows.Forms.CheckBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // draw1Cards
            // 
            this.draw1Cards.AutoSize = true;
            this.draw1Cards.Location = new System.Drawing.Point(6, 19);
            this.draw1Cards.Name = "draw1Cards";
            this.draw1Cards.Size = new System.Drawing.Size(84, 17);
            this.draw1Cards.TabIndex = 0;
            this.draw1Cards.Text = "1 Card Draw";
            this.ToolTip.SetToolTip(this.draw1Cards, "Flip 1 card at a time off the draw pile.");
            this.draw1Cards.UseVisualStyleBackColor = true;
            // 
            // draw3Cards
            // 
            this.draw3Cards.AutoSize = true;
            this.draw3Cards.Checked = true;
            this.draw3Cards.Location = new System.Drawing.Point(6, 42);
            this.draw3Cards.Name = "draw3Cards";
            this.draw3Cards.Size = new System.Drawing.Size(84, 17);
            this.draw3Cards.TabIndex = 1;
            this.draw3Cards.TabStop = true;
            this.draw3Cards.Text = "3 Card Draw";
            this.ToolTip.SetToolTip(this.draw3Cards, "Flip 3 cards at a time off the draw pile.");
            this.draw3Cards.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(114, 184);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(13, 156);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 3;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Card Back Image Location";
            this.ToolTip.SetToolTip(this.label1, "Change the image on the back of the cards.");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.draw1Cards);
            this.groupBox1.Controls.Add(this.draw3Cards);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(261, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 130);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.noScoring);
            this.groupBox2.Controls.Add(this.vegas);
            this.groupBox2.Controls.Add(this.standard);
            this.groupBox2.Location = new System.Drawing.Point(114, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 93);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game";
            // 
            // noScoring
            // 
            this.noScoring.AutoSize = true;
            this.noScoring.Location = new System.Drawing.Point(7, 65);
            this.noScoring.Name = "noScoring";
            this.noScoring.Size = new System.Drawing.Size(51, 17);
            this.noScoring.TabIndex = 2;
            this.noScoring.Text = "None";
            this.ToolTip.SetToolTip(this.noScoring, "Don\'t keep score.");
            this.noScoring.UseVisualStyleBackColor = true;
            // 
            // vegas
            // 
            this.vegas.AutoSize = true;
            this.vegas.Location = new System.Drawing.Point(7, 42);
            this.vegas.Name = "vegas";
            this.vegas.Size = new System.Drawing.Size(55, 17);
            this.vegas.TabIndex = 1;
            this.vegas.Text = "Vegas";
            this.ToolTip.SetToolTip(this.vegas, "Only refresh the draw pile 3 times.");
            this.vegas.UseVisualStyleBackColor = true;
            this.vegas.CheckedChanged += new System.EventHandler(this.vegas_CheckedChanged);
            // 
            // standard
            // 
            this.standard.AutoSize = true;
            this.standard.Checked = true;
            this.standard.Location = new System.Drawing.Point(7, 19);
            this.standard.Name = "standard";
            this.standard.Size = new System.Drawing.Size(68, 17);
            this.standard.TabIndex = 0;
            this.standard.TabStop = true;
            this.standard.Text = "Standard";
            this.ToolTip.SetToolTip(this.standard, "Keep score while refreshing the draw pile unlimited number of times.");
            this.standard.UseVisualStyleBackColor = true;
            // 
            // showTimer
            // 
            this.showTimer.AutoSize = true;
            this.showTimer.Checked = true;
            this.showTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTimer.Location = new System.Drawing.Point(12, 89);
            this.showTimer.Name = "showTimer";
            this.showTimer.Size = new System.Drawing.Size(82, 17);
            this.showTimer.TabIndex = 9;
            this.showTimer.Text = "Show Timer";
            this.ToolTip.SetToolTip(this.showTimer, "Show the Timer.");
            this.showTimer.UseVisualStyleBackColor = true;
            // 
            // showStatus
            // 
            this.showStatus.AutoSize = true;
            this.showStatus.Checked = true;
            this.showStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatus.Location = new System.Drawing.Point(12, 112);
            this.showStatus.Name = "showStatus";
            this.showStatus.Size = new System.Drawing.Size(86, 17);
            this.showStatus.TabIndex = 10;
            this.showStatus.Text = "Show Status";
            this.ToolTip.SetToolTip(this.showStatus, "Show the status bar.");
            this.showStatus.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(195, 184);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // cumulative
            // 
            this.cumulative.AutoSize = true;
            this.cumulative.Enabled = false;
            this.cumulative.Location = new System.Drawing.Point(114, 112);
            this.cumulative.Name = "cumulative";
            this.cumulative.Size = new System.Drawing.Size(109, 17);
            this.cumulative.TabIndex = 12;
            this.cumulative.Text = "Cumulative Score";
            this.ToolTip.SetToolTip(this.cumulative, "When playing vegas keep score over multiple games.");
            this.cumulative.UseVisualStyleBackColor = true;
            // 
            // autoFlip
            // 
            this.autoFlip.AutoSize = true;
            this.autoFlip.Checked = true;
            this.autoFlip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFlip.Location = new System.Drawing.Point(12, 133);
            this.autoFlip.Name = "autoFlip";
            this.autoFlip.Size = new System.Drawing.Size(67, 17);
            this.autoFlip.TabIndex = 13;
            this.autoFlip.Text = "Auto Flip";
            this.ToolTip.SetToolTip(this.autoFlip, "Automaticlly flips a card over when a\r\nface-down card is on top of a pile.");
            this.autoFlip.UseVisualStyleBackColor = true;
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 1000;
            this.ToolTip.AutoPopDelay = 5000;
            this.ToolTip.InitialDelay = 1000;
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ReshowDelay = 1000;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Options
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 214);
            this.Controls.Add(this.autoFlip);
            this.Controls.Add(this.cumulative);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.showStatus);
            this.Controls.Add(this.showTimer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton draw1Cards;
        private System.Windows.Forms.RadioButton draw3Cards;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton vegas;
        private System.Windows.Forms.RadioButton standard;
        private System.Windows.Forms.RadioButton noScoring;
        private System.Windows.Forms.CheckBox showTimer;
        private System.Windows.Forms.CheckBox showStatus;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox cumulative;
        private System.Windows.Forms.CheckBox autoFlip;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}