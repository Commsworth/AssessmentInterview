using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.GraphQL.InputTypes
{
    public class ProjectInputType : InputObjectGraphType
    {
        public ProjectInputType()
        {
            Name = "ProjectInputType";
            Description = "Create a new project";
            Field<StringGraphType>("Title");
            Field<StringGraphType>("contractorName");
            Field<StringGraphType>("contractorAddress");
            Field<DecimalGraphType>("Budget");
            Field<DateGraphType>("startDate");
            Field<DateGraphType>("endDate");
        }
    }

    public class LoginInputType : InputObjectGraphType
    {
        public LoginInputType()
        {
            Name = "LoinInputType";
            Description = "Login user";
            Field<StringGraphType>("email");
            Field<StringGraphType>("password");
        }
    }
}