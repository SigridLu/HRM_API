using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RHRM_API_ApplicationCore.Models;

namespace RHRM_API_ApplicationCore.Contracts.Services
{
    // To use Blob storage, you need Azure.Storage.Blobs nuget package
    public interface IBlobService
    {
        public Task<BlobResponseModel> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
