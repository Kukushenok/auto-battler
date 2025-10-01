using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBattler.Utils
{
    public interface IRandom
    {
        public float GetRange(float min, float max);
        public int GetRange(int minInclusive, int maxExclusive);
        public IRandom CreateOtherInstance();
    }
    public interface IRandomValue<T>
    {
        public T Value(IRandom rnd);
    }
    public abstract class AbstractRandomCollection<T>: IRandomValue<T>
    {
        public T[] values;

        public T Value(IRandom rnd)
        {
            return values[rnd.GetRange(0, values.Length)];
        }
    }
    public abstract class AbstractRandomRange<T>: IRandomValue<T>
    {
        public AbstractRandomRange(T min, T max)
        {
            minValue = min;
            maxValue = max;
        }
        
        protected T minValue;
        protected T maxValue;

        public abstract T Value(IRandom rnd);
    }
    public class IntRange : AbstractRandomRange<int>
    {
        public IntRange(int min, int max) : base(min, max)
        {
        }

        public override int Value(IRandom rnd)
        {
            return rnd.GetRange(minValue, maxValue);
        }
    }
    public class FloatRange : AbstractRandomRange<float>
    {
        public FloatRange(float min, float max) : base(min, max)
        {
        }

        public override float Value(IRandom rnd)
        {
            return rnd.GetRange(minValue, maxValue);
        }
    }
}
