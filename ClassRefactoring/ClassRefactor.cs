using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            switch (Type)
            {
                case SwallowType.African:
                    return GetAfricanLoad();
                case SwallowType.European:
                    return GetEuropeanLoad();
                default:
                    throw new InvalidOperationException();
            }           
        }

        public double GetAfricanLoad()
        {
            switch (Load) 
            {
                case SwallowLoad.None:
                    return 22;
                case SwallowLoad.Coconut: 
                    return 18;
                default: throw new InvalidOperationException();
            }
        }

        public double GetEuropeanLoad()
        {
            switch (Load)
            {
                case SwallowLoad.None:
                    return 20;
                case SwallowLoad.Coconut:
                    return 16;
                default: throw new InvalidOperationException();
            }
        }
    }
}