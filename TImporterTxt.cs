using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Для DataTable
using System.Data;
//для DataGridView
using System.Windows.Forms;

using System.Globalization;

namespace GeneralClasses
{
    class TImporterTxt




    {

        private DataTable dataTable_;


        public static void importTxt(string filePath, char separator, DataGridView dataGridView)
        {


            string[] textData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.GetEncoding(1251));
            string[] headers = textData[0].Split(separator);



            DataTable dataTable = new DataTable();

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header, typeof(string), null);
            }


            for (int i = 1; i < textData.Length; i++)
                dataTable.Rows.Add(textData[i].Split(separator));


            dataGridView.DataSource = dataTable;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public static void importTxt(string filePath, char separator, ListView listView)
        {


            string[] textData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.GetEncoding(1251));
            string[] headers = textData[0].Split(separator);



            DataTable dataTable = new DataTable();

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header, typeof(string), null);
                listView.Columns.Add("File type", 20, HorizontalAlignment.Center);
            }


            // Set to details view.
            //  listView.View = View.Details;
            // Add a column with width 20 and left alignment.


            for (int i = 1; i < textData.Length; i++)
                dataTable.Rows.Add(textData[i].Split(separator));


            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dataTable.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView.Items.Add(item);
            }






        }

        /*  //using example
        private void button2_Click(object sender, EventArgs e)
        {
            string filePath;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                char separator = '\t';
                TImporterTxt.importTxt(filePath, separator, dataGridView1);
            }
        }*/

    }
}
