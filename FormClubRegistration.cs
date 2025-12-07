using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LAB
{
    public partial class FormClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int count = 0;

        public FormClubRegistration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                comboBox2.Text == "" ||
                comboBox1.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            if (!long.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("Student ID must be numbers only.");
                return;
            }

            if (!int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Age must be a number.");
                return;
            }

            int ID = RegistrationID();
            long studentId = long.Parse(textBox1.Text);
            string firstName = textBox4.Text;
            string middleName = textBox5.Text;
            string lastName = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string gender = comboBox2.Text;
            string program = comboBox2.Text;

            clubRegistrationQuery.RegisterStudent(ID, studentId, firstName, middleName, lastName, age, gender, program);

            RefreshListOfClubMembers();

            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            MessageBox.Show("Student Registered!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frm = new FrmUpdateMember();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange
            (new string[] { "Male", "Female" });

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange
            (new string[]
            { "BS in Information Technology",
              "BS in Computer Science",
              "BS in Information Systems",
              "BS in Computer Engineering"});

            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }
        public void RefreshListOfClubMembers()
        {
            if (clubRegistrationQuery.DisplayList())
            {
                dataGridView1.DataSource = clubRegistrationQuery.bindingSource;

                count = clubRegistrationQuery.dataTable.Rows.Count;
            }
        }

        public int RegistrationID()
        {
            count++;
            return count;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
