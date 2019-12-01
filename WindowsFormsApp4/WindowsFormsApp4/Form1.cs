using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        string path = "C:/Users/Ali/Desktop/test.txt";
        Student s = new Student();
        class Student
        {
            private string _id;
            private string _name;
            private double _gpa;
            private string _department;
            private double _semester;
            private string _universityName;
            private bool _attendance;
            public string id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }

            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            public Double gpa
            {
                get
                {
                    return _gpa;
                }
                set
                {
                    _gpa = value;
                }
            }

            public string department
            {
                get
                {
                    return _department;
                }
                set
                {
                    _department = value;
                }
            }

            public Double semester
            {
                get
                {
                    return _semester;
                }
                set
                {
                    _semester = value;
                }
            }


            public string universityName
            {
                get
                {
                    return _universityName;
                }
                set
                {
                    _universityName = value;
                }
            }

            public bool attendance
            {
                get
                {
                    return _attendance;
                }
                set
                {
                    _attendance = value;
                }
            }


        }
        public Form1()
        {
            InitializeComponent();
        }

        
       private void readlistFile(ref List<Student> _list)
        {
            StreamReader reader = new StreamReader(path);
            
            while (reader.EndOfStream != true)
            {
                
                Student stu = new Student();

                stu.id = reader.ReadLine();
                stu.name = reader.ReadLine();
                stu.gpa = Convert.ToDouble(reader.ReadLine());
                stu.department = reader.ReadLine();
                stu.semester = Convert.ToDouble(reader.ReadLine());
                stu.universityName = reader.ReadLine();
                stu.attendance = Convert.ToBoolean(reader.ReadLine());
                _list.Add(stu);
                

            }
            reader.Close();
        }


        static List<Student> Top3Students(ref int first,ref int second,ref int third ,List<Student> list)
        {
            List<Student> _list = new List<Student>();
            first = 0; 
            second = 0;
            third = 0;
            for (int i = 1;i<_list.Count;i++)
            {

                if(list[first].gpa < list[i].gpa)
                {
                    third = second;
                    second = first;
                    first = i;
                }

                else if(list[second].gpa < list[i].gpa && list[second].gpa < list[first].gpa)
                {
                    second = i;
                }
                else if (list[third].gpa < list[i].gpa && list[third].gpa < list[second].gpa)
                {
                    third = i;
                }
            }
            _list.Add(list[first]);
            _list.Add(list[second]);
            _list.Add(list[third]);

            return _list;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void AddRecrdbtn_Click(object sender, EventArgs e)
        {
            List<Student> _list = new List<Student>();

            if (s.id == textBox1.Text)
            {
                MessageBox.Show("Record already exits !");
            }
            else
            {
                            
                StreamWriter writter = new StreamWriter(path, append: true);
                {
                    writter.WriteLine(s.id = textBox1.Text);
                    writter.WriteLine(s.name = textBox2.Text);
                    writter.WriteLine(s.gpa = Convert.ToDouble(textBox3.Text));
                    writter.WriteLine(s.department = textBox4.Text);
                    writter.WriteLine(s.semester = Convert.ToDouble(textBox5.Text));
                    writter.WriteLine(s.universityName = textBox6.Text);
                    writter.WriteLine(s.attendance);

                    writter.Close();
                }
                MessageBox.Show("Record Saved !");
                panel1.Visible = false;
            }
        }

        private void srchbyNmeBtn_Click(object sender, EventArgs e)
        {
            List<Student> _list = new List<Student>();
            readlistFile(ref _list);


            for (int a = 0; a < _list.Count; a++)
            {
                if (_list[a].name == textBox7.Text)
                {
                    dataGridView1.Visible = true;
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = _list[a].id;
                    dataGridView1.Rows[n].Cells[1].Value = _list[a].name;
                    dataGridView1.Rows[n].Cells[2].Value = _list[a].gpa;
                    dataGridView1.Rows[n].Cells[3].Value = _list[a].department;
                    dataGridView1.Rows[n].Cells[4].Value = _list[a].semester;
                    dataGridView1.Rows[n].Cells[5].Value = _list[a].universityName;
                    //dataGridView1.Rows[n].Cells[5].Value = _list[i].attendance;
                    textBox7.Text = "";
                    MessageBox.Show("Record Found ");
                    
                }
                
            }


            panel2.Visible = false;
        }

        private void SrchIDBtn_Click(object sender, EventArgs e)
        {
           
            List<Student> _list = new List<Student>();

            readlistFile(ref _list);


            for (int a = 0; a < _list.Count; a++)
            {
                if (_list[a].id == textBox8.Text)
                {
                    dataGridView2.Visible = true;
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = _list[a].id;
                    dataGridView2.Rows[n].Cells[1].Value = _list[a].name;
                    dataGridView2.Rows[n].Cells[2].Value = _list[a].gpa;
                    dataGridView2.Rows[n].Cells[3].Value = _list[a].department;
                    dataGridView2.Rows[n].Cells[4].Value = _list[a].semester;
                    dataGridView2.Rows[n].Cells[5].Value = _list[a].universityName;
                    //dataGridView2.Rows[n].Cells[5].Value = _list[].attendance;
                    textBox8.Text = "";
                    MessageBox.Show("Record found");
                    
                }
                
            }


            panel3.Visible = false;
        }

        private void hideDataGridsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void DeleteRCRDBtn_Click(object sender, EventArgs e)
        {
            string delete = textBox9.Text;
            
            List<Student> _list = new List<Student>();

            readlistFile(ref _list);

            for (int a = 0; a < _list.Count; a++)
            {
                if (_list[a].id == delete)
                {
                    _list.RemoveAt(a);
                    MessageBox.Show("Record deleted !");
                }

            }

            StreamWriter wri = new StreamWriter(path);
            wri.Write("");
            wri.Close();
            wri = File.AppendText(path);
            for (int k = 0; k < _list.Count; k++)
            {

                wri.WriteLine(_list[k].id);
                wri.WriteLine(_list[k].name);
                wri.WriteLine(_list[k].gpa);
                wri.WriteLine(_list[k].department);
                wri.WriteLine(_list[k].semester);
                wri.WriteLine(_list[k].universityName);
                wri.WriteLine(_list[k].attendance);
            }

            wri.Close();
            panel4.Visible = false;
        }

        private void allRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            
            List<Student> _list = new List<Student>();
            readlistFile(ref _list);

            dataGridView3.DataSource = _list;

          
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;
        }

        private void top3StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = true;
            List<Student> _listTop3 = new List<Student>();
           

            readlistFile(ref _listTop3);
            int firstLargest =  -1;
            int secondLargest = -1;
            int thirdLargest = -1;
            List<Student> top3list = Top3Students(ref firstLargest, ref secondLargest, ref thirdLargest, _listTop3);
            dataGridView4.DataSource = top3list;
        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            markAttendanceGrid.Visible = true;
            List<Student> mrkatndlist = new List<Student>();
            Student stu = new Student();

            readlistFile(ref mrkatndlist);
            
            markAttendanceGrid.DataSource = mrkatndlist;
        }


       

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView5.Visible = true;
            List<Student> _list = new List<Student>();

            readlistFile(ref _list);
            for(int a=0;a<_list.Count;a++)
            {
                int n = dataGridView5.Rows.Add();
                dataGridView5.Rows[n].Cells[0].Value = _list[a].id;
                dataGridView5.Rows[n].Cells[1].Value = _list[a].name;
                dataGridView5.Rows[n].Cells[2].Value = _list[a].attendance;
            }
            

        }

        private void hideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;
        }

        private void markAttendanceGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            List<Student> markAttenList = new List<Student>();
            readlistFile(ref markAttenList);
            
            if(markAttenList[i].attendance==true)
            {
                markAttenList[i].attendance = false;
            }
            else if(markAttenList[i].attendance==false)
            {
                markAttenList[i].attendance = true;
            }
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.Write("");
            streamWriter.Close();
            streamWriter = File.AppendText(path);
            for(int a=0;a<markAttenList.Count;a++)
            {
                streamWriter.WriteLine(markAttenList[a].id);
                streamWriter.WriteLine(markAttenList[a].name);
                streamWriter.WriteLine(markAttenList[a].gpa);
                streamWriter.WriteLine(markAttenList[a].department);
                streamWriter.WriteLine(markAttenList[a].semester); 
                streamWriter.WriteLine(markAttenList[a].universityName);
                streamWriter.WriteLine(markAttenList[a].attendance);
            }
            streamWriter.Close();
        }

        private void hideDatagridsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            markAttendanceGrid.Visible = false;
           
            dataGridView5.Visible = false;
            
        }
    }
}
