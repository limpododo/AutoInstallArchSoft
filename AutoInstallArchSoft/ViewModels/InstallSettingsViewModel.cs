using System.Collections.ObjectModel;
using System.Windows;
using AutoInstallArchSoft.Models;
using DevExpress.Mvvm;

namespace AutoInstallArchSoft.ViewModels;

public class InstallSettingsViewModel : ViewModelBase
{
    private AutoInstallAlgorithm _installAlgorithm;
    private AutoCrackAlgorithm _crackAlgorithm;

    public InstallSettingsViewModel(AutoInstallAlgorithm installAlgorithm, AutoCrackAlgorithm crackAlgorithm)
    {
        _installAlgorithm = installAlgorithm;
        _crackAlgorithm = crackAlgorithm;

        SoftPathes = new ObservableCollection<SoftPathViewModel>()
        {
            new SoftPathViewModel(new SoftPath("AutoCad")),
            new SoftPathViewModel(new SoftPath("ArchiCad")),
            new SoftPathViewModel(new SoftPath("Corona")),
            new SoftPathViewModel(new SoftPath("Lumion")),
            new SoftPathViewModel(new SoftPath("Photoshop")),
            new SoftPathViewModel(new SoftPath("Revit")),
            new SoftPathViewModel(new SoftPath("SketchUp")),
            new SoftPathViewModel(new SoftPath("3dsMax"))
        };
    }

    public ObservableCollection<SoftPathViewModel> SoftPathes
    {
        get => GetProperty(() => SoftPathes);
        set => SetProperty(() => SoftPathes, value);
    }

    public Visibility IsVisible
    {
        get => GetProperty(() => IsVisible);
        set => SetProperty(() => IsVisible, value);
    }
}