namespace ChatGPTDemo.MVVM.View;

public partial class MainView : ContentPage
{
	public static  MainView Instance { get; set; }
	public MainView()
	{
		Instance = this;
		InitializeComponent();
	}

	public void CloseIndicator()
	{ 
		this.activityIndicator.IsVisible = false;
	}
    public void OpenIndicator()
    {
        this.activityIndicator.IsVisible = true;
    }
}

