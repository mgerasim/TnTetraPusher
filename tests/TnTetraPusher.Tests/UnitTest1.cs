using System;
using System.IO;
using System.Xml.Serialization;
using TnTetraPusher.Models.Entities;
using Xunit;

namespace TnTetraPusher.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Save_Success()
        {
            var tag = new Tag
            {
                SerialNumber = Guid.NewGuid().ToString(),
            };

            var tagJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(tag);

            var body = Base64Encode(tagJsonString);

            var content = new Content
            {
                Body = body,
            };

            

            using (var stringwriter = new System.IO.StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Content));
                serializer.Serialize(stringwriter, content);
                var serialized = stringwriter.ToString();

                Assert.True(serialized.Length > 0);
            }

            
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}