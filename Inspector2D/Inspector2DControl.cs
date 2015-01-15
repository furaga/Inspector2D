using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FLib;

namespace Company.Inspector2D
{
    public partial class Inspector2DControl : UserControl
    {
        class LayerControls
        {
            public CheckBox isDraw;
            public TextBox exp;
            public ComboBox type;
            public PictureBox color;
            public NumericUpDown bold;

            public LayerControls(CheckBox isDraw, TextBox exp, ComboBox type, PictureBox color, NumericUpDown bold)
            {
                this.isDraw = isDraw;
                this.exp = exp;
                this.type = type;
                this.color = color;
                this.bold = bold;
            }
        }

        List<Bitmap> layers = new List<Bitmap>();
        List<LayerControls> layerInfo = new List<LayerControls>();


        public Inspector2DControl()
        {
            InitializeComponent();
        }

        private void Inspector2DControl_Load(object sender, EventArgs e)
        {
            layerInfo.Add(new LayerControls(checkBox1, textBox1, comboBox1, pictureBox2, numericUpDown1));
            layerInfo.Add(new LayerControls(checkBox2, textBox2, comboBox2, pictureBox3, numericUpDown2));
            layerInfo.Add(new LayerControls(checkBox3, textBox3, comboBox3, pictureBox4, numericUpDown3));
            layerInfo.Add(new LayerControls(checkBox4, textBox4, comboBox4, pictureBox5, numericUpDown4));
            layerInfo.Add(new LayerControls(checkBox5, textBox5, comboBox5, pictureBox6, numericUpDown7));
            pictureBox1.BackColor = Color.White;
        }

        private void refleshButton_Click(object sender, EventArgs e)
        {
            UpdateLayers();
            canvas.Invalidate();
        }

        void UpdateLayers()
        {
            if (VSInfo.Debugger2 != null)
            {
                var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

                foreach (var l in layers)
                    if (l != null)
                        l.Dispose();
                layers.Clear();

                for (int i = 0; i < layerInfo.Count; i++)
                {
                    try
                    {
                        if (layerInfo[i].isDraw.Checked == false)
                            continue;
                        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(document, "Inspector2D", "layer" + i + ".png"));
                        int w = (int)numericUpDown5.Value;
                        int h = (int)numericUpDown6.Value;
                        if (w <= 0 || h <= 0)
                            continue;
                        string exp = layerInfo[i].exp.Text;
                        if (string.IsNullOrWhiteSpace(exp))
                            continue;
                        string type = layerInfo[i].type.Text;
                        if (string.IsNullOrWhiteSpace(type))
                            continue;
                        int param = (int)layerInfo[i].bold.Value;
                        int argb = layerInfo[i].color.BackColor.ToArgb();

                        string code = string.Format(@"FLib.BitmapHandler.DrawAndSave(@""{0}"", {1}, {2}, {3}, @""{4}"", {5}, {6})", path, w, h, exp, type, param, argb);
                        VSInfo.Debugger2.ExecuteStatement(code, 5, true);

                        var bmp = new Bitmap(path);
                        layers.Add(bmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString() + ex.StackTrace);
                    }
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(pictureBox1.BackColor);
                foreach (var l in layers)
                    e.Graphics.DrawImage(l, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                canvas.Invalidate();
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                (sender as PictureBox).BackColor = colorDialog2.Color;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(document, "Inspector2D"));
            System.Diagnostics.Process.Start(path);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}