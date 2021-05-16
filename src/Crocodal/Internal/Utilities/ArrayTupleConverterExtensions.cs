namespace Crocodal.Internal.Utilities
{
    internal static class ArrayTupleConverterExtensions
    {
        public static T ToTuple<T>(this object[] objects)
        {
            return (T)objects[0];
        }

        public static (T1, T2) ToTuple<T1, T2>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1]);
        }

        public static (T1, T2, T3) ToTuple<T1, T2, T3>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2]);
        }

        public static (T1, T2, T3, T4) ToTuple<T1, T2, T3, T4>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2], (T4)objects[3]);
        }

        public static (T1, T2, T3, T4, T5) ToTuple<T1, T2, T3, T4, T5>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2], (T4)objects[3], (T5)objects[4]);
        }

        public static (T1, T2, T3, T4, T5, T6) ToTuple<T1, T2, T3, T4, T5, T6>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2], (T4)objects[3], (T5)objects[4], (T6)objects[5]);
        }

        public static (T1, T2, T3, T4, T5, T6, T7) ToTuple<T1, T2, T3, T4, T5, T6, T7>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2], (T4)objects[3], (T5)objects[4], (T6)objects[5], (T7)objects[6]);
        }
        
        public static (T1, T2, T3, T4, T5, T6, T7, T8) ToTuple<T1, T2, T3, T4, T5, T6, T7, T8>(this object[] objects)
        {
            return ((T1)objects[0], (T2)objects[1], (T3)objects[2], (T4)objects[3], (T5)objects[4], (T6)objects[5], (T7)objects[6], (T8)objects[7]);
        }
    }
}