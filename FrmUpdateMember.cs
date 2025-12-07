using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _07LAB
{
    public partial class FrmUpdateMember : Form
    {
        ClubRegistrationQuery club;
        public FrmUpdateMember()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            DataRowView row = comboBox1.SelectedItem as DataRowView;

            textBox2.Text = row["FirstName"].ToString();
            textBox3.Text = row["MiddleName"].ToString();
            textBox1.Text = row["LastName"].ToString();
            textBox4.Text = row["Age"].ToString();
            comboBox2.Text = row["Gender"].ToString();
            comboBox3.Text = row["Program"].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            long SID = long.Parse(comboBox1.Text);

            club.UpdateMember(
                SID,
                textBox2.Text,
                textBox3.Text,
                textBox1.Text,
                int.Parse(textBox4.Text),
                comboBox2.Text,
                comboBox3.Text
            );

            MessageBox.Show("Update Successful!");


            FormClubRegistration main = (FormClubRegistration)this.Owner;
            main.RefreshListOfClubMembers();

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            club = new ClubRegistrationQuery();
            club.DisplayList();

            comboBox1.DataSource = club.dataTable;
            comboBox1.DisplayMember = "StudentId";

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Male", "Female" });

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(new string[]
            {
                "BS in Information Technology",
                "BS in Computer Science",
                "BS in Information Systems",
                "BS in Computer Engineering"
            });
        }
    }
}
