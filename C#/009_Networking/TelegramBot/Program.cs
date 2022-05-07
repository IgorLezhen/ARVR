using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;


namespace TelegramBot
{
    internal class Program
    {
        static TelegramBotClient bot;
        static void Main(string[] args)
        {
            // http://t.me/BotFather
            // @BotFather
            // https://core.telegram.org/bots/api
            // string token =  "4159465546AAEG3gCROdn7xLKAEpsTeRucVnMBEm12WcT";
            // https://telegram.org/
            // https://core.telegram.org/api
            // https://core.telegram.org/bots
            // https://core.telegram.org/bots/samples How do I create a bot?
            // https://core.telegram.org/bots/api How do bots work?

            string token = File.ReadAllText(@"G:\_SKILLBOX\token.txt");
            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            //Console.WriteLine($"{text} TypeMessage: {e.Message.Type}");
            switch (e.Message.Type)
            {
                //обработка файлов
                case (Telegram.Bot.Types.Enums.MessageType.Document):
                    {
                        //Console.WriteLine(e.Message.Caption);
                        //Загрузка документов
                        DownLoad("DOC/", e.Message.Document.FileId, e.Message.Document.FileName);
                        break;
                    }
                case (Telegram.Bot.Types.Enums.MessageType.Audio):
                    {
                        //Загрузка аудио
                        DownLoad("AUDIO/", e.Message.Audio.FileId, e.Message.Audio.FileName);
                        break;
                    }
                case (Telegram.Bot.Types.Enums.MessageType.Photo):
                    {
                        //Загрузка изображений
                        DownLoad("PHOTO/", e.Message.Photo[e.Message.Photo.Length - 1].FileId, $"{e.Message.Photo[e.Message.Photo.Length - 1].FileUniqueId}.png");
                        break;
                    }
                default:
                    {
                        //обработка команд
                        string st = string.Empty;
                        switch (e.Message.Text.ToLower())
                        {
                            case ("/start"):
                                {
                                    //Команда старт
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                    $"Здравствуйте, {e.Message.Chat.FirstName}\n" +
                                    "Команды бота:\n" +
                                    "/file - Просмотр файлов загруженных в телеграмм\n" +
                                    "/download - Для загрузки файла введимя имя файла с расширением");
                                    break;
                                }
                            case ("/file"):
                                {
                                    //Команда просмотра файлов
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                    $"/photo - фото, изображения\n" +
                                    "/audio - аудиофайлы\n" +
                                    "/doc - документы\n");
                                    break;
                                }
                            case ("/download"):
                                {
                                    //Команда загрузки
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                    $"Введите имя файла с расширением:");
                                    Console.WriteLine(e.Message.MessageId);
                                    break;
                                }
                            case ("/photo"):
                                {
                                    //Просмотр загруженных изображений
                                    st = FileDir("PHOTO");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                        $"Для загрузки файла введите имя файла с расширением:\n{st}");
                                    break;
                                }
                            case ("/audio"):
                                {
                                    //Просмотр загруженных аудио
                                    st = FileDir("AUDIO");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                        $"Для загрузки файла введите имя файла с расширением:\n{st}");
                                    break;
                                }
                            case ("/doc"):
                                {
                                    //Просмотр загруженных документов
                                    st = FileDir("DOC");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                                         $"Для загрузки файла введите имя файла с расширением:\n{st}");
                                    break;
                                }
                            default:
                                //отправка файлов пользователю
                                if (File.Exists($"AUDIO/{e.Message.Text}"))
                                {
                                    //Скачивание аудио
                                    Send(e.Message.Text, "AUDIO/", e.Message.Chat.Id);
                                }
                                else if (File.Exists($"DOC/{e.Message.Text}"))
                                {
                                    //Скачивание документов
                                    Send(e.Message.Text, "DOC/", e.Message.Chat.Id);
                                }
                                else if (File.Exists($"PHOTO/{e.Message.Text}"))
                                {
                                    //Скачивание изображений
                                    Send(e.Message.Text, "PHOTO/", e.Message.Chat.Id);
                                }
                                else {break;}
                                break;
                        }
                        break;
                    }
            }    
            /*var messageText = e.Message.Text;
            bot.SendTextMessageAsync(e.Message.Chat.Id,
                $"{messageText}"
                );*/
        }
        /// <summary>
        /// Метод формирования списка загруженных файлов
        /// </summary>
        /// <param name="type">Тип директории</param>
        /// <returns></returns>
        static string FileDir(string type)
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
        /// Метод загрузки файлов пользователем
        /// </summary>
        /// <param name="dir">Директоия</param>
        /// <param name="fileId">Id файла</param>
        /// <param name="path">Имя файла</param>
        static async void DownLoad(string dir, string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(dir + path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();
            fs.Dispose();
        }
        /// <summary>
        /// Метод скачивания файлов
        /// </summary>
        /// <param name="file">Имя файлов</param>
        /// <param name="dir">Директория файла</param>
        /// <param name="chatId">Id чата с пользователем</param>
        static async void Send(string file, string dir, long chatId)
        {
            using (FileStream fs = new FileStream($"{dir}{file}", FileMode.Open))
            {
                InputOnlineFile iof = new InputOnlineFile(fs, Path.GetFileName($"{dir}{file}"));
                await bot.SendDocumentAsync(chatId, iof);
                fs.Close();
                fs.Dispose();
            }
        }


    }
}
