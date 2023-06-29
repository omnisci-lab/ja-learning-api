using System.Reflection;

namespace Japanese.Core.Mapper;

public class ObjectMapper
{
    public void Map(object object1, object object2)
    {
        Type typeA = object1.GetType();
        Type typeB = object2.GetType();

        PropertyInfo[] properties1 = typeA.GetProperties();

        foreach (PropertyInfo propertyA in properties1)
        {
            object? value = propertyA.GetValue(object1);
            PropertyInfo? propertyB = typeB.GetProperty(propertyA.Name);
            if (propertyB != null && propertyB.CanWrite)
            {
                propertyB.SetValue(object2, value);
            }
        }
    }
}
