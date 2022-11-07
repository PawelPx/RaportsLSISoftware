using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaportsLSISoftware
{
    public partial class Form1 : Form
    {
        private BindingList<Raport> Raports;

        static DataAccess dataAccess = new DataAccess();

        public Form1()
        {
            Raports = new BindingList<Raport>();

            InitializeComponent();
            LoadData("Wszystkie", "01-01-1000", "12-31-9999");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetComboBoxItems();
            dataGridViewRaports.DataSource = Raports;
            dataGridViewRaports.Columns["RaportID"].Visible = false;
        }

        private void LoadData(string local, string from, string to)
        {
            string commandText;
            if (local == "Wszystkie" || local == "Lokal:")
                commandText = $"Select * From Raports As r Where r.Date>='{from}' And r.Date<='{to}'";
            else
                commandText = $"Select * From Raports As r Where r.Local='{local}' And r.Date>='{from}' And r.Date<='{to}'";
            List<DbDataRecord> list = dataAccess.ReadData(commandText);

            Raports.Clear();
            foreach (DbDataRecord row in list)
            {
                Raport raport = new Raport(int.Parse(row["RaportID"].ToString()), row["Name"].ToString(), DateTime.Parse(row["Date"].ToString()),
                                                     row["Time"].ToString(), row["User"].ToString(), row["Local"].ToString());
                Raports.Add(raport);
            }
            dataGridViewRaports.Update();
            dataGridViewRaports.Refresh();
        }

        private string ConvertDateFormat(object value)
        {
            return DateTime.Parse(value.ToString()).ToString("MM-dd-yy");
        }


        private void SetComboBoxItems()
        {
            string commandText = $"Select Distinct Local From Raports";
            List<DbDataRecord> list = dataAccess.ReadData(commandText);
            comboBoxLocal.Properties.Items.Add("Wszystkie");
            foreach (DbDataRecord item in list)
            {
                comboBoxLocal.Properties.Items.Add(item["Local"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateEditFrom.EditValue != null && dateEditTo.EditValue != null)
                LoadData(comboBoxLocal.Text, ConvertDateFormat(dateEditFrom.EditValue), ConvertDateFormat(dateEditTo.EditValue));
            else
                MessageBox.Show("Proszę ustawić daty.", "Błąd");
        }
    }
}
