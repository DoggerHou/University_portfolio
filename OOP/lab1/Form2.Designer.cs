
namespace OOP_Laba_1
{
    partial class Form3
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
            this.label_Activ1 = new System.Windows.Forms.Label();
            this.textBox_First = new System.Windows.Forms.TextBox();
            this.textBox_Second = new System.Windows.Forms.TextBox();
            this.label_Activ2 = new System.Windows.Forms.Label();
            this.checkBox_Bright = new System.Windows.Forms.CheckBox();
            this.checkBox_Dark = new System.Windows.Forms.CheckBox();
            this.label_Activ3 = new System.Windows.Forms.Label();
            this.checkBox_Miracle = new System.Windows.Forms.CheckBox();
            this.pictureBox_Hell = new System.Windows.Forms.PictureBox();
            this.pictureBox_Heaven = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Heaven)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Activ1
            // 
            this.label_Activ1.AutoSize = true;
            this.label_Activ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Activ1.Location = new System.Drawing.Point(286, 14);
            this.label_Activ1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Activ1.Name = "label_Activ1";
            this.label_Activ1.Size = new System.Drawing.Size(644, 29);
            this.label_Activ1.TabIndex = 0;
            this.label_Activ1.Text = "1)Что пишешь в 1 окне, будет и во втором, и наоборот";
            // 
            // textBox_First
            // 
            this.textBox_First.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_First.Location = new System.Drawing.Point(325, 125);
            this.textBox_First.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_First.Name = "textBox_First";
            this.textBox_First.Size = new System.Drawing.Size(148, 26);
            this.textBox_First.TabIndex = 1;
            this.textBox_First.TextChanged += new System.EventHandler(this.textBox_First_TextChanged);
            // 
            // textBox_Second
            // 
            this.textBox_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Second.Location = new System.Drawing.Point(649, 125);
            this.textBox_Second.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Second.Name = "textBox_Second";
            this.textBox_Second.Size = new System.Drawing.Size(148, 26);
            this.textBox_Second.TabIndex = 2;
            this.textBox_Second.TextChanged += new System.EventHandler(this.textBox_Second_TextChanged);
            // 
            // label_Activ2
            // 
            this.label_Activ2.AutoSize = true;
            this.label_Activ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Activ2.Location = new System.Drawing.Point(286, 195);
            this.label_Activ2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Activ2.Name = "label_Activ2";
            this.label_Activ2.Size = new System.Drawing.Size(253, 29);
            this.label_Activ2.TabIndex = 3;
            this.label_Activ2.Text = "2)Выберите Сторону";
            // 
            // checkBox_Bright
            // 
            this.checkBox_Bright.AutoSize = true;
            this.checkBox_Bright.Location = new System.Drawing.Point(313, 270);
            this.checkBox_Bright.Name = "checkBox_Bright";
            this.checkBox_Bright.Size = new System.Drawing.Size(113, 29);
            this.checkBox_Bright.TabIndex = 4;
            this.checkBox_Bright.Text = "Светлая";
            this.checkBox_Bright.UseVisualStyleBackColor = true;
            this.checkBox_Bright.CheckStateChanged += new System.EventHandler(this.checkBox_Bright_CheckStateChanged);
            // 
            // checkBox_Dark
            // 
            this.checkBox_Dark.AutoSize = true;
            this.checkBox_Dark.Location = new System.Drawing.Point(678, 270);
            this.checkBox_Dark.Name = "checkBox_Dark";
            this.checkBox_Dark.Size = new System.Drawing.Size(106, 29);
            this.checkBox_Dark.TabIndex = 5;
            this.checkBox_Dark.Text = "Темная";
            this.checkBox_Dark.UseVisualStyleBackColor = true;
            this.checkBox_Dark.CheckStateChanged += new System.EventHandler(this.checkBox_Dark_CheckStateChanged);
            // 
            // label_Activ3
            // 
            this.label_Activ3.AutoSize = true;
            this.label_Activ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Activ3.Location = new System.Drawing.Point(286, 375);
            this.label_Activ3.Name = "label_Activ3";
            this.label_Activ3.Size = new System.Drawing.Size(385, 29);
            this.label_Activ3.TabIndex = 8;
            this.label_Activ3.Text = "3)Нажмите и создавайте чудеса";
            // 
            // checkBox_Miracle
            // 
            this.checkBox_Miracle.AutoSize = true;
            this.checkBox_Miracle.Location = new System.Drawing.Point(313, 433);
            this.checkBox_Miracle.Name = "checkBox_Miracle";
            this.checkBox_Miracle.Size = new System.Drawing.Size(174, 29);
            this.checkBox_Miracle.TabIndex = 9;
            this.checkBox_Miracle.Text = "Делать чудеса";
            this.checkBox_Miracle.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Hell
            // 
            this.pictureBox_Hell.BackgroundImage = global::OOP_Laba_1.Properties.Resources.imgonline_com_ua_Resize_aJoEVFEsorWTj;
            this.pictureBox_Hell.Location = new System.Drawing.Point(910, 91);
            this.pictureBox_Hell.Name = "pictureBox_Hell";
            this.pictureBox_Hell.Size = new System.Drawing.Size(175, 220);
            this.pictureBox_Hell.TabIndex = 7;
            this.pictureBox_Hell.TabStop = false;
            this.pictureBox_Hell.Visible = false;
            // 
            // pictureBox_Heaven
            // 
            this.pictureBox_Heaven.BackgroundImage = global::OOP_Laba_1.Properties.Resources.imgonline_com_ua_Resize_St6CSag5OB2N;
            this.pictureBox_Heaven.Enabled = false;
            this.pictureBox_Heaven.Location = new System.Drawing.Point(43, 91);
            this.pictureBox_Heaven.Name = "pictureBox_Heaven";
            this.pictureBox_Heaven.Size = new System.Drawing.Size(175, 220);
            this.pictureBox_Heaven.TabIndex = 6;
            this.pictureBox_Heaven.TabStop = false;
            this.pictureBox_Heaven.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(677, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 219);
            this.panel1.TabIndex = 10;
            this.panel1.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-20, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(328, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 52);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1122, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox_Miracle);
            this.Controls.Add(this.label_Activ3);
            this.Controls.Add(this.pictureBox_Hell);
            this.Controls.Add(this.pictureBox_Heaven);
            this.Controls.Add(this.checkBox_Dark);
            this.Controls.Add(this.checkBox_Bright);
            this.Controls.Add(this.label_Activ2);
            this.Controls.Add(this.textBox_Second);
            this.Controls.Add(this.textBox_First);
            this.Controls.Add(this.label_Activ1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Окно номер 1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Heaven)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Activ1;
        private System.Windows.Forms.TextBox textBox_First;
        private System.Windows.Forms.TextBox textBox_Second;
        private System.Windows.Forms.Label label_Activ2;
        private System.Windows.Forms.CheckBox checkBox_Bright;
        private System.Windows.Forms.CheckBox checkBox_Dark;
        private System.Windows.Forms.PictureBox pictureBox_Heaven;
        private System.Windows.Forms.PictureBox pictureBox_Hell;
        private System.Windows.Forms.Label label_Activ3;
        private System.Windows.Forms.CheckBox checkBox_Miracle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}