using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aws;
using Amazon.S3;
using Amazon.S3.Model;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace tests
{
    [TestClass]
    public class S3Tests
    {
        [TestMethod]
        public void GetAllKeys()
        {
            List<string> response = aws.S3CRUD.GetAllKeysAsList();
            Assert.IsNotNull(response);
            System.Diagnostics.Trace.WriteLine(JsonConvert.SerializeObject(response));
        }

        [TestMethod]
        public void ReadFirstItemInBucket()
        {
            var response = aws.S3CRUD.GetAllKeys().S3Objects.FirstOrDefault();
            var fileContents = aws.S3CRUD.ReadFromBucket(response.Key);
            Assert.IsNotNull(fileContents);
            System.Diagnostics.Trace.WriteLine(response.Key);
            System.Diagnostics.Trace.WriteLine(fileContents);
        }

        [TestMethod]
        public void MainPageSerializationTest()
        {
            var response = aws.S3CRUD.GetMainPageData;
            Assert.IsNotNull(response);
            System.Diagnostics.Trace.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }

        [TestMethod]
        public void IndividualPageSerializationTest()
        {
            var response = aws.S3CRUD.GetIndividualPageDataByKeyName(aws.S3CRUD.GetAllKeys().S3Objects.FirstOrDefault().Key);
            Assert.IsNotNull(response);
            System.Diagnostics.Trace.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }
}
