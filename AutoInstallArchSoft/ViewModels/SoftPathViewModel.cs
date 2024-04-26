using AutoInstallArchSoft.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Microsoft.Win32;

namespace AutoInstallArchSoft.ViewModels;

public class SoftPathViewModel : ViewModelBase
{
    private SoftPath _softPath;

    public SoftPathViewModel(SoftPath softPath)
    {
        _softPath = softPath;
    }

    public string SoftName
    {
        set => _softPath.Name = value;
        get => _softPath.Name;
    }

    public string Path
    {
        set => _softPath.Path = value;
        get => _softPath.Path;
    }

    #region SelectPathCommand
    [Command]
    public void SelectPath()
    {
        var openFolderDialog = new OpenFolderDialog();
        if (openFolderDialog.ShowDialog() is true)
        {
            _softPath.Path = openFolderDialog.FolderName;
            RaisePropertyChanged(() => Path);
        }
            
    }
    #endregion
    
}