using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sony.Vegas;

namespace GroupEvents
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
            this.label1 = new System.Windows.Forms.Label();
            this.listViewTracks = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEventos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(382, 333);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(301, 333);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 2;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione duas faixas a agrupar:";
            // 
            // listViewTracks
            // 
            this.listViewTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderNome,
            this.columnHeaderEventos});
            this.listViewTracks.FullRowSelect = true;
            this.listViewTracks.HideSelection = false;
            this.listViewTracks.Location = new System.Drawing.Point(12, 25);
            this.listViewTracks.Name = "listViewTracks";
            this.listViewTracks.ShowGroups = false;
            this.listViewTracks.Size = new System.Drawing.Size(445, 302);
            this.listViewTracks.TabIndex = 4;
            this.listViewTracks.UseCompatibleStateImageBehavior = false;
            this.listViewTracks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            // 
            // columnHeaderEventos
            // 
            this.columnHeaderEventos.Text = "Nº de Eventos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 368);
            this.Controls.Add(this.listViewTracks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agrupar eventos de duas faixas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOk;
        private Button buttonCancelar;
        private Label label1;
        private ListView listViewTracks;
        private ColumnHeader columnHeaderId;
        private ColumnHeader columnHeaderNome;
        private ColumnHeader columnHeaderEventos;


        Vegas MyVegas;

        public MainForm(Vegas vegas)
        {
            InitializeComponent();
            MyVegas = vegas;

            listViewTracks.Items.Clear();

            foreach (Track t in vegas.Project.Tracks)
            {
                ListViewItem i = new ListViewItem(new String[] { t.DisplayIndex.ToString(), t.Name??"(Sem nome)", t.Events.Count.ToString() });
                i.Tag = t;
                listViewTracks.Items.Add(i);
            }

            listViewTracks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listViewTracks.SelectedItems.Count == 2)
            {
                Track t1 = listViewTracks.SelectedItems[0].Tag as Track;
                Track t2 = listViewTracks.SelectedItems[1].Tag as Track;

                if (t1.Events.Count != t2.Events.Count)
                {
                    MessageBox.Show("Você selecionou duas faixas com quantidades de eventos diferentes.\nOs eventos serão agrupados apenas até a contagem de eventos da menor faixa.");
                }
                try
                {
                    for (int i = 0; i < t1.Events.Count; i++)
                    {
                        TrackEventGroup g = new TrackEventGroup();
                        MyVegas.Project.TrackEventGroups.Add(g);
                        g.Add(t1.Events[i]);
                        g.Add(t2.Events[i]);
                    }
                }
                catch { }
                finally
                {
                    Close();
                }
            }
            else
                MessageBox.Show("Selecione somente duas faixas na lista");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
