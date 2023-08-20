namespace TnTetraPusher.Models.Entities
{
    /// <summary>
    /// Контент присылаемых данных
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Версия кодирования данных
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        /// Кодированные данные
        /// </summary>
        public string Body { get; set; } = String.Empty;

        public static string Extract(string s)
        {
            String searchString = "<content>";
            int startIndex = s.IndexOf(searchString);
            searchString = "</" + searchString.Substring(1);
            int endIndex = s.IndexOf(searchString);
            String substring = s.Substring(startIndex, endIndex + searchString.Length - startIndex);

            return substring.Replace("<content>", "").Replace("</content>", "");
        }

        public static Content Parse(string s)
        {
            var body = Content.Extract(s);

            var contentJsonString = Content.Base64Decode(body);

            var content = Newtonsoft.Json.JsonConvert.DeserializeObject<Content>(contentJsonString);

            if (content is null)
            {
                throw new NullReferenceException();
            }

            return content;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
