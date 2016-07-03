using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ProvaSiteware.Infra.Data.NHibernate.Session
{
    public class DefaultConventions : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.PropertyType == typeof(string))
            {
                instance.CustomType("AnsiString");
                instance.Length(500);
            }
            else if (instance.Property.PropertyType == typeof(decimal))
            {
                instance.Precision(18);
                instance.Scale(2);
            }
        }
    }
}