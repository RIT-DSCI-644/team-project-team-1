using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Collections.Specialized;
using System.IO;

namespace aws
{
    public class s3
    {
        private static string ACCESS_KEY = "AKIASTEBWONGFJEZ2WEX";
        private static string SECRET_KEY = "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";
        private static string BUCKET_NAME = "team-proj-resources";
        private static Amazon.RegionEndpoint REGION = Amazon.RegionEndpoint.USEast2;

        public static string ReadFromBucket(string keyName, string bucketName = "")
        {
            string responseBody = "";

            try
            {
                using (var s3Client = CreateClientConnection())
                {
                    var request = new GetObjectRequest()
                    {
                        BucketName = (bucketName == string.Empty? BUCKET_NAME: bucketName),
                        Key = keyName
                    };

                    using (var response = s3Client.GetObject(request))
                    using (var responseStream = response.ResponseStream)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            catch (AmazonS3Exception s3Exception)
            {
                throw new Exception(s3Exception.Message, s3Exception.InnerException);
            }

            return responseBody;
        }

        public static AmazonS3Client CreateClientConnection()
        {
            return new AmazonS3Client(
                    ACCESS_KEY,
                    SECRET_KEY,
                    REGION
                    );
        }
    }
}

