using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orarend
{
    public partial class TimeTable : Form
    {
        List<Result> r;
        int i;
        public TimeTable(List<Result> r)
        {
            InitializeComponent();
            this.r = r;
            i = 0;
            Page.Text = (i + 1) + "/" + r.Count;
            Image img1 = Image.FromFile("../arrow.png");
            if (r.Count > 1) Next.Image = img1;
            Image img2 = Image.FromFile("../arrow.png");
            img2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            img2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Previous.Image = img2;
            Previous.Visible = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pb.Location = new System.Drawing.Point(46+i*100, 58+j*30);
                    pb.Name = (i+1) + "," + (j+8);
                    pb.Size = new System.Drawing.Size(100, 30);
                    pb.TabIndex = 19;
                    pb.TabStop = false;
                    this.Controls.Add(pb);
                }
            }
            showtable();
        }

        private void showtable()
        {
            foreach(Control c in this.Controls)
            {
                PictureBox pb = c as PictureBox;
                if (pb != null) pb.BackColor = Color.Empty;
            }
            List.Items.Clear();
            foreach (ResultSubject rs in r[i].GetSubjects())
            {
                
                List.Items.Add(rs);
                int day = (int)rs.time.day;
                for(int i=rs.time.time;i<rs.time.time+rs.length;i++)
                {
                    (this.Controls.Find(day + "," + i, true)[0] as PictureBox).BackColor = Color.Blue;
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (i <= 0) return;
            i--;
            Page.Text = (i + 1) + "/" + r.Count;
            if (i == 0) Previous.Visible = false;
            if (i != r.Count - 1) Next.Visible = true;
            showtable();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (i == r.Count-1) return;
            i++;
            Page.Text = (i + 1) + "/" + r.Count;
            if (i == r.Count - 1) Next.Visible = false;
            if (i != 0) Previous.Visible = true;
            showtable();
        }
    }
}
