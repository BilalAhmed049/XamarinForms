using BotClientApp.Bot;
using BotClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BotClientApp
{
    public partial class MainPage : ContentPage
    {
        private BotConnector _botConnector;
        public ObservableCollection<BotMessage> ConversationList { get; }
        private bool _progressVisible;
        public bool ProgressVisible
        {
            get
            {
                return _progressVisible;
            }
            set
            {
                _progressVisible = value;
                OnPropertyChanged("ProgressVisible");
            }
        }
        public MainPage()
        {
            InitializeComponent();
            ConversationList = new ObservableCollection<BotMessage>();
            BindingContext = this;
            _botConnector = new BotConnector();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _botConnector.Setup();
        }

        public async void SendButtonClicked(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async Task SendMessage()
        {
            ProgressVisible = true;
            var botResponse = await _botConnector.SendMessage("Daniel", Message.Text);
            ProgressVisible = false;
            ConversationList.Add(botResponse);
        }
    }
}

