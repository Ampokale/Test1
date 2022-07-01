using aspnetserver.EntityLayer;
namespace aspnetserver.DataAccessLayer
{
    public class UnitOfWork
    {
        #region User Endpoint
        internal async static Task<bool> DeleteUserAsync(int UserId)
        {
           
            
                try
                {
                    userDAL UserToDelete = new userDAL();

                  return UserToDelete.Delete(UserId);

                   
                }
                catch (Exception e)
                {
                    return false;
                }
            
        }

        internal async static Task<IEnumerable<UserT> >GetUserAsync()
        {


            userDAL UserGetAll = new userDAL();

                return UserGetAll.GetAll();
            
        }

        internal async static Task<bool> CreateUserAsync(UserT UserToCreate)
        {
            userDAL UserCreate = new userDAL();
            try
                {
                //UserToCreate.Password="adm@1234";
                    return UserCreate.Add(UserToCreate);

                }
                catch (Exception e)
                {
                    return false;
                }
            

        }

        internal async static Task<bool> UpdateUserAsync(UserT UserToUpdate)
        {

            userDAL UserCreate = new userDAL();
            try
                {
                      UserCreate.Update(UserToUpdate);

                    return  UserCreate.Update(UserToUpdate);

            }
                catch (Exception e)
                {
                    return false;
                }
            

        }
        internal async static Task<UserT> GetUserByIdAsync(int UserId)
        {

            userDAL userToGet = new userDAL();

            return userToGet.GetByID(UserId);

        }

        #endregion
        #region project Endpoint
        internal async static Task<bool> DeleteProjectAsync(int ProjectId)
        {


            try
            {
                ProjectsDAL projectToDelete = new ProjectsDAL();

                return projectToDelete.Delete(ProjectId);


            }
            catch (Exception e)
            {
                return false;
            }

        }
        internal async static Task<ProjectT> GetProjectByIdAsync(int ProjectId)
        {

                ProjectsDAL projectToGet = new ProjectsDAL();

                return projectToGet.GetByID(ProjectId);

        }

        internal async static Task<IEnumerable<ProjectT>> GetProjectAsync()
        {


            ProjectsDAL ProjectGetAll = new ProjectsDAL();

            return ProjectGetAll.GetAll();

        }

        internal async static Task<bool> CreateProjectAsync(ProjectT ProjectToCreate)
        {
            ProjectsDAL ProjectCreate = new ProjectsDAL();
            try
            {
                return ProjectCreate.Add(ProjectToCreate);

            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal async static Task<bool> UpdateProjectAsync(ProjectT ProjectToUpdate)
        {

            ProjectsDAL ProjectCreate = new ProjectsDAL();
            try
            {
              return  ProjectCreate.Update(ProjectToUpdate);

            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
        #region project Member Endpoint
        internal async static Task<bool> DeleteProjectMemberAsync(int ProjectMemberId)
        {


            try
            {
                projectMemberDAL projectToDelete = new projectMemberDAL();

                return projectToDelete.Delete(ProjectMemberId);

            }
            catch (Exception e)
            {
                return false;
            }

        }
        internal async static Task<ProjectMemberT> GetProjectMemberByIdAsync(int ProjectMemberId)
        {

            projectMemberDAL ProjectMemberToGet = new projectMemberDAL();

            return ProjectMemberToGet.GetByID(ProjectMemberId);

        }
        internal async static Task<IEnumerable<ProjectMemberT>> GetProjectMemberAsync()
        {


            projectMemberDAL ProjectMemberGetAll = new projectMemberDAL();

            return ProjectMemberGetAll.GetAll();

        }

        internal async static Task<bool> CreateProjectMemberAsync(ProjectMemberT ProjectMemberToCreate)
        {
            projectMemberDAL ProjectMemberCreate = new projectMemberDAL();
            try
            {
                return ProjectMemberCreate.Add(ProjectMemberToCreate);

            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal async static Task<bool> UpdateProjectMemberAsync(ProjectMemberT ProjectMemberToUpdate)
        {

            projectMemberDAL ProjectMemberUpdate = new projectMemberDAL();
            try
            {
                return ProjectMemberUpdate.Update(ProjectMemberToUpdate);

            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
        #region Status Endpoint
        internal async static Task<bool> DeleteStatusAsync(int StausId)
        {


            try
            {
                StatusDAL UserToDelete = new StatusDAL();

                return UserToDelete.Delete(StausId);


            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal async static Task<IEnumerable<StatusTableT>> GetStatusAsync()
        {


            StatusDAL UserGetAll = new StatusDAL();

            return UserGetAll.GetAll();

        }

        internal async static Task<bool> CreateStatusAsync(StatusTableT StatusToCreate)
        {
            StatusDAL StatusCreate = new StatusDAL();
            try
            {

                return StatusCreate.Add(StatusToCreate);

            }
            catch (Exception e)
            {
                return false;
            }


        }

        internal async static Task<bool> UpdateStatusAsync(StatusTableT StatusToUpdate)
        {

            StatusDAL StatusCreate = new StatusDAL();
            try
            {

                return StatusCreate.Update(StatusToUpdate);

            }
            catch (Exception e)
            {
                return false;
            }


        }
        internal async static Task<StatusTableT> GetStatusByIdAsync(int StatusId)
        {

            StatusDAL userToGet = new StatusDAL();

            return userToGet.GetByID(StatusId);

        }

        #endregion
        #region End point for Registration and login
        internal async static Task<UserT> LoginValidateAsync(LoginClass loginObj)
        {
            loginDAL obj=new loginDAL();
            return obj.loginUser(loginObj);
        }
        #endregion
        #region Task Endpoint
        internal async static Task<bool> DeleteTaskAsync(int TaskId)
        {


            try
            {
                taskDAL taskToDelete = new taskDAL();

                return taskToDelete.Delete(TaskId);


            }
            catch (Exception e)
            {
                return false;
            }

        }
        internal async static Task<TbTaskT> GetTaskByIdAsync(int TaskId)
        {

            taskDAL taskToGet = new taskDAL();

            return taskToGet.GetByID(TaskId);

        }

        internal async static Task<IEnumerable<TbTaskT>> GetTaskAsync()
        {


            taskDAL TaskGetAll = new taskDAL();

            return TaskGetAll.GetAll();

        }

        internal async static Task<bool> CreateTaskAsync(TbTaskT TaskToCreate)
        {
            taskDAL TaskCreate = new taskDAL();
            try
            {
                return TaskCreate.Add(TaskToCreate);

            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal async static Task<bool> UpdateTaskAsync(TbTaskT TaskToUpdate)
        {

            taskDAL TaskCreate = new taskDAL();
            try
            {
                return TaskCreate.Update(TaskToUpdate);

            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateTaskWithStatusAsync(int TaskToUpdateId ,int statusid)
        {

            taskDAL TaskCreate = new taskDAL();
            TbTaskT tbObj= TaskCreate.GetByID(TaskToUpdateId);
            tbObj.TaskStatus = statusid;
            try
            {
                return TaskCreate.Update(tbObj);

            }
            catch (Exception e)
            {
                return false;
            }
        }


        #endregion
    }
}
