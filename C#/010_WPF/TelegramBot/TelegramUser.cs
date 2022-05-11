using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;


namespace TelegramBot
{
    public class TelegramUser : INotifyPropertyChanged, IEquatable<TelegramUser>
    {
        
        public TelegramUser(string NickName, long ChatId)
        {
            this.nick = NickName;
            this.id = ChatId;
            Messages = new ObservableCollection<string>();
        }

        private string nick;
        public string Nick
        {
            get { return this.nick; }
            set 
            { 
                this.nick = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Nick)));
            }
        }

        private long id;
        public long Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals(TelegramUser other) => other.Id == this.id;

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text) => Messages.Add(Text);

    }
}
