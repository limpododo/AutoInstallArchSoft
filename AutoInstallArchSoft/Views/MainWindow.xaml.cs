using System.Windows;


namespace AutoInstallArchSoft;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Close(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}