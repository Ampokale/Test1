using aspnetserver.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using aspnetserver.EntityLayer;
using aspnetserver.DataAccessLayer;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPOLICY",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
           
        });
    //"http://localhost:3000"
});
//builder.Services.AddMvc();
/// work for local host
builder.Services.AddDbContext<NetFSDContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptions => 
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP TUTORIAL", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseCors("CORSPOLICY");

//app.MapGet("/get-all-post", async () => await KanbanRepo.GetPostsAsync())
//    .WithTags("Posts Endpoints");
//app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
//{
//    Post postToReturn = await KanbanRepo.GetPostByIdAsync(postId);

//    if (postToReturn != null)
//    {
//        return Results.Ok(postToReturn);
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapPost("/create-post", async (Post postToCreate) =>
//{
//    bool createSuccessful = await KanbanRepo.CreatePostsAsync(postToCreate);

//    if (createSuccessful)
//    {
//        return Results.Ok("Create successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapPut("/update-post", async (Post postToUpdate) =>
//{
//    bool updateSuccessful = await KanbanRepo.UpdatePostAsync(postToUpdate);

//    if (updateSuccessful)
//    {
//        return Results.Ok("Update successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");

//app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
//{
//    bool deleteSuccessful = await KanbanRepo.DeletePostAsync(postId);

//    if (deleteSuccessful)
//    {
//        return Results.Ok("Delete successful.");
//    }
//    else
//    {
//        return Results.BadRequest();
//    }
//}).WithTags("Posts Endpoints");


//amol added code


app.MapGet("/get-all-project", async () => await KanbanRepo.GetProjectAsync())
    .WithTags("Project Endpoints");
app.MapGet("/get-project-by-id/{projectId}", async (int projectId) =>
{
    Project postToReturn = await KanbanRepo.GetProjectByIdAsync(projectId);

    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapPost("/create-project", async (Project projectToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateProjectAsync(projectToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapPut("/update-project", async (Project projectToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateProjectAsync(projectToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");

app.MapDelete("/delete-project-by-id/{projectId}", async (int projectId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteProjectAsync(projectId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Endpoints");


//-------------------------------------User end  endpoints-------------------
app.MapGet("/get-all-users", async () => await KanbanRepo.GetUserAsync())
    .WithTags("User Endpoints");
app.MapGet("/get-user-by-id/{userId}", async (int userId) =>
{
    User userToReturn = await KanbanRepo.GetUserByIdAsync(userId);

    if (userToReturn != null)
    {
        return Results.Ok(userToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapPost("/create-User", async (User userToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateUserAsync(userToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapPut("/update-user", async (User userToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateUserAsync(userToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");

app.MapDelete("/delete-User-by-id/{projectId}", async (int userId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteUserAsync(userId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("User Endpoints");
//------------------------------------Task end Point-----------------------------------------
app.MapGet("/getAll-Task", async () => await KanbanRepo.GetTaskAsync())
    .WithTags("Task Endpoints");
app.MapGet("/get-task-by-id/{taskId}", async (int TaskId) =>
{
    KanbanTask taskToReturn = await KanbanRepo.GettaskByIdAsync(TaskId);

    if (taskToReturn != null)
    {
        return Results.Ok(taskToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/create-Task", async (KanbanTask taskToCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateTaskAsync(taskToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/update-Task", async (KanbanTask taskToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdatetaskAsync(taskToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");

app.MapPost("/delete-TaskById", async (int tskId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteTaskAsync(tskId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Task Endpoints");
//------------------------------------status end Point-----------------------------------------
app.MapGet("/get-all-status", async () => await KanbanRepo.GetStatusAsync())
    .WithTags("status Endpoints");
app.MapGet("/get-status-by-id/{statusId}", async (int statusId) =>
{
    Status statusToReturn = await KanbanRepo.GetStatusByIdAsync(statusId);

    if (statusToReturn != null)
    {
        return Results.Ok(statusToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapPost("/create-status", async (Status statusCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateStatusAsync(statusCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapPut("/update-status", async (Status statusToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateStatusAsync(statusToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");

app.MapDelete("/delete-status-by-id/{statusId}", async (int statusId) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteStatusAsync(statusId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status Endpoints");
//------------------------------------Project Member end Point-----------------------------------------
app.MapGet("/get-all-project member", async () => await KanbanRepo.GetProjectMemberAsync())
    .WithTags("Project Member Data Endpoints");
app.MapGet("/get-project member -by-id/{statusId}", async (int promemberId) =>
{
    ProjectMembers proMemToReturn = await KanbanRepo.GetProjectMemberByIdAsync(promemberId);

    if (proMemToReturn != null)
    {
        return Results.Ok(proMemToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapPost("/create-project Member", async (ProjectMembers PmCreate) =>
{
    bool createSuccessful = await KanbanRepo.CreateProjectMembersAsync(PmCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapPut("/update-project member", async (ProjectMembers pmToUpdate) =>
{
    bool updateSuccessful = await KanbanRepo.UpdateprojectMemberAsync(pmToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");

app.MapDelete("/delete-project member-by-id/{project memberId}", async (int projectMember) =>
{
    bool deleteSuccessful = await KanbanRepo.DeleteProjectMemberAsync(projectMember);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Project Member Data Endpoints");
//------------------------------------status end Point-----------------------------------------
app.MapPost("/loginCheck", async (Login loginobj) =>
{
    User loginSuccessful = await KanbanRepo.LoginValidateAsync(loginobj);

    if (loginSuccessful!=null)
    {
        List<User> luser = new List<User>();
        luser.Add(loginSuccessful);

        return Results.Json(luser);
        //return Results.Ok("login successful.");
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("Login");
//-----------------------------------------------------------------------------for Testing Purpose----------------------------------------------
app.MapGet("/getAllProjects", async () => await UnitOfWork.GetProjectAsync())
    .WithTags("project endpoints");

app.MapGet("getProjectById", async (int projectId) =>
{
    ProjectT postToReturn = await UnitOfWork.GetProjectByIdAsync(projectId);

    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project endpoints");

app.MapPost("/createProject", async (ProjectT projectToCreate) =>
{
    bool createSuccessful = await UnitOfWork.CreateProjectAsync(projectToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project endpoints");

app.MapPost("/updateProject", async (ProjectT projectToUpdate) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateProjectAsync(projectToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project endpoints");

app.MapPost("/deleteprojectById", async (int projectId) =>
{
    bool deleteSuccessful = await UnitOfWork.DeleteProjectAsync(projectId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project endpoints");
//------------------------------------------------------------User endpoinds---------------------------
app.MapGet("/getAllUsers", async () => await UnitOfWork.GetUserAsync())
      .WithTags("user endpoints");
app.MapGet("/getUserById", async (int userId) =>
{
    UserT userToReturn = await UnitOfWork.GetUserByIdAsync(userId);

    if (userToReturn != null)
    {
        return Results.Ok(userToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("user endpoints");

app.MapPost("/createuser", async (UserT userToCreate) =>
{
    bool createSuccessful = await UnitOfWork.CreateUserAsync(userToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("user endpoints");

app.MapPost("/updateUser", async (UserT userToUpdate) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateUserAsync(userToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("user endpoints");

app.MapPost("/deleteUserById", async (int userId) =>
{
    bool deleteSuccessful = await UnitOfWork.DeleteUserAsync(userId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("user endpoints");
//-----------------------------------------------------------Project Member End Point--------------------------
app.MapGet("/getAllProjectMember", async () => await UnitOfWork.GetProjectMemberAsync())
    .WithTags("project member data endpoints");
app.MapGet("/getProjectMemberById", async (int promemberId) =>
{
    ProjectMemberT proMemToReturn = await UnitOfWork.GetProjectMemberByIdAsync(promemberId);

    if (proMemToReturn != null)
    {
        return Results.Ok(proMemToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project member data endpoints");

app.MapPost("/createProjectMember", async (ProjectMemberT PmCreate) =>
{
    bool createSuccessful = await UnitOfWork.CreateProjectMemberAsync(PmCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project member data endpoints");

app.MapPost("/updateProjectMember", async (ProjectMemberT pmToUpdate) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateProjectMemberAsync(pmToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project member data endpoints");

app.MapPost("/deleteProjectMemberById", async (int projectMember) =>
{
    bool deleteSuccessful = await UnitOfWork.DeleteProjectMemberAsync(projectMember);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("project member data endpoints");
//------------------------------------status end Point-----------------------------------------
app.MapGet("/getAllstatus", async () => await UnitOfWork.GetStatusAsync())
    .WithTags("status endpoints");
app.MapGet("/getStatusById", async (int statusId) =>
{
    StatusTableT statusToReturn = await UnitOfWork.GetStatusByIdAsync(statusId);

    if (statusToReturn != null)
    {
        return Results.Ok(statusToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status endpoints");

app.MapPost("/createStatus", async (StatusTableT statusCreate) =>
{
    bool createSuccessful = await UnitOfWork.CreateStatusAsync(statusCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status endpoints");

app.MapPost("/updateStatus", async (StatusTableT statusToUpdate) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateStatusAsync(statusToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status endpoints");

app.MapPost("/deleteStatusById", async (int statusId) =>
{
    bool deleteSuccessful = await UnitOfWork.DeleteStatusAsync(statusId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("status endpoints");
//------------------------------------Login Creditioals-----------------------------------------
app.MapPost("/loginCradiantialcheck", async (LoginClass loginobj) =>
{
    UserT loginSuccessful = await UnitOfWork.LoginValidateAsync(loginobj);

    if (loginSuccessful != null)
    {
        List<UserT> luser = new List<UserT>();
        luser.Add(loginSuccessful);

        return Results.Json(luser);
        //return Results.Ok("login successful.");
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("login endpoint");
//------------------------------------Task end Point-----------------------------------------
app.MapGet("/getAllTask", async () => await UnitOfWork.GetTaskAsync())
    .WithTags("task endpoints");
app.MapGet("/getTaskById", async (int TaskId) =>
{
    TbTaskT taskToReturn = await UnitOfWork.GetTaskByIdAsync(TaskId);

    if (taskToReturn != null)
    {
        return Results.Ok(taskToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("task endpoints");

app.MapPost("/createTask", async (TbTaskT taskToCreate) =>
{
    bool createSuccessful = await UnitOfWork.CreateTaskAsync(taskToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("task endpoints");

app.MapPost("/updateTask", async (TbTaskT taskToUpdate) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateTaskAsync(taskToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("task endpoints");
app.MapPost("/updateTaskWithStatus", async (int taskId ,int statusid) =>
{
    bool updateSuccessful = await UnitOfWork.UpdateTaskWithStatusAsync(taskId, statusid);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("task endpoints");

app.MapPost("/deleteTaskById", async (int tskId) =>
{
    bool deleteSuccessful = await UnitOfWork.DeleteTaskAsync(tskId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("task endpoints");
app.Run();
