using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace QuickFade
{
    class MainForm : Form
    {
        private Button buttonOk;
        private Button buttonCancelar;
        private TextBox textBoxIincio;
        private TextBox textBoxFim;
        private CheckBox checkBoxInicio;
        private CheckBox checkBoxFim;
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
            this.textBoxIincio = new System.Windows.Forms.TextBox();
            this.textBoxFim = new System.Windows.Forms.TextBox();
            this.checkBoxInicio = new System.Windows.Forms.CheckBox();
            this.checkBoxFim = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(142, 61);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(61, 61);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // textBoxIincio
            // 
            this.textBoxIincio.Enabled = false;
            this.textBoxIincio.Location = new System.Drawing.Point(12, 35);
            this.textBoxIincio.Name = "textBoxIincio";
            this.textBoxIincio.Size = new System.Drawing.Size(100, 20);
            this.textBoxIincio.TabIndex = 2;
            this.textBoxIincio.Text = "0";
            // 
            // textBoxFim
            // 
            this.textBoxFim.Enabled = false;
            this.textBoxFim.Location = new System.Drawing.Point(117, 35);
            this.textBoxFim.Name = "textBoxFim";
            this.textBoxFim.Size = new System.Drawing.Size(100, 20);
            this.textBoxFim.TabIndex = 3;
            this.textBoxFim.Text = "0";
            // 
            // checkBoxInicio
            // 
            this.checkBoxInicio.AutoSize = true;
            this.checkBoxInicio.Location = new System.Drawing.Point(12, 12);
            this.checkBoxInicio.Name = "checkBoxInicio";
            this.checkBoxInicio.Size = new System.Drawing.Size(92, 17);
            this.checkBoxInicio.TabIndex = 6;
            this.checkBoxInicio.Text = "Início (em ms)";
            this.checkBoxInicio.UseVisualStyleBackColor = true;
            this.checkBoxInicio.CheckedChanged += new System.EventHandler(this.checkBoxInicio_CheckedChanged);
            // 
            // checkBoxFim
            // 
            this.checkBoxFim.AutoSize = true;
            this.checkBoxFim.Location = new System.Drawing.Point(117, 12);
            this.checkBoxFim.Name = "checkBoxFim";
            this.checkBoxFim.Size = new System.Drawing.Size(81, 17);
            this.checkBoxFim.TabIndex = 7;
            this.checkBoxFim.Text = "Fim (em ms)";
            this.checkBoxFim.UseVisualStyleBackColor = true;
            this.checkBoxFim.CheckedChanged += new System.EventHandler(this.checkBoxFim_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 95);
            this.Controls.Add(this.checkBoxFim);
            this.Controls.Add(this.checkBoxInicio);
            this.Controls.Add(this.textBoxFim);
            this.Controls.Add(this.textBoxIincio);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fade";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        Vegas MyVegas;

        public MainForm(Vegas vegas)
        {
            InitializeComponent();
            MyVegas = vegas;
        }

        private void checkBoxInicio_CheckedChanged(object sender, EventArgs e)
        {
            textBoxIincio.Enabled = checkBoxInicio.Checked;
            if (!textBoxIincio.Enabled)
                textBoxIincio.Text = "0";

        }

        private void checkBoxFim_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFim.Enabled = checkBoxFim.Checked;
            if (!textBoxFim.Enabled)
                textBoxFim.Text = "0";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                double Inicio = Convert.ToDouble(textBoxIincio.Text);
                double Fim = Convert.ToDouble(textBoxFim.Text);

                foreach (Track Track in MyVegas.Project.Tracks)
                {
                    foreach (TrackEvent Event in Track.Events)
                    {
                        if (Event.Selected)
                        {
                            if (checkBoxInicio.Checked)
                                Event.FadeIn.Length = Timecode.FromMilliseconds(Inicio);
                            
                            if (checkBoxFim.Checked)
                                Event.FadeOut.Length = Timecode.FromMilliseconds(Fim);
                        }
                    }
                }
                Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, Ex.GetType().ToString());
            }
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
