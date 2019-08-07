using Autofac;
using Autofac.Integration.Mvc;
using SmallCRM.Data;
using SmallCRM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static SmallCRM.Service.ContactService;


namespace SmallCRM.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ActivityService>().As<IActivityService>();
            builder.RegisterType<CampaignService>().As<ICampaignService>();
            builder.RegisterType<CampaignSourceService>().As<ICampaignSourceService>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<DocumentService>().As<IDocumentService>();
            builder.RegisterType<FeedService>().As<IFeedService>();
            builder.RegisterType<LeadService>().As<ILeadService>();
            builder.RegisterType<LeadSourceService>().As<ILeadSourceService>();
            builder.RegisterType<LeadStatusService>().As<ILeadStatusService>();
            builder.RegisterType<OpportunityService>().As<IOpportunityService>();
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<RegionService>().As<IRegionService>();
            builder.RegisterType<ReportService>().As<IReportService>();
            builder.RegisterType<SectorService>().As<ISectorService>();
            builder.RegisterType<TimeSpendingService>().As<ITimeSpendingService>();
            builder.RegisterType<WorkItemService>().As<IWorkItemService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new AutoMapperConfig().Initialize();
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
