using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bulletin
{
	public class Parser
	{
		public List<Teacher> Teacher { get; set; }
		public List<Activity> Activity { get; set; }
		public List<Student> Student { get; set; }
		public List<Evaluation> Evaluation { get; set; }
	}

	public class EvaluationConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(Student));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);

			if (jo["grade"] != null)
				return jo.ToObject<Grade>(serializer);

			if (jo["appreciation"] != null)
				return jo.ToObject<Appreciation>(serializer);


			return null;
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
