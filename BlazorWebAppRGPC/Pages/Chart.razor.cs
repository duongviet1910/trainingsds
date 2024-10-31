using System.Threading.Tasks;
using AntDesign.Charts;
using BlazorWebAppRGPC.Service.IService;
using Microsoft.AspNetCore.Components;
using BlazorWebAppRGPC.Model;
using AntDesign;
using Share;
using System.Drawing.Printing;
using BlazorWebAppRGPC.Model.DTO;

namespace BlazorWebAppRGPC.Pages
{
    public partial class Chart  
    {
        [Inject] IStudentService StudentService { get; set; }

        [Inject] IClassService ClassService { get; set; }

        public List<ClassViewDTO> ListClasss = new List<ClassViewDTO>();
        private List<StudentViewDTO> listStudentViewDTO = new List<StudentViewDTO>();
        List<ChartModel> charts = new List<ChartModel>();

        protected override async Task OnInitializedAsync()
        {
            await loadData();
        }

        private async Task loadData()
        {
            var classDatas = ClassService.GetAllClasss();

            var studentDatas = StudentService.GetAllStudent();
            foreach(var classData  in classDatas ) {
                var datastudent = new ChartModel
                {
                    Type = classData.Name,
                    Value = studentDatas
                    .Where(student => student.ClassId == classData.Id).Count(),
                };
                charts.Add(datastudent);
            }
            
        }


        private PieConfig config1 = new PieConfig
        {
            ForceFit = true,
            Radius = 0.8,
            AngleField = "value",
            ColorField = "type",
            Label = new PieLabelConfig
            {
                Visible = true,
                Type = "inner"
            }
        };

    }
}
