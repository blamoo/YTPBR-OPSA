using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;
using System.Drawing;
using System.Drawing.Imaging;

namespace MouseTrackMotion
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
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(769, 551);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Click += new System.EventHandler(this.pictureBoxCanvas_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 576);
            this.Controls.Add(this.pictureBoxCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBoxCanvas;

        Vegas MyVegas;
        VideoEvent TargetEvent;
        Point TargetCenter;
        bool Ligou;
        Random R;

        private VideoEvent FirstSelectedEvent()
        {
            foreach (Track track in MyVegas.Project.Tracks)
            {
                if (track.IsVideo())
                    foreach (VideoEvent e in track.Events)
                    {
                        if (e.Selected)
                            return e;
                    }
            }
            throw new Exception("Nenhum evento de vídeo foi selecionado");
        }

        public void UpdatePreview()
        {
            MyVegas.SaveSnapshot();
            pictureBoxCanvas.Image = Clipboard.GetImage();
            pictureBoxCanvas.Refresh();
        }

        public MainForm(Vegas vegas)
        {
            InitializeComponent();
            MyVegas = vegas;
            R = new Random();
            TargetEvent = FirstSelectedEvent();
            TargetEvent.VideoMotion.Keyframes.Clear();
            TargetEvent.VideoMotion.Keyframes[0].Position = new Timecode(0);

            vegas.Transport.CursorPosition = TargetEvent.Start;
            UpdatePreview();
        }

        int CurrentIndex;

        private void pictureBoxCanvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs a = e as MouseEventArgs;

            if (!Ligou)
            {
                TargetCenter = a.Location;
                Ligou = true;
                return;
            }

            if (a.Button == MouseButtons.Right)
            {
                MyVegas.Transport.CursorPosition = TargetEvent.Start + Timecode.FromFrames(CurrentIndex);
                CurrentIndex++;
                UpdatePreview();
                return;
            }

            VideoMotionKeyframe kf = (CurrentIndex == 0) ? TargetEvent.VideoMotion.Keyframes[0] : new VideoMotionKeyframe(Timecode.FromFrames(CurrentIndex));

            if (CurrentIndex != 0)
                TargetEvent.VideoMotion.Keyframes.Add(kf);

            ResetKeyframeCenter(kf);

            kf.MoveBy(new VideoMotionVertex(TargetCenter.X - a.X, TargetCenter.Y - a.Y));

            MyVegas.Transport.CursorPosition = TargetEvent.Start + Timecode.FromFrames(CurrentIndex);
            CurrentIndex++;
            UpdatePreview();
        }

        public void ResetKeyframeCenter(VideoMotionKeyframe k)
        {
            k.MoveBy(new VideoMotionVertex(MyVegas.Project.Video.Width / 2 - k.Center.X, MyVegas.Project.Video.Height / 2 - k.Center.Y));
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
