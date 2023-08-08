
namespace Japanese.LanguageCore.AWS.S3;

public interface IS3Helper : IDisposable
{
    Task UploadFile(string bucketName, string keyName, Stream stream);
    Task<Stream?> GetFile(string bucketName, string keyName);
}