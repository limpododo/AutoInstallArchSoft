namespace AutoInstallArchSoft.Models;

public class SoftPath
{
    public SoftPath(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    public string Path { get; set; }
}