using Front_End_Assesment.GraphQL.GraphQLTypes;
using Front_End_Assesment.Interfaces;
using Front_End_Assesment.Payload;
using Front_End_Assesment.Responses;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.GraphQL.Schemas
{
    public class ProjectMutation : ObjectGraphType<object>
    {
        public ProjectMutation(Iproject project)
        {
            Name = "ProjectMutation";

            #region Login user
            Field<LoginType>(
               "LoginUser",
               Description = "This mutation is for authenticating user Login details email: hello@commsworth.com and password : Hello",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<LoginType>> { Name = "appuser" }
               ),
               resolve: context =>
               {
                   var newuser = context.GetArgument<loginPayload>(Name = "user");
                   return project.UserLogin(newuser);
               });
            #endregion

            #region Create project
            Field<ProjectType>(
                "Create project",
                Description = "create a a new project for the program",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProjectType>> { Name = "project" }
                    ),
                resolve: context =>
               {
                   var projects = context.GetArgument<CreateProjectPayload>(Name = "createproject");
                   return project.CreateProject(projects);
               });
            #endregion
        }
    }
}
