using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.UseCases;
using AskAMech.Core.Categories.Interfaces;
using AskAMech.Core.Categories.UseCases;
using AskAMech.Core.Dashboard.Interfaces;
using AskAMech.Core.Dashboard.UseCases;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.UseCases;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Login.Interfaces;
using AskAMech.Core.Login.UseCases;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.UseCases;
using AskAMech.Core.Register.Interfaces;
using AskAMech.Core.Register.UseCases;
using AskAMech.Core.Security;
using AskAMech.Core.UserRoles.Interfaces;
using AskAMech.Core.UserRoles.UseCases;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.UseCases;
using AskAMech.Infrastructure.Data.Helpers;
using AskAMech.Infrastructure.Data.Mapping;
using AskAMech.Infrastructure.Data.Repositories;
using AskAMech.Web.Presenters;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AskAMech.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MappingProfiles>(), typeof(Startup));

            var connectionString = new SqlHelper(Configuration.GetConnectionString("AskAMechDbConnectionString"));
            services.AddSingleton(connectionString);


            services.AddTransient<IModelPresenter, ModelPresenter>();
            services.AddTransient<ISecurityManagerUseCase, SecurityManagerUseCase>();
            services.AddTransient<ILoginUseCase, LoginUseCase>();
            services.AddTransient<IRegisterUseCase, RegisterUseCase>();
            services.AddTransient<IUserDashboardUseCase, UserDashboardUseCase>();
            services.AddTransient<ICreateEmployeeUseCase, CreateEmployeeUseCase>();
            services.AddTransient<IGetQuestionsUseCase, GetQuestionsUseCase>();
            services.AddTransient<ICreateUserRoleUseCase, CreateRoleUseCase>();
            services.AddTransient<IGetEmployeesUseCase, GetEmployeesUseCase>();
            services.AddTransient<IGetRoleUseCase, GetRolesUseCase>();
            services.AddTransient<IGetEmployeesAutocompleteUseCase, GetEmployeesAutocompleteUseCase>();
            services.AddTransient<ICreateCategoryUseCase, CreateCategoryUseCase>();
            services.AddTransient<IGetCategoryUseCase, GetCategoryUseCase>();
            services.AddTransient<IEditEmployeeUseCase, EditEmployeeUseCase>();
            services.AddTransient<ICreateUserUseCase, CreateUserUseCase>();
            services.AddTransient<IGetEmployeeForUserUseCase, GetEmployeeForUserUseCase>();
            services.AddTransient<IGetEmployeeForEditUseCase, GetEmployeeForEditUseCase>();
            services.AddTransient<IEditUserProfileUseCase, EditUserProfileUseCase>();
            services.AddTransient<ICreateQuestionUseCase, CreateQuestionUseCase>();
            services.AddTransient<IUpdateEmployeeActiveStatusUseCase, UpdateEmployeeActiveStatusUseCase>();
            services.AddTransient<IGetCreateQuestionUseCase, GetCreateQuestionUseCase>();
            services.AddTransient<IGetUserProfileUseCase, GetUserProfileUseCase>();
            services.AddTransient<IEditEmployeeUserPassword, EditEmployeeUserPasswordUseCase>();
            services.AddTransient<IGetQuestionViewUseCase, GetViewQuestionUseCase>();
            services.AddTransient<IUpdateUserPasswordUseCase, UpdateUserPasswordUseCase>();
            services.AddTransient<IEditQuestionUseCase, EditQuestionUseCase>();
            services.AddTransient<IGetEditQuestionUseCase, GetEditQuestionUseCase>();
            services.AddTransient<IGetEmployeeUseCase, GetEmployeeUseCase>();
            services.AddTransient<IGetViewUserProfile, GetViewUserProfileUseCase>();
            services.AddTransient<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
            services.AddTransient<IGetUserQuestions, GetUserQuestionsUseCase>();
            services.AddTransient<IGetUserQuestionAnswersUseCase, GetUserQuestionAnswersUseCase>();
            services.AddTransient<IGetConfirmAcceptedAnswerUseCase, GetConfirmAcceptedAnswerUseCase>();
            services.AddTransient<IUpdateIsAcceptedAnswerUseCase, UpdateIsAcceptedAnswerUseCase>();
            services.AddTransient<ICreateAnswerUseCase, CreateAnswerUseCase>();
            services.AddTransient<IGetUserAnswerUseCase, GetUserAnswerUseCase>();
            services.AddTransient<IEditAnswerUseCase, EditAnswerUseCase>();
            services.AddTransient<IDeleteAnswerUseCase, DeleteAnswerUseCase>();
            services.AddTransient<IDeleteQuestionUseCase, DeleteQuestionUseCase>();


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserDashboardRepository, UserDashboardRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IAnswersRepository, AnswerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
