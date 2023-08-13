using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Japanese.LanguageCore.AWS.Helpers;

public class S3Helper : IDisposable
{
    private readonly AmazonS3Client _s3client;
    private bool disposedValue;

    internal S3Helper(BasicAWSCredentials basicAWSCredentials, AmazonS3Config s3Config)
    {
        _s3client = new AmazonS3Client(basicAWSCredentials, s3Config);
    }

    public async Task UploadFile(string bucketName, string keyName, Stream stream)
    {
        PutObjectRequest request = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = keyName,
            InputStream = stream
        };

        _ = await _s3client.PutObjectAsync(request);
    }

    public async Task<Stream?> GetFile(string bucketName, string keyName)
    {
        try
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            GetObjectResponse response = await _s3client.GetObjectAsync(request);
            return response.ResponseStream;
        }
        catch (AmazonS3Exception ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            throw new Exception("", ex);
        }
    }

    public async Task Remove(string buckerName, string keyName)
    {
        DeleteObjectRequest request = new DeleteObjectRequest
        {
            BucketName = buckerName,
            Key = keyName
        };

        _ = await _s3client.DeleteObjectAsync(request);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _s3client.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}