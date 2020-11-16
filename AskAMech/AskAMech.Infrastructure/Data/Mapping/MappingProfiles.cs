using AskAMech.Core.Domain;
using AskAMech.Infrastructure.Data.Entities;
using AutoMapper;

namespace AskAMech.Infrastructure.Data.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserEntity, User>();
            CreateMap<UserProfileEntity, UserProfile>();
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<UserDashboardEntity, UserDashboard>();
            CreateMap<ViewQuestionsEntity, ViewQuestions>();
            CreateMap<CategoryEntity, Category>();
            CreateMap<RolesEntity, Roles>();
            CreateMap<ViewEmployeeEntity, ViewEmployee>();
            CreateMap<ViewQuestionDetailsEntity, ViewQuestionDetails>();
            CreateMap<ViewAnswersEntity, ViewAnswers>();
            CreateMap<QuestionEntity, Question>();
            CreateMap<ViewUserProfileEntity, ViewUserProfile>();
            CreateMap<ViewUserQuestionsEntity, ViewUserQuestions>();
        }
    }
}
