var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HotelManagement_WebApp>("hotelmanagement-webapp");

builder.Build().Run();
