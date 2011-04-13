using System;

using Newtonsoft.Json;

namespace iTunesLibrary.Web.Comunicacao
{
    public class ConversorDeEnumeracoes : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return objectType.IsEnum;
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            return Enum.Parse( objectType, reader.Value.ToString() );
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            writer.WriteValue( Enum.GetName( value.GetType(), value ) );
            writer.Flush();
        }
    }
}