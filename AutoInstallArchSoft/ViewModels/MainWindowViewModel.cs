using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using AutoInstallArchSoft.Enums;
using AutoInstallArchSoft.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoInstallArchSoft.ViewModels;

public class MainWindowViewModel : ObservableRecipient
{
    private Visibility _mainPageIsVisible;
    private Visibility _settingPageIsVisible;
    
    private Visibility _keyIsInput;
    private string _key = String.Empty;
    private string _oneFolderPath = String.Empty;
    private KeyStatus _keyStatus;

    private Visibility _oneFolderIsVisible;
    private Visibility _manyFoldersIsVisible;
    private bool _isOneFolderLocation;

    private AutoInstallAlgorithm _installAlgorithm;

    public MainWindowViewModel()
    {
        _installAlgorithm = new AutoInstallAlgorithm();
        _installAlgorithm.PathToArchiveFolder = "/Binary";
        
        SelectPage(1);
        IsOneFolderLocation = true;
        KeyIsInput = Visibility.Hidden;

        GoToSettingPageCommand = new RelayCommand(GoToSettingPage);
        GoToMainPageCommand = new RelayCommand(GoToMainPage);
        GoToTelegramCommand = new RelayCommand(GoToTelegram);
    }
    public Visibility MainPageIsVisible
    {
        get => _mainPageIsVisible;
        set => SetProperty(ref _mainPageIsVisible, value);
    }
    public Visibility SettingPageIsVisible
    {
        get => _settingPageIsVisible;
        set => SetProperty(ref _settingPageIsVisible, value);
    }
    
    public Visibility KeyIsInput
    {
        get => _keyIsInput;
        set => SetProperty(ref _keyIsInput, value);
    }

    public KeyStatus KeyStatus
    {
        get => _keyStatus;
        set => SetProperty(ref _keyStatus, value);
    }
    public string Key
    {
        get => _key;
        set
        {
            KeyIsInput = value.Length > 0 ? Visibility.Visible : Visibility.Hidden;
            KeyStatus = value.Equals("123-456-789") ? KeyStatus.True : KeyStatus.False;
                
            SetProperty(ref _key, value);
        }
    }

    public bool IsOneFolderLocation
    {
        get => _isOneFolderLocation;
        set
        {
            SelectInstallLocation(value ? 0 : 1);
            
            SetProperty(ref _isOneFolderLocation, value);
        }
    }  
    public string OneFolderPath
    {
        get => _oneFolderPath;
        set
        {
            _installAlgorithm.PathsToTargetFolders.Add(value);
            SetProperty(ref _oneFolderPath, value);
        }
    }
    
    public Visibility OneFolderIsVisible
    {
        get => _oneFolderIsVisible;
        set => SetProperty(ref _oneFolderIsVisible, value);
    }
    
    public Visibility ManyFoldersIsVisible
    {
        get => _manyFoldersIsVisible;
        set => SetProperty(ref _manyFoldersIsVisible, value);
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

    private void SelectInstallLocation(int indexLocation)
    {
        switch (indexLocation)
        {
            case 0:
                OneFolderIsVisible = Visibility.Visible;
                ManyFoldersIsVisible = Visibility.Hidden;
                break;
            case 1:
                OneFolderIsVisible = Visibility.Hidden;
                ManyFoldersIsVisible = Visibility.Visible;
                break;
        }
    }
}