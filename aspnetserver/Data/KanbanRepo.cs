using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public class KanbanRepo
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }
        internal async static Task<Post> GetPostByIdAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts
                    .FirstOrDefaultAsync(post => post.PostId == postId);
            }
        }

        internal async static Task<bool> CreatePostsAsync(Post postToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Posts.AddAsync(postToCreate);

                    return await db.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(postToUpdate);

                    return await db.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> DeletePostAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Post postToDelete = await GetPostByIdAsync(postId);

                    db.Remove(postToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        #region Amol Added code
        #region Status Endpoint
        internal async static Task<bool> DeleteStatusAsync(int StustsId)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    Post postToDelete = await GetPostByIdAsync(StustsId);

                    db1.Remove(postToDelete);

                    return await db1.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        
        internal async static Task<List<Status>> GetStatusAsync()
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.status.ToListAsync();
            }
        }
        internal async static Task<Status> GetStatusByIdAsync(int StatusId)
        {
            using (var  db1 = new KanbanContext())
            {
                return await db1.status
                    .FirstOrDefaultAsync(status => status.StatusId == StatusId);
            }
        }

        internal async static Task<bool> CreateStatusAsync(Status StatusToCreate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    await db1.status.AddAsync(StatusToCreate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdateStatusAsync(Status statusToUpdate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    db1.status.Update(statusToUpdate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        #endregion

        #region Project EndPoinds

        internal async static Task<Project> GetProjectByIdAsync(int ProjectId)
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.project
                    .FirstOrDefaultAsync(Projec=> Projec.PojectId == ProjectId);
            }
        }
        internal async static Task<bool> DeleteProjectAsync(int ProjectId)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    Project postToDelete = await GetProjectByIdAsync(ProjectId);

                    db1.Remove(postToDelete);

                    return await db1.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<List<Project>> GetProjectAsync()
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.project.ToListAsync();
            }
        }
       

        internal async static Task<bool> CreateProjectAsync(Project projectToCreate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    await db1.project.AddAsync(projectToCreate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdateProjectAsync(Project projectToUpdate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    db1.project.Update(projectToUpdate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        #endregion
        #region task EndPoint
        internal async static Task<KanbanTask> GettaskByIdAsync(int taskId)
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.task
                    .FirstOrDefaultAsync(t => t.TId == taskId);
            }
        }
        internal async static Task<bool> DeleteTaskAsync(int taskId)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    KanbanTask postToDelete = await GettaskByIdAsync(taskId);

                    db1.Remove(postToDelete);

                    return await db1.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<List<KanbanTask>> GetTaskAsync()
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.task.ToListAsync();
            }
        }


        internal async static Task<bool> CreateTaskAsync(KanbanTask projectToCreate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    await db1.task.AddAsync(projectToCreate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdatetaskAsync(KanbanTask projectToUpdate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    db1.task.Update(projectToUpdate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        #endregion
        #region User EndPoint
        internal async static Task<User> GetUserByIdAsync(int UserId)
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.user
                    .FirstOrDefaultAsync(U => U.UserId == UserId);
            }
        }
        internal async static Task<bool> DeleteUserAsync(int usertId)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    User userToDelete = await GetUserByIdAsync(usertId);

                    db1.Remove(userToDelete);

                    return await db1.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<List<User>> GetUserAsync()
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.user.ToListAsync();
            }
        }


        internal async static Task<bool> CreateUserAsync(User UserToCreate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    await db1.user.AddAsync(UserToCreate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdateUserAsync(User UserToUpdate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    db1.user.Update(UserToUpdate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        #endregion
        #region Project Members EndPoint
        internal async static Task<ProjectMembers> GetProjectMemberByIdAsync(int projectMemberId)
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.projectMember.FirstOrDefaultAsync(pm => pm.project_MId == projectMemberId);
            }
        }
        internal async static Task<bool> DeleteProjectMemberAsync(int projecMembertMId)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    KanbanTask postToDelete = await GettaskByIdAsync(projecMembertMId);

                    db1.Remove(postToDelete);

                    return await db1.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<List<ProjectMembers>> GetProjectMemberAsync()
        {
            using (var db1 = new KanbanContext())
            {
                return await db1.projectMember.ToListAsync();
            }
        }


        internal async static Task<bool> CreateProjectMembersAsync(ProjectMembers ProjectMemberToCreate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    await db1.projectMember.AddAsync(ProjectMemberToCreate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> UpdateprojectMemberAsync(ProjectMembers projectMemberToUpdate)
        {
            using (var db1 = new KanbanContext())
            {
                try
                {
                    db1.projectMember.Update(projectMemberToUpdate);

                    return await db1.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
        #endregion
        #region End point for Registration and login
        internal async static Task<User> LoginValidateAsync(Login loginObj)
        {
            
            using (var db1 = new KanbanContext())
            {
                return await  db1.user.FirstOrDefaultAsync(pm => pm.Email == loginObj.UserName && pm.password == loginObj.Password);
            
                
                    
                
                
            }
        }
        #endregion
        #endregion

    }
}
