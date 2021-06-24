using System;
using System.Linq;

namespace MyArray
{
    public class Functions
    {
        public const string RotationOutOfRangeError = "rotation index must be less than array length";
        public void RotateByShift<T>(T[] array, int rotationIndex)
        {
            if (rotationIndex > array.Length)
                throw new ArgumentOutOfRangeException(RotationOutOfRangeError);

            var shiftingPart = array.Take(rotationIndex);
            array.CopyTo(array.Skip(rotationIndex).Take(rotationIndex - array.Length), 0);
            array.Concat(shiftingPart);
        }
    }
}
