//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace cSharpConcepts
//{
//    /*
//     In this article, we are going to compare two objects of the same class having collection property or multiple collection properties. 
//    We will create a generic compare method that will compare the two objects of the same class. This comparison will be applicable to any type of class.
//    It is quite easy to compare the objects having only primitive properties. The problem arises when we have collection properties (say List) as member property inside the class.
//    This compare method will be used to compare the objects having List properties.
//     */

//    // Step#1 Create a console application (say ObjectComparasionDemo) in C# using Visual Studio and add classes as below. You can create these as a separate file also.
//    public class EmployeeComparingObjects
//    {
//        public int EmpId { get; set; }
//        public string EmpName { get; set; }
//        public int EmpAge { get; set; }
//        public DateTime JoiningDate { get; set; }
//        public List <Department> EmpDepartment { get; set; }
//    }

//    public class Department
//    {
//        public int DeptId { get; set; }
//        public string DeptName { get; set; }
//    }

//    public class Student
//    {
//        public int StudentId { get; set; }
//        public string StudentName { get; set; }
//        public DateTime JoiningDate { get; set; }
//        public List <Course> StudentCourse { get; set; }
//    }

//    public class Course
//    {
//        public int CourseId { get; set; }
//        public string CourseName { get; set; }
//    }

//    // Step 2 - Add the static class CompareObject.cs
//    /*
//     This method is responsible for comparing the given two objects. 
//    This will recursively call the same method when it encounters the List property inside an object. 
//    This will read all the properties of the object and compare it with the second object's property. 
//    When it encounters List property, it will start comparison on each and every object available inside its collection by recursively calling the same method.
//     */
//    public static class CompareBoject
//    {
//        public static bool Compare <T> (T e1, T e2)
//        {
//            bool flag = true;
//            bool match = false;
//            int countFirst, countSecond;
//            foreach(PropertyInfo propObj1 in e1.GetType().GetProperties())
//            {
//                var propObj2 = e2.GetType().GetProperty(propObj1.Name);
//                if (propObj1.PropertyType.Name.Equals("List `1"))
//                {
//                    dynamic objList1 = propObj1.GetValue(e1, null);
//                    dynamic objList2 = propObj2.GetValue(e2, null);
//                    countFirst = objList1.Count;
//                    countSecond = objList2.Count;
//                    if (countFirst == countSecond)
//                    {
//                        countFirst = objList1.Count - 1;
//                        while (countFirst > -1)
//                        {
//                            match = false;
//                            countSecond = objList2.Count - 1;
//                            while (countSecond > -1)
//                            {
//                                match = Compare(objList1[countFirst], objList2[countSecond]);
//                                if (match)
//                                {
//                                    objList2.Remove(objList2[countSecond]);
//                                    countSecond = -1;
//                                    match = true;
//                                }
//                                if (match == false && countSecond == 0)
//                                {
//                                    return false;
//                                }
//                                countSecond--;
//                            }
//                            countFirst--;
//                        }
//                    } else
//                    {
//                        return false;
//                    }
//                } else if (!(propObj1.GetValue(e1, null)).Equals(propObj2.GetValue(e2, null)))
//                {
//                    flag = false;
//                    return flag;
//                }
//            }
//            return flag;
//        }
//    }

//    // Step 3 - Modify the Main method of class/file Program.cs
//    // For our convinience, we have created the objects of both Employee and Student, so as to demonstrate that this compare method will be applicable on both classes and you can create your own class for comparision.
//    static void ObjectCompareMain(string[] args)
//    {
//        bool compare;
//        var datetime = DateTime.Now;
//        Employee e1 = new Employee
//        {
//            EmpId = 1,
//            EmpAge = 25,
//            EmpName = "Subbu",
//            JoiningDate = datetime,
//            EmpDepartment = new List<Department> {
//            new Department() {
//                DeptId = 1, DeptName = "android"
//            },
//            new Department() {
//                DeptId = 2, DeptName = "ios"
//            }
//        }
//        };
//        Employee e2 = new Employee
//        {
//            EmpId = 2,
//            EmpAge = 26,
//            EmpName = "Subbu",
//            JoiningDate = datetime,
//            EmpDepartment = new List<Department> {
//            new Department() {
//                DeptId = 3, DeptName = "mvc"
//            },
//            new Department {
//                DeptId = 4, DeptName = "mvvm"
//            }
//        }
//        };
//        Employee e3 = new Employee
//        {
//            EmpId = 1,
//            EmpAge = 25,
//            EmpName = "Subbu",
//            JoiningDate = datetime,
//            EmpDepartment = new List<Department> {
//            new Department() {
//                DeptId = 1, DeptName = "android"
//            },
//            new Department() {
//                DeptId = 2, DeptName = "ios"
//            }
//        }
//        };
//        compare = CompareObject.Compare<Employee>(e1, e2);
//        if (compare)
//        {
//            Console.WriteLine("e1 and e2 Employee Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("e1 and e2 Employees object are Not equal");
//        }
//        compare = CompareObject.Compare<Employee>(e1, e3);
//        if (compare)
//        {
//            Console.WriteLine("e1 and e3 Employee Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("e1 and e3 Employees object are Not equal");
//        }
//        compare = CompareObject.Compare<Employee>(e2, e3);
//        if (compare)
//        {
//            Console.WriteLine("e2 and e3 Employee Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("e2 and e3 Employees object are Not equal");
//        }
//        Student s1 = new Student
//        {
//            StudentId = 1,
//            StudentName = "Imran",
//            StudentCourse = new List<Course> {
//            new Course() {
//                CourseId = 1, CourseName = "Course_A"
//            },
//            new Course() {
//                CourseId = 2, CourseName = "Course_B"
//            }
//        }
//        };
//        Student s2 = new Student
//        {
//            StudentId = 2,
//            StudentName = "Irfan",
//            StudentCourse = new List<Course> {
//            new Course() {
//                CourseId = 3, CourseName = "Course_C"
//            },
//            new Course() {
//                CourseId = 2, CourseName = "Course_D"
//            }
//        }
//        };
//        Student s3 = new Student
//        {
//            StudentId = 1,
//            StudentName = "Imran",
//            StudentCourse = new List<Course> {
//            new Course() {
//                CourseId = 1, CourseName = "Course_A"
//            },
//            new Course() {
//                CourseId = 2, CourseName = "Course_B"
//            }
//        }
//        };
//        compare = CompareObject.Compare<Student>(s1, s2);
//        if (compare)
//        {
//            Console.WriteLine("s1 and s2 Student Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("s1 and s2 Students object are Not equal");
//        }
//        compare = CompareObject.Compare<Student>(s1, s3);
//        if (compare)
//        {
//            Console.WriteLine("s1 and s3 Student Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("s1 and s3 Students object are Not equal");
//        }
//        compare = CompareObject.Compare<Student>(s2, s3);
//        if (compare)
//        {
//            Console.WriteLine("s2 and s3 Student Objects are Equal");
//        }
//        else
//        {
//            Console.WriteLine("s2 and s3 Students object are Not equal");
//        }
//    }
//}
