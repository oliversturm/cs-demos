using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReturnsAndLocals {
  class Program {
    static void Main(string[] args) {
      // Sample taken from MS blog post, because it's a good one

      ref int Find(int number, int[] numbers) {
        for (int i = 0; i < numbers.Length; i++) {
          if (numbers[i] == number) {
            return ref numbers[i]; // return the storage location, not the value
          }
        }
        throw new IndexOutOfRangeException($"{nameof(number)} not found");
      }

      int[] array = { 1, 15, -39, 0, 7, 14, -12 };
      ref int place = ref Find(7, array); // aliases 7's place in the array
      place = 9; // replaces 7 with 9 in the array
      Console.WriteLine(array[4]); // prints 9
    }
  }
}
