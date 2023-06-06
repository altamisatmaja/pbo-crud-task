using System;
using System.Data;
using Npgsql;

namespace altamis
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=12345678; Database=postgres";
        private NpgsqlConnection conn;
        private string psql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connectionString);
            baca_database();
        }

        private void baca_database()
        {
            try
            {
                conn.Open();
                psql = @"select penjual_laptop.id_penjual, penjual_laptop.nama_laptop, penjual_laptop.harga_satuan, penjual_laptop.stok_laptop, pembeli_laptop.id_pembeli, pembeli_laptop.nama_pembeli, pembeli_laptop.laptop_dibeli, pembeli_laptop.harga_laptop, pembeli_laptop.stok_laptop_dibeli from penjual_laptop inner join pembeli_laptop on penjual_laptop.nama_laptop = pembeli_laptop.laptop_dibeli";
                cmd = new NpgsqlCommand(psql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error guys: " + ex.Message);
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string altamis = @"insert into penjual_laptop (id_penjual, nama_laptop, harga_satuan, stok_laptop) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd = new NpgsqlCommand(altamis, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data masuk!");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string altamis = @"insert into pembeli_laptop (id_pembeli, nama_pembeli, laptop_dibeli, harga_laptop, stok_laptop_dibeli) values ('" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            cmd = new NpgsqlCommand(altamis, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data masuk!");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baca_database();
        }
    }
}