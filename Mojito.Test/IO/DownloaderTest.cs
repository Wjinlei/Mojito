namespace Mojito.Test.IO;

public class DownloaderTest
{
    [Test]
    public void TestSinglethreadedDownload()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl, "VirtualBox-6.1.14-140239-Win.zip");
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestMultithreadDownloader()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl, "VirtualBox-6.1.14-140239-Win.zip", 8);
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }
}
