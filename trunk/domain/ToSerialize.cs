/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 20:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace domain
{
	/// <summary>
	/// Description of ToSerialize.
	/// </summary>
	public class ToSerialize:ISerialize
	{
		private static ToSerialize instance;
		private ToSerialize()
		{
		}
		public static ISerialize getInstance() 
		{
			if(instance == null)
			{
				instance = new ToSerialize();
			}
			return instance;
		}
		
		public byte[] Serialize<T>(T obj)
		{
			try
            {
                IFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, obj);
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
                return buffer;
            }
            catch (Exception ex)
            {
                throw new Exception("序列化失败,原因:" + ex.Message);
            }
		}
		
		public T Desrialize<T>(T obj, byte[] bytes)
		{
			try
            {
                obj = default(T);
                IFormatter formatter = new BinaryFormatter();
                byte[] buffer = bytes;
                MemoryStream stream = new MemoryStream(buffer);
                stream.Seek(0,SeekOrigin.Begin);
                obj = (T)formatter.Deserialize(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("反序列化失败,原因:" + ex.Message);
            }
            return obj;
		}
		
	}
}
