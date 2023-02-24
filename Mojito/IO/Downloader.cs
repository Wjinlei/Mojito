using System.Net.Http.Headers;

namespace Mojito.IO;

public class Downloader
{
    private readonly HttpClient HttpClient;
    public string Savepath { get; set; }
    public string Url { get; set; }
    public int ThreadCount { get; set; }

    /// <summary>
    /// Single-threaded file download, automatically gets the file name portion of the URL as the file name to save
    /// </summary>
    /// <param name="url">Download Url</param>
    public Downloader(string url)
    {
        Url = url;
        Savepath = Path.GetFileName(url);
        ThreadCount = 1;
        HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    /// <summary>
    /// Single-threaded file download, and custom save file name
    /// </summary>
    /// <param name="url">Download Url</param>
    public Downloader(string url, string savePath)
    {
        Url = url;
        Savepath = savePath;
        ThreadCount = 1;
        HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    /// <summary>
    /// Multithreaded file download, automatically get URL file name portion saved as file name
    /// </summary>
    /// <param name="url">Download Url</param>
    /// <param name="threadCount">Thread Count</param>
    public Downloader(string url, int threadCount)
    {
        Url = url;
        Savepath = Path.GetFileName(url);
        ThreadCount = threadCount;
        HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    /// <summary>
    /// Multithreaded file download, and custom save file name
    /// </summary>
    /// <param name="url">Download Url</param>
    /// <param name="savePath">Save Path</param>
    /// <param name="threadCount">Thread Count</param>
    public Downloader(string url, string savePath, int threadCount)
    {
        Url = url;
        Savepath = savePath;
        ThreadCount = threadCount;
        HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    /// <summary>
    /// Start download
    /// </summary>
    /// <param name="overwrite">If the file already exists, whether to overwrite it</param>
    /// <returns></returns>
    public Result StartDownload(bool overwrite)
    {
        try
        {
            var response = HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, Url)).Result;
            if (!response.IsSuccessStatusCode)
                return Result.Error(new HttpRequestException("Get file size failed."));
            if (response.Content.Headers.ContentLength is null)
                return Result.Error(new NullReferenceException("ContentLength is null"));

            // Total file size
            var fileSize = response.Content.Headers.ContentLength.Value;
            // Calculate the average block size
            var blockSize = fileSize / ThreadCount;

            // Create the same size file to occupy the location
            var fileMode = overwrite ? FileMode.Create : FileMode.CreateNew;
            using (var fs = new FileStream(Savepath, fileMode))
            {
                fs.SetLength(fileSize);
            }

            var tasksDownloadRange = new List<Task<Result>>();
            for (int i = 0; i < ThreadCount; i++)
            {
                // Calculate the segmentation download range
                var from = i * blockSize;
                var to = (i + 1) * blockSize - 1;
                if (i == ThreadCount - 1)
                    to = fileSize - 1;
                // Add task
                tasksDownloadRange.Add(DownloadRange(from, to));
            }

            // Wait for all tasks to finish and collect return values
            var results = Task.WhenAll(tasksDownloadRange);

            foreach (var result in results.Result)
            {
                if (!result.Success)
                    return result;
            }
            return Result.Ok;
        }
        catch (Exception ex)
        {
            return Result.Error(ex);
        }
    }

    /// <summary>
    /// Download the file part
    /// </summary>
    /// <param name="from">The position at which to start sending data.</param>
    /// <param name="to">The position at which to stop sending data.</param>
    /// <returns></returns>
    private Task<Result> DownloadRange(long from, long to)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            request.Headers.Range = new RangeHeaderValue(from, to);
            var response = HttpClient.Send(request);
            using (var fileStream = new FileStream(Savepath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                using var stream = response.Content.ReadAsStream();
                fileStream.Position = from;
                stream.CopyTo(fileStream);
            }
            return Task.FromResult(Result.Ok);
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Error(ex));
        }
    }
}

