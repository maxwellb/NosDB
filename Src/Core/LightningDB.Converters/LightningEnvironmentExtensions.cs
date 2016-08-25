using System;

namespace LightningDB.Converters {
	public static class LightningEnvironmentExtensions {
		private static readonly Lazy<ConverterStore> ConverterStoreDefault = new Lazy<ConverterStore>(DefaultConverters.GetDefaultConverterStore); 
		public static ConverterStore ConverterStore(this LightningEnvironment environment)
		{
			return ConverterStoreDefault.Value;
		}
	}
}
