using Olympiad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace Olimpiad
{
    /// <summary>
    /// Логика взаимодействия для Add_Win.xaml
    /// </summary>
    public partial class Add_Win : Window
    {
        string database;

        string filename;
        byte[] photo;

        public Add_Win(string db)
        {
            InitializeComponent();

            database = db;

            this.Title = database + "ChangeForm";

            switch (database) //В зависимости от имени таблицы меняем названия элементов управления, их положение и видимость
            {
                case "Cities":
                    {
                        Label label1 = new Label();

                        label1.Content = "City Name";

                        FirstStack.Children.Add(label1);

                        TextBox tb1 = new TextBox();

                        SecStack.Children.Add(tb1);

                        break;
                    }

                case "Countries":
                    {
                        Label lbl1 = new Label();

                        lbl1.Content = "Country Name";

                        FirstStack.Children.Add(lbl1);

                        TextBox tb1 = new TextBox();

                        SecStack.Children.Add(tb1);

                        break;
                    }

                case "KindSports":
                    {
                        Label label1 = new Label();

                        label1.Content = "Sport Name";

                        FirstStack.Children.Add(label1);

                        TextBox tb1 = new TextBox();

                        SecStack.Children.Add(tb1);

                        break;
                    }

                case "OlimpInfoes":
                    {
                        Label lb1 = new Label();
                        Label lb2 = new Label();
                        Label lb3 = new Label();
                        Label lb4 = new Label();

                        lb1.Content = "Olimp Name";
                        lb2.Content = "City";
                        lb3.Content = "Olymp Type";
                        lb4.Content = "Date";

                        lb2.Margin = new Thickness(0, 10, 0, 0);

                        FirstStack.Children.Add(lb1);
                        FirstStack.Children.Add(lb2);
                        FirstStack.Children.Add(lb3);
                        FirstStack.Children.Add(lb4);

                        TextBox tb1 = new TextBox();
                        ComboBox cb1 = new ComboBox();
                        TextBox tb2 = new TextBox();
                        DatePicker picker = new DatePicker();

                        DataBaseControl db_control = new DataBaseControl();

                        cb1.ItemsSource = db_control.GetContext().OlimpInfos.ToList();
                        cb1.DisplayMemberPath = "CityName";
                        cb1.SelectedValuePath = "Id";
                        cb1.SelectedValue = db_control.GetContext().OlimpInfos.ToList();

                        tb2.Margin = new Thickness(0, 10, 0, 0);
                        cb1.Margin = new Thickness(0, 10, 0, 0);
                        tb2.Margin = new Thickness (0, 10, 0, 0);
                        picker.Margin = new Thickness(0, 10, 0, 0);

                        SecStack.Children.Add(tb1);
                        SecStack.Children.Add(cb1);
                        SecStack.Children.Add(tb2);
                        SecStack.Children.Add(picker);

                        

                        break;
                    }

                case "Participants":
                    {
                        Label label1 = new Label();
                        Label label2 = new Label();
                        Label label3 = new Label();
                        Label label4 = new Label();
                        Label label5 = new Label();

                        label1.Content = "Name";
                        label2.Content = "Age";
                        label3.Content = "Country";
                        label4.Content = "Sex";
                        label5.Content = "Photo";

                        label3.Margin = new Thickness(0, 10, 0, 0);
                        label4.Margin = new Thickness(0, 10, 0, 0);
                        label5.Margin = new Thickness(0,10, 0, 0);

                        List<Label> labels = new List<Label>() { label1, label2, label3, label4, label5 };

                        foreach (var label in labels)
                        {
                            FirstStack.Children.Add(label);
                        }

                        TextBox text1 = new TextBox();
                        TextBox text2 = new TextBox();

                        text1.Margin = new Thickness(5);
                        text2.Margin = new Thickness(5);

                        ComboBox comboBox1 = new ComboBox();
                        ComboBox comboBox2 = new ComboBox();

                        comboBox1.Margin = new Thickness(5);
                        comboBox2.Margin = new Thickness(5);

                        comboBox2.Items.Add("Women");
                        comboBox2.Items.Add("Man");

                        DataBaseControl dbCont = new DataBaseControl();
                        
                        var context = dbCont.GetContext();
                        
                        comboBox1.ItemsSource = context.Countries.ToList();

                        comboBox1.DisplayMemberPath = "CountryName";
                        comboBox1.SelectedValuePath = "Id";
                        comboBox1.SelectedValue = context.Countries.ToList();

                        Button button1 = new Button();

                        button1.Click += Button1_Click;

                        button1.Content = "Choose Photo";
                        button1.Margin = new Thickness(0, 10, 0, 0);

                        SecStack.Children.Add(text1);
                        SecStack.Children.Add(text2);
                        SecStack.Children.Add(comboBox1);
                        SecStack.Children.Add(comboBox2);
                        SecStack.Children.Add(button1);

                        
                        break;
                    }

                case "Results":
                    {
                        Label lb1 = new Label();
                        Label lb2 = new Label();
                        Label lb3 = new Label();

                        lb1.Content = "Parti List";
                        lb2.Content = "Olimp Info";
                        lb3.Content = "Score";

                        FirstStack.Children.Add(lb1);
                        FirstStack.Children.Add(lb2);
                        FirstStack.Children.Add(lb3);

                        ComboBox cb1 = new ComboBox();
                        ComboBox cb2 = new ComboBox();

                        cb2.Margin = new Thickness(0, 10, 0, 0);

                        DataBaseControl db_control = new DataBaseControl();

                        cb1.ItemsSource = db_control.GetContext().Participants.ToList();
                        cb1.DisplayMemberPath = "ParticipantName";
                        cb1.SelectedValuePath = "Id";
                        cb1.SelectedValue = db_control.GetContext().Participants.ToList();


                        cb2.ItemsSource = db_control.GetContext().OlimpInfos.ToList();

                        cb2.DisplayMemberPath = "OlimpName";
                        cb2.SelectedValuePath = "Id";
                        cb2.SelectedValue = db_control.GetContext().OlimpInfos.ToList();

                        TextBox tb1 = new TextBox();

                        tb1.Margin = new Thickness(0, 10, 0, 0);

                        SecStack.Children.Add(cb1);
                        SecStack.Children.Add(cb2);
                        SecStack.Children.Add(tb1);

                        

                        break;
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (database)
            {
                case "Cities":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        City city = new City() { CityName = (SecStack.Children[0] as TextBox).Text};

                        dbcontrol.GetContext().Cities.Add(city);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }

                case "Countries":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        Country country = new Country() { CountryName = (SecStack.Children[0] as TextBox).Text };

                        dbcontrol.GetContext().Countries.Add(country);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }

                case "KindSports":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();
                        
                        KindSport kindSport = new KindSport() { KindSportName = (SecStack.Children[0] as TextBox).Text };

                        dbcontrol.GetContext().KindSports.Add(kindSport);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }

                case "OlimpInfoes":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        OlimpInfo info = new OlimpInfo() { OlimpName = (SecStack.Children[0] as TextBox).Text, CityCountryId = int.Parse((SecStack.Children[1] as ComboBox).SelectedValue as string), OlympType = (SecStack.Children[2] as TextBox).Text, Date = DateTime.Parse((SecStack.Children[3] as DatePicker).Text) };

                        dbcontrol.GetContext().OlimpInfos.Add(info);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }

                case "Participants":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        Participant parti = new Participant() { ParticipantName = (SecStack.Children[0] as TextBox).Text, Age = int.Parse((SecStack.Children[1] as TextBox).Text), CountryId = int.Parse((SecStack.Children[2] as ComboBox).SelectedValue as string), Sex = Convert.ToBoolean((SecStack.Children[3] as ComboBox).SelectedIndex), Photo = photo };

                        dbcontrol.GetContext().Participants.Add(parti);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }

                case "Results":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        Result result = new Result() { OlimpInfoId = int.Parse((SecStack.Children[1] as ComboBox).SelectedValue as string), PartiListId = int.Parse((SecStack.Children[0] as ComboBox).SelectedValue as string), Score = int.Parse((SecStack.Children[2] as TextBox).Text) };

                        dbcontrol.GetContext().Results.Add(result);
                        dbcontrol.GetContext().SaveChanges();

                        break;
                    }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.bmp; *.gif; *.jpg; *.png";
            ofd.FileName = "";

            ofd.ShowDialog();

            filename = ofd.FileName;


            photo = CreateCopy();
        }

        private byte[] CreateCopy()
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(filename);

            int maxWidth = 300, maxHeight = 300;
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);


            System.Drawing.Image mi = new Bitmap(newWidth, newHeight);

            Graphics g = Graphics.FromImage(mi);

            g.DrawImage(img, 0,0, newWidth, newHeight);

            MemoryStream ms = new MemoryStream();
            mi.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);

            BinaryReader br = new BinaryReader(ms);

            byte[] buf = br.ReadBytes((int)ms.Length);

            return buf;
        }
    }
}
