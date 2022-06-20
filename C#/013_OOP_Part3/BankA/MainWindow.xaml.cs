using Newtonsoft.Json;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Client<int>> client = new List<Client<int>>();
        List<Individual<int>> individual = new List<Individual<int>>();
        List<Entity<int>> entity = new List<Entity<int>>();
        List<VIP<int>> vip = new List<VIP<int>>();
        string json;
        public MainWindow()
        {
            InitializeComponent();
            json = File.ReadAllText("_base.json");
            if (json.Length != 0)
            {
                client = JsonConvert.DeserializeObject<List<Client<int>>>(json);
                ClientsTypeAdd();
            }
            //clientList.ItemsSource = client;
            //clientList.Items.Refresh();
        }

        private void ClientsTypeAdd()
        {
            individual.Clear();
            entity.Clear();
            vip.Clear();
            for (int item = 0; item <= client.Count - 1; item++)
            {
                switch (client[item].Type)
                {
                    case "Физическое лицо":
                        individual.Add(new Individual<int>(individual.Count + 1, "Физическое лицо", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].StatusAccount));
                        break;
                    case "Юридическое лицо":
                        entity.Add(new Entity<int>(individual.Count + 1, "Юридическое лицо", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].StatusAccount));
                        break;
                    case "VIP":
                        vip.Add(new VIP<int>(individual.Count + 1, "VIP", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].StatusAccount));
                        break;
                }
            }
        }

        private void btnOpenAction(object sender, RoutedEventArgs e)
        {
            if (ClientType.SelectedIndex == -1) { MessageBox.Show("Выберите тип клиента", "Ошибка данных"); }
            //TxtBxSurname.Text = ClientType.SelectedIndex.ToString();
            else
            {
                if (TxtBxSurname.Text == String.Empty || TxtBxName.Text == String.Empty || TxtBxPatronymic.Text == String.Empty)
                { MessageBox.Show("Введите данные клиента", "Ошибка данных"); }
                else
                {
                    client.Add(new Client<int>(
                        client.Count + 1,
                        ClientType.Text,
                        TxtBxSurname.Text,
                        TxtBxName.Text,
                        TxtBxPatronymic.Text,
                         
                        0,
                        "Открыт"));
                    TxtBxSurname.Text = String.Empty;
                    TxtBxName.Text = String.Empty;
                    TxtBxPatronymic.Text = String.Empty;
                    ClientsTypeAdd();
                    SaveData();
                }
            }
        }

        private void SaveData()
        {
            //SortBy();//сортировка по фамилии
            clientList.Items.Refresh();
            json = JsonConvert.SerializeObject(client);
            File.WriteAllText("_base.json", json);
        }

        private void ClientTypeSelectChangeAction(object sender, SelectionChangedEventArgs e)
        {
            switch (ClientType.SelectedIndex)
            {
                case 0:
                    clientList.ItemsSource = individual;
                    clientList.Items.Refresh();
                    break;
                case 1:
                    clientList.ItemsSource = entity;
                    clientList.Items.Refresh();
                    break;
                case 2:
                    clientList.ItemsSource = vip;
                    clientList.Items.Refresh();
                    break;
            }
        }
    }
}
