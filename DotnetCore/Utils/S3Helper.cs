using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using DotnetCore.Model.S3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Utils
{
    public static class S3Helper
    {

        public static async Task<string> FetchData(FetchS3Request fetchS3Request)
        {
            string accessKey = "AKIAIASMTPFKZFQ62R7A";
            string secretKey = "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";
            string responseBody = "";

            using (var client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.APSoutheast2))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = fetchS3Request.BucketName,
                    Key = fetchS3Request.FileKey,
                };

                using (GetObjectResponse response = await client.GetObjectAsync(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"];
                    Console.WriteLine("The object's title is {0}", title);
                    responseBody = reader.ReadToEnd();
                }
            }
            return responseBody;
        }
    }
}
