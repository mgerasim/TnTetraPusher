using System;
using System.IO;
using System.Xml.Serialization;
using TnTetraPusher.Models.Entities;
using Xunit;

namespace TnTetraPusher.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("123==", "<content>123==</content>\r\nОтправлено из приложения \"Почта\" для Windows\r\n")]
        [InlineData("123==", "RWQRQW REWQR WQER QWE RTWE WERT<content>123==</content>\r\nОтправлено из приложения \"Почта\" для Windows\r\n")]
        [InlineData("123==", "<content>123==</content>QWERQ WQER QWER QWER QWER\r\nОтправлено из приложения \"Почта\" для Windows\r\n")]
        [InlineData("eyJib2R5IjoiZXlKelpYSnBZV3hPZFcxaVpYSWlPaUpCY21kb0lTQlNaV1psY21WdVkyVkZjbkp2Y2pvZ1RrUkZSbEpsWVdSbGNpQnBjeUJ1YjNRZ1pHVm1hVzVsWkNJc0ltUmhkR1ZVYVcxbElqb2lNakF5TXkwd09DMHlNRlF3TlRvd05Ub3dOQzQwTmpWYUluMD0iLCJ2ZXJzaW9uIjoxfQ==", "<content>eyJib2R5IjoiZXlKelpYSnBZV3hPZFcxaVpYSWlPaUpCY21kb0lTQlNaV1psY21WdVkyVkZjbkp2Y2pvZ1RrUkZSbEpsWVdSbGNpQnBjeUJ1YjNRZ1pHVm1hVzVsWkNJc0ltUmhkR1ZVYVcxbElqb2lNakF5TXkwd09DMHlNRlF3TlRvd05Ub3dOQzQwTmpWYUluMD0iLCJ2ZXJzaW9uIjoxfQ==</content>\r\nОтправлено из приложения \"Почта\" для Windows\r\n")]
        public void Extract_Success(string actual, string content)
        {
            var s = Content.Extract(content); 
            
            Assert.Equal(actual, s);
        }

        [Theory]
        [InlineData(1, "eyJzZXJpYWxOdW1iZXIiOiJBcmdoISBSZWZlcmVuY2VFcnJvcjogTkRFRlJlYWRlciBpcyBub3QgZGVmaW5lZCIsImRhdGVUaW1lIjoiMjAyMy0wOC0yMFQwNTozNDo1Ny4zMTRaIn0=", "<content>eyJib2R5IjoiZXlKelpYSnBZV3hPZFcxaVpYSWlPaUpCY21kb0lTQlNaV1psY21WdVkyVkZjbkp2Y2pvZ1RrUkZSbEpsWVdSbGNpQnBjeUJ1YjNRZ1pHVm1hVzVsWkNJc0ltUmhkR1ZVYVcxbElqb2lNakF5TXkwd09DMHlNRlF3TlRvek5EbzFOeTR6TVRSYUluMD0iLCJ2ZXJzaW9uIjoxfQ==</content>")]
        public void Parse_Success(int version, string body, string encodeConent)
        {
            var content = Content.Parse(encodeConent);

            Assert.Equal(version, content.Version);

            Assert.Equal(body, content.Body);
        }

        [Theory]
        [InlineData("Argh! ReferenceError: NDEFReader is not defined", "eyJzZXJpYWxOdW1iZXIiOiJBcmdoISBSZWZlcmVuY2VFcnJvcjogTkRFRlJlYWRlciBpcyBub3QgZGVmaW5lZCIsImRhdGVUaW1lIjoiMjAyMy0wOC0yMFQwNTozNDo1Ny4zMTRaIn0=")]
        public void CreateTag_Success(string serialNumber, string body)
        {
            var tag = Tag.FromBase64(body);

            Assert.Equal(serialNumber, tag.SerialNumber);
        }

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