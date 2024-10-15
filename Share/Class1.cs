using ProtoBuf.Grpc;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Share;

[DataContract]
public class Empty
{

}
[DataContract]
public class BooleanGrpc
{
    [DataMember(Order = 1)]
    public Boolean result { get; set; }
    [DataMember(Order = 2)]
    public String mess { get; set; }
}

[DataContract]
public class StudentGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }
    [DataMember(Order = 2)]
    public virtual string Name { get; set; }
    [DataMember(Order = 3)]
    public virtual DateTime Dob {  get; set; }
    [DataMember(Order = 4)]
    public virtual String Address { get; set; }
    [DataMember(Order = 5)]
    public virtual ClassGrpc ClassStudent { get; set; }
    [DataMember(Order = 6)]
    public virtual int ClassId { get; set; }
    [DataMember(Order = 7)]
    public virtual string ClassName { get; set; }
}

[DataContract]
public class ListStudents
{
    [DataMember(Order = 1)]
    public List<StudentGrpc> List = new List<StudentGrpc>();
}
[ServiceContract]
public interface StudentProto
{
    [OperationContract]
    ListStudents GetListStudent(Empty request,
        CallContext context = default);
    [OperationContract]
    StudentGrpc GetStudentById(IntGrpc id,
        CallContext context = default);
    [OperationContract]
    BooleanGrpc AddStudent(StudentGrpc request, CallContext context = default);
    [OperationContract]
    BooleanGrpc UpdateStudent(StudentGrpc request, CallContext context = default);
    [OperationContract]
    BooleanGrpc DeleteStudent(StudentGrpc request, CallContext context = default);
    [OperationContract]
    DataPageStudent GetDataPage(PageStudent pageStudent, CallContext context = default);


}

[DataContract]
public class DataPageStudent
{
    [DataMember(Order = 1)]
    public List<StudentGrpc> List = new List<StudentGrpc>();
    [DataMember(Order = 2)]
    public int Total { get; set; }
}
[DataContract]
public class PageStudent
{
    [DataMember(Order = 1)]
    public int PageNumber { get; set; }
    [DataMember(Order = 2)]
    public int PageSize { get; set; }
    [DataMember(Order = 3)]
    public StudentGrpc StudentGrpc { get; set; }
}




[DataContract]
public class ClassGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }
    [DataMember(Order = 2)]
    public virtual string Name { get; set; }

    [DataMember(Order = 3)]
    public virtual string Subject { get; set; }

    [DataMember(Order = 4)]
    public virtual int TeacherId { get; set; }
    [DataMember(Order = 5)]
    public virtual string TeacherName { get; set; }
}
[DataContract]
public class ListClasses
{
    [DataMember(Order = 1)]
    public List<ClassGrpc> List = new List<ClassGrpc>();
}
[DataContract]
public class DataPage
{
    [DataMember(Order = 1)]
    public List<ClassGrpc> List = new List<ClassGrpc>();
    [DataMember(Order = 2)]
    public int Total { get; set; }
}
[DataContract]
public class Page
{
    [DataMember(Order = 1)]
    public int PageNumber { get; set; }
    [DataMember(Order = 2)]
    public int PageSize { get; set; }
    [DataMember(Order =3)] 
    public ClassGrpc ClassGrpc { get; set; }
}

[ServiceContract]
public interface ClassProto
{
    [OperationContract]
    ListClasses GetListClass(Empty request,
        CallContext context = default);
    [OperationContract]
    ClassGrpc GetClassById(IntGrpc id,
        CallContext context = default);
    [OperationContract]
    BooleanGrpc AddClass(ClassGrpc request, CallContext context = default);
    [OperationContract]
    BooleanGrpc UpdateClass(ClassGrpc request, CallContext context = default);
    [OperationContract]
    BooleanGrpc DeleteClass(ClassGrpc request, CallContext context = default);
    [OperationContract]
    DataPage GetDataPage(Page page, CallContext context = default);
}

[DataContract]
public class TeacherGrpc
{
    [DataMember(Order = 1)]
    public virtual int Id { get; set; }
    [DataMember(Order = 2)]
    public virtual string Name { get; set; }

    [DataMember(Order = 3)]
    public virtual DateTime Dob { get; set; }
}
[DataContract]
public class ListTeachers
{
    [DataMember(Order = 1)]
    public List<TeacherGrpc> List = new List<TeacherGrpc>();
}
[DataContract]
public class IntGrpc
{
    [DataMember(Order = 1)]
    public int Id { get; set; }
}
[ServiceContract]
public interface TeacherProto
{
    [OperationContract]
    ListTeachers GetListTeacher(Empty request,
        CallContext context = default);
    [OperationContract]
    TeacherGrpc GetTeacherById(IntGrpc id,
        CallContext context = default);
}