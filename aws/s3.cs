﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Collections.Specialized;
using System.IO;
using utilities;

using model;
using Newtonsoft.Json;

namespace aws
{
    public class S3CRUD
    {
        private static readonly string myPassKey = "Lv1TpHYjmsRUYPjs7SYDR9HNzvE2RvY=";
        private static readonly string myEncryptedAccessKey = "4Uw2djKxnGqZtZLTjpv+62Db+FiHLnhH0MpZScHFwAQ=";
        private static readonly string myEncryptedSecretKey = "8Nc7Nd+SDXhUS++T3OBcb9Ur0sgNTjpqIV5Sp+kxa/8R52SzhN4Ptr3rxrxm3sZ2";
        private static readonly string BUCKET_NAME = "team-proj-resources";
        private static readonly Amazon.RegionEndpoint REGION = Amazon.RegionEndpoint.USEast2;
        private static readonly AmazonS3Client s3Client = null;

        /// <summary>
        /// returns file payload from AWS S3 bucket as a string
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        public static string ReadFromBucket(string keyName, string bucketName = "")
        {
            string responseBody = "";

            try
            {
                //using (GetS3Client())
                //{
                    var request = new GetObjectRequest()
                    {
                        BucketName = (bucketName == string.Empty? BUCKET_NAME: bucketName),
                        Key = keyName
                    };

                    using (var response = GetS3Client.GetObject(request))
                    using (var responseStream = response.ResponseStream)
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                //}
            }
            catch (AmazonS3Exception s3Exception)
            {
                throw new Exception(s3Exception.Message, s3Exception.InnerException);
            }

            return responseBody;
        }

        private static AmazonS3Client GetS3Client {
            get
            {
                return s3Client == null ? new AmazonS3Client(
                    crypto.Decrypt(myEncryptedAccessKey, myPassKey),
                    crypto.Decrypt(myEncryptedSecretKey, myPassKey),
                    REGION
                    ) : s3Client;
            }
        }

        /// <summary>
        /// returns an objects containing all keys and associated metadata
        /// </summary>
        /// <returns></returns>
        public static ListObjectsV2Response GetAllKeys(int maxKeysReturned = 1000)
        {
            ListObjectsV2Response response;
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = BUCKET_NAME,
                    MaxKeys = maxKeysReturned
                };

                response = GetS3Client.ListObjectsV2(request);
            }
            catch (AmazonS3Exception s3Exception)
            {
                throw new Exception(s3Exception.Message, s3Exception.InnerException);
            }
            catch (Exception e)
            {
                throw e;
            }

            return response;
        }

        public static MainPage GetMainPageData() {
            return JsonConvert.DeserializeObject<MainPage>(ReadFromBucket("MainPage.txt"));
        }
    }
}

