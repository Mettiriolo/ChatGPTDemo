using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTDemo.MVVM.Models
{
    [INotifyPropertyChanged]
    public partial class Message
    {
        [ObservableProperty]
        private string user="Me";
        [ObservableProperty]
        private string text;

        public Message()
        {
            
        }
        public Message(string text)
        {
            Text = text;
            User = "Me";
        }
        public Message(string text,string user)
        {
            Text = text;
            User = user;
        }

    }
}
