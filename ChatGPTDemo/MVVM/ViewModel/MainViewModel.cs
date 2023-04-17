using ChatGPTDemo.MVVM.Model.OpenAI;
using ChatGPTDemo.MVVM.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Message = ChatGPTDemo.MVVM.Models.Message;

namespace ChatGPTDemo.MVVM.ViewModel
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        [ObservableProperty]
        private Message message;

        [ObservableProperty]
        private ObservableCollection<Message> history;

        private readonly HttpClient _httpClient= new();

        public MainViewModel()
        {
            Message = new Message();
            History = new ObservableCollection<Message>();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Constants.ApiKey}");
        }

        [RelayCommand]
        public async Task Send()
        {
            if (!string.IsNullOrWhiteSpace(Message.Text))
            {
                History.Add(new Message(Message.Text));
                MainView.Instance.OpenIndicator();
                StringContent content = new(
                    "{\r\n  \"model\": \"gpt-3.5-turbo\",\r\n  \"messages\": [{\"role\": \"user\", \"content\": \"" + Message.Text + "\"}]\r\n}\r\n"
                    , Encoding.UTF8
                    , "application/json");
                Message.Text = string.Empty;
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsync(Constants.ApiUri, content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    Root responseData = JsonSerializer.Deserialize<Root>(responseString);
                    History.Add(new Message(responseData!.Choices.First().Message.Content, "AI"));
                    MainView.Instance.CloseIndicator();

                }
                catch (Exception ex)
                {
                    MainView.Instance.CloseIndicator();
                    Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message} ");
                }
            }
            else
            {
                Console.WriteLine("---> You need to provide some input ");
            }
        }
    }
}
