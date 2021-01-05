using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace TmsOpenApiCSharpDemo
{
    public static class SignHelper
    {
        public static void BuildHttpRequestSinData(HttpClient client,int userId,string apiKey,string json)
        {
            var appId = userId.ToString();
            var apiTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var body = json;
            string sign = $"{appId}{apiTime}{body}{apiKey}".ToMD5String();

            client.DefaultRequestHeaders.Add("appId", appId);
            client.DefaultRequestHeaders.Add("time", apiTime);
            client.DefaultRequestHeaders.Add("sign", sign);
        }


        /// <summary>
        /// 转换为MD5加密后的字符串（默认加密为32位）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5String(this string str)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(str);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            md5.Dispose();

            return sb.ToString();
        }
    }
}