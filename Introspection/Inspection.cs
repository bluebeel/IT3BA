using System;
using System.Reflection;

namespace Introspection
{
	public class Inspection
	{
		private readonly Type type;
		private readonly MemberInfo[] members;

		public Inspection(Type type)
		{
			this.type = type;
			this.members = this.type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance |
														BindingFlags.Public | BindingFlags.Static |
														BindingFlags.DeclaredOnly);
		}

		public void String()
		{
			foreach (MemberInfo m in members)
			{
				switch (m.MemberType)
				{
					case MemberTypes.Constructor:
						Console.WriteLine("Constructor: {0}", ((ConstructorInfo)m).Name);
						foreach (ParameterInfo pi in ((ConstructorInfo)m).GetParameters())
						{
							Console.WriteLine("\t Parameter:");
							Console.WriteLine("\t\t Type = {0}", pi.ParameterType.Name);
							Console.WriteLine("\t\t Name = {0}", pi.Name);
						}
						break;
						
					case MemberTypes.Method:
						Console.WriteLine("Method: {0}", m.Name);
						foreach (ParameterInfo pi in ((MethodInfo)m).GetParameters())
						{
							Console.WriteLine("\t Parameter:");
							Console.WriteLine("\t\t Type = {0}", pi.ParameterType.Name);
							Console.WriteLine("\t\t Name = {0}", pi.Name);
						}
						Console.WriteLine("\t Return Type: {0}", ((MethodInfo)m).ReturnType.Name);
						break;

					case MemberTypes.Field:
						Console.WriteLine("Field: {0}", m.Name);
						Console.WriteLine("\t Attributes = {0}", ((FieldInfo)m).Attributes);
						Console.WriteLine("\t Type = {0}", ((FieldInfo)m).FieldType);
						break;
						
					case MemberTypes.Property:
						Console.WriteLine("Property: {0}", m.Name);
						foreach (MethodInfo mi in ((PropertyInfo)m).GetAccessors())
						{
							Console.WriteLine("\t Property:");
							Console.Write("\t\t Name = {0}", mi.Name);
						}
						break;

				}
			}
		}
	}
}
