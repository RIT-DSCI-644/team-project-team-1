using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aws;
using Amazon.S3;
using Amazon.S3.Model;
using System.Linq;

namespace tests
{
    [TestClass]
    public class S3Tests
    {
        [TestMethod]
        public void GetAllKeys()
        {
            string response = aws.S3CRUD.GetAllKeys().ToString();
            Assert.IsNotNull(response);
            System.Diagnostics.Trace.WriteLine(response);
        }

        [TestMethod]
        public void ReadFirstItemInBucket() {

            var response = aws.S3CRUD.GetAllKeys().S3Objects.FirstOrDefault();
            var fileContents = aws.S3CRUD.ReadFromBucket(response.Key);
            Assert.IsNotNull(fileContents);
            System.Diagnostics.Trace.WriteLine(response.Key);
            System.Diagnostics.Trace.WriteLine(fileContents);
        }
    }
}
