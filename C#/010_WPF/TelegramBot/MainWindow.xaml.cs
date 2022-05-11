using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace TelegramBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 
        ObservableCollection<TelegramUser> Users;
        TelegramBotClient bot;

        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<TelegramUser>();
            userList.ItemsSource = Users;
            string token = File.ReadAllText(@"G:\_SKILLBOX\token.txt");
            bot = new TelegramBotClient(token);
            //проверка наличия директорий
            if (Directory.Exists("AUDIO") == false) Directory.CreateDirectory("AUDIO");
            if (Directory.Exists("DOC") == false) Directory.CreateDirectory("DOC");
            if (Directory.Exists("PHOTO") == false) Directory.CreateDirectory("PHOTO");
            //Обработка сообщений
            bot.OnMessage += delegate (object sender, MessageEventArgs e)
            {
                string msg = $"{DateTime.Now:g}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
                string json = JsonConvert.SerializeObject($"{msg}\n");
                File.AppendAllText("data.json", json);
                this.Dispatcher.Invoke(() =>
                {
                    var person = new TelegramUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                    if (!Users.Contains(person)) Users.Add(person);
                    switch (e.Message.Type)
                    {
                        //обработка файлов
                        case (Telegram.Bot.Types.Enums.MessageType.Document):
                            {
                                //Console.WriteLine(e.Message.Caption);
                                //Загрузка документов
                                DownLoad("DOC/", e.Message.Document.FileId, e.Message.Document.FileName, e.Message.Chat.FirstName, e.Message.Chat.Id);
                                break;
                            }
                        case (Telegram.Bot.Types.Enums.MessageType.Audio):
                            {
                                //Загрузка аудио
                                DownLoad("AUDIO/", e.Message.Audio.FileId, e.Message.Audio.FileName, e.Message.Chat.FirstName, e.Message.Chat.Id);
                                break;
                            }
                        case (Telegram.Bot.Types.Enums.MessageType.Photo):
                            {
                                //Загрузка изображений
                                DownLoad("PHOTO/", e.Message.Photo[e.Message.Photo.Length - 1].FileId, $"{e.Message.Photo[e.Message.Photo.Length - 1].FileUniqueId}.png", e.Message.Chat.FirstName, e.Message.Chat.Id);
                                break;
                            }
                        default:
                            {
                                //обработка команд
                                string st = string.Empty;
                                string txt = string.Empty;
                                switch (e.Message.Text.ToLower())
                                {
                                    case ("/start"):
                                        {
                                            //Команда старт
                                            txt = $"Здравствуйте, {e.Message.Chat.FirstName}\n" +
                                            "Команды бота:\n" +
                                            "/file - Просмотр файлов загруженных в телеграмм\n" +
                                            "/download - Для загрузки файла введимя имя файла с расширением";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                            break;
                                        }
                                    case ("/file"):
                                        {
                                            //Команда просмотра файлов
                                            txt = $"/photo - фото, изображения\n" +
                                            "/audio - аудиофайлы\n" +
                                            "/doc - документы\n";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                            break;
                                        }
                                    case ("/download"):
                                        {
                                            //Команда загрузки
                                            txt = $"Введите имя файла с расширением:";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                            break;
                                        }
                                    case ("/audio"):
                                        {
                                            //Просмотр загруженных аудио
                                            st = FileDir("AUDIO");
                                            txt = $"Для загрузки файла введите имя файла с расширением:\n{st}";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                            break;
                                        }
                                   case ("/doc"):
                                        {
                                            //Просмотр загруженных документов
                                            st = FileDir("DOC");
                                            txt = $"Для загрузки файла введите имя файла с расширением:\n{st}";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                        break;
                                        }
                                   case ("/photo"):
                                        {
                                            //Просмотр загруженных изображений
                                            st = FileDir("PHOTO");
                                            txt = $"Для загрузки файла введите имя файла с расширением:\n{st}";
                                            Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                            SendMsg(e.Message.Chat.FirstName, e.Message.Chat.Id, txt);
                                            break;
                                        }
                                   default:
                                       //отправка файлов пользователю
                                       if (File.Exists($"AUDIO/{e.Message.Text}"))
                                       {
                                           //Скачивание аудио
                                           SendFls(e.Message.Text, "AUDIO/", e.Message.Chat.FirstName, e.Message.Chat.Id);
                                       }
                                       else if (File.Exists($"DOC/{e.Message.Text}"))
                                       {
                                           //Скачивание документов
                                           SendFls(e.Message.Text, "DOC/", e.Message.Chat.FirstName, e.Message.Chat.Id);
                                       }
                                       else if (File.Exists($"PHOTO/{e.Message.Text}"))
                                       {
                                           //Скачивание изображений
                                           SendFls(e.Message.Text, "PHOTO/", e.Message.Chat.FirstName, e.Message.Chat.Id);
                                       }
                                       else
                                       {
                                           //Обычный текст
                                           Users[Users.IndexOf(person)].AddMessage($"{person.Nick}: {e.Message.Text}");
                                       }
                                       break;
                                 }
                            break;
                        }
                    }
                });
            };
            bot.StartReceiving();
            btnSendMsg.Click += delegate { SendMsg(); };
            txtBxSendMsg.KeyDown += (s, e) => { if (e.Key == Key.Return) { SendMsg(); } };
        }

        /// <summary>
        /// Отправка сообщений техподдержкой
        /// </summary>
        public void SendMsg()
        {
            var concreteUser = Users[Users.IndexOf(userList.SelectedItem as TelegramUser)];
            string responseMsg = $"Support: {txtBxSendMsg.Text}";
            concreteUser.Messages.Add(responseMsg);

            bot.SendTextMessageAsync(concreteUser.Id, txtBxSendMsg.Text);
            string logText = $"{DateTime.Now:g}: >> {concreteUser.Nick} {concreteUser.Id} {responseMsg}\n";
            string json = JsonConvert.SerializeObject(logText);
            File.AppendAllText("data.json", json);
            txtBxSendMsg.Text = string.Empty;
        }

        /// <summary>
        /// Отправка сообщений ботом
        /// </summary>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="chatId">Id чата с пользователем</param>
        /// <param name="txt">Текс сообщения</param>
        public void SendMsg(string firstName, long chatId, string txt)
        {
            string responseMsg = $"Bot: {txt}";
            foreach (var concreteUser in Users)
            {
                if (concreteUser.Id == chatId)
                {
                    concreteUser.Messages.Add(responseMsg);
                } 
            }
            bot.SendTextMessageAsync(chatId, txt);
            string logText = $"{DateTime.Now:g}: >> {firstName} {chatId} {responseMsg}\n";
            string json = JsonConvert.SerializeObject(logText);
            File.AppendAllText("data.json", json);
        }

        /// <summary>
        /// Метод формирования списка загруженных файлов
        /// </summary>
        /// <param name="type">Тип директории</param>
        /// <returns></returns>
        public string FileDir(string type)
        {
            DirectoryInfo dir = new DirectoryInfo($@"{type}");
            string st = string.Empty;
            foreach (var s in dir.GetFiles())
            {
                st += $"{s.Name}\n";
            }
            return st;
        }

        /// <summary>
        /// Метод скачивания файлов
        /// </summary>
        /// <param name="file">Имя файлов</param>
        /// <param name="dir">Директория файла</param>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="chatId">Id чата с пользователем</param>
        public async void SendFls(string file, string dir, string firstName, long chatId)
        {
            using (FileStream fs = new FileStream($"{dir}{file}", FileMode.Open))
            {
                InputOnlineFile iof = new InputOnlineFile(fs, Path.GetFileName($"{dir}{file}"));
                string responseMsg = $"BotFile: {dir}{file}";
                foreach (var concreteUser in Users)
                {
                    if (concreteUser.Id == chatId)
                    {
                        concreteUser.Messages.Add(responseMsg);
                    }
                }
                await bot.SendDocumentAsync(chatId, iof);
                string logText = $"{DateTime.Now:g}: >> {firstName} {chatId} {responseMsg}\n";
                string json = JsonConvert.SerializeObject(logText);
                File.AppendAllText("data.json", json);
                fs.Close();
                fs.Dispose();
            }
        }

        /// <summary>
        /// Метод загрузки файлов пользователем
        /// </summary>
        /// <param name="dir">Директоия</param>
        /// <param name="fileId">Id файла</param>
        /// <param name="path">Имя файла</param>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="chatId">Id чата с пользователем</param>
        public async void DownLoad(string dir, string fileId, string path, string firstName, long chatId)
        {
            var file = await bot.GetFileAsync(fileId);
            string responseMsg = $"{firstName} File: {dir}{path}";
            FileStream fs = new FileStream(dir + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            foreach (var concreteUser in Users)
            {
                if (concreteUser.Id == chatId)
                {
                    concreteUser.Messages.Add(responseMsg);
                }
            }
            fs.Close();
            fs.Dispose();
        }
    }
}