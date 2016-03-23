using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabKhomandiak06
{
    public partial class Form1 : Form
    {
        List<PointF> points = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            Graphics g = this.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {

                Brush b = Brushes.Black;
                g.FillRectangle(b, e.X, e.Y, 3, 3);
                points.Add(new PointF(e.X, e.Y));
            }
            if (e.Button == MouseButtons.Right)
            {
                Pen p = new Pen(Color.Black, 2);
                PointF[] ps = points.ToArray();
                if (ps.Length > 1)
                    g.DrawLines(p, ps);
            }
        }
        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            points.Clear();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            if (points.Count > 0)
            {
                points.RemoveAt(points.Count - 1);
                Brush b = Brushes.Black;
                foreach (PointF po in points)
                    g.FillRectangle(b, po.X, po.Y, 3, 3);
                Pen p = new Pen(Color.Black, 2);
                PointF[] ps = points.ToArray();
                if (ps.Length > 1)
                    g.DrawLines(p, ps);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "Serializable|*.dat";
            saveFileDialog1.Title = "Save a Points File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, points);
                fs.Close();
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream openStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Serializable|*.dat";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((openStream = openFileDialog1.OpenFile()) != null)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        points.Clear();
                        points = (List<PointF>)bf.Deserialize(openStream);
                        Graphics g = this.CreateGraphics();
                        g.Clear(this.BackColor);
                        if (points.Count > 0)
                        { 
                            Brush b = Brushes.Black;
                            foreach (PointF po in points)
                                g.FillRectangle(b, po.X, po.Y, 3, 3);
                            Pen p = new Pen(Color.Black, 2);
                            PointF[] ps = points.ToArray();
                            if (ps.Length > 1)
                                g.DrawLines(p, ps);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            if (points.Count > 0)
            {
                Brush b = Brushes.Black;
                foreach (PointF po in points)
                    g.FillRectangle(b, po.X, po.Y, 3, 3);
                Pen p = new Pen(Color.Black, 2);
                PointF[] ps = points.ToArray();
                if (ps.Length > 1)
                    g.DrawLines(p, ps);
            }
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }
    }
}
