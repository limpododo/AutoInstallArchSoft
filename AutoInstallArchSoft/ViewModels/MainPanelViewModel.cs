using System.Windows;
using AutoInstallArchSoft.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace AutoInstallArchSoft.ViewModels;

public class MainPanelViewModel : ViewModelBase
{
    private AutoInstallAlgorithm _installAlgorithm;
    private AutoCrackAlgorithm _crackAlgorithm;

    public MainPanelViewModel(AutoInstallAlgorithm installAlgorithm, AutoCrackAlgorithm crackAlgorithm)
    {
        _installAlgorithm = installAlgorithm;
        _crackAlgorithm = crackAlgorithm;
    }

    public Visibility IsVisible
    {
        get => GetProperty(() => IsVisible);
        set => SetProperty(() => IsVisible, value);
    }

    #region StartInstallCommand
    [Command]
    public void StartInstall()
    {
        //_installAlgorithm.Start();
    }
    #endregion

    #region StartCrackCommand
    [Command]
    public void StartCrack()
    {
       //_crackAlgorithm.Start();
    }
    #endregion
}