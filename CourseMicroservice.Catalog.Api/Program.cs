using CourseMicroservice.Catalog.Api;
using CourseMicroservice.Catalog.Api.Features.Categories;
using CourseMicroservice.Catalog.Api.Features.Courses;
using CourseMicroservice.Catalog.Api.Options;
using CourseMicroservice.Catalog.Api.Repositories;
using CourseMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();
builder.Services.AddDbContextExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

var app = builder.Build();

app.AddCategoryEnpointExt();
app.AddCourseEndpointsExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();