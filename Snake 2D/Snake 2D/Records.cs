using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_2D
{
    public partial class Records : Form
    {
        static int countRecords = 20;
        string[] names = new String[countRecords];
        int[] records = new int[countRecords];
        DataGridViewTextBoxCell temp;

        public Records()
        {
            InitializeComponent();
            readRecords();
            tableOnce.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableOnce.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableOnce.BorderStyle = BorderStyle.None;
            tableOnce.RowHeadersWidth = 4;
        }

        private void readRecords()
        {
            try
            {
                StreamReader file = new StreamReader(Environment.CurrentDirectory + "\\records.txt");
                for (int i = 0; i < countRecords; i++)
                {
                    names[i] = file.ReadLine();
                    records[i] = int.Parse(file.ReadLine());
                }
                tableOnce.RowCount = countRecords;
                for (int i = 0; i < countRecords; i++)
                {
                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[0];
                    temp.Value = names[i];

                    temp = (DataGridViewTextBoxCell)tableOnce.Rows[i].Cells[1];
                    temp.Value = records[i];
                }

                file.Close();
            }catch(Exception ex)
            {
                setNulls();
                writeRecords();
            }
        }
        public void writeRecords()
        {
            StreamWriter file = new StreamWriter(Environment.CurrentDirectory + "\\records.txt");
            for(int i=0; i<countRecords; i++)
            {
                file.WriteLine(names[i]);
                file.WriteLine(records[i]);
            }
            file.Close();
        }

        public void setRecord(int newRecord, string newName)
        {
            bool flag = false;
            int tempI = countRecords-1;
            string tempName = "";
            int tempRecord = 0;
            for(int i=countRecords-1; i>=1; i--)
            {
                if(records[i]<=newRecord && records[i-1]>newRecord)
                {
                    tempI = i;
                    tempName = names[tempI];
                    tempRecord = records[tempI];

                    records[i] = newRecord;
                    names[i] = newName;
                    
                    flag = true;
                    break;
                }
            }
            if(!flag)
            {
                if (records[0] < newRecord)
                {
                    tempI = 0;
                    tempName = names[tempI];
                    tempRecord = records[tempI];

                    records[0] = newRecord;
                    names[0] = newName;
                    flag = true;
                }
            }

            if (flag)
            {
                for (int i = tempI + 1; i < countRecords; i++)
                {
                    string _tempName2 = names[i];
                    int _tempRecord2 = records[i];
                    names[i] = tempName;
                    records[i] = tempRecord;

                    tempName = _tempName2;
                    tempRecord = _tempRecord2;
            }
                writeRecords();
            }
        }

        private void setNulls()
        {
            for(int i=0; i<countRecords; i++)
            {
                names[i] = "Нету";
                records[i] = 0;
            }
        }

        private void Records_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            writeRecords();
        }

        public void showRecords()
        {
            Program.menu.Visible = false;
            Program.game.Visible = false;
            readRecords();
            Program.records.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.menu.Visible = true;
        }
    }
}
