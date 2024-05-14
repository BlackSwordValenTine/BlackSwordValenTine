using System;
using System.Text;

class Program
{
    // Main entry point of the program
    static unsafe void Main()
    {
        // Example byte array initialization
        byte[] byteArray = { 0x12, 0x34, 0x56, 0x78 };
        int number = 0;

        // Fixing the pointer to the byte array
        fixed (byte* p = byteArray)
        {
            // Example string converted to byte array
            byte[] ariaBytes = Encoding.UTF8.GetBytes("โดย: Aria จัดทำ ตามคำขอจาก BackSWV:");
            Console.WriteLine($"ขนาดของ Aria คือ {ariaBytes.Length} ไบต์");

            // Extend the byte array with additional bytes
            byte[] extendedAria = new byte[ariaBytes.Length + 4];
            Array.Copy(ariaBytes, 0, extendedAria, 4, ariaBytes.Length);
            Console.WriteLine($"ข้อมูลทั้งหมดของ Aria คือ: {BitConverter.ToString(extendedAria)}");
            Console.WriteLine($"ความยาวของ Aria หลังจากเพิ่มไบต์เป็น {extendedAria.Length} ไบต์");

            // Using pointer to read int value from byte array
            byte* p2 = p;
            number = *(int*)p2; // Read 4 bytes as an int
            Console.WriteLine("Number before shifting: " + number);

            // Left bitwise shift
            number = number << 2;
            Console.WriteLine("Number after left shift: " + number);

            // Right bitwise shift
            number = number >> 1;
            Console.WriteLine("Number after right shift: " + number);

            // Copy byte array
            byte[] copyArray = new byte[4];
            Buffer.BlockCopy(byteArray, 0, copyArray, 0, 4);
            Console.WriteLine("Copy of byteArray: " + BitConverter.ToString(copyArray));

            // XOR operation
            number = number ^ 0x0F;
            Console.WriteLine("Number after XOR with 0x0F: " + number);

            // Convert int to short
            short shortNumber = (short)number;
            Console.WriteLine("Number as Int16: " + shortNumber);
        }

        // Wait for user input before closing
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
