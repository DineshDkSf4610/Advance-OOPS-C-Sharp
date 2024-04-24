using System;
namespace MultilevelInheritanceTwo;


class Program
{
    public static void Main(string[] args)
    {
        DepartmentDetails department = new DepartmentDetails("Computer Application", "BCA");
        DepartmentDetails department1 = new DepartmentDetails("Computer Application", "MCA");
        DepartmentDetails department2 = new DepartmentDetails("Computer Science", "B.SC");

        RackInfo rackInfo = new RackInfo(department.DepartmentID, department.DepartmentName, department.Degree, 1, 3);
        RackInfo rackInfo1 = new RackInfo(department1.DepartmentID, department1.DepartmentName, department1.Degree, 2, 5);
        RackInfo rackInfo2 = new RackInfo(department2.DepartmentID, department2.DepartmentName, department2.Degree, 3, 7);

        BookInfo book1 = new BookInfo(rackInfo.RackNumberID, rackInfo.DepartmentID, rackInfo.DepartmentName, rackInfo.Degree, rackInfo.RackNumber, rackInfo.ColumnNumber, "c++", "danish", 130);
        BookInfo book2 = new BookInfo(rackInfo1.RackNumberID, rackInfo1.DepartmentID, rackInfo1.DepartmentName, rackInfo1.Degree, rackInfo1.RackNumber, rackInfo1.ColumnNumber, "React Native", "FaceBook", 130);
        BookInfo book3 = new BookInfo(rackInfo2.RackNumberID, rackInfo2.DepartmentID, rackInfo2.DepartmentName, rackInfo2.Degree, rackInfo2.RackNumber, rackInfo2.ColumnNumber, "Flutter", "Google", 130);

        book1.DisplayInfo();
        book2.DisplayInfo();
        book3.DisplayInfo();
    }
}