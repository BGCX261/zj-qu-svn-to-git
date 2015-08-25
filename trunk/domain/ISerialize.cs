/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-24
 * Time: 20:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace domain
{
	/// <summary>
	/// Description of ISerialize.
	/// </summary>
	public interface ISerialize
	{
		byte[] Serialize<T>(T obj);
		T Desrialize<T>(T obj, byte[] bytes);
	}
}
