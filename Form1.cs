﻿using System;
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

        string textHtml = "<!DOCTYPE html>" + "<meta charset='utf-8'>" + "<link href='bootstrap.css' rel='stylesheet' media='screen'>";
        int count; /// количество сообшений на стене
                   
        string ApiUrl;
        WebRequest wrq;
        WebResponse wrs;
        Stream strm;
        StreamReader sr;

        public Form1()
        {
            InitializeComponent();
            idEdit.Text = "22822305";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichBox.Text = "";
            textBox.Text = "";
            string line;
            
            int countN = on();
            if (countN == 0)
            {
                return;
            }
            countLabel.Text = "На стене было " + count +" записей.";
            for (int i = with(); i <= countN; i++)
            {
                ApiUrl = "https://api.vk.com/method/wall.getById?posts=" + (groupRadioButton.Checked ? "-" : "") + idEdit.Text + "_" + i;
                try
                {
                    wrq = WebRequest.Create(ApiUrl);
                    wrs = wrq.GetResponse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Не удалось получить данные.\n Проверьте подключение к интернету.");
                    return;
                }
                strm = wrs.GetResponseStream();
                sr = new StreamReader(strm);
                line = sr.ReadLine();
                strm.Close();
                textBox.Text = line;
                if (line.Length < 20) continue; /// Если ответ пустой, то значит запись была удаленна и мы тоже пропускаем её
                parseJSON(line);
                line = "ID: " + id + "\nДата: " + date + "\nLike: " + likes + "\nТекст:\n" + text + "\n\n";
                RichBox.Text += line.Replace('\"', '"');
                textHtml += "<div class='hero-unit'>" + "ID: <a href='http://" + "vk.com/public" + idEdit.Text + "?w=wall-" + idEdit.Text + "_" + id + @"'>" + id + "</a>" + "<br>Дата: " + date + "<br>Понравилось: <i class='icon-heart'></i>" + likes + "<br>Текст:<br>" + text + "</div>";
            }

            textHtml += "</html>";
            File.WriteAllText("Wall" + (groupRadioButton.Checked ? "ClubId" : "UserId") + idEdit.Text + ".html", textHtml);


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
            ApiUrl = @"https://api.vk.com/method/wall.get?owner_id=" + (groupRadioButton.Checked ? "-" : "") + idEdit.Text;/// пусто - пользователь, минус - группа
            try
            {
                wrq = WebRequest.Create(ApiUrl);
                wrs = wrq.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Не удалось получить данные.\n Проверьте подключение к интернету.");
                return 0;
            }

            strm = wrs.GetResponseStream();
            sr = new StreamReader(strm);
            string line = sr.ReadLine();
            strm.Close();

            JsonTextReader reader = new JsonTextReader(new StringReader(line));
            reader.Read(); reader.Read();
            if (reader.Value.ToString() == "error")
            {
                MessageBox.Show(" С данным идентификатором " + (groupRadioButton.Checked ? "группа" : "пользователь") + " не существует.");
                return 0;
            }
            reader.Read(); reader.Read(); reader.Read(); reader.Read(); reader.Read();
            count = Convert.ToInt32(reader.Value);

            if (onEdit.Text != "")
            {
                if (Convert.ToInt32(onEdit.Text) < Convert.ToInt32(withEdit.Text))
                {
                    MessageBox.Show(" Неверно задано ограничения, на получение записей.\n" + @" Число ""с какого"", больше чем число ""по какое"".");
                    return 0;
                }
                if (Convert.ToInt32(onEdit.Text) >= 1) return Convert.ToInt32(onEdit.Text);
            }
            return count;
        }

        private void withEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 48 | e.KeyValue > 57 & e.KeyValue < 96 | e.KeyValue > 105)
                e.SuppressKeyPress = true;
            if (e.KeyValue == 8 | e.KeyValue == 46)
                e.SuppressKeyPress = false;
        }

        private void onEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 48 | e.KeyValue > 57 & e.KeyValue < 96 | e.KeyValue > 105)
                e.SuppressKeyPress = true;
            if (e.KeyValue == 8 | e.KeyValue == 46)
                e.SuppressKeyPress = false;
        }

        private void idEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue < 48 | e.KeyValue > 57 & e.KeyValue < 96 | e.KeyValue > 105)
                e.SuppressKeyPress = true;
            if (e.KeyValue == 8 | e.KeyValue == 46)
                e.SuppressKeyPress = false;
        }

    }
}
