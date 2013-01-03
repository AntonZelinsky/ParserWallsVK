using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ParserWallsVK
{
    public partial class Form1 : Form
    {
        int id; 
        DateTime date;
        int likes;
        string text;
        string textHtml = null;
        int count; /// количество сообшений на стене
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichBox.Text = "";
            textBox.Text = "";
            string minus = null;/// пусто - пользователь, минус - группа
            if (radioButton1.Checked) minus = "-";

            string ApiUrl = @"https://api.vk.com/method/wall.get?owner_id=" + minus + idGroup.Text;
            WebRequest wrq;
            WebResponse wrs;
            Stream strm;
            StreamReader sr;
            string line;
            try
            {
                wrq = WebRequest.Create(ApiUrl);
                wrs = wrq.GetResponse();
                strm = wrs.GetResponseStream();
                sr = new StreamReader(strm);
                line = sr.ReadLine();
                strm.Close();

                JsonTextReader reader = new JsonTextReader(new StringReader(line));

                reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read();reader.Read();
            
                count = Convert.ToInt32(reader.Value);

                countLabel.Text = "На стене было " + count +" записей.";

                for (int i = 1; i < count; i++)
                {
                    ApiUrl = @"https://api.vk.com/method/wall.getById?posts="+ minus + idGroup.Text + "_" + i;
                    wrq = WebRequest.Create(ApiUrl);
                    wrs = wrq.GetResponse();
                    strm = wrs.GetResponseStream();
                    sr = new StreamReader(strm);
                    line = sr.ReadLine();
                    strm.Close();
                    textBox.Text = line;
                    if (line.Length < 20) continue;
                    parseJSON(line);
                    textHtml += "ID: " + id + "\nДата: " + date + "\nLike: " + likes + "\nТекст:\n" + text + "\n\n";
                    RichBox.Text = textHtml;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(" Неудалось получить данные.\n Проверьте подключение к интернету.");
                return;
            }

        }

        private void parseJSON(string json)
        {
            responseGroups rg = JsonConvert.DeserializeObject<responseGroups>(json);
            id = rg.response[0].id;
            date = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(rg.response[0].date);
            likes = rg.response[0].likes.count;
            text = rg.response[0].text;
        }
    }
}
