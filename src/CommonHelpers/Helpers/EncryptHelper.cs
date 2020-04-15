using CommonHelpers.Algorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpers.Helpers
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        /// 加密数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryptKey"></param>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public static string Encrypt(string data, string encryptKey, EncodingTypes encodingType = EncodingTypes.Base64)
        {
            return AES.Encrypt(data, encryptKey, encodingType);
        }

        /// <summary>
        /// 解密数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryptKey"></param>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public static string Decrypt(string data, string encryptKey, EncodingTypes encodingType = EncodingTypes.Base64)
        {
            return AES.Decrypt(data, encryptKey, encodingType);
        }
    }
}
