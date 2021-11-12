
namespace week08
{
    partial class Form1
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.carBtn = new System.Windows.Forms.Button();
            this.ballBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBallColor = new System.Windows.Forms.Button();
            this.presentBtn = new System.Windows.Forms.Button();
            this.btnBoxColor = new System.Windows.Forms.Button();
            this.btnRibbonColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 155);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 283);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // carBtn
            // 
            this.carBtn.Location = new System.Drawing.Point(12, 12);
            this.carBtn.Name = "carBtn";
            this.carBtn.Size = new System.Drawing.Size(124, 49);
            this.carBtn.TabIndex = 1;
            this.carBtn.Text = "CAR";
            this.carBtn.UseVisualStyleBackColor = true;
            this.carBtn.Click += new System.EventHandler(this.carBtn_Click);
            // 
            // ballBtn
            // 
            this.ballBtn.Location = new System.Drawing.Point(142, 13);
            this.ballBtn.Name = "ballBtn";
            this.ballBtn.Size = new System.Drawing.Size(124, 49);
            this.ballBtn.TabIndex = 2;
            this.ballBtn.Text = "BALL";
            this.ballBtn.UseVisualStyleBackColor = true;
            this.ballBtn.Click += new System.EventHandler(this.ballBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // btnBallColor
            // 
            this.btnBallColor.BackColor = System.Drawing.Color.Orange;
            this.btnBallColor.Location = new System.Drawing.Point(142, 69);
            this.btnBallColor.Name = "btnBallColor";
            this.btnBallColor.Size = new System.Drawing.Size(124, 23);
            this.btnBallColor.TabIndex = 4;
            this.btnBallColor.UseVisualStyleBackColor = false;
            this.btnBallColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // presentBtn
            // 
            this.presentBtn.Location = new System.Drawing.Point(272, 13);
            this.presentBtn.Name = "presentBtn";
            this.presentBtn.Size = new System.Drawing.Size(124, 49);
            this.presentBtn.TabIndex = 5;
            this.presentBtn.Text = "PRESENT";
            this.presentBtn.UseVisualStyleBackColor = true;
            this.presentBtn.Click += new System.EventHandler(this.presentBtn_Click);
            // 
            // btnBoxColor
            // 
            this.btnBoxColor.BackColor = System.Drawing.Color.DarkRed;
            this.btnBoxColor.Location = new System.Drawing.Point(272, 68);
            this.btnBoxColor.Name = "btnBoxColor";
            this.btnBoxColor.Size = new System.Drawing.Size(124, 23);
            this.btnBoxColor.TabIndex = 6;
            this.btnBoxColor.UseVisualStyleBackColor = false;
            this.btnBoxColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // btnRibbonColor
            // 
            this.btnRibbonColor.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRibbonColor.Location = new System.Drawing.Point(272, 97);
            this.btnRibbonColor.Name = "btnRibbonColor";
            this.btnRibbonColor.Size = new System.Drawing.Size(124, 23);
            this.btnRibbonColor.TabIndex = 7;
            this.btnRibbonColor.UseVisualStyleBackColor = false;
            this.btnRibbonColor.Click += new System.EventHandler(this.btnBallColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRibbonColor);
            this.Controls.Add(this.btnBoxColor);
            this.Controls.Add(this.presentBtn);
            this.Controls.Add(this.btnBallColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ballBtn);
            this.Controls.Add(this.carBtn);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button carBtn;
        private System.Windows.Forms.Button ballBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBallColor;
        private System.Windows.Forms.Button presentBtn;
        private System.Windows.Forms.Button btnBoxColor;
        private System.Windows.Forms.Button btnRibbonColor;
    }
}

