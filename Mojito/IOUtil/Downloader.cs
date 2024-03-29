﻿using System.Net.Http.Headers;

namespace Mojito.IOUtil;

public class Downloader
{
    private readonly HttpClient httpClient;
    public int ThreadCount { get; set; }
    public string Url { get; set; }
    public string SavePath { get; set; }

    /// <summary>
    /// Single-threaded file download, and custom save file name
    /// </summary>
    /// <param name="url">Download Url</param>
    public Downloader(string url, string savePath)
    {
        Url = url;
        SavePath = savePath;
        ThreadCount = 1;
        httpClient = new HttpClient
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
        SavePath = savePath;
        ThreadCount = threadCount;
        httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    /// <summary>
    /// Multithreaded file download, custom save file name and timeout
    /// </summary>
    /// <param name="url">Download Url</param>
    /// <param name="savePath">Save Path</param>
    /// <param name="threadCount">Thread Count</param>
    /// <param name="timeout">Timeout</param>
    public Downloader(string url, string savePath, int threadCount, TimeSpan timeout)
    {
        Url = url;
        SavePath = savePath;
        ThreadCount = threadCount;
        httpClient = new HttpClient
        {
            Timeout = timeout
        };
    }

    /// <summary>
    /// Start download
    /// </summary>
    /// <param name="overwrite">If the file already exists, whether to overwrite it</param>
    /// <returns></returns>
    public void StartDownload(bool overwrite)
    {
        var response = httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, Url)).Result;
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException("Get file size failed.");
        if (response.Content.Headers.ContentLength is null)
            throw new NullReferenceException("ContentLength is null");

        // Total file size
        var fileSize = response.Content.Headers.ContentLength.Value;
        // Calculate the average block size
        var blockSize = fileSize / ThreadCount;

        // Create the same size file to occupy the location
        var fileMode = overwrite ? FileMode.Create : FileMode.CreateNew;
        using (var fs = new FileStream(SavePath, fileMode))
        {
            fs.SetLength(fileSize);
        }

        // Segmented download
        var tasksDownloadRange = new List<Task>();
        for (int i = 0; i < ThreadCount; i++)
        {
            // Calculate the segmentation download range
            var from = i * blockSize;
            var to = (i + 1) * blockSize - 1;
            if (i == ThreadCount - 1)
                to = fileSize - 1;

            tasksDownloadRange.Add(DownloadPart(from, to));
        }

        // Wait for all tasks to finish and collect return values
        Task.WhenAll(tasksDownloadRange);
    }

    /// <summary>
    /// Download the file part
    /// </summary>
    /// <param name="from">The position at which to start sending data.</param>
    /// <param name="to">The position at which to stop sending data.</param>
    /// <returns></returns>
    private Task DownloadPart(long from, long to)
    {
        // Get part
        var request = new HttpRequestMessage(HttpMethod.Get, Url);
        request.Headers.Range = new RangeHeaderValue(from, to);
        var response = httpClient.Send(request);

        // Open stream
        using var fileStream = new FileStream(SavePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        using var stream = response.Content.ReadAsStream();

        // Write file
        fileStream.Position = from;
        stream.CopyTo(fileStream);

        return Task.CompletedTask;
    }
}

