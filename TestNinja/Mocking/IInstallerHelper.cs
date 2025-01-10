namespace TestNinja.Mocking
{
    public interface IInstallerHelper
    {
        //creating interfaces for the external dependencies
        bool DownloadInstaller(string customerName, string installerName);
    }
}