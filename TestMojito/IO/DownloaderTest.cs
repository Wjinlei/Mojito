namespace TestMojito.IO;

public class DownloaderTest
{
    [Test]
    public void TestSinglethreadedDownload1()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl);
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestSinglethreadedDownload2()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl, "VirtualBox.zip");
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestMultithreadDownloader1()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl, 8);
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }

    [Test]
    public void TestMultithreadDownloader2()
    {
        const string downloadUrl = "http://softdown.huweishen.com/5/VirtualBox-6.1.14-140239-Win.zip";
        var downloader = new Mojito.IO.Downloader(downloadUrl, "VirtualBox.zip", 8);
        var result = downloader.StartDownload(true);
        if (!result.Success)
            TestContext.Out.WriteLine(result.Message);
        Assert.That(result.Success, Is.True);
    }
}
