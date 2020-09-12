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
    public partial class Starter : Form
    {
        List<Subject> subjects;
        public Starter()
        {
            InitializeComponent();
            subjects = new List<Subject>();
        }

        private void Sub_length_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            if ((int)n.Value > 4) n.Value = 4; 
            bool l = true;
            foreach(Control c in this.Controls)
            {
                NumericUpDown temp = c as NumericUpDown;
                if (temp != null && temp.Name == "pos1")
                {
                    l = false;
                    if ((int)(sender as NumericUpDown).Value == 0)
                    {
                        temp.Value = 0;
                        this.Controls.Remove(temp);
                        this.Controls.Remove(this.Controls.Find("day1", true)[0]);
                    }
                }
            }
            if (!l) return;

            ComboBox cb = new ComboBox();
            cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb.FormattingEnabled = true;
            cb.Location = new System.Drawing.Point(StartofList.Location.X, StartofList.Location.Y + 20);
            cb.Name = "day1";
            cb.Size = new System.Drawing.Size(100, 20);
            cb.TabIndex = 7;
            cb.Items.Add("Hétfő");
            cb.Items.Add("Kedd");
            cb.Items.Add("Szerda");
            cb.Items.Add("Csütörtök");
            cb.Items.Add("Péntek");
            cb.SelectedItem = "Hétfő";
            this.Controls.Add(cb);

            NumericUpDown nud = new NumericUpDown();
            nud.Location = new System.Drawing.Point(StartofList.Location.X+100, StartofList.Location.Y+20);
            nud.Name = "pos1";
            nud.Size = new System.Drawing.Size(120, 20);
            nud.TabIndex = 3;
            nud.ValueChanged += NumericUpDown_ValueChanged;
            this.Controls.Add(nud);
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            if ((int)n.Value > 20) n.Value = 20;
            int i = Convert.ToInt32(n.Name.Substring(3))+1;
            bool l = true;
            foreach (Control c in this.Controls)
            {
                NumericUpDown temp = c as NumericUpDown;
                if (temp != null && temp.Name == ("pos" + i))
                {
                    l = false;
                    if ((int)n.Value == 0) 
                    {
                        temp.Value = 0;
                        this.Controls.Remove(temp);
                        this.Controls.Remove(this.Controls.Find("day" + i,true)[0]);
                    }
                }
            }
            if (!l)
            {
                return;
            }
            
            ComboBox cb = new ComboBox();
            cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb.FormattingEnabled = true;
            cb.Location = new System.Drawing.Point(n.Location.X-100, n.Location.Y + 20);
            cb.Name = "day" + i;
            cb.Size = new System.Drawing.Size(100, 20);
            cb.TabIndex = 7;
            cb.Items.Add("Hétfő");
            cb.Items.Add("Kedd");
            cb.Items.Add("Szerda");
            cb.Items.Add("Csütörtök");
            cb.Items.Add("Péntek");
            cb.SelectedItem = "Hétfő";
            this.Controls.Add(cb);

            NumericUpDown nud = new NumericUpDown();
            nud.Location = new System.Drawing.Point(n.Location.X, n.Location.Y + 20);
            nud.Name = "pos" + i;
            nud.Size = new System.Drawing.Size(120, 20);
            nud.TabIndex = 3;
            nud.ValueChanged += NumericUpDown_ValueChanged;
            this.Controls.Add(nud);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            List<DayOfWeek> day = new List<DayOfWeek>();
            List<int> time = new List<int>();
            foreach(Control c in this.Controls)
            {
                NumericUpDown nud = c as NumericUpDown;
                if (nud != null && nud.Name.Substring(0, 3)=="pos" && (int)nud.Value!=0)
                {
                    time.Add((int)nud.Value);
                }
            }
            foreach (Control c in this.Controls)
            {
                ComboBox cb = c as ComboBox;
                if (cb != null && cb.Name.Substring(0, 3) == "day")
                {
                    switch(cb.Text)
                    {
                        case "Hétfő":
                            day.Add(DayOfWeek.Monday);
                            break;
                        case "Kedd":
                            day.Add(DayOfWeek.Tuesday);
                            break;
                        case "Szerda":
                            day.Add(DayOfWeek.Wednesday);
                            break;
                        case "Csütörtök":
                            day.Add(DayOfWeek.Thursday);
                            break;
                        case "Péntek":
                            day.Add(DayOfWeek.Friday);
                            break;
                    }
                }
            }
            List<Occasion> temp = new List<Occasion>();
            for(int i=0;i<time.Count;i++)
            {
                temp.Add(new Occasion(day[i], time[i]));
            }
            try
            {
                Subject s = new Subject(Sub_name.Text, (int)Sub_length.Value, temp);
                List.Items.Add(s);
                subjects.Add(s);
                Sub_name.Text = "";
                Sub_length.Value = 0;
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Valami el lett baszarintva", "Hiba");
            }
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if(subjects.Count<1)
            {
                MessageBox.Show("Ennél talán egy kicsivel több órát is be lehetne vállalni.");
                return;
            }
            Results r = get_results(subjects);
            if(r.count()==0)
            {
                MessageBox.Show("Nincs a megadott feltételeknek megfelelő órarend");
                return;
            }
            using (TimeTable tt=new TimeTable(r))
            {
                tt.ShowDialog();
            }
        }

        private Results get_results(List<Subject> s)
        {
            Result r = new Result();
            Results rs = new Results();
            get_results(s, r, rs);
            return rs;
        }
        
        private void get_results(List<Subject> s,Result r,Results rs)
        {
            Subject sub = s[r.count()];
            for(sub.first(); !sub.end(); sub.next())
            {
                if(r.add(new ResultSubject(sub.name, sub.length, sub.current())))
                {
                    if (r.count() == s.Count) rs.add(new Result(r));
                    else get_results(s, r, rs);
                    r.removelast();
                }
            }
        }

        private void List_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete && List.SelectedItems!=null)
            {
                List<Subject> temp = new List<Subject>();
                foreach(var v in List.SelectedItems)
                {
                    Subject s = v as Subject;
                    temp.Add(s);
                }
                foreach(Subject s in temp)
                {
                    List.Items.Remove(s);
                    subjects.Remove(s);
                }
            }
        }
    }
}
