using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BankA_Exercise3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Задание 2
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Инициализация работы
        //Инициализация списков клиентов
        List<Client<int>> client = new List<Client<int>>();
        List<Individual<int>> individual = new List<Individual<int>>();
        List<Entity<int>> entity = new List<Entity<int>>();
        List<VIP<int>> vip = new List<VIP<int>>();
        //Буферная переменная для сохранения данных
        string json;

        public MainWindow()
        {
            InitializeComponent();
            //Создать файл, если его нет
            if (File.Exists("_base.json") == false) { File.Create("_base.json"); }
            //Чтение данный из файла
            json = File.ReadAllText("_base.json");
            //Чтение формирование списка клиентов из файла, если файл не пустой
            if (json.Length != 0)
            {
                client = JsonConvert.DeserializeObject<List<Client<int>>>(json);
                //Метод формирования клиентов по типам
                ClientsTypeAdd();
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод формирования клиентов по типам
        /// </summary>
        private void ClientsTypeAdd()
        {
            //Очистка списков клиентов с целью избежать повтора данных
            individual.Clear();
            entity.Clear();
            vip.Clear();
            //Формирования клиентов по типам
            for (int item = 0; item <= client.Count - 1; item++)
            {
                switch (client[item].Type)
                {
                    case "Физическое лицо":
                        individual.Add(new Individual<int>(individual.Count + 1, "Физическое лицо", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].TypeAccount, client[item].StatusAccount));
                        break;
                    case "Юридическое лицо":
                        entity.Add(new Entity<int>(individual.Count + 1, "Юридическое лицо", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].TypeAccount, client[item].StatusAccount));
                        break;
                    case "VIP":
                        vip.Add(new VIP<int>(individual.Count + 1, "VIP", client[item].Surname, client[item].Name, client[item].Patronymic,
                                                           client[item].NumAccount, client[item].SumAccount, client[item].TypeAccount, client[item].StatusAccount));
                        break;
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        private void SaveData()
        {
            clientList.Items.Refresh();
            json = JsonConvert.SerializeObject(client);
            File.WriteAllText("_base.json", json);
        }

        /// <summary>
        /// Метод сброса данных
        /// </summary>
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

        /// <summary>
        /// Метод закрытия счёта
        /// </summary>
        /// <param name="numAccount">Номер счета</param>
        private void CloseAccount(string numAccount)
        {
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numAccount)
                {
                    //Закрыть счет только в случае когда баланс равен 0
                    if (client[item].SumAccount == 0)
                    {
                        client[item].StatusAccount = "Закрыт";
                    }
                    else { MessageBox.Show("Закрытие счёта не доступно. Есть средства на счёте", "Внимание!"); }
                }

            }
        }

        /// <summary>
        /// Вывод данных клиента в поля TextBox
        /// </summary>
        /// <param name="surname">Фамилия клиента</param>
        /// <param name="name">Имя клиента</param>
        /// <param name="patronymic">Отчество клиента</param>
        /// <param name="numAccount">Номер счёта клиента</param>
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

        /// <summary>
        /// Метод пополнения счёта
        /// </summary>
        /// <param name="numAccount">Номер счёта клиента</param>
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

        /// <summary>
        /// Полнение счёта на который переводятся средства
        /// Физическое лицо может переводить только физическому лицу
        /// Юридическое лицо может переводить физическому лицу и юридическому лицу
        /// VIP может переводить всем
        /// </summary>
        /// <param name="numOutAccount">Номер счёта с которого переводятся средства</param>
        /// <param name="numAccount">Номер счета на который переводятся средства</param>
        /// <param name="type">Тип клиента</param>
        private void SumTransferAccount(string numOutAccount, string numAccount, int type)
        {
            //Буферная переменная баланса счёта
            int sumAccount = 0;
            string typeAccount = String.Empty;
            //Задание переменной баланса счёта с которого переводятся средства
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numOutAccount)
                {
                    sumAccount = client[item].SumAccount;
                    typeAccount = client[item].TypeAccount;
                }
            }
            //Перевод средств на заданный счёт с проверкой о возможности перевода по типам клиента и счёта, наличии средств и открытого счёта
            for (int item = 0; item <= client.Count - 1; item++)
            {
                if (client[item].NumAccount == numAccount)
                {
                    switch (type)
                    {
                        case 0:
                            if (client[item].Type == "Физическое лицо" && Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт" && typeAccount == "Не депозитный счёт")
                            {
                                SubtractionSumTransfer(numOutAccount);
                                client[item].SumAccount += Convert.ToInt32(TxtBxSumTransfer.Text);
                            }
                            else { MessageBox.Show("Данный перевод недоступен", "Внимание!"); }
                            break;
                        case 1:
                            if (client[item].Type != "VIP" && Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт" && typeAccount == "Не депозитный счёт")
                            {
                                SubtractionSumTransfer(numOutAccount);
                                client[item].SumAccount += Convert.ToInt32(TxtBxSumTransfer.Text);
                            }
                            else { MessageBox.Show("Данная перевод недоступен", "Внимание!"); }
                            break;
                        case 2:
                            if (Convert.ToInt32(TxtBxSumTransfer.Text) <= sumAccount && client[item].StatusAccount == "Открыт" && typeAccount == "Не депозитный счёт")
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

        /// <summary>
        /// Вычитание средств со счёта с которого переводятся средства
        /// </summary>
        /// <param name="numOutAccount"></param>
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
        #endregion

        #region Обработчики событий
        /// <summary>
        /// Метод открытия счета (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenAction(object sender, RoutedEventArgs e)
        {
            //Проверка заполненных данных
            if (ClientType.SelectedIndex == -1) { MessageBox.Show("Выберите тип клиента", "Ошибка данных"); }
            else if (CbxTypeAccount.SelectedIndex == -1) { MessageBox.Show("Выберите тип счёта", "Ошибка данных"); }
            else
            {
                //Проверка заполненных данных
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
                        CbxTypeAccount.Text,
                        "Открыт"));
                    ClearData();
                    ClientsTypeAdd();
                    SaveData();
                }
            }
        }

        /// <summary>
        /// Метод закрытия счета (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseAccountAction(object sender, RoutedEventArgs e)
        {
            //Обработка в зависимости от типа клиента
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

        /// <summary>
        /// Метод типа клиента (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод выделения конретного клиента (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод пополнения счёта (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод перевода средств со счёта на счёт (обработчик события)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion 
    }
}
