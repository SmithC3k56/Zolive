using Minio;
using Minio.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.FileManager
{
    public class TestMinio
    {
        [SetUp]
        public void Setup()
        {
            //var config = InitConfiguration();

            //ConfigNew.Configuration = config;
        }

        [Test]
        public void Test1()
        {
            var endpoint = "localhost:9000";
            var accessKey = "minio";
            var secretKey = "minio123";
            try
            {
                var minio = new MinioClient(endpoint, accessKey, secretKey);
                    //.WithSSL();
                // 4. Initializing minio client with temporary credentials
                //IWebProxy proxy = new WebProxy("192.168.0.1", 8000);
                //MinioClient minioClient = new MinioClient(endpoint, accessKey, secretKey, sessionToken: "ACF1vg5nYFy9AtO9BHcsu4lOdW8QJtcdjg7ZfG8skXekRgsPbdnVjRSKf3PQ6vXdX2kZNKcs2zfACBxope8mmUm5tyq7sabvzlh2hRdTj5qDa2eiOXqTLDHuvLaH7leFFw2uG1q13nc2dV35/eJ26HouPzGDUmR/4H3MUgFomPg+7qMCihXghnMNnTCY3yLgjyHUEv0Rq25yWM0BE1jvnYcNK8aTEZzsyd0Um4mJQ10jF2mF94zpusqS+qUU/jVM+e38JShx0Sd3AZ8kWQ4aw4WrMB5TBfNYD1dRF9ZwkyKwbLcHFLiUBrRaaKDKsMzgTueLLOaCTBGvQzLCC7hMyTWk1h2+ek5nIqq9RZThx4zE8IYemZvV2aDEjRHsa0KOHf3NzcX46GTTM+IqRO/uDKou0ZJRBSVMur8kibe3RL/AHiwQqZtvcu7F95CHq2zgLHZIsV6c1GY7RuErSSJqWGoIbFp8pYaNg7F/NqsRc/5IEXOJGtwL7sWGx7zaK3+iOjYL2Kh2GLJwW8SEFekP3d5HliH89Eqmk5i2sp63Q9g=");
                //Run(minio).Wait();
                getObject(minio).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private async static Task getObject(MinioClient minioClient)
        {
            var bucketName = "image-zolive";
            var location = "us-east-1";
            var objectName = "test.zip";
            var filePath = "D:\\minio_docker\\user_default.txt";
            var contentType = "application/zip";
            try
{
                // Check whether the object exists using statObject().
                // If the object is not found, statObject() throws an exception,
                // else it means that the object exists.
                // Execution is successful.
                await minioClient.StatObjectAsync(bucketName, objectName);

                // Get input stream to have content of 'my-objectname' from 'my-bucketname'
                //await minioClient.GetObjectAsync(bucketName, objectName,
                //                                 (stream) =>
                //                                 {
                //                                     using (StringWriter sw = new StringWriter())
                //                                     {
                //                                         Console.SetOut(sw);

                //                                         //ConsoleUser cu = new ConsoleUser();
                //                                         //cu.DoWork();
                //                                         stream.CopyTo(Console.OpenStandardOutput());
                //                                         Console.WriteLine(sw);

                //                                         string expected = string.Format("Ploeh{0}", Environment.NewLine);
                //                                         //Assert.AreEqual<string>(expected, sw.ToString());
                //                                     }
                //                                 });
                
                await minioClient.GetObjectAsync(bucketName, objectName,"test.zip");

                try
                {
                    String url = await minioClient.PresignedGetObjectAsync(bucketName, objectName, 60 * 60 * 24);
                    Console.WriteLine(url);
                }
                catch (MinioException e)
                {
                    Console.WriteLine("Error occurred: " + e);
                }
            }
            catch (MinioException e)
            {
                Console.WriteLine("Error occurred: " + e);
            }
        }
        private async static Task Run(MinioClient minio)
        {
            var bucketName = "image-zolive";
            var location = "us-east-1";
            var objectName = "test.zip";
            var filePath = "D:\\minio_docker\\user_default.txt";
            var contentType = "application/zip";

            try
            {
                // Make a bucket on the server, if not already present.
                bool found = await minio.BucketExistsAsync(bucketName);
                if (!found)
                {
                    await minio.MakeBucketAsync(bucketName, location);
                }
                // Upload a file to bucket.
                //var link = await minio.GetObjectAsync(bucketName, objectName, "test.zip");
                await minio.GetObjectAsync(bucketName, objectName,
                                    (stream) =>
                                    {
                                        stream.CopyTo(Console.OpenStandardOutput());
                                    });
                //await minio.PutObjectAsync(bucketName, objectName, filePath, contentType);
                Console.WriteLine("Successfully uploaded " + objectName);
            }
            catch (MinioException e)
            {
                Console.WriteLine("File Upload Error: {0}", e.Message);
            }
        }
    }
}
