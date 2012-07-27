using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Sony.Vegas;

namespace Wiggler
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
            this.propertyGridInicial = new System.Windows.Forms.PropertyGrid();
            this.labelFinal = new System.Windows.Forms.Label();
            this.labelInicial = new System.Windows.Forms.Label();
            this.propertyGridFinal = new System.Windows.Forms.PropertyGrid();
            this.checkBoxVar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownFrames = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(541, 335);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(460, 335);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // propertyGridInicial
            // 
            this.propertyGridInicial.Location = new System.Drawing.Point(12, 48);
            this.propertyGridInicial.Name = "propertyGridInicial";
            this.propertyGridInicial.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridInicial.Size = new System.Drawing.Size(299, 281);
            this.propertyGridInicial.TabIndex = 5;
            this.propertyGridInicial.ToolbarVisible = false;
            // 
            // labelFinal
            // 
            this.labelFinal.AutoSize = true;
            this.labelFinal.Location = new System.Drawing.Point(314, 30);
            this.labelFinal.Name = "labelFinal";
            this.labelFinal.Size = new System.Drawing.Size(0, 13);
            this.labelFinal.TabIndex = 6;
            // 
            // labelInicial
            // 
            this.labelInicial.AutoSize = true;
            this.labelInicial.Location = new System.Drawing.Point(9, 31);
            this.labelInicial.Name = "labelInicial";
            this.labelInicial.Size = new System.Drawing.Size(48, 13);
            this.labelInicial.TabIndex = 6;
            this.labelInicial.Text = "Absoluto";
            // 
            // propertyGridFinal
            // 
            this.propertyGridFinal.Enabled = false;
            this.propertyGridFinal.Location = new System.Drawing.Point(317, 47);
            this.propertyGridFinal.Name = "propertyGridFinal";
            this.propertyGridFinal.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridFinal.Size = new System.Drawing.Size(299, 281);
            this.propertyGridFinal.TabIndex = 5;
            this.propertyGridFinal.ToolbarVisible = false;
            // 
            // checkBoxVar
            // 
            this.checkBoxVar.AutoSize = true;
            this.checkBoxVar.Location = new System.Drawing.Point(317, 12);
            this.checkBoxVar.Name = "checkBoxVar";
            this.checkBoxVar.Size = new System.Drawing.Size(97, 17);
            this.checkBoxVar.TabIndex = 7;
            this.checkBoxVar.Text = "Com variação?";
            this.checkBoxVar.UseVisualStyleBackColor = true;
            this.checkBoxVar.CheckedChanged += new System.EventHandler(this.checkBoxVar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "A cada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "frame(s)";
            // 
            // numericUpDownFrames
            // 
            this.numericUpDownFrames.Location = new System.Drawing.Point(59, 338);
            this.numericUpDownFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFrames.Name = "numericUpDownFrames";
            this.numericUpDownFrames.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownFrames.TabIndex = 11;
            this.numericUpDownFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 370);
            this.Controls.Add(this.numericUpDownFrames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxVar);
            this.Controls.Add(this.labelFinal);
            this.Controls.Add(this.propertyGridFinal);
            this.Controls.Add(this.labelInicial);
            this.Controls.Add(this.propertyGridInicial);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tremer evento de vídeo";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOk;
        private Button buttonCancelar;
        private PropertyGrid propertyGridInicial;
        private Label labelInicial;
        private PropertyGrid propertyGridFinal;
        private Label labelFinal;
        private CheckBox checkBoxVar;

        Vegas MyVegas;
        WigglerKeyFrame Inicial;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDownFrames;
        WigglerKeyFrame Final;

        public MainForm(Vegas vegas)
        {
            InitializeComponent();
            MyVegas = vegas;

            Inicial = new WigglerKeyFrame();

            propertyGridInicial.SelectedObject = Inicial;
            propertyGridFinal.SelectedObject = null;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            foreach (Track Track in MyVegas.Project.Tracks)
            {
                if (Track.IsAudio())
                    continue;

                foreach (VideoEvent Event in Track.Events)
                {
                    if (Event.Selected)
                    {
                        VideoMotionKeyframes kf = Event.VideoMotion.Keyframes; Event.VideoMotion.ScaleToFill = true;
                        Random r = new Random();
                        long count = Event.Length.FrameCount;
                        long d = (long) numericUpDownFrames.Value;
                        long iterations = count / d;

                        kf.Clear();
                        kf[0].Position = new Timecode();


                        for (int i = 1; i < iterations; i++)
                        {
                            VideoMotionKeyframe k = new VideoMotionKeyframe(Timecode.FromFrames(i * d));
                            kf.Add(k);
                        }

                        for (int i = 0; i < iterations; i++)
                        {
                            if (checkBoxVar.Checked)
                                Inicial.RandomizeRelative(kf[i], r, i / (float) iterations, Final);
                            else
                                Inicial.Randomize(kf[i], r);
                        }


                        Close();
                        return;
                    }
                }
                MessageBox.Show("Nenhum evento de vídeo foi selecionado");
                Close();
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxVar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVar.Checked)
            {
                labelInicial.Text = "Inicial";
                labelFinal.Text = "Final";
                Final = new WigglerKeyFrame();
                propertyGridFinal.SelectedObject = Final;
                propertyGridFinal.Enabled = true;
            }
            else
            {
                labelInicial.Text = "Absoluto";
                labelFinal.Text = "";
                propertyGridFinal.SelectedObject = null;
                propertyGridFinal.Enabled = false;
            }
        }
    }

    public class WigglerKeyFrame
    {
        #region Props
        [Category("Posição do centro"), DescriptionAttribute("Variação mínima na horizontal em pixels\n(0 = sem alteração)")]
        public float MinX { get { return _MinX; } set { _MinX = value; } }
        [Category("Posição do centro"), DescriptionAttribute("Variação máxima na horizontal em pixels\n(0 = sem alteração)")]
        public float MaxX { get { return _MaxX; } set { _MaxX = value; } }
        [Category("Posição do centro"), DescriptionAttribute("Variação mínima na vertical em pixels\n(0 = sem alteração)")]
        public float MinY { get { return _MinY; } set { _MinY = value; } }
        [Category("Posição do centro"), DescriptionAttribute("Variação máxima na vertical em pixels\n(0 = sem alteração)")]
        public float MaxY { get { return _MaxY; } set { _MaxY = value; } }
        [Category("Rotação"), DescriptionAttribute("Variação mínima na rotação em graus\n(0 = sem alteração)")]
        public float MinRotation { get { return _MinRotation; } set { _MinRotation = value; } }
        [Category("Rotação"), DescriptionAttribute("Variação míaxima na rotação em graus\n(0 = sem alteração)")]
        public float MaxRotation { get { return _MaxRotation; } set { _MaxRotation = value; } }
        [Category("Tamanho"), DescriptionAttribute("Multiplicador mínimo para o tamanho do quadro\n(1 = sem alteração)")]
        public float MinScale { get { return _MinScale; } set { _MinScale = value; } }
        [Category("Tamanho"), DescriptionAttribute("Multiplicador máximo para o tamanho do quadro\n(1 = sem alteração)")]
        public float MaxScale { get { return _MaxScale; } set { _MaxScale = value; } }

        float _MinX = -10;
        float _MaxX = 10;

        float _MinY = -10;
        float _MaxY = 10;

        float _MinRotation = 0;
        float _MaxRotation = 0;

        float _MinScale = 1;
        float _MaxScale = 1;
        #endregion

        public WigglerKeyFrame()
        {
        }

        public void Randomize(VideoMotionKeyframe k, Random r)
        {
            k.MoveBy(new VideoMotionVertex(RandomHelper(r, _MinX, _MaxX), RandomHelper(r, _MinY, _MaxY)));

            float d = RandomHelper(r, _MinScale, _MaxScale);
            k.ScaleBy(new VideoMotionVertex(d, d));

            k.RotateBy(Math.PI * RandomHelper(r, _MinRotation, _MaxRotation) / 180d);
        }

        public void RandomizeRelative(VideoMotionKeyframe k, Random r, float step, WigglerKeyFrame f)
        {
            WigglerKeyFrame tmp = Lerp(step, f);
            tmp.Randomize(k, r);
        }

        float RandomHelper(Random r, float min, float max)
        {
            return (float) (min + (max - min) * r.NextDouble());
        }

        float Lerp(float step, float v1, float v2)
        {
            return v1 + (v2 - v1) * step;
        }

        WigglerKeyFrame Lerp(float step, WigglerKeyFrame that)
        {
            WigglerKeyFrame ret = new WigglerKeyFrame();

            ret.MinX = Lerp(step, this.MinX, that.MinX);
            ret.MaxX = Lerp(step, this.MaxX, that.MaxX);
            ret.MinY = Lerp(step, this.MinY, that.MinY);
            ret.MaxY = Lerp(step, this.MaxY, that.MaxY);
            ret.MinRotation = Lerp(step, this.MinRotation, that.MinRotation);
            ret.MaxRotation = Lerp(step, this.MaxRotation, that.MaxRotation);
            ret.MinScale = Lerp(step, this.MinScale, that.MinScale);
            ret.MaxScale = Lerp(step, this.MaxScale, that.MaxScale);

            return ret;
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
