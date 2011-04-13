using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTunesLibrary.Web.Comunicacao
{
    public class ConversorDeDatas : DateTimeConverterBase
    {
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            DateTime data;

            if( string.IsNullOrEmpty( reader.Value.ToString() ) )
                return DateTime.MinValue;
            if( DateTime.TryParse( reader.Value.ToString(), out data ) )
                return data;
            else
                throw new InvalidDataException( "Uma data inválida foi informada " + reader.Value.ToString() );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            DateTime data = Convert.ToDateTime( value );

            writer.WriteValue( data.ToString( "dd/MM/yyyy" ) );
            writer.Flush();
        }
    }
}