using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Japanese.LanguageCore.AWS;

public class SimpleStorageService
{
    private readonly AmazonS3Client _s3client;

    public SimpleStorageService(BasicAWSCredentials basicAWSCredentials, AmazonS3Config s3Config)
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
        catch(AmazonS3Exception ex)
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
}