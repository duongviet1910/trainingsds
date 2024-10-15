using BlazorWebAppRGPC.Model.DTO;
using BlazorWebAppRGPC.Service;
using BlazorWebAppRGPC.Service.IService;
using Share;

namespace BlazorWebAppRGPC.Model.Mapper
{
    public class ClasssMapper
    {
        public ClassViewDTO ClassGrpcToClassViewDTO(ClassGrpc classGrpc)
        {
            ClassViewDTO _class = new ClassViewDTO();
            _class.Id = classGrpc.Id;
            _class.Name = classGrpc.Name;
            _class.SubjectName = classGrpc.Subject;
            _class.TeacherName = classGrpc.TeacherName;
            _class.TeacherId = classGrpc.TeacherId;
            return _class;
        }
        public ClassGrpc ClassViewDTOToClassGrpc(ClassViewDTO classViewDTO)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classViewDTO.Id;
            classGrpc.Name = classViewDTO.Name;
            classGrpc.Subject = classViewDTO.SubjectName;
            classGrpc.TeacherName= classViewDTO.TeacherName;    
            classGrpc.TeacherId= classViewDTO.TeacherId;
            return classGrpc;
        }
        public ClassGrpc ClassDTOToClassGrpc(ClassDTO classDTO)
        {
            ClassGrpc classGrpc = new ClassGrpc();
            classGrpc.Id = classDTO.Id; 
            classGrpc.Name = classDTO.Name;
            classGrpc.Subject = classDTO.SubjectName;
            classGrpc.TeacherName = classDTO.TeacherName;
            classGrpc.TeacherId = classDTO.TeacherId;
            return classGrpc;
        }
    }
}
