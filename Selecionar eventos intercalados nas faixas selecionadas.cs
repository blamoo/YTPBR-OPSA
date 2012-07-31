using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace SelectCustom
{
    class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.numericUpDownIntervalo = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownComeco = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalo = new System.Windows.Forms.Label();
            this.labelComeco = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownComeco)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(180, 38);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(99, 38);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // numericUpDownIntervalo
            // 
            this.numericUpDownIntervalo.Location = new System.Drawing.Point(62, 12);
            this.numericUpDownIntervalo.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownIntervalo.Name = "numericUpDownIntervalo";
            this.numericUpDownIntervalo.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownIntervalo.TabIndex = 2;
            this.numericUpDownIntervalo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownIntervalo.ValueChanged += new System.EventHandler(this.numericUpDownIntervalo_ValueChanged);
            // 
            // numericUpDownComeco
            // 
            this.numericUpDownComeco.Location = new System.Drawing.Point(199, 12);
            this.numericUpDownComeco.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownComeco.Name = "numericUpDownComeco";
            this.numericUpDownComeco.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownComeco.TabIndex = 3;
            // 
            // labelIntervalo
            // 
            this.labelIntervalo.AutoSize = true;
            this.labelIntervalo.Location = new System.Drawing.Point(5, 14);
            this.labelIntervalo.Name = "labelIntervalo";
            this.labelIntervalo.Size = new System.Drawing.Size(51, 13);
            this.labelIntervalo.TabIndex = 4;
            this.labelIntervalo.Text = "Intervalo:";
            // 
            // labelComeco
            // 
            this.labelComeco.AutoSize = true;
            this.labelComeco.Location = new System.Drawing.Point(124, 14);
            this.labelComeco.Name = "labelComeco";
            this.labelComeco.Size = new System.Drawing.Size(69, 13);
            this.labelComeco.TabIndex = 5;
            this.labelComeco.Text = "Começar em:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 71);
            this.Controls.Add(this.labelComeco);
            this.Controls.Add(this.labelIntervalo);
            this.Controls.Add(this.numericUpDownComeco);
            this.Controls.Add(this.numericUpDownIntervalo);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecionar eventos intercalados";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownComeco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOk;
        private Button buttonCancelar;
        private NumericUpDown numericUpDownIntervalo;
        private NumericUpDown numericUpDownComeco;
        private Label labelIntervalo;
        private Label labelComeco;

        Vegas MyVegas;

        public MainForm(Vegas vegas)
        {
            InitializeComponent();
            MyVegas = vegas;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            foreach (Track Track in MyVegas.Project.Tracks)
            {
                if (!Track.Selected)
                    continue;

                foreach (TrackEvent Event in Track.Events)
                {
                    Event.Selected = (Event.Index % numericUpDownIntervalo.Value == numericUpDownComeco.Value) ? true : false;
                }
            }
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDownIntervalo_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownComeco.Maximum = numericUpDownIntervalo.Value - 1;

            if (numericUpDownIntervalo.Value <= numericUpDownComeco.Value)
                numericUpDownComeco.Value = numericUpDownIntervalo.Value - 1;
        }
    }

    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            new MainForm(vegas).ShowDialog();
        }
    }
}
