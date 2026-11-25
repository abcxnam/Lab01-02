using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student() { }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Student> students = new List<Student>
        {
            new Student(1, "An", 16),
            new Student(2, "Binh", 14),
            new Student(3, "Anh", 18),
            new Student(4, "Cuong", 20),
            new Student(5, "Dung", 15)
        };

        // a. In toàn bộ danh sách học sinh
        Console.WriteLine("a. Danh sách toàn bộ học sinh:");
        PrintStudents(students);

        // b. Tìm và in danh sách học sinh có tuổi từ 15 đến 18
        Console.WriteLine("\nb. Học sinh có tuổi từ 15 đến 18:");
        var age15To18 = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
        PrintStudents(age15To18);

        // c. Tìm và in học sinh có tên bắt đầu bằng chữ "A"
        Console.WriteLine("\nc. Học sinh có tên bắt đầu bằng chữ \"A\":");
        var nameStartsWithA = students
            .Where(s => !string.IsNullOrEmpty(s.Name) &&
                        s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            .ToList();
        PrintStudents(nameStartsWithA);

        // d. Tính tổng tuổi của tất cả học sinh
        Console.WriteLine("\nd. Tổng tuổi của tất cả học sinh:");
        int totalAge = students.Sum(s => s.Age);
        Console.WriteLine($"   Tổng tuổi = {totalAge}");

        // e. Tìm và in học sinh có tuổi lớn nhất
        Console.WriteLine("\ne. Học sinh có tuổi lớn nhất:");
        int maxAge = students.Max(s => s.Age);
        var oldestStudents = students.Where(s => s.Age == maxAge).ToList();
        PrintStudents(oldestStudents);

        // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in kết quả
        Console.WriteLine("\nf. Danh sách học sinh sắp xếp theo tuổi tăng dần:");
        var sortedByAge = students.OrderBy(s => s.Age).ToList();
        PrintStudents(sortedByAge);

        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();
    }

    static void PrintStudents(List<Student> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("   Không có học sinh nào.");
            return;
        }

        foreach (var s in list)
        {
            Console.WriteLine("   " + s);
        }
    }
}