
namespace Kursova_Chess
{
    partial class GameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.errout = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSwitchView = new System.Windows.Forms.Button();
            this.btnShowLegal = new System.Windows.Forms.Button();
            this.lPlayerTurn = new System.Windows.Forms.Label();
            this.scrW = new System.Windows.Forms.Label();
            this.scrB = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errout
            // 
            this.errout.AutoSize = true;
            this.errout.Location = new System.Drawing.Point(12, 383);
            this.errout.Name = "errout";
            this.errout.Size = new System.Drawing.Size(35, 15);
            this.errout.TabIndex = 1;
            this.errout.Text = "Error:\r\n";
            this.errout.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 37);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Kursova_Chess.Properties.Resources.Board;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(163, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 5;
            this.panel1.Tag = "SGI";
            this.panel1.Visible = false;
            // 
            // btnSwitchView
            // 
            this.btnSwitchView.Location = new System.Drawing.Point(12, 55);
            this.btnSwitchView.Name = "btnSwitchView";
            this.btnSwitchView.Size = new System.Drawing.Size(136, 37);
            this.btnSwitchView.TabIndex = 6;
            this.btnSwitchView.Text = "Switch View";
            this.btnSwitchView.UseVisualStyleBackColor = true;
            this.btnSwitchView.Visible = false;
            this.btnSwitchView.Click += new System.EventHandler(this.btnSwitchView_Click);
            // 
            // btnShowLegal
            // 
            this.btnShowLegal.Location = new System.Drawing.Point(12, 98);
            this.btnShowLegal.Name = "btnShowLegal";
            this.btnShowLegal.Size = new System.Drawing.Size(136, 37);
            this.btnShowLegal.TabIndex = 7;
            this.btnShowLegal.Text = "Moves: On";
            this.btnShowLegal.UseVisualStyleBackColor = true;
            this.btnShowLegal.Visible = false;
            this.btnShowLegal.Click += new System.EventHandler(this.btnShowLegal_Click);
            // 
            // lPlayerTurn
            // 
            this.lPlayerTurn.AutoSize = true;
            this.lPlayerTurn.Location = new System.Drawing.Point(15, 200);
            this.lPlayerTurn.Name = "lPlayerTurn";
            this.lPlayerTurn.Size = new System.Drawing.Size(45, 15);
            this.lPlayerTurn.TabIndex = 1;
            this.lPlayerTurn.Text = " moves";
            this.lPlayerTurn.Visible = false;
            // 
            // scrW
            // 
            this.scrW.AutoSize = true;
            this.scrW.Location = new System.Drawing.Point(15, 150);
            this.scrW.Name = "scrW";
            this.scrW.Size = new System.Drawing.Size(44, 15);
            this.scrW.TabIndex = 1;
            this.scrW.Text = "White: ";
            this.scrW.Visible = false;
            // 
            // scrB
            // 
            this.scrB.AutoSize = true;
            this.scrB.Location = new System.Drawing.Point(15, 175);
            this.scrB.Name = "scrB";
            this.scrB.Size = new System.Drawing.Size(41, 15);
            this.scrB.TabIndex = 1;
            this.scrB.Text = "Black: ";
            this.scrB.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 472);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 37);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 521);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowLegal);
            this.Controls.Add(this.btnSwitchView);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.scrB);
            this.Controls.Add(this.scrW);
            this.Controls.Add(this.lPlayerTurn);
            this.Controls.Add(this.errout);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameWindow";
            this.Tag = "Stanislav Iliev";
            this.Text = "Chess Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSwitchView;
        private System.Windows.Forms.Button btnShowLegal;
        private System.Windows.Forms.Label lPlayerTurn;
        private System.Windows.Forms.Label scrW;
        private System.Windows.Forms.Label scrB;
        private System.Windows.Forms.Button btnExit;
    }
}

