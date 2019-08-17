namespace PhilosophersFrm
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
               this.button1 = new System.Windows.Forms.Button();
               this.button2 = new System.Windows.Forms.Button();
               this.button3 = new System.Windows.Forms.Button();
               this.button4 = new System.Windows.Forms.Button();
               this.button5 = new System.Windows.Forms.Button();
               this.panel1 = new System.Windows.Forms.Panel();
               this.btn_start = new System.Windows.Forms.Button();
               this.btn_stop = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.txtnum = new System.Windows.Forms.TextBox();
               this.btnadd = new System.Windows.Forms.Button();
               this.panel1.SuspendLayout();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.button1.ForeColor = System.Drawing.Color.DarkOrange;
               this.button1.Location = new System.Drawing.Point(143, 256);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(107, 34);
               this.button1.TabIndex = 0;
               this.button1.Text = "Philosopher 1";
               this.button1.UseVisualStyleBackColor = true;
               // 
               // button2
               // 
               this.button2.ForeColor = System.Drawing.Color.DarkOrange;
               this.button2.Location = new System.Drawing.Point(3, 177);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(107, 34);
               this.button2.TabIndex = 0;
               this.button2.Text = "Philosopher 3";
               this.button2.UseVisualStyleBackColor = true;
               // 
               // button3
               // 
               this.button3.ForeColor = System.Drawing.Color.DarkOrange;
               this.button3.Location = new System.Drawing.Point(3, 16);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(107, 34);
               this.button3.TabIndex = 0;
               this.button3.Text = "Philosopher 5";
               this.button3.UseVisualStyleBackColor = true;
               // 
               // button4
               // 
               this.button4.ForeColor = System.Drawing.Color.DarkOrange;
               this.button4.Location = new System.Drawing.Point(275, 177);
               this.button4.Name = "button4";
               this.button4.Size = new System.Drawing.Size(107, 34);
               this.button4.TabIndex = 0;
               this.button4.Text = "Philosopher 4";
               this.button4.UseVisualStyleBackColor = true;
               // 
               // button5
               // 
               this.button5.ForeColor = System.Drawing.Color.DarkOrange;
               this.button5.Location = new System.Drawing.Point(275, 16);
               this.button5.Name = "button5";
               this.button5.Size = new System.Drawing.Size(107, 34);
               this.button5.TabIndex = 0;
               this.button5.Text = "Philosopher 2";
               this.button5.UseVisualStyleBackColor = true;
               // 
               // panel1
               // 
               this.panel1.BackColor = System.Drawing.Color.MistyRose;
               this.panel1.Controls.Add(this.button1);
               this.panel1.Controls.Add(this.button4);
               this.panel1.Controls.Add(this.button5);
               this.panel1.Controls.Add(this.button3);
               this.panel1.Controls.Add(this.button2);
               this.panel1.Location = new System.Drawing.Point(295, 12);
               this.panel1.Name = "panel1";
               this.panel1.Size = new System.Drawing.Size(382, 324);
               this.panel1.TabIndex = 1;
               // 
               // btn_start
               // 
               this.btn_start.BackColor = System.Drawing.Color.ForestGreen;
               this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.btn_start.ForeColor = System.Drawing.Color.White;
               this.btn_start.Location = new System.Drawing.Point(717, 87);
               this.btn_start.Name = "btn_start";
               this.btn_start.Size = new System.Drawing.Size(75, 23);
               this.btn_start.TabIndex = 2;
               this.btn_start.Text = "Start";
               this.btn_start.UseVisualStyleBackColor = false;
               this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
               // 
               // btn_stop
               // 
               this.btn_stop.BackColor = System.Drawing.Color.Red;
               this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.btn_stop.ForeColor = System.Drawing.Color.White;
               this.btn_stop.Location = new System.Drawing.Point(717, 145);
               this.btn_stop.Name = "btn_stop";
               this.btn_stop.Size = new System.Drawing.Size(75, 23);
               this.btn_stop.TabIndex = 2;
               this.btn_stop.Text = "Stop";
               this.btn_stop.UseVisualStyleBackColor = false;
               this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(3, 145);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(116, 13);
               this.label1.TabIndex = 3;
               this.label1.Text = "number of philosophers";
               // 
               // txtnum
               // 
               this.txtnum.Location = new System.Drawing.Point(128, 142);
               this.txtnum.Name = "txtnum";
               this.txtnum.Size = new System.Drawing.Size(100, 20);
               this.txtnum.TabIndex = 4;
               // 
               // btnadd
               // 
               this.btnadd.Location = new System.Drawing.Point(13, 178);
               this.btnadd.Name = "btnadd";
               this.btnadd.Size = new System.Drawing.Size(75, 23);
               this.btnadd.TabIndex = 5;
               this.btnadd.Text = "Create";
               this.btnadd.UseVisualStyleBackColor = true;
               this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(815, 385);
               this.Controls.Add(this.btnadd);
               this.Controls.Add(this.txtnum);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.btn_stop);
               this.Controls.Add(this.btn_start);
               this.Controls.Add(this.panel1);
               this.Name = "Form1";
               this.Text = "Form1";
               this.Load += new System.EventHandler(this.Form1_Load);
               this.panel1.ResumeLayout(false);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.Button button3;
          private System.Windows.Forms.Button button4;
          private System.Windows.Forms.Button button5;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.Button btn_start;
          private System.Windows.Forms.Button btn_stop;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox txtnum;
          private System.Windows.Forms.Button btnadd;
     }
}

