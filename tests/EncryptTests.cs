using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using utilities;
using System.Security.Cryptography;

namespace tests
{
    [TestClass]
    public class EncryptTests
    {
        private readonly string PASSPHRASE = "This is my passphrase!";
        private readonly string myPassKey = "kH4dy3/UT+/8T8MnGL1RfC0fnJjgtDw=";
        private readonly string myEncryptedAccessKey = "crWi1Glx06KHgmMVKVZdLdwbPhS/t+r6Dhheap8gQMk=";
        private readonly string myEncryptedSecretKey = "ADDoK4fdjGvFU6Io1ySKovxaEdhKadir2U77eAnTST8=";
        private readonly string ACCESS_KEY = "823094898230943222343";
        private readonly string SECRET_KEY = "LASKDJFID023I4JW09FS3J2LK";

        [TestMethod]
        public void GenerateAPassKeyTest()
        {
            var passKey = crypto.GenerateAPassKey(PASSPHRASE);
            Assert.IsNotNull(passKey);
            System.Diagnostics.Trace.WriteLine(passKey);
        }
        [TestMethod]
        public void EncryptAccessKey() {
            string EncryptedKey = crypto.Encrypt(ACCESS_KEY, myPassKey);
            Assert.IsNotNull(EncryptedKey);
            //Assert.AreEqual(myEncryptedAccessKey, EncryptedKey);
            System.Diagnostics.Trace.WriteLine(EncryptedKey);
        }

        [TestMethod]
        public void DeCryptAccessKey() {
            string DecryptedKey = crypto.Decrypt(myEncryptedAccessKey, myPassKey);
            Assert.AreEqual(ACCESS_KEY, DecryptedKey);
            System.Diagnostics.Trace.WriteLine(DecryptedKey);
        }

        [TestMethod]
        public void EncryptSecretKey() {
            string EncryptedKey = crypto.Encrypt(SECRET_KEY, myPassKey);
            Assert.IsNotNull(EncryptedKey);
            System.Diagnostics.Trace.WriteLine(EncryptedKey);
        }

        [TestMethod]
        public void DeCryptSecretKey() {
            string DecryptedKey = crypto.Decrypt(myEncryptedSecretKey, myPassKey);
            Assert.AreEqual(SECRET_KEY, DecryptedKey);
            System.Diagnostics.Trace.WriteLine(DecryptedKey);
        }
    }
}
