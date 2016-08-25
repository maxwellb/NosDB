using LightningDB;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace LightningDB.Converters
{
	public class DefaultConverters
	{
		public DefaultConverters()
		{
		}

		private void ConvertFromBytesWithCorrectSize<TTo>(ConverterStore store, Func<LightningDatabase, byte[], TTo> convert,
			int? size = null)
			where TTo : struct
		{
			store.AddConvertFromBytes<TTo>(convert.EnsureCorrectSize<TTo>(size));
		}
		
		public static ConverterStore GetDefaultConverterStore()
		{
			DefaultConverters defaultConverters = new DefaultConverters();
			ConverterStore store = new ConverterStore();
			store.AddConvertToBytes<Guid>((LightningDatabase db, Guid x) => x.ToByteArray());
			store.AddConvertToBytes<double>((LightningDatabase db, double x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<float>((LightningDatabase db, float x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<bool>((LightningDatabase db, bool x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<short>((LightningDatabase db, short x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<int>((LightningDatabase db, int x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<long>((LightningDatabase db, long x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<ushort>((LightningDatabase db, ushort x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<uint>((LightningDatabase db, uint x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<ulong>((LightningDatabase db, ulong x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<char>((LightningDatabase db, char x) => BitConverter.GetBytes(x));
			store.AddConvertToBytes<byte>((LightningDatabase db, byte x) => new byte[] {x});
			store.AddConvertToBytes<sbyte>((LightningDatabase db, sbyte x) => new byte[] {(byte) x});
			store.AddConvertToBytes<string>((LightningDatabase db, string x) => Encoding.UTF8.GetBytes(x));
			store.AddConvertToBytes<byte[]>((LightningDatabase db, byte[] x) => x);
			defaultConverters.ConvertFromBytesWithCorrectSize<Guid>(store, (LightningDatabase db, byte[] x) => new Guid(x), new int?(16));
			ConverterStore converterStore = store;
			int? nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<double>(converterStore,
				(LightningDatabase db, byte[] x) => BitConverter.ToDouble(x, 0), nullable);
			ConverterStore converterStore1 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<float>(converterStore1,
				(LightningDatabase db, byte[] x) => BitConverter.ToSingle(x, 0), nullable);
			ConverterStore converterStore2 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<bool>(converterStore2,
				(LightningDatabase db, byte[] x) => BitConverter.ToBoolean(x, 0), nullable);
			ConverterStore converterStore3 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<short>(converterStore3,
				(LightningDatabase db, byte[] x) => BitConverter.ToInt16(x, 0), nullable);
			ConverterStore converterStore4 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<int>(converterStore4,
				(LightningDatabase db, byte[] x) => BitConverter.ToInt32(x, 0), nullable);
			ConverterStore converterStore5 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<long>(converterStore5,
				(LightningDatabase db, byte[] x) => BitConverter.ToInt64(x, 0), nullable);
			ConverterStore converterStore6 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<ushort>(converterStore6,
				(LightningDatabase db, byte[] x) => BitConverter.ToUInt16(x, 0), nullable);
			ConverterStore converterStore7 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<uint>(converterStore7,
				(LightningDatabase db, byte[] x) => BitConverter.ToUInt32(x, 0), nullable);
			ConverterStore converterStore8 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<ulong>(converterStore8,
				(LightningDatabase db, byte[] x) => BitConverter.ToUInt64(x, 0), nullable);
			ConverterStore converterStore9 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<char>(converterStore9,
				(LightningDatabase db, byte[] x) => BitConverter.ToChar(x, 0), nullable);
			ConverterStore converterStore10 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<byte>(converterStore10, (LightningDatabase db, byte[] x) => x[0], nullable);
			ConverterStore converterStore11 = store;
			nullable = null;
			defaultConverters.ConvertFromBytesWithCorrectSize<sbyte>(converterStore11, (LightningDatabase db, byte[] x) => (sbyte) x[0],
				nullable);
			store.AddConvertFromBytes<string>((LightningDatabase db, byte[] x) => Encoding.UTF8.GetString(x));
			store.AddConvertFromBytes<byte[]>((LightningDatabase db, byte[] x) => x);
			return store;
		}
	}
}