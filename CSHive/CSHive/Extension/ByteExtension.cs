﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Byte的相关转换
    /// </summary>
    public static class ByteExtension
    {

	
        /// <summary>
        /// 从原字节数组中返回新的数组
        /// </summary>
        /// <param name="bs">源数组</param>
        /// <param name="length">返回的长度</param>
        /// <returns></returns>
        public static byte[] GetBytes(this byte[] bs, int length)
        {
            return bs.GetBytes(0, length);
        }

        /// <summary>
        /// 从原字节数组中返回新的数组
        /// </summary>
        /// <param name="bs">源数组</param>
        /// <param name="index">源数组起始索引</param>
        /// <param name="length">返回的长度</param>
        /// <returns></returns>
        public static byte[] GetBytes(this byte[] bs, int index, int length)
        {
            var newBs = new byte[length];
            Buffer.BlockCopy(bs, 0, newBs, index, length);
            return newBs;
        }

        /// <summary>
        /// 将字节流按UTF8编码返回结果字符串
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static string ToUtf8(this byte[] bs)
        {
            return Encoding.UTF8.GetString(bs);
        }

        /// <summary>
        /// 将字节流按UTF8编码返回结果字符串
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="index">字节流中起始索引</param>
        /// <param name="length">有效长度</param>
        /// <returns></returns>
        public static string ToUtf8(this byte[] bs, int index, int length)
        {
            return Encoding.UTF8.GetString(bs, index, length);
        }

        /// <summary>
        /// 将字节流按编码返回结果字符串
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToString(this byte[] bs, Encoding encoding)
        {
            return encoding.GetString(bs);
        }

        /// <summary>
        /// 返回16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes)
        {
            return ToHexString(bytes, false);
        }
        /// <summary>
        /// 返回16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="length">转换长度</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, int startIndex, int length)
        {
            return bytes.ToHexString(startIndex, length, false);
        }

        /// <summary>
        /// 返回16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="removeDashes">是否移除连字符</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, bool removeDashes)
        {
            string hex = BitConverter.ToString(bytes);
            if (removeDashes)
                hex = hex.Replace("-", "");

            return hex;
        }

        /// <summary>
        /// 返回16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="length">转换长度</param>
        /// <param name="removeDashes">是否移除连字符</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes, int startIndex, int length, bool removeDashes)
        {
            string hex = BitConverter.ToString(bytes, startIndex, length);
            if (removeDashes)
                hex = hex.Replace("-", "");

            return hex;
        }

        /// <summary>
        /// 返回2进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBinString(this byte[] bytes)
        {
            return bytes.ToBinString("-");
        }

        /// <summary>
        /// 返回2进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="dashes">连字符</param>
        /// <returns></returns>
        public static string ToBinString(this byte[] bytes, string dashes)
        {
            var list = new List<string>(bytes.Length);
            list.AddRange(bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
            return string.Join(dashes, list.ToArray());
        }

        /// <summary>
        /// 将小于2G的byte[]数据前加上长度标识
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ToPackage(this byte[] bytes)
        {
            var length = bytes.Length;
            var packageLength = length + 4;
            var bs = new byte[packageLength];
            Buffer.BlockCopy(BitConverter.GetBytes(packageLength), 0, bs, 0, 4);
            Buffer.BlockCopy(bytes, 0, bs, 4, length);
            //Array.Copy(BitConverter.GetBytes(length), 0, bs, 0, 4);
            //Array.Copy(bytes, 0, bs, 4, length);
            return bs;
        }

        /// <summary>
        /// 字节流转为base64字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

    }
}