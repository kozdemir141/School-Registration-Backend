using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();
            builder.RegisterType<EfEducatorDal>().As<IEducatorDal>();

            builder.RegisterType<EducatorManager>().As<IEducatorService>();
            builder.RegisterType<StudentManager>().As<IStudentService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EfLessonDal>().As<ILessonDal>();
            builder.RegisterType<LessonManager>().As<ILessonService>();

            builder.RegisterType<EfStudentLessonDal>().As<IStudentLessonDal>();
            builder.RegisterType<StudentLessonManager>().As<IStudentLessonService>();

            builder.RegisterType<EfDepartmentDal>().As<IDeparmentDal>();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
