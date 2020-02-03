using GraphQL;
using GraphQL.Types;
using GraphiQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Front_End_Assesment.GraphQL.Schemas
{
    public class ProjectShema : Schema
    {
        public ProjectShema(IDependencyResolver resolve) : base((IServiceProvider) resolve)
        {
            Query = (ProjectQuery)resolve.Resolve(typeof(ProjectQuery));
            Mutation = (ProjectMutation)resolve.Resolve(typeof(ProjectMutation));
        }

        public interface IDependencyResolver
        {
            T Resolve<T>();
            object Resolve(Type type);
        }
    }

}