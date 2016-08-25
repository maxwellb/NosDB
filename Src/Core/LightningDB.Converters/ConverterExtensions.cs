using LightningDB;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LightningDB.Converters {
	public static class ConverterExtensions {
		public static void AddConvertFromBytes<TTo>(this ConverterStore store, Func<LightningDatabase, byte[], TTo> convert) {
			store.AddConvertFromBytes<TTo>(new ConvertFromBytesInstance<TTo>(convert));
		}

		public static void AddConvertToBytes<TFrom>(this ConverterStore store, Func<LightningDatabase, TFrom, byte[]> convert) {
			store.AddConvertToBytes<TFrom>(new ConvertToBytesInstance<TFrom>(convert));
		}

		public static Func<LightningDatabase, byte[], TTo> EnsureCorrectSize<TTo>(this Func<LightningDatabase, byte[], TTo> convert, int? size = null)
		where TTo : struct {
			Func<LightningDatabase, byte[], TTo> func = (LightningDatabase db, byte[] x) => {
				int? nullable = size;
				int actualSize = (nullable.HasValue ? nullable.GetValueOrDefault() : Marshal.SizeOf(typeof(TTo)));
				if ((int)x.Length != actualSize) {
					throw new InvalidCastException(string.Format("Invalid byte count. {0} given {1} required.", (int)x.Length, actualSize));
				}
				return convert(db, x);
			};
			return func;
		}
	}
}