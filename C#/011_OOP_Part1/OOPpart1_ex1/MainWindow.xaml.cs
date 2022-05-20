using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;


namespace OOPpart1_ex1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Инициализация листов и переменной, используемой при хранении данных
        List<Client> client = new List<Client>();//лист используется для хранения данных в исходном виде
        List<Consultant> consultant = new List<Consultant>();//лист используется для хранения данных со своими требованиями
        string json;
        public MainWindow()
        {
            InitializeComponent();
            //если выбран консультант, то TextBox блокируются для редактирования и меняется цвет фона
            if (RbtnConsultant.IsChecked == true)
            {
                TbxSurname.IsReadOnly = true;
                TbxSurname.Background = Brushes.WhiteSmoke;
                TbxName.IsReadOnly = true;
                TbxName.Background = Brushes.WhiteSmoke;
                TbxPatronymic.IsReadOnly = true;
                TbxPatronymic.Background = Brushes.WhiteSmoke;
                TbxIdPassport.IsReadOnly = true;
                TbxIdPassport.Background = Brushes.WhiteSmoke;
            }
            //загрузка данных из файла и формирование листов client и consultant
            json = File.ReadAllText("_base.json");
            client = JsonConvert.DeserializeObject<List<Client>>(json);
            for (int item = 0; item <= client.Count - 1; item++)
            {
                consultant.Add(new Consultant(client[item].Surname, client[item].Name, client[item].Patronymic, $"{ client[item].PhoneNumber }", client[item].Surname));
            }
            ItemSoureData();//выгруска данных в ListView
        }

        //Метод заполнения TextBox данными выбранного клиента
        private void ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbxSurname.Text = consultant[clientList.SelectedIndex].Surname;
            TbxName.Text = consultant[clientList.SelectedIndex].Name;
            TbxPatronymic.Text = consultant[clientList.SelectedIndex].Patronymic;
            TbxPhoneNumber.Text = consultant[clientList.SelectedIndex].PhoneNumber;
            TbxIdPassport.Text = consultant[clientList.SelectedIndex].IdPassport;
        }
        //Метод обработки кнопки Редактировать
        private void ClickAction(object sender, RoutedEventArgs e)
        {
            //выполняется если выбрана какая-либо запись о клиенте
            if (clientList.SelectedIndex != -1)
            {
                //замена данных в листах
                client[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                consultant[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                ItemSoureData();// обновление данных
            }
        }
        //Метод обновления данных для отображения в ListView
        private void ItemSoureData()
        {
            clientList.ItemsSource = consultant;
            clientList.Items.Refresh();
            SaveData(); //сохранение данных
        }
        //Метод сохранения данных в файл
        private void SaveData()
        {
            json = JsonConvert.SerializeObject(client);
            File.WriteAllText("_base.json", json);
        }
    }
}
