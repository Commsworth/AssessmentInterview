using Front_End_Assesment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using GraphQL.Types;
using Front_End_Assesment.GraphQL.GraphQLTypes;
using Front_End_Assesment.Models;

namespace Front_End_Assesment.GraphQL.Schemas
{
    public class ProjectQuery : ObjectGraphType<object>
    {
        public ProjectQuery(Iproject project)
        {
            Name = "ProjectQuery";

            #region Project
            Field<ListGraphType<LoadProjectType>>(
                "LoadProject",
                Description = "Load all Project",

                resolve: context => project.LoadProject()
            );
            #endregion

            #region Location
            Field<ListGraphType<LocationType>>(
                "LoadLocations",
                Description = "Load all location to maps",

                resolve: context => project.LoadLocation()
            );
            #endregion
        }
    }
}