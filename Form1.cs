using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
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
                   
        string ApiUrl;
        WebRequest wrq;
        WebResponse wrs;
        Stream strm;
        StreamReader sr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichBox.Text = "";
            textBox.Text = "";
            string line;
            try
            {
                int countN = on();
                countLabel.Text = "На стене было " + count +" записей.";
                for (int i = with(); i <= countN; i++)
                {
                    ApiUrl = @"https://api.vk.com/method/wall.getById?posts=" + (groupRadioButton.Checked ? "-" : "") + idGroup.Text + "_" + i;
                    wrq = WebRequest.Create(ApiUrl);
                    wrs = wrq.GetResponse();
                    strm = wrs.GetResponseStream();
                    sr = new StreamReader(strm);
                    line = sr.ReadLine();
                    strm.Close();
                    textBox.Text = line;
                    if (line.Length < 20) continue; /// Если ответ пустой, то значит запись была удаленна и мы тоже пропускаем её
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

        private int with()
        {
            if (withEdit.Text != "")
            {
                if (Convert.ToInt32(withEdit.Text) > 1) return Convert.ToInt32(withEdit.Text);
            }
            return 1;
        }

        private int on()
        {
            ApiUrl = @"https://api.vk.com/method/wall.get?owner_id=" + (groupRadioButton.Checked ? "-" : "") + idGroup.Text;/// пусто - пользователь, минус - группа
            wrq = WebRequest.Create(ApiUrl);
            wrs = wrq.GetResponse();
            strm = wrs.GetResponseStream();
            sr = new StreamReader(strm);
            string line = sr.ReadLine();
            strm.Close();

            JsonTextReader reader = new JsonTextReader(new StringReader(line));
            reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read();
            count = Convert.ToInt32(reader.Value);

            if (onEdit.Text != "")
            {
                if (Convert.ToInt32(onEdit.Text) >= 1) return Convert.ToInt32(onEdit.Text);
            }
            return count;
        }
    }
}
