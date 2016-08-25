using LightningDB;
using System;

namespace LightningDB.Converters {
	public class ConvertToBytesInstance<TFrom> : IConvertToBytes<TFrom> {
		private readonly Func<LightningDatabase, TFrom, byte[]> _convert;

		public Type ConvertFromType {
			get {
				return typeof(TFrom);
			}
		}

		public ConvertToBytesInstance(Func<LightningDatabase, TFrom, byte[]> convert) {
			this._convert = convert;
		}

		public byte[] Convert(LightningDatabase db, TFrom instance) {
			return this._convert(db, instance);
		}
	}
}