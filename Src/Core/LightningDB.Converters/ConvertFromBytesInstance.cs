using LightningDB;
using System;

namespace LightningDB.Converters {
	public class ConvertFromBytesInstance<TTo> : IConvertFromBytes<TTo> {
		private readonly Func<LightningDatabase, byte[], TTo> _convert;

		public Type ConvertFromType {
			get {
				return typeof(TTo);
			}
		}

		public ConvertFromBytesInstance(Func<LightningDatabase, byte[], TTo> convert) {
			this._convert = convert;
		}

		public TTo Convert(LightningDatabase db, byte[] bytes) {
			return (bytes == null ? default(TTo) : this._convert(db, bytes));
		}
	}
}