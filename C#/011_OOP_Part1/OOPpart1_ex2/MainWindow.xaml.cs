using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;


namespace OOPpart1_ex2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Инициализация листов и переменной, используемой при хранении данных
        List<Client> client = new List<Client>();//лист используется для хранения данных в исходном виде
        List<Consultant> consultant = new List<Consultant>();//лист используется для хранения данных со своими требованиями
        List<Manager> manager = new List<Manager>();//лист используется для хранения данных со своими требованиями
        string json;
        public MainWindow()
        {
            InitializeComponent();
            //загрузка данных из файла и формирование листов client, consultant и manager
            json = File.ReadAllText("_base.json");
            client = JsonConvert.DeserializeObject<List<Client>>(json);
            for (int item = 0; item <= client.Count - 1; item++)
            {
                consultant.Add(new Consultant(client[item].Surname, client[item].Name, client[item].Patronymic, $"{ client[item].PhoneNumber }", client[item].IdPassport));
                manager.Add(new Manager(client[item].Surname, client[item].Name, client[item].Patronymic, $"{ client[item].PhoneNumber }", client[item].IdPassport));
            }

            RbtnConsultant.IsChecked = true;
        }
        // формат приложения для работы консультанта
        private void RbtnConsultantAction(object sender, RoutedEventArgs e)
        {
            TbxSurname.IsReadOnly = true;
            TbxSurname.Background = Brushes.WhiteSmoke;
            TbxName.IsReadOnly = true;
            TbxName.Background = Brushes.WhiteSmoke;
            TbxPatronymic.IsReadOnly = true;
            TbxPatronymic.Background = Brushes.WhiteSmoke;
            TbxIdPassport.IsReadOnly = true;
            TbxIdPassport.Background = Brushes.WhiteSmoke;
            btnAdd.IsEnabled = false;
            clientList.ItemsSource = consultant;
            SotrudnikChange();//
        }
        // формат приложения для работы менеджера
        private void RbtnManagerAction(object sender, RoutedEventArgs e)
        {
            TbxSurname.IsReadOnly = false;
            TbxSurname.Background = Brushes.White;
            TbxName.IsReadOnly = false;
            TbxName.Background = Brushes.White;
            TbxPatronymic.IsReadOnly = false;
            TbxPatronymic.Background = Brushes.White;
            TbxIdPassport.IsReadOnly = false;
            TbxIdPassport.Background = Brushes.White;
            btnAdd.IsEnabled = true;
            clientList.ItemsSource = manager;
            SotrudnikChange(); //метод переключения сотрудников
        }

        //Метод заполнения TextBox данными выбранного клиента
        private void ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientList.SelectedIndex != -1)
            {
                //формат для консультанта
                if (RbtnConsultant.IsChecked == true)
                {
                    TbxSurname.Text = consultant[clientList.SelectedIndex].Surname;
                    TbxName.Text = consultant[clientList.SelectedIndex].Name;
                    TbxPatronymic.Text = consultant[clientList.SelectedIndex].Patronymic;
                    TbxPhoneNumber.Text = consultant[clientList.SelectedIndex].PhoneNumber;
                    TbxIdPassport.Text = consultant[clientList.SelectedIndex].IdPassport;
                }
                //формат для менеджера
                else if (RbtnManager.IsChecked == true)
                {
                    TbxSurname.Text = manager[clientList.SelectedIndex].Surname;
                    TbxName.Text = manager[clientList.SelectedIndex].Name;
                    TbxPatronymic.Text = manager[clientList.SelectedIndex].Patronymic;
                    TbxPhoneNumber.Text = manager[clientList.SelectedIndex].PhoneNumber;
                    TbxIdPassport.Text = manager[clientList.SelectedIndex].IdPassport;
                }
            } 
        }
        //метод переключения сотрудников
        private void SotrudnikChange()
        {
            clientList.Items.Refresh();
            clientList.SelectedIndex = -1;
            TbxSurname.Text = null;
            TbxName.Text = null;
            TbxPatronymic.Text = null;
            TbxPhoneNumber.Text = null;
            TbxIdPassport.Text = null;
        }

        //Метод обработки кнопки Редактировать
        private void RedactorClickAction(object sender, RoutedEventArgs e)
        {
            //выполняется если выбрана какая-либо запись о клиенте
            if (clientList.SelectedIndex != -1)
            {
                //замена данных в листах
                if (RbtnConsultant.IsChecked == true)
                {
                    client[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    consultant[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    manager[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    SaveData();// обновление и сохранение данных
                }
                //замена данных в листах
                else if (RbtnManager.IsChecked == true)
                {
                    client[clientList.SelectedIndex].Surname = TbxSurname.Text;
                    client[clientList.SelectedIndex].Name = TbxName.Text;
                    client[clientList.SelectedIndex].Patronymic = TbxPatronymic.Text;
                    client[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    client[clientList.SelectedIndex].IdPassport = TbxIdPassport.Text;
                    manager[clientList.SelectedIndex].Surname = TbxSurname.Text;
                    manager[clientList.SelectedIndex].Name = TbxName.Text;
                    manager[clientList.SelectedIndex].Patronymic = TbxPatronymic.Text;
                    manager[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    manager[clientList.SelectedIndex].IdPassport = TbxIdPassport.Text;
                    consultant[clientList.SelectedIndex].Surname = TbxSurname.Text;
                    consultant[clientList.SelectedIndex].Name = TbxName.Text;
                    consultant[clientList.SelectedIndex].Patronymic = TbxPatronymic.Text;
                    consultant[clientList.SelectedIndex].PhoneNumber = TbxPhoneNumber.Text;
                    consultant[clientList.SelectedIndex].IdPassport = TbxIdPassport.Text;
                    SaveData();// обновление и сохранение данных
                }
            }
        }

        //Метод обработки кнопки Добавить
        private void AddClickAction(object sender, RoutedEventArgs e)
        {
            client.Add(new Client(TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, TbxPhoneNumber.Text, TbxIdPassport.Text));
            manager.Add(new Manager(TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, TbxPhoneNumber.Text, TbxIdPassport.Text));
            consultant.Add(new Consultant(TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, TbxPhoneNumber.Text, TbxIdPassport.Text));
            SaveData();// обновление и сохранение данных
        }

        //Метод обновления данных для отображения в ListView и сохранения в файл
        private void SaveData()
        {
            clientList.Items.Refresh();
            json = JsonConvert.SerializeObject(client);
            File.WriteAllText("_base.json", json);
        }
    }
}
 