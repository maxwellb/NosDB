using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LightningDB.Converters {
	public class ConverterStore {
		private readonly IDictionary<Type, object> _convertToBytes = new ConcurrentDictionary<Type, object>();

		private readonly IDictionary<Type, object> _convertFromBytes = new ConcurrentDictionary<Type, object>();

		public ConverterStore() {
		}

		public void AddConvertFromBytes<TConvertTo>(IConvertFromBytes<TConvertTo> converter) {
			this._convertFromBytes.Add(converter.ConvertFromType, converter);
		}

		public void AddConvertToBytes<TConvertFrom>(IConvertToBytes<TConvertFrom> converter) {
			this._convertToBytes.Add(converter.ConvertFromType, converter);
		}

		public IConvertFromBytes<TConvertTo> GetFromBytes<TConvertTo>() {
			return (IConvertFromBytes<TConvertTo>)this.GetFromBytes(typeof(TConvertTo));
		}

		public object GetFromBytes(Type toType) {
			if (!this._convertToBytes.ContainsKey(toType)) {
				throw new ConverterNotFoundException(toType);
			}
			return this._convertFromBytes[toType];
		}

		public IConvertToBytes<TConvertFrom> GetToBytes<TConvertFrom>() {
			return (IConvertToBytes<TConvertFrom>)this.GetToBytes(typeof(TConvertFrom));
		}

		public object GetToBytes(Type fromType) {
			if (!this._convertToBytes.ContainsKey(fromType)) {
				throw new ConverterNotFoundException(fromType);
			}
			return this._convertToBytes[fromType];
		}
	}
}