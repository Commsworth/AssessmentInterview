using Front_End_Assesment.Payload;
using Front_End_Assesment.Repositories;
using Front_End_Assesment.Responses;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front_End_Assesment.GraphQL.GraphQLTypes
{
    public class ProjectType : InputObjectGraphType<CreateProjectPayload>
    {
        public ProjectType()
        {
            Name = "CreateProjectType";
            Description = "Create project";
            //Field<NonNullGraphType<StringGraphType>>("title").Description=("Title of Project");
            //Field<NonNullGraphType<DecimalGraphType>>("budget").Description=("Project Budget");
            //Field<NonNullGraphType<StringGraphType>>("contractorName").Description=("Contractor name for the project");
            //Field<NonNullGraphType<StringGraphType>>("contractorAddress").Description=("Contractor address for the project");
            //Field<NonNullGraphType<StringGraphType>>("startDate").Description = ("Startdate for the project");
            //Field<NonNullGraphType<StringGraphType>>("endDate").Description = ("endate for the project");
            Field(x => x.title, type: typeof(StringGraphType)).Description("Title of Project");
            Field(x => x.budget, type: typeof(DecimalGraphType)).Description("Project Budget");
            Field(x => x.startDate, type: typeof(StringGraphType)).Description("Startdate for the project");
            Field(x => x.endDate, type: typeof(StringGraphType)).Description("endate for the project");
            Field(x => x.contractorName, type: typeof(StringGraphType)).Description("Contractor name for the project");
            Field(x => x.contractorAddress, type: typeof(StringGraphType)).Description("Contractor address for the project");
        }
    }
    public class LoadProjectType : ObjectGraphType//<CreateProjectPayload>
    {
        public LoadProjectType()
        {
            Name = "LoadProjectType";
            Description = ":pad project";
            Field<NonNullGraphType<IntGraphType>>("id").Description = ("Project Id");
            Field<NonNullGraphType<StringGraphType>>("title").Description = ("Title of Project");
            Field<NonNullGraphType<DecimalGraphType>>("budget").Description = ("Project Budget");
            Field<NonNullGraphType<StringGraphType>>("contractorName").Description = ("Contractor name for the project");
            Field<NonNullGraphType<StringGraphType>>("contractorAddress").Description = ("Contractor address for the project");
            Field<NonNullGraphType<StringGraphType>>("startDate").Description = ("Startdate for the project");
            Field<NonNullGraphType<StringGraphType>>("endDate").Description = ("endate for the project");
            //Field(x => x.Title, type: typeof(StringGraphType)).Description("Title of Project");
            //Field(x => x.Budget, type:typeof(DecimalGraphType)).Description("Project Budget");
            //Field(x => x.startDate ,type:typeof(StringGraphType)).Description("Startdate for the project");
            //Field(x => x.endDate, type: typeof(StringGraphType)).Description("endate for the project");
            //Field(x => x.contractorName, type: typeof(StringGraphType)).Description("Contractor name for the project");
            //Field(x => x.contractorAddress, type: typeof(StringGraphType)).Description("Contractor address for the project");
        }
    }
    public class LoginType : InputObjectGraphType//<loginPayload>
    {
        public LoginType()
        {
            Name = "LoginType";
            Description = "Login into the application";
            Field<NonNullGraphType<StringGraphType>>("email").Description = ("Use hello@commsworth.com as username");
            Field<NonNullGraphType<StringGraphType>>("password").Description = ("use Hello as Password for authentication");
            //Field(x => x.email, type: typeof(StringGraphType)).Description("Email to log into the app hello@commsworth.com");
            //Field(x => x.password, type: typeof(StringGraphType)).Description("Password to log into the app Hello");
        }
    }

    public class LocationType : ObjectGraphType<Location>
    {
        public LocationType()
        {
            Name = "LocationType";
            Description = "Location to be shown on the map";
            Field(x => x.location, type: typeof(StringGraphType)).Description("Name of the location");
            Field(x => x.longitude, type: typeof(StringGraphType)).Description("Longitude of the project");
            Field(x => x.latitude, type: typeof(StringGraphType)).Description("Latitude of the location");
        }
    }
    public class GenericResponseType : ObjectGraphType<genericResp>
    {
        public GenericResponseType()
        {
            Name = "genericResp";
            Description = "genericResp";

            Field(x => x.status,type: typeof(StringGraphType)).Description("response status");
            Field(x => x.message, type: typeof(StringGraphType)).Description("response message");

        }

    }

    public class LoginResponseType : ObjectGraphType<loginResp>
    {
        public LoginResponseType()
        {
            Name = "loginResp";
            Description = "loginResp";

            Field(x => x.status).Description("response status");
            Field(x => x.message).Description("response message");
            Field(x => x.accessToken).Description("JWT token fro accessing other graphql methods");

        }

    }
}
