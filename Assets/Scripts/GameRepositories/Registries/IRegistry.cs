using System.Collections.Generic;
namespace Game.Registries
{
    public interface IRegistry<T> : IEnumerable<KeyValuePair<string, T>> where T : IIdentifiable
    {
        public T Get(string id);
    }
}