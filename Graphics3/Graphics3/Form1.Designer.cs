namespace Graphics3
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
            this.drawButton = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.parallelProjectionAngle_text = new System.Windows.Forms.TextBox();
            this.help_button = new System.Windows.Forms.Button();
            this.scaleUpBtn = new System.Windows.Forms.Button();
            this.scaleDownBtn = new System.Windows.Forms.Button();
            this.rotateXButton = new System.Windows.Forms.Button();
            this.rotateZButton = new System.Windows.Forms.Button();
            this.rotateYButton = new System.Windows.Forms.Button();
            this.rotationAngle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(32, 172);
            this.drawButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(427, 119);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Perspective projection";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Canvas.Location = new System.Drawing.Point(520, 29);
            this.Canvas.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(3109, 2261);
            this.Canvas.TabIndex = 2;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 439);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(427, 76);
            this.button1.TabIndex = 3;
            this.button1.Text = "Parallel Projection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.drawParallelClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 305);
            this.button2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(427, 119);
            this.button2.TabIndex = 4;
            this.button2.Text = "Oblique projection";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.drawObliqueClicked);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(5, 2227);
            this.exit_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(459, 55);
            this.exit_button.TabIndex = 5;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(5, 2158);
            this.clear_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(459, 55);
            this.clear_button.TabIndex = 6;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 532);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Projection angle";
            // 
            // parallelProjectionAngle_text
            // 
            this.parallelProjectionAngle_text.Location = new System.Drawing.Point(275, 532);
            this.parallelProjectionAngle_text.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.parallelProjectionAngle_text.MaxLength = 3;
            this.parallelProjectionAngle_text.Name = "parallelProjectionAngle_text";
            this.parallelProjectionAngle_text.Size = new System.Drawing.Size(177, 38);
            this.parallelProjectionAngle_text.TabIndex = 8;
            this.parallelProjectionAngle_text.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.parallelProjectionAngle_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.parallelProjectionAngle_text_KeyPress);
            // 
            // help_button
            // 
            this.help_button.Location = new System.Drawing.Point(5, 2082);
            this.help_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(459, 55);
            this.help_button.TabIndex = 9;
            this.help_button.Text = "Help";
            this.help_button.UseVisualStyleBackColor = true;
            // 
            // scaleUpBtn
            // 
            this.scaleUpBtn.Location = new System.Drawing.Point(43, 684);
            this.scaleUpBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.scaleUpBtn.Name = "scaleUpBtn";
            this.scaleUpBtn.Size = new System.Drawing.Size(200, 55);
            this.scaleUpBtn.TabIndex = 10;
            this.scaleUpBtn.Text = "Scale Up";
            this.scaleUpBtn.UseVisualStyleBackColor = true;
            this.scaleUpBtn.Click += new System.EventHandler(this.scaleUpBtn_Click);
            // 
            // scaleDownBtn
            // 
            this.scaleDownBtn.Location = new System.Drawing.Point(259, 684);
            this.scaleDownBtn.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.scaleDownBtn.Name = "scaleDownBtn";
            this.scaleDownBtn.Size = new System.Drawing.Size(200, 55);
            this.scaleDownBtn.TabIndex = 11;
            this.scaleDownBtn.Text = "Scale Down";
            this.scaleDownBtn.UseVisualStyleBackColor = true;
            // 
            // rotateXButton
            // 
            this.rotateXButton.Location = new System.Drawing.Point(43, 781);
            this.rotateXButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rotateXButton.Name = "rotateXButton";
            this.rotateXButton.Size = new System.Drawing.Size(200, 55);
            this.rotateXButton.TabIndex = 12;
            this.rotateXButton.Text = "Rotate X";
            this.rotateXButton.UseVisualStyleBackColor = true;
            this.rotateXButton.Click += new System.EventHandler(this.rotateXButton_Click);
            // 
            // rotateZButton
            // 
            this.rotateZButton.Location = new System.Drawing.Point(159, 888);
            this.rotateZButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rotateZButton.Name = "rotateZButton";
            this.rotateZButton.Size = new System.Drawing.Size(200, 55);
            this.rotateZButton.TabIndex = 13;
            this.rotateZButton.Text = "Rotate Z";
            this.rotateZButton.UseVisualStyleBackColor = true;
            this.rotateZButton.Click += new System.EventHandler(this.rotateZButton_Click);
            // 
            // rotateYButton
            // 
            this.rotateYButton.Location = new System.Drawing.Point(259, 781);
            this.rotateYButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rotateYButton.Name = "rotateYButton";
            this.rotateYButton.Size = new System.Drawing.Size(200, 55);
            this.rotateYButton.TabIndex = 14;
            this.rotateYButton.Text = "Rotate Y";
            this.rotateYButton.UseVisualStyleBackColor = true;
            this.rotateYButton.Click += new System.EventHandler(this.rotateYButton_Click);
            // 
            // rotationAngle
            // 
            this.rotationAngle.Location = new System.Drawing.Point(305, 975);
            this.rotationAngle.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.rotationAngle.MaxLength = 3;
            this.rotationAngle.Name = "rotationAngle";
            this.rotationAngle.Size = new System.Drawing.Size(177, 38);
            this.rotationAngle.TabIndex = 15;
            this.rotationAngle.TextChanged += new System.EventHandler(this.rotationAngle_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 975);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "Rotation angle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(3661, 2088);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rotationAngle);
            this.Controls.Add(this.rotateYButton);
            this.Controls.Add(this.rotateZButton);
            this.Controls.Add(this.rotateXButton);
            this.Controls.Add(this.scaleDownBtn);
            this.Controls.Add(this.scaleUpBtn);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.parallelProjectionAngle_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.drawButton);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox parallelProjectionAngle_text;
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.Button scaleUpBtn;
        private System.Windows.Forms.Button scaleDownBtn;
        private System.Windows.Forms.Button rotateXButton;
        private System.Windows.Forms.Button rotateZButton;
        private System.Windows.Forms.Button rotateYButton;
        public System.Windows.Forms.TextBox rotationAngle;
        private System.Windows.Forms.Label label2;
    }
}

