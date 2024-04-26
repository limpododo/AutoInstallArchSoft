using System.Diagnostics;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using AutoInstallArchSoft.Models;

namespace AutoInstallArchSoft.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly string TELEGRAMBOTLINK = Application.Current.Resources["TgBotLink"].ToString();
    
    private AutoInstallAlgorithm _installAlgorithm;
    private AutoCrackAlgorithm _crackAlgorithm;

    public MainWindowViewModel()
    {   
        _installAlgorithm = new AutoInstallAlgorithm();
        _crackAlgorithm = new AutoCrackAlgorithm();
        
        MainPanelViewModel = new MainPanelViewModel(_installAlgorithm, _crackAlgorithm);
        InstallSettingsViewModel = new InstallSettingsViewModel(_installAlgorithm, _crackAlgorithm);
        
        MainPanelViewModel.IsVisible = Visibility.Visible;
        InstallSettingsViewModel.IsVisible = Visibility.Collapsed;
        
        InstallSettingsButtonText = Application.Current.Resources["InstallSettingsButtonText1"].ToString();
    }

    public MainPanelViewModel MainPanelViewModel
    {
        get => GetProperty(() => MainPanelViewModel);
        set => SetProperty(() => MainPanelViewModel, value);
    }
    public InstallSettingsViewModel InstallSettingsViewModel 
    {
        get => GetProperty(() => InstallSettingsViewModel);
        set => SetProperty(() => InstallSettingsViewModel, value);
    }
    
    #region OpenInstallSettingCommand

    [Command]
    public void OpenInstallSetting()
    {
        if (InstallSettingsViewModel.IsVisible != Visibility.Visible)
        {
            MainPanelViewModel.IsVisible = Visibility.Collapsed;
            InstallSettingsViewModel.IsVisible = Visibility.Visible;

            InstallSettingsButtonText = Application.Current.Resources["InstallSettingsButtonText2"].ToString();
        }
        else
        {
            MainPanelViewModel.IsVisible = Visibility.Visible;
            InstallSettingsViewModel.IsVisible = Visibility.Collapsed;

            InstallSettingsButtonText = Application.Current.Resources["InstallSettingsButtonText1"].ToString();
        }
    }
    public string InstallSettingsButtonText
    {
        get => GetProperty(() => InstallSettingsButtonText);
        set => SetProperty(() => InstallSettingsButtonText, value);
    }
    
    public bool CanOpenInstallSetting => true;
    #endregion
    
    #region GoToTelegramCommand
    [Command]
    public void GoToTelegram()
    {
        try { Process.Start(new ProcessStartInfo(TELEGRAMBOTLINK) { UseShellExecute = true });}
        catch (Exception e) { /* ignore */ }
    }
    public bool CanGoToTelegram => false;
    #endregion
   
}