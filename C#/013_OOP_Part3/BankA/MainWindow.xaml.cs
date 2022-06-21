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
                    ClearData();
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
            ClearData();
        }

        private void ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientList.SelectedIndex != -1)
            {
                switch (ClientType.SelectedIndex)
                {
                    case 0:
                        ClientInfoPrint(
                            individual[clientList.SelectedIndex].Surname,
                            individual[clientList.SelectedIndex].Name,
                            individual[clientList.SelectedIndex].Patronymic,
                            individual[clientList.SelectedIndex].NumAccount);
                        break;
                    case 1:
                        ClientInfoPrint(
                            entity[clientList.SelectedIndex].Surname,
                            entity[clientList.SelectedIndex].Name,
                            entity[clientList.SelectedIndex].Patronymic,
                            entity[clientList.SelectedIndex].NumAccount);
                        break;
                    case 2:
                        ClientInfoPrint(
                            vip[clientList.SelectedIndex].Surname,
                            vip[clientList.SelectedIndex].Name,
                            vip[clientList.SelectedIndex].Patronymic,
                            vip[clientList.SelectedIndex].NumAccount);
                        break;
                }
            }
        }

        private void btnTopUpAccountAction(object sender, RoutedEventArgs e)
        {
            switch (ClientType.SelectedIndex)
            {
                case 0:
                    TopUpAccount(individual[clientList.SelectedIndex].NumAccount);
                    break;
                case 1:
                    TopUpAccount(entity[clientList.SelectedIndex].NumAccount);
                    break;
                case 2:
                    TopUpAccount(vip[clientList.SelectedIndex].NumAccount);
                    break;
            }
            ClearData();
            ClientsTypeAdd();
            SaveData();
        }

        private void TopUpAccount(string numAccount)
        {
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numAccount)
                {
                    if (client[item].StatusAccount == "Открыт")
                    {
                        client[item].SumAccount += Convert.ToInt32(TxtBxSumBalans.Text);
                    }
                    else { MessageBox.Show("Пополнение счёта не доступно. Счёт закрыт", "Внимание!"); }
                }
            }
        }

        private void ClearData()
        {
            clientList.SelectedIndex = -1;
            TxtBxSurname.Text = String.Empty;
            TxtBxName.Text = String.Empty;
            TxtBxPatronymic.Text = String.Empty;
            TxtBlockNumAccount.Text = String.Empty;
            TxtBxSumBalans.Text = String.Empty;
            TxtBxTransfer.Text = String.Empty;
            TxtBxSumTransfer.Text = String.Empty;
        }

        private void ClientInfoPrint(
            string surname,
            string name,
            string patronymic,
            string numAccount)
        {
            TxtBxSurname.Text = surname;
            TxtBxName.Text = name;
            TxtBxPatronymic.Text = patronymic;
            TxtBlockNumAccount.Text = numAccount;
        }

        private void btnSumTransferAction(object sender, RoutedEventArgs e)
        {
            string sumOutAccount = String.Empty;
            switch (ClientType.SelectedIndex)
            {
                case 0:
                    sumOutAccount = individual[clientList.SelectedIndex].NumAccount;
                    break;
                case 1:
                    sumOutAccount = entity[clientList.SelectedIndex].NumAccount;
                    break;
                case 2:
                    sumOutAccount = vip[clientList.SelectedIndex].NumAccount;
                    break;
            }

            if (TxtBxTransfer.Text != String.Empty && TxtBxSumTransfer.Text != String.Empty)
            {
                SumTransferAccount(sumOutAccount, TxtBxTransfer.Text, ClientType.SelectedIndex);
                ClearData();
                ClientsTypeAdd();
                SaveData();
            }
            else
            { MessageBox.Show("Введите данные перевода", "Ошибка данных"); }

        }

        private void SumTransferAccount(string numOutAccount, string numAccount, int type)
        {
            int sumAccount = 0;
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numOutAccount)
                {
                    sumAccount = client[item].SumAccount;
                }
            }
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numAccount)
                {
                    switch (type)
                    {
                        case 0:
                            if (client[item].Type == "Физическое лицо" &&  Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт")
                            {
                                SubtractionSumTransfer(numOutAccount);
                                client[item].SumAccount += Convert.ToInt32(TxtBxSumTransfer.Text);
                            }
                            else { MessageBox.Show("Данный перевод недоступен", "Внимание!"); }
                            break;
                        case 1:
                            if (client[item].Type != "VIP" && Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт")
                            {
                                SubtractionSumTransfer(numOutAccount);
                                client[item].SumAccount += Convert.ToInt32(TxtBxSumTransfer.Text);
                            }
                            else { MessageBox.Show("Данная перевод недоступен", "Внимание!"); }
                            break;
                        case 2:
                            if (Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт")
                            {
                                SubtractionSumTransfer(numOutAccount);
                                client[item].SumAccount += Convert.ToInt32(TxtBxSumTransfer.Text);
                            }
                            else { MessageBox.Show("Данная перевод недоступен", "Внимание!"); }
                            break;
                    }
                }    
            }
        }

        private void SubtractionSumTransfer(string numOutAccount)
        {
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numOutAccount)
                {
                    client[item].SumAccount -= Convert.ToInt32(TxtBxSumTransfer.Text);
                }
            }
        }

        private void btnCloseAccountAction(object sender, RoutedEventArgs e)
        {
            switch (ClientType.SelectedIndex)
            {
                case 0:
                    CloseAccount(individual[clientList.SelectedIndex].NumAccount);
                    break;
                case 1:
                    CloseAccount(entity[clientList.SelectedIndex].NumAccount);
                    break;
                case 2:
                    CloseAccount(vip[clientList.SelectedIndex].NumAccount);
                    break;
            }
            ClearData();
            ClientsTypeAdd();
            SaveData();
        }

        private void CloseAccount(string numAccount)
        {
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numAccount)
                {
                    if (client[item].SumAccount == 0)
                    {
                        client[item].StatusAccount = "Закрыт";
                    }
                    else { MessageBox.Show("Закрытие счёта не доступно. Есть средства на счёте", "Внимание!"); }
                }
                
            }
        }
    }
}