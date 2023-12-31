using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using AutoInstallArchSoft.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoInstallArchSoft.ViewModels;

public class MainWindowViewModel : ObservableRecipient
{
    private Visibility mainPageIsVisible;
    private Visibility settingPageIsVisible;
    
    private Visibility keyIsInput;
    private string key;
    private KeyStatus keyStatus;

    public MainWindowViewModel()
    {
        SelectPage(1);
        KeyIsInput = Visibility.Hidden;

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
    
    public Visibility KeyIsInput
    {
        get => keyIsInput;
        set => SetProperty(ref keyIsInput, value);
    }

    public KeyStatus KeyStatus
    {
        get => keyStatus;
        set => SetProperty(ref keyStatus, value);
    }
    public string Key
    {
        get => key;
        set
        {
            KeyIsInput = value.Length > 0 ? Visibility.Visible : Visibility.Hidden;
            KeyStatus = value.Equals("123") ? KeyStatus.True : KeyStatus.False;
                
            SetProperty(ref key, value);
        }
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