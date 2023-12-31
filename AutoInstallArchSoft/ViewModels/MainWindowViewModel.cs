using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoInstallArchSoft.ViewModels;

public class MainWindowViewModel : ObservableRecipient
{
    private Visibility mainPageIsVisible;
    private Visibility settingPageIsVisible;

    public MainWindowViewModel()
    {
        MainPageIsVisible = Visibility.Visible;
        SettingPageIsVisible = Visibility.Hidden;

        GoToSettingPageCommand = new RelayCommand(GoToSettingPage);
        GoToMainPageCommand = new RelayCommand(GoToMainPage);
        GoToTelegramCommand = new RelayCommand(GoToTelegram);
    }
    public Visibility MainPageIsVisible
    {
        get => mainPageIsVisible;
        set => SetProperty(ref mainPageIsVisible, value);
    }
    public Visibility SettingPageIsVisible
    {
        get => settingPageIsVisible;
        set => SetProperty(ref settingPageIsVisible, value);
    }
    
    public ICommand GoToSettingPageCommand { get; }
    private void GoToSettingPage() => SelectPage(1);
    
    public ICommand GoToMainPageCommand { get; }
    private void GoToMainPage() => SelectPage(0);

    
    public ICommand GoToTelegramCommand { get; }
    private void GoToTelegram()
    {
        Process.Start(new ProcessStartInfo("https://t.me/ArchSoft_bot") { UseShellExecute = true });
    }
    private void SelectPage(int indexPage)
    {
        switch (indexPage)
        {
            case 0:
                MainPageIsVisible = Visibility.Visible;
                SettingPageIsVisible = Visibility.Hidden;
                break;
            case 1:
                MainPageIsVisible = Visibility.Hidden;
                SettingPageIsVisible = Visibility.Visible;
                break;
        }
    }
}