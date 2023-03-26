namespace Harvest.Common.Requests;

using System;
using System.Net.Http;
using Authentication;

public class HarvestRequestAdapter : IDisposable
{
    private readonly AuthCredential credential;
    private readonly HttpClient httpClient;

    public HarvestRequestAdapter(AuthCredential credential, HttpClient httpClient = null)
    {
        this.credential = credential;
        this.httpClient = httpClient ?? new HttpClient();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
    }
}