namespace Mojito.Test.IO;

public class DownloaderTest
{
    [Test]
    public void TestSinglethreadedDownload()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IOUtil.Downloader(downloadUrl, "VirtualBox-6.1.14-140239-Win.zip");
        downloader.StartDownload(true);
    }

    [Test]
    public void TestMultithreadDownloader()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IOUtil.Downloader(downloadUrl, "VirtualBox-6.1.14-140239-Win.zip", 8);
        downloader.StartDownload(true);
    }
}
