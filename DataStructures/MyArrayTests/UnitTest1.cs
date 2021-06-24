using System;
using Xunit;
using FluentAssertions;
using MyArray;

namespace MyArrayTests
{
    public class UnitTest1
    {
        [Fact]
        public void RotateByShift_should_thorw_if_rotaion_index_out_of_array_range()
        {
            var input = new int[0];

            Action act = () => new Functions().RotateByShift(input, 1);

            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains(Functions.RotationOutOfRangeError));
        }

        [Fact]
        public void RotateByShift_should_rotate_array()
        {
            var input = new int[] { 1, 2, 3};
            var expectedOutput = new int[] { 3, 1, 2 };

            var sut = new Functions();
            sut.RotateByShift(input, 2);

            input.Should().BeEquivalentTo(expectedOutput);
        }
    }
}
